using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using Newtonsoft.Json;

namespace DungeonEditor
{
    public class ImageLoader
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
                        m_image = Bitmap.FromFile(m_imageFileName) as Bitmap;
                    else if (m_imageFileName != null)
                        System.Windows.Forms.MessageBox.Show("Not found: " + m_imageFileName);
                }
                return m_image;
            }
        }
    }
}
