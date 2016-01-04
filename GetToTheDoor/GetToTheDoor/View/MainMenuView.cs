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
        Vector2 continueButtonPos = new Vector2(8f, 4.5f);
        Vector2 newGameButtonPos = new Vector2(8f, 7f);
        Vector2 infoWindowPos = new Vector2(3f, 6f);
        Vector2 infoWindow2Pos = new Vector2(13f, 6f);
        Vector2 titlePos = new Vector2(8f, 2f);
        Vector2 creditSongPos = new Vector2(0f, 0f);
        Vector2 size = new Vector2(4f, 2f);
        Vector2 infoSize = new Vector2(6f, 3f);
        Vector2 titleSize = new Vector2(10f, 2f);
        Texture2D continueButton, newGameButton, infoWindow, infoWindow2, title;
        Vector2 textureCenter, infoWCenter, infoW2Center, titleCenter;
        Vector2 scale, infoscale, titleScale;
        SpriteFont spriteFont;
        public MainMenuView(Camera _camera, Texture2D buttonTexture, Texture2D NewGameButton, Texture2D InfoWindow, Texture2D InfoWindow2, Texture2D Title, SpriteFont spriteF)
        {
            camera = _camera;
            continueButton = buttonTexture;
            newGameButton = NewGameButton;
            infoWindow = InfoWindow;
            infoWindow2 = InfoWindow2;
            title = Title;
            spriteFont = spriteF;
            textureCenter = new Vector2(buttonTexture.Width / 2, buttonTexture.Height / 2);
            infoWCenter = new Vector2(infoWindow.Width / 2, infoWindow.Height / 2);
            infoW2Center = new Vector2(infoWindow2.Width / 2, infoWindow2.Height / 2);
            titleCenter = new Vector2(title.Width / 2, title.Height / 2);
            scale = camera.Scale(size, buttonTexture.Width, buttonTexture.Height);
            infoscale = camera.Scale(infoSize, InfoWindow.Width, InfoWindow.Height);
            titleScale = camera.Scale(titleSize, title.Width, title.Height);
            
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
            spriteBatch.Draw(title, camera.convertToVisualCoords(titlePos), null, Color.White, 0, titleCenter, titleScale, SpriteEffects.None, 1f);
            spriteBatch.Draw(continueButton, camera.convertToVisualCoords(continueButtonPos), null, Color.White, 0, textureCenter, scale, SpriteEffects.None, 1f);
            spriteBatch.Draw(newGameButton, camera.convertToVisualCoords(newGameButtonPos), null, Color.White, 0, textureCenter, scale, SpriteEffects.None, 1f);
            spriteBatch.Draw(infoWindow, camera.convertToVisualCoords(infoWindowPos), null, Color.White, 0, infoWCenter, infoscale, SpriteEffects.None, 1f);
            spriteBatch.Draw(infoWindow2, camera.convertToVisualCoords(infoWindow2Pos), null, Color.White, 0, infoW2Center, infoscale, SpriteEffects.None, 1f);
            spriteBatch.DrawString(spriteFont, "Music:\n\"Pixelland\" Kevin MacLeod (incompetech.com) \nLicensed under Creative Commons: By Attribution 3.0 \nhttp://creativecommons.org/licenses/by/3.0/\nDeathSound from: http://www.freesfx.co.uk", creditSongPos, Color.Black);
        }



    }
}
