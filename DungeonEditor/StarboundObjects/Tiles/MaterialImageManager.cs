using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Drawing;

namespace DungeonEditor.StarboundObjects.Tiles
{
    [ReadOnly(true)]
    public abstract class MaterialImageManager
    {
        abstract public Rectangle? GetImageFrame(int variant = 0, int colour = 0);

        abstract public Bitmap GetImageFrameBitmap(int variant = 0, int colour = 0);

        abstract public bool DrawTile(Graphics gfx, int x, int y, int gridFactor = Editor.Editor.DEFAULT_GRID_FACTOR,
            bool background = false, float opacity = 1.0f);
    }
}
