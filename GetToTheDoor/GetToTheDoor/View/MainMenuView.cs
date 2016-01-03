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
        Vector2 continueButtonPos = new Vector2(8f, 2f);
        Vector2 newGameButtonPos = new Vector2(8f, 4.5f);
        Vector2 infoWindowPos = new Vector2(8f, 7f);
        Vector2 infoWindow2Pos = new Vector2(15f, 7f);
        Vector2 size = new Vector2(4f, 2f);
        Vector2 infoSize = new Vector2(6f, 3f);
        Texture2D continueButton, newGameButton, infoWindow, infoWindow2;
        Vector2 textureCenter;
        Vector2 scale, infoscale;
        public MainMenuView(Camera _camera, Texture2D buttonTexture, Texture2D NewGameButton, Texture2D InfoWindow, Texture2D InfoWindow2)
        {
            camera = _camera;
            continueButton = buttonTexture;
            newGameButton = NewGameButton;
            infoWindow = InfoWindow;
            infoWindow2 = InfoWindow2;
            textureCenter = new Vector2(buttonTexture.Width / 2, buttonTexture.Height / 2);
            scale = camera.Scale(size, buttonTexture.Width, buttonTexture.Height);
            infoscale = camera.Scale(infoSize, InfoWindow.Width, InfoWindow.Height);
        }

        public Vector2 getContinueButtonPos()
        {
            return continueButtonPos;
        }
        public Vector2 getNewGameButtonPos()
        {
            return newGameButtonPos;
        }
        public Vector2 getSize()
        {
            return size;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(continueButton, camera.convertToVisualCoords(continueButtonPos), null, Color.White, 0, textureCenter, scale, SpriteEffects.None, 1f);
            spriteBatch.Draw(newGameButton, camera.convertToVisualCoords(newGameButtonPos), null, Color.White, 0, textureCenter, scale, SpriteEffects.None, 1f);
            spriteBatch.Draw(infoWindow, camera.convertToVisualCoords(infoWindowPos), null, Color.White, 0, textureCenter, infoscale, SpriteEffects.None, 1f);
            spriteBatch.Draw(infoWindow2, camera.convertToVisualCoords(infoWindow2Pos), null, Color.White, 0, textureCenter, infoscale, SpriteEffects.None, 1f);
        }



    }
}
