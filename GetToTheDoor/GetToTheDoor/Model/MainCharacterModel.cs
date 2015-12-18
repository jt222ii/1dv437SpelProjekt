using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GetToTheDoor.Model
{
    class MainCharacterModel
    {
        Vector2 position = new Vector2(8f, 2f);
        Vector2 velocity;
        static float baseGravity = 7f;
        Vector2 acceleration = new Vector2(0f, baseGravity);
        float moveSpeed = 3f;
        //x radius, y radius
        Vector2 characterSize = new Vector2(0.5f, 0.5f);
        TileSystem tileSystem;
        bool hasKey = false;

        public MainCharacterModel(TileSystem _tileSystem, float gameScale)
        {
            characterSize *= gameScale;
            tileSystem = _tileSystem;
        }
        public Vector2 getSize
        {
            get
            {
                return characterSize;
            }
        }
        public bool HasKey
        {
            get
            {
                return hasKey;
            }
            set
            {
                hasKey = value;
            }
        }
        public Vector2 Velocity
        {
            get
            {
                return velocity;
            }
            set
            {
                velocity = value;
            }
        }
        public void Update(float elapsedTime)
        {
            velocity = elapsedTime * acceleration + velocity;
            position = elapsedTime * velocity + position;
            Collision();
        }

        public void moveLeft()
        {
            if (position.X - characterSize.X <= 0)
            {
                return;
            }
            velocity.X = -moveSpeed;
        }
        public void moveRight()
        {
            if (position.X + characterSize.X >= 16)
            {
                return;
            }
            velocity.X = moveSpeed;
        }
        public void stopMoving()
        {
            velocity.X = 0;
        }
        public void jump()
        {
            if (velocity.Y == 0)
            {
                velocity.Y = -5f;
            }
        }

        public void Collision()
        {
            if (position.X + characterSize.X >= 16)
            {
                position.X = 16 - characterSize.X;
                velocity.X = 0;
            }
            else if (position.X - characterSize.X <= 0)
            {
                position.X = 0 + characterSize.X;
                velocity.X = 0;
            }
        }

        public Vector2 Position
        {
            get
            {
                return position;
            }
            set
            {
                Position = value;
            }
        }

        public void landOnTile(Tile tile)
        {
            position.Y = tile.Position.Y - tile.Size.Y; //if you somehow manage to land inside a tile you get moved up. Only happens when you hit it diagonally in a specific angle and place
            acceleration.Y = 0;
            velocity.Y = 0;
        }
        public void hitHeadOnTile()
        {
            velocity.Y = -velocity.Y*0.5f;
        }
        public void collideX(Tile tile)
        {
            if (position.X-tile.Position.X > 0)
            {
                position.X = tile.Position.X + tile.Size.X;
            }
            else if (position.X - tile.Position.X < 0)
            {
                position.X = tile.Position.X - tile.Size.X;
            }
        }
        public void fall()
        {
            acceleration.Y = baseGravity;
        }
    }
}
