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
        List<Ground> Grounds = new List<Ground>();

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
            foreach (Ground ground in Grounds)
            {
                ground.Draw(world, view, projection);
            }

        }
            
        public void LoadContent()
        {
            foreach (Wall wall in Walls)
            {
                wall.LoadContent();
            }
            foreach (Ground ground in Grounds)
            {
                ground.LoadContent();
            }
        }

        public void addWall(Wall _wall)
        {
            this.Walls.Add(_wall);
        }
        
         public void addGround(int x, int y, String _modelName)
        {
             for(int i = 0; i < x; i++)
             {
                for(int j = 0; j < y; j++)
                {
                    Ground tempGround = new Ground(new Vector3(x, y, 0), new Vector3(0, 0, 0), _modelName, content);
                    addGround(tempGround);
                    
                }
             }
        }

         public void addGround(Ground _ground)
         {
             this.Grounds.Add(_ground);
         }
    }
}
