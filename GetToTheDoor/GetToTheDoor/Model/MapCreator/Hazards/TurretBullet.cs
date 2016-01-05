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
        Vector2 position;
        Vector2 Velocity = new Vector2(-5f, 0f);
        Vector2 size = new Vector2(0.5f, 0.5f);
        bool justCollided = false;
        public TurretBullet(Vector2 pos, bool turnedRight, AudioPlayer audioPlayer)
        {
            audioPlayer.turretShot();
            position = pos;
            if(turnedRight)
            {
                Velocity.X = -Velocity.X; 
            }
        }

        public Vector2 Position
        {
            get { return position; }
        }
        

        public void Update(float elapsedTime)
        {
            position = elapsedTime * Velocity + position;
        }
        
        public bool JustCollided
        {
            get
            {
                return justCollided;
            }
            set
            {
                justCollided = false;
            }
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
                justCollided = true;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
