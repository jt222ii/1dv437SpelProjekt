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
        Vector2 position;
        Vector2 velocity;
        static float baseGravity = 8f;
        Vector2 acceleration = new Vector2(0f, baseGravity);
        float moveSpeed = 3f;
        //x radius, y radius
        Vector2 characterSize = new Vector2(0.4f, 0.4f);
        MapSystem mapSystem;
        bool _isDead = false;
        bool hasKey = false;
        bool isJumping = false;

        public MainCharacterModel(MapSystem _mapSystem)
        {
            mapSystem = _mapSystem;
            position = mapSystem.getSpawnPoint;
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
        public bool isDead
        {
            get
            {
                return _isDead;
            }
            set
            {
                _isDead = value;
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
            if (position.X - characterSize.X / 2 <= 0 || _isDead)
            {
                stopMoving();
                return;
            }
            velocity.X = -moveSpeed;
        }
        public void moveRight()
        {
            if (position.X + characterSize.X / 2 >= 16 || _isDead)
            {
                stopMoving();
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
            if (!isJumping && !_isDead)
            {
                velocity.Y = -4f;
                isJumping = true;
            }
        }

        public void Collision()
        {
            if (position.X + characterSize.X / 2 >= 16)
            {
                position.X = 16 - characterSize.X/2;
                velocity.X = 0;
            }
            else if (position.X - characterSize.X / 2 <= 0)
            {
                position.X = 0 + characterSize.X/2;
                velocity.X = 0;
            }

            if(position.Y >= 16)
            {
                isDead = true;
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
            position.Y = tile.Position.Y - (tile.Size.Y/2 + characterSize.Y/2);
            isJumping = false;
            acceleration.Y = 0;
            velocity.Y = 0;
        }
        public void hitHeadOnTile(Tile tileHitFromBelow)
        {
            position.Y = tileHitFromBelow.Position.Y + tileHitFromBelow.Size.Y;
            velocity.Y = -velocity.Y*0.5f;
        }
        public void collideX(Tile tile)
        {
            if (position.X-tile.Position.X > 0)
            {
                position.X = tile.Position.X + (tile.Size.X / 2 + characterSize.X / 2);
            }
            else if (position.X - tile.Position.X < 0)
            {
                position.X = tile.Position.X - (tile.Size.X / 2 + characterSize.X / 2);
            }
        }
        public void fall()
        {
            acceleration.Y = baseGravity;
        }

        public bool IsJumping
        {
            get { return isJumping; }
        }
    }
}
