using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;

namespace DungeonEditor
{
    class ImageLoader
    {
        private Image m_image = null;
        private string m_imageFileName;

        public ImageLoader(string fileName)
        {
            m_imageFileName = fileName;
        }

        public Image ImageFile
        {
            get
            {
                if (m_image == null )
                {
                    if ( m_imageFileName != null && File.Exists(m_imageFileName) )
                        m_image = Image.FromFile(m_imageFileName);
                }
                return m_image;
            }
        }
    }
}
