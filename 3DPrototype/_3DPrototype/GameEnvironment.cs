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
        List<Collectable> Collectables = new List<Collectable>();

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
            foreach (Collectable collectable in Collectables)
            {
                collectable.Draw(world, view, projection);
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
            foreach (Collectable collectable in Collectables)
            {
                collectable.LoadContent();
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

         public void addCollectable(Collectable _collectable)
         {
             this.Collectables.Add(_collectable);
         }

         public bool updateCollisionCollectables(Player _player)
         {
             bool tempBool=false;
             foreach (Collectable collectable in Collectables)
             {
                 float distance = Vector3.Distance(collectable.getPosition(), _player.getPosition());
                 if(distance < 1.1)
                 {
                     collectable.setCatched(true);
                 }
                 else collectable.setCatched(false);
             }
             for(int i = 0; i < Collectables.Count; i++)
             {
                 if(Collectables.ElementAt(i).getIsCatched() == true)
                 {
                     Collectables.RemoveAt(i);
                     tempBool = true;
                     Console.WriteLine("Collectable Removed");
                 }
             }
             return tempBool;
         }
    }
}
