using System;
using System.Drawing;
using System.IO;

namespace DungeonEditor
{
    public class ImageLoader : IDisposable
    {
        private Bitmap m_image;
        private readonly string m_imageFileName;

        public ImageLoader(string fileName)
        {
            m_imageFileName = fileName;
        }

        public Bitmap ImageFile
        {
            get
            {
                if (m_image != null) 
                    return m_image;

                if (m_imageFileName != null && File.Exists(m_imageFileName))
                {
                    using (Bitmap loadBmp = new Bitmap(m_imageFileName))
                    {
                        m_image = new Bitmap(loadBmp.Width, loadBmp.Height, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);

                        using (Graphics pGraphics = Graphics.FromImage(m_image))
                        {
                            Rectangle rct = new Rectangle(0, 0, loadBmp.Width, loadBmp.Height);
                            pGraphics.DrawImage(loadBmp, rct, rct, GraphicsUnit.Pixel);
                            pGraphics.Dispose();
                        }

                        Editor.Editor.Log.Write("Loaded image " + m_imageFileName);
                    }
                }

                else if (m_imageFileName != null)
                {
                    Editor.Editor.Log.Write("Image not found " + m_imageFileName);
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
