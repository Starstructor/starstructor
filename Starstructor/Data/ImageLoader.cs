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
using System.Drawing;
using System.IO;

namespace Starstructor.Data
{
    public class ImageLoader : IDisposable
    {
        private Bitmap m_image;
        private readonly string m_imageFileName;

        public ImageLoader(Image image)
        {
            m_image = (Bitmap) image;
        }

        public ImageLoader(string fileName)
        {
            m_imageFileName = fileName;
        }

        public Bitmap ImageFile
        {
            get
            {
                if (m_image != null) return m_image;

                if (m_imageFileName != null && File.Exists(m_imageFileName))
                {
                    using (Bitmap loadBmp = new Bitmap(m_imageFileName))
                    {
                        m_image = new Bitmap(loadBmp.Width, loadBmp.Height, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);

                        using (Graphics gfx = Graphics.FromImage(m_image))
                        {
                            Rectangle rct = new Rectangle(0, 0, loadBmp.Width, loadBmp.Height);
                            gfx.DrawImage(loadBmp, rct, rct, GraphicsUnit.Pixel);
                        }

                        Editor.Log.Write("Loaded image " + m_imageFileName);
                    }
                }

                else if (m_imageFileName != null)
                {
                    Editor.Log.Write("Image not found " + m_imageFileName);
                }

                return m_image;
            }
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
