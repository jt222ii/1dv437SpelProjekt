﻿using GetToTheDoor.MapCreator;
using GetToTheDoor.MapCreator.Hazards;
using GetToTheDoor.Model;
using GetToTheDoor.View;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GetToTheDoor
{
    class MapSystem
    {
        ContentManager content;
        Camera camera;
        List<Tile> tiles = new List<Tile>();
        List<Turret> turrets = new List<Turret>();
        List<SawBlade> sawBlades = new List<SawBlade>();
        Key key;
        Door door;
        float tileSize = 0.5f;
        Vector2 spawnPosition;

        List<char[,]> levels = new List<char[,]>();

        public MapSystem(ContentManager _content, Camera _camera, int selectedLevel)
        {
            content = _content;
            camera = _camera;
            LevelCreator levelCreator = new LevelCreator();
            levels = levelCreator.getLevels();
            loadLevel(selectedLevel);
        }
        public bool levelExists(int level)
        {
            if(level >= 0 && levels.Count > level)
            {
                return true;
            }
            return false;
        }

        public void loadLevel(int level)
        {
            for (int i = 0; i < levels[level].GetLength(1); i++)
            {
                for (int y = 0; y < levels[level].GetLength(0); y++)
                {                                   
                    if (levels[level][y, i] == '#')
                    {
                        tiles.Add(new Tile(content, camera, new Vector2(tileSize / 2 + tileSize * i, tileSize / 2 + tileSize * y), tileSize));
                    }
                    else if (levels[level][y, i] == 'D')
                    {
                        door = new Door(content, camera, new Vector2(tileSize / 2 + tileSize * i, tileSize / 2 + tileSize * y), tileSize);
                    }
                    else if (levels[level][y, i] == 'K')
                    {
                        key = new Key(content, camera, new Vector2(tileSize / 2 + tileSize * i, tileSize / 2 + tileSize * y), tileSize);
                    }
                    else if (levels[level][y, i] == '>')
                    {
                        turrets.Add(new Turret(content, camera, new Vector2(tileSize / 2 + tileSize * i, tileSize / 2 + tileSize * y), tileSize, true));
                    }
                    else if (levels[level][y, i] == '<')
                    {
                        turrets.Add(new Turret(content, camera, new Vector2(tileSize / 2 + tileSize * i, tileSize / 2 + tileSize * y), tileSize, false));
                    }
                    else if (levels[level][y, i] == '$')
                    {
                        spawnPosition = new Vector2(tileSize / 2 + tileSize * i, tileSize / 2 + tileSize * y);
                    }
                    else if (levels[level][y, i] == '*')
                    {
                        sawBlades.Add(new SawBlade(content, camera, new Vector2(tileSize / 2 + tileSize * i, tileSize / 2 + tileSize * y), tileSize));
                    }
                
                }
            }
        }
        public Vector2 getSpawnPoint
        {
            get
            {
                return spawnPosition;
            }
        }
        public void drawTiles(SpriteBatch spriteBatch, float elapsedTime)
        {
            if (key != null)
            {
                key.Draw(spriteBatch);
            }
            door.Draw(spriteBatch);
            foreach(Tile tile in tiles)
            {
                tile.Draw(spriteBatch);
            }
            foreach(Turret turret in turrets)
            {
                turret.Draw(spriteBatch, elapsedTime);
            }
            foreach (SawBlade sawBlade in sawBlades)
            {
                sawBlade.Draw(spriteBatch);
            }

        }

        public void UpdateHazards(float time, MainCharacterModel charModel)
        {
            foreach (Turret turret in turrets)
            {
                turret.Update(time, charModel);
            }
            foreach (SawBlade sawBlade in sawBlades)
            {
                sawBlade.Update(time, tiles, charModel);
            }
        }
            

        public bool playerGetsTheKey(MainCharacterModel charModel)
        {
            if (key != null)
            {
                if (key.collides(charModel))
                {
                    key = null;
                    return true;
                }
            }
            return false;
        }

        public bool playerUnlocksDoor(MainCharacterModel charModel)
        {
            return door.collidesAndUnlocks(charModel);
        }

        public Tile landsOnTile(MainCharacterModel charModel)
        {
            foreach(Tile tile in tiles)
            {
                if(tile.landsOnTile(charModel))
                {
                    return tile;
                }
            }
            return null;
        }
        public Tile hitsHeadOnTile(MainCharacterModel charModel)
        {
            foreach (Tile tile in tiles)
            {
                if (tile.hitsHeadOnTile(charModel))
                {
                    return tile;
                }
            }
            return null;
        }
        public Tile hitsTileOnX(MainCharacterModel charModel)
        {
            foreach (Tile tile in tiles)
            {
                if (tile.collisionX(charModel))
                {
                    return tile;
                }
            }
            return null;
        }

    }
}
