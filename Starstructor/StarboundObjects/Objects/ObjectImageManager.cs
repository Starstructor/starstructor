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

using System;
using System.ComponentModel;
using System.IO;
using System.Drawing;
using Starstructor.EditorTypes;
using System.Drawing.Imaging;

namespace Starstructor.StarboundObjects.Objects
{
    [ReadOnly(true)]
    public class ObjectImageManager : IDisposable
    {
        private ImageLoader m_image;
        private readonly ObjectFrames m_frames;
        private readonly string m_parseName;
        private readonly bool m_flipped;
        private string m_fileName;

        public ObjectFrames Frames 
        {
            get
            {
                return m_frames;
            }
        }

        public ImageLoader Loader
        {
            get
            {
                return m_image;
            }
        }

        public ObjectImageManager(string name, string framesDir, bool flipped)
        {
            m_flipped = flipped;
            int idx = name.IndexOf(':');

            // Get the file name (ex: "stuff.png")
            m_fileName = name;

            if (idx != -1)
                m_fileName = name.Substring(0, idx);

            // Get the parse name (ex: "<color>.<frame>", there is also <key>)
            m_parseName = "";

            if (idx != -1)
                m_parseName = name.Substring(idx+1);

            // Get the image file
            string imagePath = EditorHelpers.FindAsset(framesDir, m_fileName);

            if ( imagePath == null )
                Editor.Log.Write("Asset " + m_fileName + " not found in active directory: " + framesDir);

            m_image = imagePath != null ? new ImageLoader(imagePath) : null;

            // Get frames file
            string framePath = EditorHelpers.FindAsset(framesDir, Path.GetFileNameWithoutExtension(m_fileName) + ".frames") ??
                               EditorHelpers.FindAsset(framesDir, "default.frames");

            m_frames = framePath != null ? JsonParser.ParseJson<ObjectFrames>(framePath) : null;
        }

        public string GetFrameKey(string frame = "default", string colour = "default", string key = "default")
        {
            string result = m_parseName;
            result = result.Replace("<frame>", frame);
            result = result.Replace("<color>", colour);
            result = result.Replace("<key>", key);
            return result;
        }

        public Rectangle? GetImageFrame(string frame = "default", string colour = "default", string key = "default")
        {
            if (m_image.ImageFile == null)
                return null;

            string frameKey = GetFrameKey(frame, colour, key);

            Vec2I? framePos = m_frames.GetPositionFromKey(frameKey);

            // key does not exist
            if (framePos == null) 
                return null;

            return m_frames.GetFrameRectangle(framePos.Value);
        }

        public Bitmap GetImageFrameBitmap(string frame = "default", string colour = "default", string key = "default")
        {
            Rectangle? frameRect = GetImageFrame(frame, colour, key);

            if ( frameRect == null )
                return null;

            Bitmap result = m_image.ImageFile.Clone(frameRect.Value, m_image.ImageFile.PixelFormat);
            result.RotateFlip(m_flipped ? RotateFlipType.RotateNoneFlipX : RotateFlipType.RotateNoneFlipNone);
            return result;
        }

        public bool DrawObject(Graphics gfx, int x, int y, int originX, int originY, int sizeX, int sizeY, 
            int gridFactor = Editor.DEFAULT_GRID_FACTOR, float opacity = 1.0f)
        {
            if (m_image == null || m_image.ImageFile == null || m_frames == null)
                return false;

            /*Rectangle? srcRect = GetImageFrame();
            if ( srcRect == null )
                return false;*/

            Image srcImage = GetImageFrameBitmap();
            if (srcImage == null)
                return false;
            
            Rectangle dstRect = new Rectangle(
                x*gridFactor + originX,
                y*gridFactor + originY,
                sizeX,
                sizeY);

            ColorMatrix colourMatrix = new ColorMatrix();
            colourMatrix.Matrix33 = opacity;

            ImageAttributes attributes = new ImageAttributes();
            attributes.SetColorMatrix(colourMatrix);
            
            // Fix this, scaling on colour map
            gfx.DrawImage(srcImage, 
                dstRect, 
                0,
                0,
                srcImage.Width,
                srcImage.Height,
                GraphicsUnit.Pixel, 
                attributes);
            
            return true;
        }

        public void Dispose()
        {
            if (m_image == null) 
                return;

            m_image.Dispose();
            m_image = null;
        }
    }
}
