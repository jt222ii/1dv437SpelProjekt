using GetToTheDoor.Model;
using GetToTheDoor.View;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
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
        Texture2D idleCharacter, walkingLeftCharacter, walkingRightCharacter, deadChar, turretLeft, bloodDrop;
        SpriteBatch spriteBatch;
        AudioPlayer audioPlayer;
        int selectedLevel = 0;
        bool justFinishedLevel = false;
        bool justDied = false;

        public GameController(ContentManager content, GraphicsDeviceManager graphics, SpriteBatch _spriteBatch, Camera _camera, AudioPlayer audioP)
        {
            Content = content;
            spriteBatch = _spriteBatch;

            audioPlayer = audioP;
            walkingLeftCharacter = Content.Load<Texture2D>("Character/BoxLeft");
            walkingRightCharacter = Content.Load<Texture2D>("Character/BoxRight");
            idleCharacter = Content.Load<Texture2D>("Character/BoxIdle");
            deadChar = Content.Load<Texture2D>("Character/BoxDed");
            bloodDrop = Content.Load<Texture2D>("Character/BloodParticle");
            turretLeft = Content.Load<Texture2D>("Hazards/TurretLeft");
            camera = _camera;
            mapSystem = new MapSystem(Content, camera, selectedLevel, audioPlayer, spriteBatch);
            charModel = new MainCharacterModel(mapSystem);
            charView = new MainCharacterView(idleCharacter, walkingLeftCharacter, walkingRightCharacter, deadChar, bloodDrop, charModel, camera);
        }
        public void Update(GameTime gameTime)
        {
            
            mapSystem.UpdateHazards((float)gameTime.ElapsedGameTime.TotalSeconds, charModel);  
            
            if(charModel.isDead && justDied == false)
            {
                justDied = true;
                audioPlayer.Death();
            }

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
                if(!charModel.IsJumping && !charModel.isDead)
                {
                    charModel.jump();
                    audioPlayer.jump();
                }
            }
            charModel.Update((float)gameTime.ElapsedGameTime.TotalSeconds);

            Tile tileCollidedWith = mapSystem.landsOnTile(charModel);
            if (tileCollidedWith != null)
            {
                charModel.landOnTile(tileCollidedWith);
            }
            else
            {
                charModel.fall();
            }
            tileCollidedWith = mapSystem.hitsHeadOnTile(charModel);
            if (tileCollidedWith != null)
            {
                charModel.hitHeadOnTile(tileCollidedWith);
            }

            tileCollidedWith = mapSystem.hitsTileOnX(charModel);
            if (tileCollidedWith != null)
            {
                charModel.collideX(tileCollidedWith);
            }

            if(mapSystem.playerGetsTheKey(charModel))
            {
                audioPlayer.keyPickup();
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
            loadLevel();
        }
        public void loadLevel()
        {
            justDied = false;
            mapSystem = new MapSystem(Content, camera, selectedLevel, audioPlayer, spriteBatch);
            charModel = new MainCharacterModel(mapSystem);
            charView = new MainCharacterView(idleCharacter, walkingLeftCharacter, walkingRightCharacter, deadChar, bloodDrop, charModel, camera);
        }
        public void nextLevel()
        {
            if(nextLevelExists())
            {
                selectedLevel++;
                loadLevel();
            }
        }
        public void prevLevel()
        {
            if (mapSystem.levelExists(selectedLevel - 1))
            {
                selectedLevel--;
            }
            loadLevel();        
        }
        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public void Draw(GameTime gameTime)
        {
            mapSystem.drawTiles(spriteBatch, (float)gameTime.ElapsedGameTime.TotalSeconds);
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

        public bool nextLevelExists()
        {
            return mapSystem.levelExists(selectedLevel + 1);
        }
    }
}
