﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GetToTheDoor.View
{
    class MidMenuView
    {
        Camera camera;
        ContentManager Content;

        Vector2 restartButtonPos = new Vector2(8f, 2f);
        Vector2 prevButtonPos = new Vector2(8f, 4.5f);
        Vector2 nextButtonPos = new Vector2(8f, 7f);
        Vector2 victoryTextPos = new Vector2(8f, 0.5f);
        Vector2 size = new Vector2(4f, 2f);
        Texture2D nextLevelButton, previousLevelButton, restartButton, victoryText, mainMenu;
        Vector2 textureCenter, textCenter;
        Vector2 scale;
        public MidMenuView(ContentManager content, Camera _camera, Texture2D NextLevel, Texture2D PrevLevel, Texture2D RestartLevel)
        {
            camera = _camera;
            Content = content;
            nextLevelButton = NextLevel;
            previousLevelButton = PrevLevel;
            restartButton = RestartLevel;
            victoryText = Content.Load<Texture2D>("Menu/winText-01");
            mainMenu = Content.Load<Texture2D>("Menu/MainMenuButton");
            textureCenter = new Vector2(NextLevel.Width / 2, NextLevel.Height / 2);
            textCenter = new Vector2(victoryText.Width / 2, victoryText.Height / 2);
            scale = camera.Scale(size, NextLevel.Width, NextLevel.Height);
        }

        public Vector2 getNextButtonPos()
        {
            return nextButtonPos;
        }
        public Vector2 getPrevButtonPos()
        {
            return prevButtonPos;
        }
        public Vector2 getRestartButtonPos()
        {
            return restartButtonPos;
        }
        public Vector2 getSize()
        {
            return size;
        }

        public void Draw(SpriteBatch spriteBatch, bool isPlayerDead, bool nextLevelExists)
        {
            var nextVisualLoc = camera.convertToVisualCoords(nextButtonPos);
            var prevVisualLoc = camera.convertToVisualCoords(prevButtonPos);
            var restartVisualLoc = camera.convertToVisualCoords(restartButtonPos);
            spriteBatch.Draw(restartButton, restartVisualLoc, null, Color.White, 0, textureCenter, scale, SpriteEffects.None, 1f);
            spriteBatch.Draw(previousLevelButton, prevVisualLoc, null, Color.White, 0, textureCenter, scale, SpriteEffects.None, 1f);
            if (!isPlayerDead && nextLevelExists)
            {
                spriteBatch.Draw(nextLevelButton, nextVisualLoc, null, Color.White, 0, textureCenter, scale, SpriteEffects.None, 1f);
            }
            else if(!isPlayerDead && !nextLevelExists)
            {
                spriteBatch.Draw(victoryText, camera.convertToVisualCoords(victoryTextPos), null, Color.White, 0, textureCenter, scale*2, SpriteEffects.None, 1f);
                spriteBatch.Draw(mainMenu, nextVisualLoc, null, Color.White, 0, textureCenter, scale, SpriteEffects.None, 1f);
            }
        }

    }
}
