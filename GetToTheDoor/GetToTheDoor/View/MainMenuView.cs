using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GetToTheDoor.View
{
    class MainMenuView
    {
        Camera camera;
        ContentManager Content;
        Vector2 playButtonPos = new Vector2(8f, 4.5f);
        Vector2 size = new Vector2(2f, 1f);
        Texture2D playButton;
        Vector2 textureCenter;
        Vector2 scale;
        public MainMenuView(ContentManager content, Camera _camera, Texture2D buttonTexture)
        {
            camera = _camera;
            Content = content;
            playButton = buttonTexture;
            textureCenter = new Vector2(buttonTexture.Width / 2, buttonTexture.Height / 2);
            scale = camera.Scale(size, buttonTexture.Width, buttonTexture.Height);
        }

        public Vector2 getPlayButtonPos()
        {
            return playButtonPos;
        }
        public Vector2 getSize()
        {
            return size;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            var buttonVisualLoc = camera.convertToVisualCoords(playButtonPos);
            spriteBatch.Draw(playButton, buttonVisualLoc, null, Color.White, 0, textureCenter, scale, SpriteEffects.None, 1f);
        }



    }
}
