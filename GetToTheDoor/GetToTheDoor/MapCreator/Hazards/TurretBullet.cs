using GetToTheDoor.Model;
using GetToTheDoor.View;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GetToTheDoor.MapCreator.Hazards
{
    class TurretBullet
    {
        Camera camera;
        Vector2 position, textureCenter;
        Vector2 Velocity = new Vector2(-5f, 0f);
        Texture2D texture;
        Vector2 size = new Vector2(0.5f, 0.5f);
        Vector2 scale;
        bool hasCollided = false;
        public TurretBullet(Camera _camera, Vector2 pos, bool turnedRight, Texture2D bulletTexture)
        {
            texture = bulletTexture;
            camera = _camera;
            position = pos;
            if(turnedRight)
            {
                Velocity.X = -Velocity.X; 
            }
            textureCenter = new Vector2(texture.Width / 2, texture.Height / 2);
            scale = camera.Scale(size, texture.Width, texture.Height);
        }
        
        public void Draw(SpriteBatch spriteBatch)
        {
            Vector2 characterVisualLocation = camera.convertToVisualCoords(position);
            spriteBatch.Draw(texture, characterVisualLocation, null, Color.White, 0, textureCenter, scale, SpriteEffects.None, 1f);
        }

        public void Update(float elapsedTime)
        {
            position = elapsedTime * Velocity + position;
        }
        
        public bool bulletHasCollided()
        {
            return hasCollided;
        }

        public bool bulletCollidesWithPlayer(MainCharacterModel charModel)
        {
            float minX, maxX, minY, maxY;
            minX = position.X - size.X / 2;
            maxX = position.X + size.X / 2;
            minY = position.Y - size.Y / 2;
            maxY = position.Y + size.Y / 2;
            if  (
                charModel.Position.Y > minY && charModel.Position.Y < maxY &&
                charModel.Position.X + charModel.getSize.X / 2 > minX &&
                charModel.Position.X - charModel.getSize.X / 2 < maxX
                )
            {
                hasCollided = true;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
