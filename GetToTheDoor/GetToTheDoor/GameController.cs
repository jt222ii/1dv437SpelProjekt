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
    public class GameController : Game
    {
        static float scale = 0.5f; // if this is changed the levels need to be changed to fit the new size
        TileSystem mapSystem;

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D mainCharacter;
        MainCharacterModel charModel;
        MainCharacterView charView;
        Camera camera;
        public GameController()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 720;
            //graphics.PreferredBackBufferWidth = 1920;
            //graphics.PreferredBackBufferHeight = 1080;
            graphics.IsFullScreen = false;
            graphics.ApplyChanges();
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
            camera = new Camera(graphics.GraphicsDevice.Viewport);
            mapSystem = new TileSystem(Content, camera, scale);
            mainCharacter = Content.Load<Texture2D>("ethan");
            charModel = new MainCharacterModel(mapSystem, scale);
            charView = new MainCharacterView(mainCharacter, charModel, camera);
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
        int test = 0;
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            if (Keyboard.GetState().IsKeyUp(Keys.Right) && Keyboard.GetState().IsKeyUp(Keys.Left))
            {
                charModel.stopMoving();
            }
            else
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Right))
                {
                    charModel.moveRight();
                }
                if (Keyboard.GetState().IsKeyDown(Keys.Left))
                {
                    charModel.moveLeft();
                }
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                charModel.jump();
            }
            charModel.Update((float)gameTime.ElapsedGameTime.TotalSeconds);

            Tile landedOnTile = mapSystem.landsOnTile(charModel);
            if (landedOnTile != null)
            {
                charModel.landOnTile(landedOnTile);
                test++;
            }
            else
            {
                charModel.fall();
            }
            if (mapSystem.lookForCollisionHead(charModel))
            {
                charModel.hitHeadOnTile();
            }

            Tile collidedTile = mapSystem.lookForCollisionX(charModel);
            if (collidedTile != null)
            {
                charModel.collideX(collidedTile);
            }

            if(mapSystem.playerGetsTheKey(charModel))
            {
                charModel.HasKey = true;
            }
            mapSystem.playerWantsToGoThroughDoor(charModel);
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            mapSystem.drawTiles(spriteBatch);
            charView.Draw(spriteBatch);
            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
