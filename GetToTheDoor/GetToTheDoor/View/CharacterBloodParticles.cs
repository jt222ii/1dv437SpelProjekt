using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GetToTheDoor.View
{
    class CharacterBloodParticles
    {
        private Vector2 particleSize = new Vector2(0.1f, 0.1f);
        private Vector2 randomDirection;
        private float maxSpeed = 5f;
        private Texture2D _spark;
        private Vector2 position;
        private Vector2 velocity;
        private Vector2 acceleration = new Vector2(0.0f, 2f);
        private Vector2 startPos;
        private float particleLifeTime;
        private float fade = 1;
        private SpriteBatch _spriteBatch;
        private Camera _camera;
        Vector2 scale;
        public CharacterBloodParticles(Texture2D spark, Random rand, SpriteBatch spriteBatch, Camera camera, Vector2 StartLocation, float particlesLifeTime)
        {
            particleLifeTime = particlesLifeTime;
            startPos = StartLocation;
            position = StartLocation;
            _spark = spark;
            _camera = camera;
            _spriteBatch = spriteBatch;
            randomDirection = new Vector2((float)rand.NextDouble() - 0.5f, (float)rand.NextDouble() - 0.7f);
            //normalize to get it spherical vector with length 1.0
            randomDirection.Normalize();
            //add random length between 0 to maxSpeed
            randomDirection = randomDirection * ((float)rand.NextDouble() * maxSpeed);
            velocity = randomDirection;
            scale = _camera.Scale(particleSize, _spark.Width, _spark.Height);
        }

        public void Draw(float elapsedTime)
        {
            fade -= elapsedTime / particleLifeTime;
            velocity = elapsedTime * acceleration + velocity;
            position = elapsedTime * velocity + position;

            Color color = new Color(fade, fade, fade, fade);
            _spriteBatch.Draw(_spark, _camera.convertToVisualCoords(position), null, color, 0, randomDirection, scale, SpriteEffects.None, 0.9f);
      
        }

    }
}
