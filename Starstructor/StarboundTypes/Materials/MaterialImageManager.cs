/*Starstructor, the Starbound Toolet 
Copyright (C) 2013-2014 Chris Stamford
Contact: cstamford@gmail.com

Source file contributers:
 Adam Heinermann    contact: aheinerm@gmail.com
 Chris Stamford     contact: cstamford@gmail.com

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

using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using Starstructor.EditorTypes;

namespace Starstructor.StarboundTypes.Materials
{
    [ReadOnly(true)]
    public class MaterialImageManager : IMaterialImageManager
    {
        private ImageLoader m_image;
        private readonly string m_fileName;

        // Internal frames definition
        public static Vec2I FRAME_SIZE = new Vec2I(16,24);    // size of each frame
        public static Vec2I TILE_BASE = new Vec2I(4,12);      // offset to center of tile
        public static Vec2I TILE_SIZE = new Vec2I(8,8);       // size of a tile

        public MaterialImageManager(string name, Image image)
        {
            m_fileName = name;
            m_image = new ImageLoader(image);
        }

        public MaterialImageManager(string name, string framesDir)
        {
            // Get the image file
            m_fileName = EditorHelpers.FindAsset(framesDir, name);

            if ( m_fileName == null )
                Editor.Log.Write("Failed asset acquisition of " + framesDir + " " + name);

            m_image = new ImageLoader(m_fileName);
        }

        public Rectangle? GetImageFrame(int variant = 0, int colour = 0)
        {
            if (m_image.ImageFile == null) return null;

            return new Rectangle(
                FRAME_SIZE.x * variant + TILE_BASE.x,
                FRAME_SIZE.y * colour + TILE_BASE.y,
                TILE_SIZE.x,
                TILE_SIZE.y);
        }

        public Bitmap GetImageFrameBitmap(int variant = 0, int colour = 0)
        {
            Rectangle? frameRect = GetImageFrame(variant, colour);
            return frameRect == null ? null : m_image.ImageFile.Clone(frameRect.Value, m_image.ImageFile.PixelFormat);
        }

        public bool DrawTile(Graphics gfx, int x, int y, int gridFactor = Editor.DEFAULT_GRID_FACTOR, 
            bool background = false, float opacity = 1.0f)
        {
            if (m_fileName.Contains(".internal"))
            {
                int a = 5 + 2;
            }

            if (m_image == null || m_image.ImageFile == null) return false;

            Rectangle? srcRect = GetImageFrame();

            if (srcRect == null) return false;

            Rectangle dstRect = new Rectangle(
                x * gridFactor,
                y * gridFactor,
                gridFactor,
                gridFactor);

            ColorMatrix colourMatrix = new ColorMatrix();
            colourMatrix.Matrix33 = opacity;

            if (background)
            {
                // Darken
                colourMatrix.Matrix40 = -0.3f;
                colourMatrix.Matrix41 = -0.3f;
                colourMatrix.Matrix42 = -0.3f;
            }

            ImageAttributes attributes = new ImageAttributes();
            attributes.SetColorMatrix(colourMatrix);

            // Fix this, scaling on colour map
            gfx.DrawImage(m_image.ImageFile,
                dstRect,
                srcRect.Value.X,
                srcRect.Value.Y,
                srcRect.Value.Width,
                srcRect.Value.Height,
                GraphicsUnit.Pixel,
                attributes);

            return true;
        }

        public void Dispose()
        {
            if (m_image == null) return;
            m_image.Dispose();
            m_image = null;
        }
    }
}
