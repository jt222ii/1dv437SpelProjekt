using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GetToTheDoor.View
{
    class Camera
    {
        private int windowSizeX;
        private int windowSizeY;
        public Camera(Viewport port)
        {
            windowSizeX = port.Width;
            windowSizeY = port.Height;
        }
        public Vector2 convertToVisualCoords(Vector2 coords)
        {
            float visualX = coords.X * (windowSizeX/16);
            float visualY = coords.Y * (windowSizeY/9);
            return new Vector2(visualX, visualY);
        }
        public Vector2 convertToLogicalCoords(Vector2 visualCoords)
        {
            float logicalX = (visualCoords.X)*16 / windowSizeX;
            float logicalY = (visualCoords.Y)*9 / windowSizeY;
            return new Vector2(logicalX, logicalY);
        }

        public Vector2 Scale(Vector2 size, float texturewidth, float textureheight)
        {
            float scaleX = (size.X/16) * windowSizeX / texturewidth;
            float scaleY = (size.Y / 9) * windowSizeY / textureheight;
            return new Vector2(scaleX, scaleY);
        }


        public Vector2 getSizeOfField()
        {
            return new Vector2(windowSizeX, windowSizeY);
        }
    }
}
