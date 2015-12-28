﻿using GetToTheDoor.Controller;
using GetToTheDoor.Model;
using GetToTheDoor.View;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GetToTheDoor
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class MasterController : Game
    {
        GameController gameController;
        MenuController menuController;
        MidMenuController midController;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Camera camera;
        MouseState lastMouseState;
        float timer = 0;
        float timeUntilMenuToShow = 2;

        //ska tas bort
        Texture2D sawBlade;
        float rotation = 0;
        //
        GameState currentState;
        enum GameState
        {
            mainMenu,
            playing,
            midMenu,
        }
        public MasterController()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 720;
            //graphics.PreferredBackBufferWidth = 1920;
            //graphics.PreferredBackBufferHeight = 1080;
            graphics.IsFullScreen = false;
            graphics.ApplyChanges();
            this.IsMouseVisible = true;
            Content.RootDirectory = "Content";
            currentState = GameState.mainMenu;
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

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {

            // Create a new SpriteBatch, which can be used to draw textures.
            sawBlade = Content.Load<Texture2D>("SawBlade");
            spriteBatch = new SpriteBatch(GraphicsDevice);
            camera = new Camera(graphics.GraphicsDevice.Viewport);
            gameController = new GameController(Content, graphics, spriteBatch, camera);
            menuController = new MenuController(Content, graphics, spriteBatch, camera);
            midController = new MidMenuController(Content, graphics, spriteBatch, camera);
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                currentState = GameState.mainMenu;
            if (currentState == GameState.mainMenu)
            {
                var mouseState = Mouse.GetState();
                if (lastMouseState.LeftButton == ButtonState.Released && mouseState.LeftButton == ButtonState.Pressed)
                {
                    menuController.Update(new Vector2(mouseState.Position.X, mouseState.Position.Y));
                    if(menuController.pressedPlay)
                    {
                        currentState = GameState.playing;
                        menuController.pressedPlay = false;
                    }
                }
                lastMouseState = mouseState;
            }
            else if(currentState == GameState.playing)
            {
                gameController.Update(gameTime);
            }
            else if (currentState == GameState.midMenu)
            {
                var mouseState = Mouse.GetState();
                if (lastMouseState.LeftButton == ButtonState.Released && mouseState.LeftButton == ButtonState.Pressed)
                {
                    midController.Update(new Vector2(mouseState.Position.X, mouseState.Position.Y), gameController.isPlayerDead());
                    if(midController.pressedRestart)
                    {            
                        currentState = GameState.playing;
                        gameController.reloadLevel();
                        midController.pressedRestart = false;
                    }
                    else if (midController.pressedNext && !gameController.isPlayerDead())
                    {
                        System.Console.WriteLine(gameController.isPlayerDead());
                        currentState = GameState.playing;
                        gameController.nextLevel();
                        midController.pressedNext = false;
                    }
                    else if (midController.pressedPrev)
                    {
                        currentState = GameState.playing;
                        gameController.prevLevel();
                        midController.pressedPrev = false;
                    }
                }
                lastMouseState = mouseState;

            }
            if(gameController.isPlayerDead() && currentState != GameState.midMenu)
            {
                timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (timer >= timeUntilMenuToShow)
                {
                    currentState = GameState.midMenu;
                    timer = 0;
                }
            }
            else if (gameController.JustFinishedLevel && currentState != GameState.midMenu)
            {
                currentState = GameState.midMenu;
                gameController.JustFinishedLevel = false;
            }
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.SlateGray);
            spriteBatch.Begin();
            // ska tas bort
            rotation += (float)gameTime.ElapsedGameTime.TotalSeconds*2;
            spriteBatch.Draw(sawBlade, camera.convertToVisualCoords(new Vector2(6f, 5f)), null, Color.White, rotation, new Vector2(sawBlade.Width/2, sawBlade.Height/2), 1f, SpriteEffects.None, 1f);
            // 
            if (currentState == GameState.mainMenu)
            {
                menuController.Draw();
            }
            else if (currentState == GameState.playing)
            {
                gameController.Draw(gameTime);
            }
            else if (currentState == GameState.midMenu)
            {
                midController.Draw(gameController.isPlayerDead());
            }
            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}