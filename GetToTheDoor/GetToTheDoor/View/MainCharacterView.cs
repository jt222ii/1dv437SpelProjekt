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
        Texture2D activeTexture, idleCharacterTexture, walkingCharacterTextureLeft, walkingCharacterTextureRight, deadCharacter;
        MainCharacterModel characterModel;
        Vector2 textureCenter;
        Camera camera;
        Vector2 scale;
        public MainCharacterView(Texture2D characterIdle, Texture2D characterWalkingLeft, Texture2D characterWalkingRight, Texture2D characterDead, MainCharacterModel mainModel, Camera _camera)
        {        
            idleCharacterTexture = characterIdle;
            walkingCharacterTextureLeft = characterWalkingLeft;
            walkingCharacterTextureRight = characterWalkingRight;
            deadCharacter = characterDead;
            characterModel = mainModel;
            camera = _camera;
            textureCenter = new Vector2(characterIdle.Width / 2, characterIdle.Height / 2);
            Vector2 size = characterModel.getSize;
            scale = camera.Scale(size, characterIdle.Width, characterIdle.Height);
            setIdle();
        }

        public void Draw(SpriteBatch spriteBatch, float elapsedTime)
        {
            if(characterModel.isDead)
            {
                setDead();
            }
            Vector2 characterVisualLocation = camera.convertToVisualCoords(characterModel.Position);
            spriteBatch.Draw(activeTexture, characterVisualLocation, null, Color.White, 0, textureCenter, scale, SpriteEffects.None, 1f);
        }

        public void setIdle()
        {
            activeTexture = idleCharacterTexture;
        }
        public void setWalkingLeft()
        {
            activeTexture = walkingCharacterTextureLeft;
        }

        public void setWalkingRight()
        {
            activeTexture = walkingCharacterTextureRight;
        }

        public void setDead()
        {
            activeTexture = deadCharacter;
        }


    }
}
