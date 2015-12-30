﻿using GetToTheDoor.Model;
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
            texture = Content.Load<Texture2D>("Tile");
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

        public bool landsOnTile(MainCharacterModel charModel)
        {
            float minX, maxX, minY, maxY;
            minX = position.X-tileSize.X/2;
            maxX = position.X + tileSize.X / 2;
            minY = position.Y - tileSize.Y / 2;
            maxY = position.Y + tileSize.Y / 2;
            return 
                (
                charModel.Position.X + charModel.getSize.X/ 3 > minX && charModel.Position.X - charModel.getSize.X/3 < maxX && 
                charModel.Position.Y + charModel.getSize.Y / 2 > minY && 
                charModel.Position.Y - charModel.getSize.Y / 2 < minY &&
                charModel.Velocity.Y >= 0
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
                charModel.Position.X + charModel.getSize.X / 3 > minX && charModel.Position.X - charModel.getSize.X / 3 < maxX &&
                charModel.Position.Y > minY &&
                charModel.Position.Y - charModel.getSize.Y / 2 < maxY &&
                charModel.Velocity.Y <= 0
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
                charModel.Position.Y + charModel.getSize.Y /3 > minY && charModel.Position.Y - charModel.getSize.Y / 3 < maxY &&
                charModel.Position.X + charModel.getSize.X / 2 > minX &&
                charModel.Position.X - charModel.getSize.X / 2 < maxX
                );
        }
    }
}
