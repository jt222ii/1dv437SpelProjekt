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
    class Door
    {
        Vector2 position;
        Vector2 tileSize;

        public Door(Vector2 pos, float size)
        {
            tileSize = new Vector2(size, size);
            position = pos;
        }


        public bool collidesAndUnlocks(MainCharacterModel charModel)
        {
            float minX, maxX, minY, maxY;
            minX = position.X - tileSize.X / 2;
            maxX = position.X + tileSize.X / 2;
            minY = position.Y - tileSize.Y / 2;
            maxY = position.Y + tileSize.Y / 2;
            if (
                charModel.Position.X > minX && charModel.Position.X < maxX &&
                charModel.Position.Y + charModel.getSize.Y > minY &&
                charModel.Position.Y - charModel.getSize.Y < maxY     
                )
            {
                if (charModel.HasKey)
                {
                    return true;
                }
            }    
            return false;
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
    }
}
