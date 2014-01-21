/*Starstructor, the Starbound Toolet 
Copyright (C) 2013-2014 Chris Stamford
Contact: cstamford@gmail.com

Source file contributers:
 Chris Stamford     contact: cstamford@gmail.com
 Adam Heinermann    contact: aheinerm@gmail.com

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

namespace Starstructor.Editor
{
    public static class EditorHelpers
    {
        /** Searches known Starbound paths for an asset. It searches for fileName in the following order:
         *          activeDirectory -> mods -> assets
         *  A null return value indicates that the file doesn't exist under any path.
         */
        public static string FindAsset(string activeDirectory, string fileName)
        {
            // This is a workaround for a bug in Path.Combine
            while (fileName.Length > 0 &&
                (fileName[0] == Path.DirectorySeparatorChar || fileName[0] == Path.AltDirectorySeparatorChar))
            {
                fileName = fileName.Substring(1);
            }

            // Get the initial asset path
            string assetPath = Path.Combine(activeDirectory, fileName);

            if (!File.Exists(assetPath))
            {
                // Try the mods directory
                assetPath = Path.Combine(Editor.Settings.ModsDirPath, fileName);

                if (!File.Exists(assetPath))
                {
                    assetPath = Path.Combine(Editor.Settings.AssetDirPath, fileName);

                    if (!File.Exists(assetPath))
                    {
                        //MessageBox.Show("Failed to locate " + imagePath + "\n" + baseDir + " | " + m_fileName);
                        return null;
                    }
                }
            }

            return assetPath;
        }
        public static string ParsePath(string activeDirectory, string path)
        {
            // This is a file name without any directories
            if (Path.GetFileName(path) == path)
                return Path.Combine(activeDirectory, path);

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
            else if (type == "lava" || type == "water" || type == "tar" || type == "acid" || type == "tentaclejuice" || type == "brush" )
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