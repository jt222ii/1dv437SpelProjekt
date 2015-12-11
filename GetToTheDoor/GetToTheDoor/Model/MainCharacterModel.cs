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
        float moveSpeed = 5f;
        //x radius, y radius
        Vector2 characterSize = new Vector2(0.4f, 0.4f);

        public MainCharacterModel()
        {

        }
        public Vector2 getSize
        {
            get
            {
                return characterSize;
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
            Console.WriteLine(position);
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
            if (position.Y + characterSize.Y >= 9)
            {
                position.Y = 9 - characterSize.Y;
                velocity.Y = 0;
                acceleration.Y = 0;
            }
            else if(acceleration.Y == 0)
            {
                acceleration.Y = baseGravity;
            }

        }

        public Vector2 getPosition
        {
            get
            {
                return position;
            }
        }
    }
}
