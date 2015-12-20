using GetToTheDoor.Model;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GetToTheDoor.View
{
    class MainCharacterView
    {
        Texture2D characterTexture;
        MainCharacterModel characterModel;
        Vector2 textureCenter;
        Camera camera;
        Vector2 scale;
        public MainCharacterView(Texture2D character, MainCharacterModel mainModel, Camera _camera)
        {
            characterTexture = character;
            characterModel = mainModel;
            camera = _camera;
            textureCenter = new Vector2(characterTexture.Width / 2, characterTexture.Height / 2);
            Vector2 size = characterModel.getSize;
            scale = camera.Scale(size, characterTexture.Width, characterTexture.Height);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Vector2 characterVisualLocation = camera.convertToVisualCoords(characterModel.Position);
            spriteBatch.Draw(characterTexture, characterVisualLocation, null, Color.White, 0, textureCenter, scale, SpriteEffects.None, 1f);
        }


    }
}
