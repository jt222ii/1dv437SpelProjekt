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
        Texture2D texture, bulletTexture;
        Vector2 position;
        Camera camera;
        Vector2 textureCenter;
        Vector2 tileSize;
        Vector2 scale;
        float timer = 0;
        float fireRate = 1f;
        bool _turnedRight;

        List<TurretBullet> bullets = new List<TurretBullet>();
        public Turret(ContentManager Content, Camera _camera, Vector2 pos, float size, bool turnedRight)
        {
            _turnedRight = turnedRight;
            bulletTexture = Content.Load<Texture2D>("TurretShot");
            tileSize = new Vector2(size, size);
            if (turnedRight)
            {
                texture = Content.Load<Texture2D>("TurretRight");
            }
            else
            {
                texture = Content.Load<Texture2D>("TurretLeft");
            }
            position = pos;
            camera = _camera;
            textureCenter = new Vector2(texture.Width / 2, texture.Height / 2);
            scale = camera.Scale(tileSize, texture.Width, texture.Height);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Vector2 pos = position;
            spriteBatch.Draw(texture, camera.convertToVisualCoords(pos), null, Color.White, 0, textureCenter, scale, SpriteEffects.None, 1f);
            foreach (TurretBullet bullet in bullets)
            {
                bullet.Draw(spriteBatch);
            }
        }

        public void Update(float time)
        {
            timer += time;
            if(timer >= fireRate)
            {
                bullets.Add(new TurretBullet(camera, position, _turnedRight, bulletTexture));
                timer = 0;
            }
            foreach(TurretBullet bullet in bullets)
            {
                bullet.Update(time);
            }
        }
    }
}
