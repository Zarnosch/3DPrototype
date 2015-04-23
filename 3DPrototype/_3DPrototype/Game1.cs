using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using _3DPrototype;

namespace Prototype3dXNA
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        GameEnvironment upperWorld;

       

        /// <summary>
        /// Stores the model that we are going to draw.
        /// </summary>
        //private Model model;

        /// <summary>
        /// Stores the world matrix for the model, which transforms the 
        /// model to be in the correct position, scale, and rotation
        /// in the game world.
        /// </summary>
        private Matrix world = Matrix.CreateTranslation(new Vector3(0, 0, 0));

        /// <summary>
        /// Stores the view matrix for the model, which gets the model
        /// in the right place, relative to the camera.
        /// </summary>
        private Matrix view = Matrix.CreateLookAt(new Vector3(0, 0, 10), new Vector3(0, 0, 0), Vector3.UnitY);

        /// <summary>
        /// Stores the projection matrix, which gets the model projected
        /// onto the screen in the correct way.  Essentially, this defines the
        /// properties of the camera you are using.
        /// </summary>
        private Matrix projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45), 800f / 480f, 0.1f, 100f);

        //private Vector3 position;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            upperWorld = new GameEnvironment (Content, "upperWorld", new Vector3(0, 0, 0), new Vector3(0, 0, 0));
            //Wall testWall = new Wall(new Vector3(0, 0, 0), new Vector3(0, 0, 0), "cube", Content);
            //Wall testWall2 = new Wall(new Vector3(2, 0, 0), new Vector3(0, 0, 0), "Wuerfel1Yellow", Content);

            Wall testWall = new Wall(new Vector3(0, 0, 0), new Vector3(0, 0, 0), "FloorPlate", Content);
            Wall testWall2 = new Wall(new Vector3(0, 0, 0), new Vector3(0, 0, 0), "WallLeft", Content);
            Wall testWall3 = new Wall(new Vector3(2, 0, 0), new Vector3(0, 0, 0), "FloorPlate", Content);
            Wall testWall4 = new Wall(new Vector3(0, 0, 0), new Vector3(0, 0, 0), "WallBack", Content);
            //Wall testWall5 = new Wall(new Vector3(0, 0, 0), new Vector3(0, 0, 0), "WandRechts1", Content);
            Wall testWall5 = new Wall(new Vector3(0, 0, 0), new Vector3(0, 0, 0), "WallRight", Content);
            Wall testWall6 = new Wall(new Vector3(0, 0, 0), new Vector3(0, 0, 0), "ApeMonster", Content);
            Wall testWall7 = new Wall(new Vector3(0, 0, 2), new Vector3(0, 0, 0), "FloorPlate", Content);
            Wall testWall8 = new Wall(new Vector3(0, 0, 4), new Vector3(0, 0, 0), "FloorPlate", Content);

            upperWorld.addWall(testWall);
            upperWorld.addWall(testWall2);
            upperWorld.addWall(testWall3);
            upperWorld.addWall(testWall4);
            upperWorld.addWall(testWall5);
            upperWorld.addWall(testWall6);
            upperWorld.addWall(testWall7);
            upperWorld.addWall(testWall8);

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //model = Content.Load<Model>("cube");
            //model = Content.Load<Model>("Pfeil1");


            //view = Matrix.CreateLookAt(new Vector3(10, 10, 10), Vector3.Zero, Vector3.Up);
            view = Matrix.CreateLookAt(new Vector3(8, 25, 4), new Vector3(0, 0, 0), new Vector3(0, 1, 0));

            projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45f), graphics.GraphicsDevice.Viewport.AspectRatio, .1f, 1000f);
            //position = new Vector3(0, 0, 0);
            

            // TODO: use this.Content to load your game content here
            upperWorld.LoadContent();
            
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
            Content.Unload();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here
            /*
            position += new Vector3(0, 0.01f, 0);
            
            */
            //world = Matrix.CreateTranslation(position);
            // KEYBOARD INPUTS ********************************
            

            //END KEYBOARD INPUTS ****************************

            //position += new Vector3(0, 0.01f, 0);
           // world = Matrix.CreateTranslation(position);
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            
            upperWorld.Draw(world, view, projection);
            base.Draw(gameTime);
        }

        /// <summary>
        /// Does the work of drawing a model, given specific world, view, and projection
        /// matrices.
        /// </summary>
        /// <param name="model">The model to draw</param>
        /// <param name="world">The transformation matrix to get the model in the right place in the world.</param>
        /// <param name="view">The transformation matrix to get the model in the right place, relative to the camera.</param>
        /// <param name="projection">The transformation matrix to project the model's points onto the screen correctly.</param>
        
            
    }
}
