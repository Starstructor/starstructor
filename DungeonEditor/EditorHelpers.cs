using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonEditor
{
    public static class EditorHelpers
    {
        public static string ParsePath(string activeDirectory, string path)
        {
            // This is a file name without any directories
            if(Path.GetFileName(path) == path)
            {
                return Path.Combine(activeDirectory, path);
            }
            else
            {
                return Editor.Settings.AssetDirPath + path;
            }
        }

        public static string GetExtensionFromBrushType(string type)
        {
            if (type == "back" || type == "front" || type == "surface" || type == "surfacebackground")
            {
                type = ".material";
            }
            else if (type == "object")
            {
                type = ".object";
            }
            else if (type == "npc")
            {
                type = ".npctype";
            }
            else if (type == "lava" || type == "water" || type == "tar" || type == "acid" || type == "tentaclejuice")
            {
                type = ".INTERNAL";
            }
            else
            {
                type = null;
            }

            return type;
        }

        public static Image GetGeneratedRectangle(int width, int height, byte r, byte g, byte b, byte a)
        {
            Image rect = new Bitmap(width, height);
            Graphics gfx = Graphics.FromImage(rect);
            SolidBrush gfxBrush = new SolidBrush(Color.FromArgb(
                a,
                r,
                g,
                b));

            gfx.FillRectangle(gfxBrush, new Rectangle(0, 0, 8, 8));
            gfxBrush.Dispose();
            gfx.Dispose();

            return rect;
        }

        public static Image LoadImageFromFile(string path)
        {
            using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                return Image.FromStream(stream);
            }
        }
    }
}
