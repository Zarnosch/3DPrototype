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

        private int gamestate = 1;
        private KeyboardState oldState1;
        private MouseState oldState2;
        private int xPos;
        private int yPos;
        private SpriteFont font1;

        private Texture2D background;
        private Texture2D white;
        private int whiteDepth = 1;
        private Texture2D endScreen;

        GameEnvironment upperWorld;
        Player player;
        KeyboardState oldState;
        int points;


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
            //Points
            points = 0;
            //Keyboard
            oldState = Keyboard.GetState();
            //Environment
            upperWorld = new GameEnvironment(Content, "upperWorld", new Vector3(0, 0, 0), new Vector3(0, 0, 0));
            //Grounds
            Ground testGround01 = new Ground(new Vector3(0, 0, 0), new Vector3(0, 0, 0), "FloorPlate", Content);
            Ground testGround02 = new Ground(new Vector3(2, 0, 0), new Vector3(0, 0, 0), "FloorPlate", Content);
            Ground testGround03 = new Ground(new Vector3(0, 0, 2), new Vector3(0, 0, 0), "FloorPlate", Content);
            Ground testGround04 = new Ground(new Vector3(-2, 0, 0), new Vector3(0, 0, 0), "FloorPlate", Content);
            Ground testGround05 = new Ground(new Vector3(0, 0, -2), new Vector3(0, 0, 0), "FloorPlate", Content);
            Ground testGround06 = new Ground(new Vector3(-4, 0, 0), new Vector3(0, 0, 0), "FloorPlate", Content);
            Ground testGround07 = new Ground(new Vector3(0, 0, 4), new Vector3(0, 0, 0), "FloorPlate", Content);
            Ground testGround08 = new Ground(new Vector3(0, 0, -4), new Vector3(0, 0, 0), "FloorPlate", Content);
            Ground testGround09 = new Ground(new Vector3(4, 0, 0), new Vector3(0, 0, 0), "FloorPlate", Content);
            Ground testGround10 = new Ground(new Vector3(-2, 0, 2), new Vector3(0, 0, 0), "FloorPlate", Content);
            Ground testGround11 = new Ground(new Vector3(2, 0, 2), new Vector3(0, 0, 0), "FloorPlate", Content);
            Ground testGround12 = new Ground(new Vector3(2, 0, -2), new Vector3(0, 0, 0), "FloorPlate", Content);
            Ground testGround13 = new Ground(new Vector3(-2, 0, -2), new Vector3(0, 0, 0), "FloorPlate", Content);
            //Walls           
            Wall testWall01 = new Wall(new Vector3(0, 0, 0), new Vector3(0, 0, 0), "WallLeft", Content);
            Wall testWall02 = new Wall(new Vector3(0, 0, 0), new Vector3(0, 0, 0), "WallBack", Content);
            Wall testWall03 = new Wall(new Vector3(0, 0, 0), new Vector3(0, 0, 0), "WallRight", Content);
            //Wall testWall04 = new Wall(new Vector3(0, 0, 0), new Vector3(0, 0, 0), "WallFront", Content);      



            //Player
            player = new Player(new Vector3(0, 0, 0), new Vector3(0, 0, 0), "ApeMonster", Content);

            //Creatures

            //Collectables
            Collectable Vase01 = new Collectable(new Vector3(2, 1, 0), new Vector3(0, 0, 0), "Vase", Content);

            upperWorld.addWall(testWall01);
            upperWorld.addWall(testWall02);
            upperWorld.addWall(testWall03);
            //upperWorld.addWall(testWall04);
            upperWorld.addGround(testGround01);
            upperWorld.addGround(testGround02);
            upperWorld.addGround(testGround03);
            upperWorld.addGround(testGround04);
            upperWorld.addGround(testGround05);
            upperWorld.addGround(testGround06);
            upperWorld.addGround(testGround07);
            upperWorld.addGround(testGround08);
            upperWorld.addGround(testGround09);
            upperWorld.addGround(testGround10);
            upperWorld.addGround(testGround11);
            upperWorld.addGround(testGround12);
            upperWorld.addGround(testGround13);
            upperWorld.addCollectable(Vase01);



            Ground testGround = new Ground(new Vector3(0, 0, 4), new Vector3(0, 0, 0), "FloorPlate", Content);
            //upperWorld.addGround(3, 4, "FloorPlate");
            //upperWorld.addGround(testGround);
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



            // TODO: use this.Content to load your game content here

            background = Content.Load<Texture2D>("Monitor");
            white = Content.Load<Texture2D>("WhitePoint");
            endScreen = Content.Load<Texture2D>("EndScreen");
            font1 = Content.Load<SpriteFont>("Score");

            upperWorld.LoadContent();
            player.LoadContent();


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

            //world = Matrix.CreateTranslation(position);


            if (gamestate == 1)
            {
                this.IsMouseVisible = true;
                MouseState newState2 = Mouse.GetState();
                xPos = newState2.X;
                yPos = newState2.Y;

                if (newState2.LeftButton == ButtonState.Pressed && oldState2.LeftButton == ButtonState.Released)
                {
                    if (xPos >= 226 && yPos >= 232 && xPos <= 532 && yPos <= 305)
                        gamestate++;

                    if (xPos >= 226 && yPos >= 348 && xPos <= 532 && yPos <= 421)
                    {
                        this.Exit();
                    }

                }

                oldState2 = newState2; // this reassigns the old state so that it is ready for next time

                /*
                KeyboardState newState1 = Keyboard.GetState();  // get the newest state

                // handle the input
                if (oldState1.IsKeyUp(Keys.Left) && newState1.IsKeyDown(Keys.Left))
                {
                    gamestate++;
                }

                oldState1 = newState1;  // set the new state as the old state for next time
                 */
            }

            if (gamestate == 2)
            {
                this.IsMouseVisible = false;
                // KEYBOARD INPUTS ********************************
                UpdateInput(1);
                //END KEYBOARD INPUTS ****************************

                //Collision
                if (upperWorld.updateCollisionCollectables(player) == true)
                {
                    points += 1;
                    Console.WriteLine("Points: " + points);
                }

                view = Matrix.CreateLookAt(Vector3.Add(player.getPosition(), new Vector3(5, 5, 0)), player.getPosition(), new Vector3(0, 1, 0));

                if (points == 1)
                {
                    gamestate++;
                }
            }

            if (gamestate == 3)
            {
                whiteDepth++;
            }
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            if (gamestate == 1)
            {
                spriteBatch.Begin();

                spriteBatch.Draw(background, new Rectangle(0, 0, 800, 480), Color.White);

                spriteBatch.End();
            }


            if (gamestate == 2)
            {
                spriteBatch.Begin();
                spriteBatch.DrawString(font1, "Score: 0", new Vector2(20, 10), Color.Black);
                spriteBatch.End();

                GraphicsDevice.DepthStencilState = new DepthStencilState() { DepthBufferEnable = true };
                upperWorld.Draw(world, view, projection);
                player.Draw(world, view, projection);
            }

            if (gamestate == 3)
            {
                GraphicsDevice.DepthStencilState = new DepthStencilState() { DepthBufferEnable = true };
                upperWorld.Draw(world, view, projection);
                player.Draw(world, view, projection);

                spriteBatch.Begin();
                spriteBatch.Draw(white, new Rectangle(0, 0, 800, whiteDepth), Color.White);
                spriteBatch.DrawString(font1, "Score: 1", new Vector2(20, 10), Color.Black);
                if (whiteDepth > 480)
                    //endScreen
                    spriteBatch.Draw(endScreen, new Rectangle(130, 100, 550, 300), Color.White);
                spriteBatch.End();


            }

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


        // helper functions
        // keyboardHandling Steps describes how fast the player will move with one Keyhit (2 for a gridspace of 1)
        private void UpdateInput(int steps)
        {
            KeyboardState newState = Keyboard.GetState();
            if (newState.IsKeyDown(Keys.W))
            {
                // If not down last update, key has just been pressed.
                if (!oldState.IsKeyDown(Keys.W))
                {
                    player.moveForward(steps);
                }
            }
            else if (oldState.IsKeyDown(Keys.W))
            {
                // Key was down last update, but not down now, so
                // it has just been released.
            }
            else if (newState.IsKeyDown(Keys.A))
            {
                // If not down last update, key has just been pressed.
                if (!oldState.IsKeyDown(Keys.A))
                {
                    player.moveLeft(steps);
                }
            }
            else if (oldState.IsKeyDown(Keys.A))
            {
                // Key was down last update, but not down now, so
                // it has just been released.
            }
            if (newState.IsKeyDown(Keys.S))
            {
                // If not down last update, key has just been pressed.
                if (!oldState.IsKeyDown(Keys.S))
                {
                    player.moveBack(steps);
                }
            }
            else if (oldState.IsKeyDown(Keys.S))
            {
                // Key was down last update, but not down now, so
                // it has just been released.
            }
            if (newState.IsKeyDown(Keys.D))
            {
                // If not down last update, key has just been pressed.
                if (!oldState.IsKeyDown(Keys.D))
                {
                    player.moveRight(steps);
                }
            }
            else if (oldState.IsKeyDown(Keys.D))
            {
                // Key was down last update, but not down now, so
                // it has just been released.
            }

            // Update saved state.
            oldState = newState;
        }
    }
}
