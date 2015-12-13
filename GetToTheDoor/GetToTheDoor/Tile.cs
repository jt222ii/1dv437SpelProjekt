using GetToTheDoor.Model;
using GetToTheDoor.View;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GetToTheDoor
{
    class Tile
    {
        Texture2D texture;
        Vector2 position;
        Camera camera;
        Vector2 textureCenter;
        Vector2 tileSize;
        Vector2 scale;

        public Tile(ContentManager Content, Camera _camera, Vector2 pos, float size)
        {
            tileSize = new Vector2(size, size);
            texture = Content.Load<Texture2D>("1_043");
            position = pos;
            camera = _camera;
            textureCenter = new Vector2(texture.Width / 2, texture.Height / 2);
            scale = camera.Scale(tileSize, texture.Width, texture.Height);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Vector2 pos = position;
            spriteBatch.Draw(texture, camera.convertToVisualCoords(pos), null, Color.White, 0, textureCenter, scale, SpriteEffects.None, 1f);
        }
        public Vector2 Size
        {
            get
            {
                return tileSize;
            }
        }
        public Vector2 Position
        {
            get
            {
                return position;
            }
        }

        public Rectangle getBounds()
        {
            return new Rectangle((int)Position.X, (int)Position.Y, texture.Width, texture.Height);
        }

        public bool landsOnTile(MainCharacterModel charModel)
        {
            float minX, maxX, minY, maxY;
            minX = position.X-tileSize.X/2;
            maxX = position.X + tileSize.X / 2;
            minY = position.Y - tileSize.Y / 2;
            maxY = position.Y + tileSize.Y / 2;
            return 
                (
                charModel.Position.X > minX && charModel.Position.X < maxX && 
                charModel.Position.Y + charModel.getSize.Y > minY && 
                charModel.Position.Y - charModel.getSize.Y < minY
                );
        }
        public bool hitsHeadOnTile(MainCharacterModel charModel)
        {
            float minX, maxX, minY, maxY;
            minX = position.X - tileSize.X / 2;
            maxX = position.X + tileSize.X / 2;
            minY = position.Y - tileSize.Y / 2;
            maxY = position.Y + tileSize.Y / 2;
            return
                (
                charModel.Position.X > minX && charModel.Position.X < maxX &&
                charModel.Position.Y + charModel.getSize.Y > minY &&
                charModel.Position.Y - charModel.getSize.Y < maxY
                );
        }

        public bool collisionX(MainCharacterModel charModel)
        {
            float minX, maxX, minY, maxY;
            minX = position.X - tileSize.X / 2;
            maxX = position.X + tileSize.X / 2;
            minY = position.Y - tileSize.Y / 2;
            maxY = position.Y + tileSize.Y / 2;
            return
                (
                charModel.Position.Y > minY && charModel.Position.Y < maxY &&
                charModel.Position.X + charModel.getSize.X > minX &&
                charModel.Position.X - charModel.getSize.X < maxX
                );
        }
    }
}
