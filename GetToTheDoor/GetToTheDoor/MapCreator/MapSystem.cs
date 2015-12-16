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
    class TileSystem
    {
        List<Tile> tiles = new List<Tile>();
        Key key;
        Door door;
        float tileSize = 0.5f;

        public TileSystem(ContentManager content, Camera camera)
        {
            key = new Key(content, camera, new Vector2(tileSize/2, 3.5f), tileSize);
            door = new Door(content, camera, new Vector2(8f, 5.5f), tileSize);
            for (int i = 0; i < 10; i++)
            {
                tiles.Add(new Tile(content, camera, new Vector2(tileSize/2 + 0.5f*i, 8.5f), tileSize));
            }
            for (int i = 10; i < 14; i++)
            {
                tiles.Add(new Tile(content, camera, new Vector2(tileSize / 2 + 0.5f * i, 7f), tileSize));
            }
            for (int i = 0; i < 5; i++)
            {
                tiles.Add(new Tile(content, camera, new Vector2(tileSize / 2 + 0.5f * i, 4f+0.5f*i), tileSize));
            }

            for (int i = 0; i < 5; i++)
            {
                tiles.Add(new Tile(content, camera, new Vector2(8f, 6f + 0.5f * i), tileSize));
            }
        }

        public void drawTiles(SpriteBatch spriteBatch)
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

        public bool playerWantsToGoThroughDoor(MainCharacterModel charModel)
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
