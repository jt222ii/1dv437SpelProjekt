using GetToTheDoor.Model;
using GetToTheDoor.View;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GetToTheDoor.Controller
{
    class GameController
    {
        MainCharacterModel charModel;
        MainCharacterView charView;
        Camera camera;
        ContentManager Content;
        MapSystem mapSystem;
        Texture2D mainCharacter, deadChar, turretLeft;
        SpriteBatch spriteBatch;
        int selectedLevel = 0;
        bool justFinishedLevel = false;
        public GameController(ContentManager content, GraphicsDeviceManager graphics, SpriteBatch _spriteBatch, Camera _camera)
        {
            Content = content;
            spriteBatch = _spriteBatch;
            mainCharacter = Content.Load<Texture2D>("Ethan");
            deadChar = Content.Load<Texture2D>("Ded");
            turretLeft = Content.Load<Texture2D>("TurretLeft");
            camera = _camera;
            mapSystem = new MapSystem(Content, camera, selectedLevel);
            charModel = new MainCharacterModel(mapSystem);
            charView = new MainCharacterView(mainCharacter, deadChar, charModel, camera);
        }
        public void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.R))
            {
                reloadLevel();
            }
            mapSystem.UpdateHazards((float)gameTime.ElapsedGameTime.TotalSeconds, charModel);
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
            }
            else
            {
                charModel.fall();
            }
            if (mapSystem.hitsHeadOnTile(charModel))
            {
                charModel.hitHeadOnTile();
            }

            Tile collidedTile = mapSystem.hitsTileOnX(charModel);
            if (collidedTile != null)
            {
                charModel.collideX(collidedTile);
            }

            if(mapSystem.playerGetsTheKey(charModel))
            {
                charModel.HasKey = true;
            }
            if (mapSystem.playerUnlocksDoor(charModel))
            {
                justFinishedLevel = true;
            }
        }

        public void reloadLevel()
        {
            mapSystem = new MapSystem(Content, camera, selectedLevel);
            charModel = new MainCharacterModel(mapSystem);
            charView = new MainCharacterView(mainCharacter, deadChar, charModel, camera);
        }
        public void nextLevel()
        {
            if(mapSystem.levelExists(selectedLevel+1))
            {
                selectedLevel++;
                mapSystem = new MapSystem(Content, camera, selectedLevel);
                charModel = new MainCharacterModel(mapSystem);
                charView = new MainCharacterView(mainCharacter, deadChar, charModel, camera);
            }
        }
        public void prevLevel()
        {
            if (mapSystem.levelExists(selectedLevel - 1))
            {
                selectedLevel--;
            }
            mapSystem = new MapSystem(Content, camera, selectedLevel);
            charModel = new MainCharacterModel(mapSystem);
            charView = new MainCharacterView(mainCharacter, deadChar, charModel, camera);          
        }
        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public void Draw(GameTime gameTime)
        {
            mapSystem.drawTiles(spriteBatch);
            charView.Draw(spriteBatch);        
        }

        public bool isPlayerDead()
        {
            return charModel.isDead;
        }

        public bool JustFinishedLevel
        {
            get
            {
                return justFinishedLevel;
            }
            set
            {
                justFinishedLevel = value;
            }
        }
    }
}
