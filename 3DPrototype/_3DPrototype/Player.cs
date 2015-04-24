using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace _3DPrototype
{
    class Player
    {
        Vector3 position;
        Vector3 orientation;
        Model model;
        String modelName;
        ContentManager content;

        public Player(Vector3 _position, Vector3 _orientation, String _modelName, ContentManager _content)
        {
            position = _position;
            orientation = _orientation;
            modelName = _modelName;
            content = _content;
        }

        public void Draw(Matrix world, Matrix view, Matrix projection)
        {
            foreach (ModelMesh mesh in model.Meshes)
            {
                foreach (BasicEffect effect in mesh.Effects)
                {
                    effect.EnableDefaultLighting();
                    effect.World = Matrix.CreateTranslation(position);
                    effect.View = view;
                    effect.Projection = projection;
                }
                mesh.Draw();
            }
        }

        public void LoadContent()
        {
            model = content.Load<Model>(modelName);
        }
        //getter
        public Vector3 getPosition()
        {
            return this.position;
        }
        public Vector3 getOrientation()
        {
            return this.orientation; ;
        }
        //setter
        public void setPosition(Vector3 _position)
        {
            this.position = _position;
        }
        public void setOrientation(Vector3 _orientation)
        {
            this.orientation = _orientation;
        }

        //easier methos to move the player with the keys
        public void moveLeft(int steps)
        {
            this.setPosition(Vector3.Add(position, new Vector3(0, 0, steps)));
        }
        public void moveRight(int steps)
        {
            this.setPosition(Vector3.Add(position, new Vector3(0, 0, -steps)));
        }
        public void moveBack(int steps)
        {
            this.setPosition(Vector3.Add(position, new Vector3(steps, 0, 0)));
        }
        public void moveForward(int steps)
        {
            this.setPosition(Vector3.Add(position, new Vector3(-steps,0,0)));
        }
    }
}
