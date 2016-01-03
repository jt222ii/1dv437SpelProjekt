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
        //int spriteHeight = 78;
        //int spriteWidth = 44;
        //float timeElapsed = 0;
        //float maxTime;
        //int numberOfFrames;
        //int numFramesX;
        //int numFramesY;
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
            //timeElapsed += elapsedTime;
            //if (timeElapsed >= maxTime)
            //{
            //    timeElapsed = 0;
            //}
            //float percentAnimated = timeElapsed / maxTime;
            //int frame = (int)(percentAnimated * numberOfFrames);
            //int frameX = frame % numFramesX;
            //int frameY = frame / numFramesX;
            //int frameWidth = activeTexture.Width / numFramesX;
            //int frameHeight = activeTexture.Height / numFramesY;
            //textureCenter = new Vector2(frameWidth / 2, frameHeight / 2);
            //Rectangle rect = new Rectangle(frameWidth * frameX, frameHeight * frameY, frameWidth, frameHeight); spriteBatch.Draw(activeTexture, characterVisualLocation, rect, Color.White, 0, textureCenter, scale, SpriteEffects.None, 1f);
            spriteBatch.Draw(activeTexture, characterVisualLocation, null, Color.White, 0, textureCenter, scale, SpriteEffects.None, 1f);
        }

        public void setIdle()
        {
            activeTexture = idleCharacterTexture;
            //maxTime = 1f;
            //numberOfFrames = 4;
            //numFramesX = 4;
            //numFramesY = 1;
        }
        public void setWalkingLeft()
        {
            activeTexture = walkingCharacterTextureLeft;
            //maxTime = 0.75f;
            //numberOfFrames = 11;
            //numFramesX = 5;
            //numFramesY = 3;
        }

        public void setWalkingRight()
        {
            activeTexture = walkingCharacterTextureRight;
            //maxTime = 0.75f;
            //numberOfFrames = 10;
            //numFramesX = 5;
            //numFramesY = 2;
        }

        public void setDead()
        {
            activeTexture = deadCharacter;
            //maxTime = 2f;
            //numberOfFrames = 9;
            //numFramesX = 5;
            //numFramesY = 2;
        }


    }
}
