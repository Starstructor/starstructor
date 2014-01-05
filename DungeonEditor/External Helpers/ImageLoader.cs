using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using Newtonsoft.Json;

namespace DungeonEditor
{
    public class ImageLoader : IDisposable
    {
        private Bitmap m_image = null;
        private string m_imageFileName;

        public ImageLoader(string fileName)
        {
            m_imageFileName = fileName;
        }

        public Bitmap ImageFile
        {
            get
            {
                if (m_image == null )
                {
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
                        }
                    }
                    else if (m_imageFileName != null)
                        System.Windows.Forms.MessageBox.Show("Not found: " + m_imageFileName);
                }
                return m_image;
            }
        }

        public void Dispose()
        {
            if (m_image != null)
            {
                m_image.Dispose();
                m_image = null;
            }
        }
    }
}
