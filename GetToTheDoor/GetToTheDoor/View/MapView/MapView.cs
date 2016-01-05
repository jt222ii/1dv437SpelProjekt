using GetToTheDoor.MapCreator.Hazards;
using GetToTheDoor.Model;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GetToTheDoor.View.MapObjects
{
    class MapView
    {
        Texture2D tileTexture, sawBladeTexture, turretRightTexture, turretLeftTexture, turretBulletTexture, shockWaveTexture, doorTexture, keyTexture;
        Vector2 tileCenter, sawBladeCenter, turretCenter, bulletCenter, doorCenter, keyCenter; 
        Vector2 scale;
        Camera camera;
        SpriteBatch spriteBatch;
        List<BulletShockWave> particles = new List<BulletShockWave>();
        int shockWaveCount = 0;
        public MapView(ContentManager Content, Camera _camera, SpriteBatch _spriteBatch)
        {
            camera = _camera;
            spriteBatch = _spriteBatch;
            tileTexture = Content.Load<Texture2D>("Tiles/Tile");
            sawBladeTexture = Content.Load<Texture2D>("Hazards/SawBlade");
            turretRightTexture = Content.Load<Texture2D>("Hazards/TurretRight");
            turretLeftTexture = Content.Load<Texture2D>("Hazards/TurretLeft");
            turretBulletTexture = Content.Load<Texture2D>("Hazards/TurretShot");
            shockWaveTexture = Content.Load<Texture2D>("Hazards/Shockwave2");
            doorTexture = Content.Load<Texture2D>("Door");
            keyTexture = Content.Load<Texture2D>("Nyckel");

            tileCenter = new Vector2(tileTexture.Width / 2, tileTexture.Height / 2);
            sawBladeCenter = new Vector2(sawBladeTexture.Width / 2, sawBladeTexture.Height / 2);
            turretCenter = new Vector2(turretRightTexture.Width / 2, turretRightTexture.Height / 2);
            bulletCenter = new Vector2(turretBulletTexture.Width / 2, turretBulletTexture.Height / 2);
            doorCenter = new Vector2(doorTexture.Width / 2, doorTexture.Height / 2);
            keyCenter = new Vector2(keyTexture.Width / 2, keyTexture.Height / 2);
        }
        public void DrawTile(Tile tile)
        {
            scale = camera.Scale(tile.Size, tileTexture.Width, tileTexture.Height);
            Vector2 pos = tile.Position;
            spriteBatch.Draw(tileTexture, camera.convertToVisualCoords(pos), null, Color.White, 0, tileCenter, scale, SpriteEffects.None, 1f);
        }

        public void DrawSaw(SawBlade sawBlade)
        {
            scale = camera.Scale(sawBlade.Size, sawBladeTexture.Width, sawBladeTexture.Height);
            spriteBatch.Draw(sawBladeTexture, camera.convertToVisualCoords(sawBlade.Position), null, Color.White, sawBlade.Rotation, sawBladeCenter, scale, SpriteEffects.None, 1f); ;
        }

        public void DrawTurret(Turret turret, float elapsedTime)
        {

            if (turret.TurnedRight)
            {
                spriteBatch.Draw(turretRightTexture, camera.convertToVisualCoords(turret.Position), null, Color.White, 0, turretCenter, scale, SpriteEffects.None, 1f);
            }
            else
            {
                spriteBatch.Draw(turretLeftTexture, camera.convertToVisualCoords(turret.Position), null, Color.White, 0, turretCenter, scale, SpriteEffects.None, 1f);
            }
            foreach (TurretBullet bullet in turret.bulletList)
            {
                DrawBullet(bullet, elapsedTime);
            }
            if (shockWaveCount < turret.BulletsHitLocations.Count)
            {
                shockWaveCount = turret.BulletsHitLocations.Count;
                particles.Add(new BulletShockWave(shockWaveTexture, camera, new Vector2(0.1f, 0.1f), turret.BulletsHitLocations[shockWaveCount-1]));
            }
            foreach(BulletShockWave shockWave in particles)
            {
                shockWave.Draw(elapsedTime, spriteBatch);
            }
        }

        public void DrawBullet(TurretBullet bullet, float elapsedTime)
        {
            spriteBatch.Draw(turretBulletTexture, camera.convertToVisualCoords(bullet.Position), null, Color.White, 0, turretCenter, scale, SpriteEffects.None, 1f);
            foreach (BulletShockWave particle in particles)
            {
                particle.Draw(elapsedTime, spriteBatch);
            }
        }

        public void DrawDoor(Door door)
        {
            scale = camera.Scale(door.Size, doorTexture.Width, doorTexture.Height);
            spriteBatch.Draw(doorTexture, camera.convertToVisualCoords(door.Position), null, Color.White, 0, doorCenter, scale, SpriteEffects.None, 1f);
        }

        public void DrawKey(Key key)
        {
            scale = camera.Scale(key.Size, keyTexture.Width, keyTexture.Height);
            spriteBatch.Draw(keyTexture, camera.convertToVisualCoords(key.Position), null, Color.White, 0, doorCenter, scale, SpriteEffects.None, 1f);

        }
    }
}
