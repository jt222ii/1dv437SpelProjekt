﻿using GetToTheDoor.View;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GetToTheDoor.Controller
{
    class MidMenuController
    {
        MidMenuView midMenuView;
        Camera camera;
        ContentManager Content;
        Texture2D nextButton, prevButton, restartButton;
        SpriteBatch spriteBatch;
        bool _pressedNext = false;
        bool _pressedPrev = false;
        bool _pressedRestart = false;
        bool _pressedMainMenu = false;
        public MidMenuController(ContentManager content, GraphicsDeviceManager graphics, SpriteBatch _spriteBatch, Camera _camera)
        {
            Content = content;
            spriteBatch = _spriteBatch;
            nextButton = Content.Load<Texture2D>("Menu/NextButton");
            prevButton = Content.Load<Texture2D>("Menu/PrevButton");
            restartButton = Content.Load<Texture2D>("Menu/RestartButton");
            camera = _camera;
            midMenuView = new MidMenuView(Content, camera, nextButton, prevButton, restartButton);
        }

        public void Update(Vector2 mousePos, bool playerFailed, bool nextLevelExists)
        {
            var ButtonSize = midMenuView.getSize();
            var nextButtonPos = midMenuView.getNextButtonPos();
            var mainMenuButtonPos = midMenuView.getNextButtonPos();
            var prevButtonPos = midMenuView.getPrevButtonPos();
            var restartButtonPos = midMenuView.getRestartButtonPos();
            if (
                camera.convertToLogicalCoords(mousePos).X < nextButtonPos.X + ButtonSize.X / 2 &&
                camera.convertToLogicalCoords(mousePos).X > nextButtonPos.X - ButtonSize.X / 2 &&
                camera.convertToLogicalCoords(mousePos).Y < nextButtonPos.Y + ButtonSize.Y / 2 &&
                camera.convertToLogicalCoords(mousePos).Y > nextButtonPos.Y - ButtonSize.Y / 2 &&
                !playerFailed && nextLevelExists
               )
            {
                _pressedNext = true;
            }


            else if (
                camera.convertToLogicalCoords(mousePos).X < prevButtonPos.X + ButtonSize.X / 2 &&
                camera.convertToLogicalCoords(mousePos).X > prevButtonPos.X - ButtonSize.X / 2 &&
                camera.convertToLogicalCoords(mousePos).Y < prevButtonPos.Y + ButtonSize.Y / 2 &&
                camera.convertToLogicalCoords(mousePos).Y > prevButtonPos.Y - ButtonSize.Y / 2
               )
            {
                _pressedPrev = true;
            }


            else if (
                camera.convertToLogicalCoords(mousePos).X < restartButtonPos.X + ButtonSize.X / 2 &&
                camera.convertToLogicalCoords(mousePos).X > restartButtonPos.X - ButtonSize.X / 2 &&
                camera.convertToLogicalCoords(mousePos).Y < restartButtonPos.Y + ButtonSize.Y / 2 &&
                camera.convertToLogicalCoords(mousePos).Y > restartButtonPos.Y - ButtonSize.Y / 2
               )
            {
                _pressedRestart = true;
            }

            else if (
                camera.convertToLogicalCoords(mousePos).X < nextButtonPos.X + ButtonSize.X / 2 &&
                camera.convertToLogicalCoords(mousePos).X > nextButtonPos.X - ButtonSize.X / 2 &&
                camera.convertToLogicalCoords(mousePos).Y < nextButtonPos.Y + ButtonSize.Y / 2 &&
                camera.convertToLogicalCoords(mousePos).Y > nextButtonPos.Y - ButtonSize.Y / 2 &&
                !playerFailed && !nextLevelExists
               )
            {
                _pressedMainMenu = true;
            }
        }

        public void Draw(bool isPlayerDead, bool nextLevelExists)
        {
            midMenuView.Draw(spriteBatch, isPlayerDead, nextLevelExists);
        }

        public bool pressedNext
        {
            get
            {
                return _pressedNext;
            }
            set
            {
                _pressedNext = value;
            }
        }
        public bool pressedPrev
        {
            get
            {
                return _pressedPrev;
            }
            set
            {
                _pressedPrev = value;
            }
        }
        public bool pressedRestart
        {
            get
            {
                return _pressedRestart;
            }
            set
            {
                _pressedRestart = value;
            }
        }
        public bool pressedMainMenu
        {
            get
            {
                return _pressedMainMenu;
            }
            set
            {
                _pressedMainMenu = value;
            }
        }
    }
}
