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
    class Turret
    {
        AudioPlayer audioPlayer;
        Vector2 position;
        Camera camera;
        Vector2 tileSize;
        float timer = 0;
        float fireRate = 1f;
        bool _turnedRight;

        List<TurretBullet> bullets = new List<TurretBullet>();
        List<Vector2> bulletsHitLocations = new List<Vector2>();
        public Turret(ContentManager Content, Camera _camera, Vector2 pos, float size, bool turnedRight, AudioPlayer audioP)
        {
            audioPlayer = audioP;
            _turnedRight = turnedRight;
            tileSize = new Vector2(size, size);
            position = pos;
            camera = _camera;
        }


        public void Update(float time, MainCharacterModel charModel)
        {
            timer += time;
            if(timer >= fireRate)
            {
                bullets.Add(new TurretBullet(position, _turnedRight, audioPlayer));
                timer = 0;
            }
            List<TurretBullet> bulletsToDelete = new List<TurretBullet>();
            foreach(TurretBullet bullet in bullets)
            {
                bullet.Update(time);
                if(bullet.bulletCollidesWithPlayer(charModel))
                {
                    bulletsHitLocations.Add(bullet.Position);
                    charModel.isDead = true;
                    bulletsToDelete.Add(bullet);
                }
            }
            if (bulletsToDelete != null)
            {
                foreach(TurretBullet bullet in bulletsToDelete)
                {
                    bullets.Remove(bullet);
                }
            }
        }

        public List<TurretBullet> bulletList
        {
            get 
            { 
                return bullets; 
            }
        }
        public List<Vector2> BulletsHitLocations
        {
            get
            {
                return bulletsHitLocations;
            }
        }

        public bool TurnedRight
        {
            get
            {
                return _turnedRight;
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
