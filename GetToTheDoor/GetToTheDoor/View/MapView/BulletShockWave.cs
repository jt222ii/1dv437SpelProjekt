using GetToTheDoor.View;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GetToTheDoor.MapCreator.Hazards
{
    class BulletShockWave
    {
        private Vector2 position;
        private Camera _camera;
        private Texture2D texture;
        private Vector2 scale;
        private float fade = 1;
        private Vector2 particleMinSize = new Vector2(0,0);
        private Vector2 particleMaxSize = new Vector2(5f, 5f);
        private float maxTimeToLive = 0.8f;
        private float timeLived = 0;
        private Vector2 particleSize;
        private float lifePercent;

        public BulletShockWave(Texture2D shockwaveTexture, Camera camera, Vector2 Scale, Vector2 startLocation)
        {
            position = startLocation;
            scale = Scale;
            _camera = camera;
            texture = shockwaveTexture;
        }
        public void Draw(float elapsedTime, SpriteBatch spriteBatch)
        {
            fade -= elapsedTime / maxTimeToLive;
            timeLived += elapsedTime;
            lifePercent = timeLived / maxTimeToLive;
            particleSize = (particleMinSize + lifePercent * particleMaxSize) * scale;
            Color color = new Color(fade, fade, fade, fade);
            Vector2 texturescale = _camera.Scale(particleSize, texture.Width, texture.Height);
            spriteBatch.Draw(texture, _camera.convertToVisualCoords(position), null, color, 0, new Vector2(texture.Width / 2, texture.Height / 2), texturescale, SpriteEffects.None, 1f);
        }


    }
}
