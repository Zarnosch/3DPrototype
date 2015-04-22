using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;


namespace _3DPrototype
{
     class GameEnvironment
    {
        String name;
        Vector3 position;
        Vector3 orientation;
        ContentManager content;
        List<Wall> Walls = new List<Wall>();

       public GameEnvironment(ContentManager _content, String _name, Vector3 _position, Vector3 _orientation)
        {
            name = _name;
            position = _position;
            orientation = _orientation;
            content = _content;
        }

        public void Draw(Matrix world, Matrix view, Matrix projection)
        {
            foreach (Wall wall in Walls)
            {
                wall.Draw(world, view, projection);
            }

        }
            
        public void LoadContent()
        {
            foreach (Wall wall in Walls)
            {
                wall.LoadContent();
            }
        }

        public void addWall(Wall _wall)
        {
            this.Walls.Add(_wall);
        }
    }
}
