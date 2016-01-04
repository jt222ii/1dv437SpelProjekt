﻿using GetToTheDoor.Model;
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
        Texture2D texture, bulletTexture, shockWave;
        AudioPlayer audioPlayer;
        Vector2 position;
        Camera camera;
        Vector2 textureCenter;
        Vector2 tileSize;
        Vector2 scale;
        float timer = 0;
        float fireRate = 1f;
        bool _turnedRight;

        List<TurretBullet> bullets = new List<TurretBullet>();
        List<BulletHitParticles> particles = new List<BulletHitParticles>();
        public Turret(ContentManager Content, Camera _camera, Vector2 pos, float size, bool turnedRight, AudioPlayer audioP)
        {
            audioPlayer = audioP;
            _turnedRight = turnedRight;
            shockWave = Content.Load<Texture2D>("Hazards/Shockwave2");
            bulletTexture = Content.Load<Texture2D>("Hazards/TurretShot");
            tileSize = new Vector2(size, size);
            if (turnedRight)
            {
                texture = Content.Load<Texture2D>("Hazards/TurretRight");
            }
            else
            {
                texture = Content.Load<Texture2D>("Hazards/TurretLeft");
            }
            position = pos;
            camera = _camera;
            textureCenter = new Vector2(texture.Width / 2, texture.Height / 2);
            scale = camera.Scale(tileSize, texture.Width, texture.Height);
        }

        public void Draw(SpriteBatch spriteBatch, float elapsedTime)
        {
            Vector2 pos = position;
            spriteBatch.Draw(texture, camera.convertToVisualCoords(pos), null, Color.White, 0, textureCenter, scale, SpriteEffects.None, 1f);
            foreach (TurretBullet bullet in bullets)
            {
                bullet.Draw(spriteBatch);
            }
            foreach(BulletHitParticles particle in particles)
            {
                particle.Draw(elapsedTime, spriteBatch);
            }
        }

        public void Update(float time, MainCharacterModel charModel)
        {
            timer += time;
            if(timer >= fireRate)
            {
                bullets.Add(new TurretBullet(camera, position, _turnedRight, bulletTexture, audioPlayer));
                timer = 0;
            }
            List<TurretBullet> bulletsToDelete = new List<TurretBullet>();
            foreach(TurretBullet bullet in bullets)
            {
                bullet.Update(time);
                if(bullet.bulletCollidesWithPlayer(charModel))
                {
                    particles.Add(new BulletHitParticles(shockWave, camera, 1f, bullet.Position));
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
    }
}
