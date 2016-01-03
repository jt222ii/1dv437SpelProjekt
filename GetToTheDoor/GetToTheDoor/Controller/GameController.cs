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
        Texture2D idleCharacter, walkingLeftCharacter, walkingRightCharacter, deadChar, turretLeft;
        SpriteBatch spriteBatch;
        int selectedLevel = 0;
        bool justFinishedLevel = false;
        public GameController(ContentManager content, GraphicsDeviceManager graphics, SpriteBatch _spriteBatch, Camera _camera)
        {
            Content = content;
            spriteBatch = _spriteBatch;

            //walkingLeftCharacter = Content.Load<Texture2D>("WalkLeft2");
            //walkingRightCharacter = Content.Load<Texture2D>("WalkRight2");
            //idleCharacter = Content.Load<Texture2D>("Idle2");
            //deadChar = Content.Load<Texture2D>("DeathSheet");

            walkingLeftCharacter = Content.Load<Texture2D>("BoxLeft");
            walkingRightCharacter = Content.Load<Texture2D>("BoxRight");
            idleCharacter = Content.Load<Texture2D>("BoxIdle");
            deadChar = Content.Load<Texture2D>("BoxDed");

            turretLeft = Content.Load<Texture2D>("TurretLeft");
            camera = _camera;
            mapSystem = new MapSystem(Content, camera, selectedLevel);
            charModel = new MainCharacterModel(mapSystem);
            charView = new MainCharacterView(idleCharacter, walkingLeftCharacter, walkingRightCharacter, deadChar, charModel, camera);
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
                charView.setIdle();
            }
            else
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Right))
                {
                    charModel.moveRight();
                    charView.setWalkingRight();
                }
                if (Keyboard.GetState().IsKeyDown(Keys.Left))
                {
                    charModel.moveLeft();
                    charView.setWalkingLeft();
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
            Tile tileHitFromBelow = mapSystem.hitsHeadOnTile(charModel);
            if (tileHitFromBelow != null)
            {
                charModel.hitHeadOnTile(tileHitFromBelow);
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
        public void restart()
        {
            selectedLevel = 0;
            reloadLevel();
        }
        public void reloadLevel()
        {
            mapSystem = new MapSystem(Content, camera, selectedLevel);
            charModel = new MainCharacterModel(mapSystem);
            charView = new MainCharacterView(idleCharacter, walkingLeftCharacter, walkingRightCharacter, deadChar, charModel, camera);
        }
        public void nextLevel()
        {
            if(mapSystem.levelExists(selectedLevel+1))
            {
                selectedLevel++;
                mapSystem = new MapSystem(Content, camera, selectedLevel);
                charModel = new MainCharacterModel(mapSystem);
                charView = new MainCharacterView(idleCharacter, walkingLeftCharacter, walkingRightCharacter, deadChar, charModel, camera);
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
            charView = new MainCharacterView(idleCharacter, walkingLeftCharacter, walkingRightCharacter, deadChar, charModel, camera);          
        }
        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public void Draw(GameTime gameTime)
        {
            mapSystem.drawTiles(spriteBatch);
            charView.Draw(spriteBatch, (float)gameTime.ElapsedGameTime.TotalSeconds);        
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
