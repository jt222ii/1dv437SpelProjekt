using GetToTheDoor.View;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GetToTheDoor.Controller
{
    class MenuController
    {
        MainMenuView mainMenuView;
        Camera camera;
        ContentManager Content;
        Texture2D continueButton, newGameButton, infoWindow;
        SpriteBatch spriteBatch;
        bool _pressedContinue = false;
        bool _pressedNewGame = false;
        public MenuController(ContentManager content, GraphicsDeviceManager graphics, SpriteBatch _spriteBatch, Camera _camera)
        {
            Content = content;
            spriteBatch = _spriteBatch;
            continueButton = Content.Load<Texture2D>("Menu/ContinueButton");
            newGameButton = Content.Load<Texture2D>("Menu/NewGameButton");
            infoWindow = Content.Load<Texture2D>("Menu/InfoWindow");
            camera = _camera;
            mainMenuView = new MainMenuView(camera, continueButton, newGameButton, infoWindow);
        }

        public void Update(Vector2 mousePos)
        {
            var ButtonSize = mainMenuView.getSize();
            var continueButtonPos = mainMenuView.getContinueButtonPos();
            var newGameButtonPos = mainMenuView.getNewGameButtonPos();
            if (
                camera.convertToLogicalCoords(mousePos).X < continueButtonPos.X + ButtonSize.X / 2 &&
                camera.convertToLogicalCoords(mousePos).X > continueButtonPos.X - ButtonSize.X / 2 &&
                camera.convertToLogicalCoords(mousePos).Y < continueButtonPos.Y + ButtonSize.Y / 2 &&
                camera.convertToLogicalCoords(mousePos).Y > continueButtonPos.Y - ButtonSize.Y / 2 
               )
            {
                _pressedContinue = true;
            }

            if (
                camera.convertToLogicalCoords(mousePos).X < newGameButtonPos.X + ButtonSize.X / 2 &&
                camera.convertToLogicalCoords(mousePos).X > newGameButtonPos.X - ButtonSize.X / 2 &&
                camera.convertToLogicalCoords(mousePos).Y < newGameButtonPos.Y + ButtonSize.Y / 2 &&
                camera.convertToLogicalCoords(mousePos).Y > newGameButtonPos.Y - ButtonSize.Y / 2
               )
            {
                _pressedNewGame = true;
            }
        }

        public void Draw()
        {
            mainMenuView.Draw(spriteBatch);
        }

        public bool pressedNewGame
        {
            get
            {
                return _pressedNewGame;
            }
            set
            {
                _pressedNewGame = value;
            }
        }
        public bool pressedContinue
        {
            get
            {
               return _pressedContinue;
            }
            set
            {
                _pressedContinue = value;
            }
        }
    }
}
