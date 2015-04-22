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
    class Wall 
    {
        Vector3 position;
        Vector3 orientation;
        Model model;
        String modelName;
        ContentManager content;

        public Wall(Vector3 _position, Vector3 _orientation, String _modelName, ContentManager _content)
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
                    effect.World = Matrix.CreateTranslation(position);
                    effect.View = view;
                    effect.Projection = projection;
                    Console.Out.WriteLine("Loaded Wall" + position);
                }
                mesh.Draw();
            }
        }

        public void LoadContent()
        {
            Console.Out.WriteLine("Loaded Wall");
            model = content.Load<Model>(modelName);
        }
    }
}
