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
        Texture2D playButton;
        SpriteBatch spriteBatch;
        bool _pressedPlay = false;
        public MenuController(ContentManager content, GraphicsDeviceManager graphics, SpriteBatch _spriteBatch, Camera _camera)
        {
            Content = content;
            spriteBatch = _spriteBatch;
            playButton = Content.Load<Texture2D>("PlayButton");
            camera = _camera;
            mainMenuView = new MainMenuView(Content, camera, playButton);
        }

        public void Update(Vector2 mousePos)
        {
            var playButtonSize = mainMenuView.getSize();
            var playButtonPos = mainMenuView.getPlayButtonPos();
            if (
                camera.convertToLogicalCoords(mousePos).X < playButtonPos.X + playButtonSize.X &&
                camera.convertToLogicalCoords(mousePos).X > playButtonPos.X - playButtonSize.X &&
                camera.convertToLogicalCoords(mousePos).Y < playButtonPos.Y + playButtonSize.Y &&
                camera.convertToLogicalCoords(mousePos).Y > playButtonPos.Y - playButtonSize.Y 
               )
            {
                _pressedPlay = true;
            }
        }

        public void Draw()
        {
            mainMenuView.Draw(spriteBatch);
        }

        public bool pressedPlay
        {
            get
            {
               return _pressedPlay;
            }
        }
    }
}
