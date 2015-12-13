﻿using GetToTheDoor.Model;
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
    class TileSystem
    {
        List<Tile> tiles = new List<Tile>();
        float tileSize = 0.5f;

        public TileSystem(ContentManager content, Camera camera)
        {
            for (int i = 0; i < 10; i++)
            {
                tiles.Add(new Tile(content, camera, new Vector2(tileSize/2 + 0.5f*i, 8.5f), tileSize));
            }
            for (int i = 10; i < 15; i++)
            {
                tiles.Add(new Tile(content, camera, new Vector2(tileSize / 2 + 0.5f * i, 7f), tileSize));
            }
            for (int i = 0; i < 5; i++)
            {
                tiles.Add(new Tile(content, camera, new Vector2(tileSize / 2 + 0.5f * i, 4f+0.5f*i), tileSize));
            }
        }

        public void drawTiles(SpriteBatch spriteBatch)
        {
            foreach(Tile tile in tiles)
            {
                tile.Draw(spriteBatch);
            }
        }

        public List<Tile> getTiles
        {
            get
            {
                return tiles;
            }
        }

        public bool lookForCollision(MainCharacterModel charModel)
        {
            foreach(Tile tile in tiles)
            {
                if(tile.landsOnTile(charModel))
                {
                    return true;
                }
            }
            return false;
        }
        public bool lookForCollisionHead(MainCharacterModel charModel)
        {
            foreach (Tile tile in tiles)
            {
                if (tile.hitsHeadOnTile(charModel))
                {
                    return true;
                }
            }
            return false;
        }
        public Tile lookForCollisionX(MainCharacterModel charModel)
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
