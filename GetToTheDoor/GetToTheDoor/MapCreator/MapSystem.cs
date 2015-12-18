using GetToTheDoor.MapCreator;
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
        ContentManager content;
        Camera camera;
        List<Tile> tiles = new List<Tile>();
        Key key;
        Door door;
        float tileSize = 1f;

        List<char[,]> levels = new List<char[,]>();

        public TileSystem(ContentManager _content, Camera _camera, float gameScale)
        {
            tileSize *= gameScale;
            content = _content;
            camera = _camera;
            LevelCreator levelCreator = new LevelCreator();
            levels = levelCreator.getLevels();
            loadLevel(0);
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
                
                }
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
