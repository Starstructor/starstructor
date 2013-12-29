/*Starstructor, the Starbound Toolet
Copyright (C) 2013-2014  Chris Stamford
Contact: cstamford@gmail.com

This program is free software; you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation; either version 2 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License along
with this program; if not, write to the Free Software Foundation, Inc.,
51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA.
*/

using System.Drawing;
using System.IO;

namespace DungeonEditor
{
    public static class EditorHelpers
    {
        public static string ParsePath(string activeDirectory, string path)
        {
            // This is a file name without any directories
            if (Path.GetFileName(path) == path)
            {
                return Path.Combine(activeDirectory, path);
            }

            return Editor.Settings.AssetDirPath + path;
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
            var gfxBrush = new SolidBrush(Color.FromArgb(
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
            using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                return Image.FromStream(stream);
            }
        }
    }
}