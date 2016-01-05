using GetToTheDoor.Model;
using GetToTheDoor.View;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GetToTheDoor.MapCreator.Hazards
{
    class SawBlade
    {
        Vector2 tileSize, position;
        float rotation = 0;
        Vector2 Velocity = new Vector2(0f, 2f);
        float sawminX, sawmaxX, sawminY, sawmaxY;
        public SawBlade(ContentManager Content, Vector2 pos, float size)
        {

            tileSize = new Vector2(size, size);         
            position = pos;

        }

        public void Update(float elapsedTime, List<Tile> tiles, MainCharacterModel charModel)
        {
            sawminX = position.X - tileSize.X / 2;
            sawmaxX = position.X + tileSize.X / 2;
            sawminY = position.Y - tileSize.Y / 2;
            sawmaxY = position.Y + tileSize.Y / 2;
            position = elapsedTime * Velocity + position;
            rotation += elapsedTime * 2;
            foreach(Tile tile in tiles)
            {
                float tileminX, tilemaxX, tileminY, tilemaxY;
                tileminX = tile.Position.X - tile.Size.X / 2;
                tilemaxX = tile.Position.X + tile.Size.X / 2;
                tileminY = tile.Position.Y - tile.Size.Y / 2;
                tilemaxY = tile.Position.Y + tile.Size.Y / 2;
                if
                    (
                        position.X + tileSize.X / 2 > tileminX && position.X - tileSize.X / 2 < tilemaxX &&
                        position.Y > tileminY &&
                        position.Y - tileSize.Y / 2 < tilemaxY
                        ||
                        position.X + tileSize.X / 2 > tileminX && position.X - tileSize.X/2 < tilemaxX && 
                        position.Y + tileSize.Y / 2 > tileminY && 
                        position.Y - tileSize.Y / 2 < tileminY
                    )
                {
                    Velocity = -Velocity;
                }
            }
            if
                ( 
                charModel.Position.Y + charModel.getSize.Y / 2 > sawminY && charModel.Position.Y - charModel.getSize.Y / 2 < sawmaxY &&
                charModel.Position.X + charModel.getSize.X / 2 > sawminX &&
                charModel.Position.X - charModel.getSize.X / 2 < sawmaxX
                )
            {
                charModel.isDead = true;
            }
        }

        public Vector2 Position
        {
            get
            {
                return position;
            }
        }
        public Vector2 Size
        {
            get
            {
                return tileSize;
            }
        }

        public float Rotation
        {
            get
            {
                return rotation;
            }
        }
    }
}
