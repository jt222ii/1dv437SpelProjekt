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
        Vector2 position = new Vector2(8f, 4.5f);
        Vector2 velocity;
        static float baseGravity = 7f;
        Vector2 acceleration = new Vector2(0f, baseGravity);
        float moveSpeed = 3f;
        //x radius, y radius
        Vector2 characterSize = new Vector2(0.25f, 0.25f);
        TileSystem tileSystem;

        public MainCharacterModel(TileSystem _tileSystem)
        {
            tileSystem = _tileSystem;
        }
        public Vector2 getSize
        {
            get
            {
                return characterSize;
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

        public void landOnTile()
        {
            velocity.Y = 0;
            acceleration.Y = 0;
        }
        public void fall()
        {
            acceleration.Y = baseGravity;
        }
    }
}
