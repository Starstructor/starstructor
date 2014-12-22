using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Starstructor.Data
{
    class ImageManager
    {
        private static readonly Dictionary<string, Bitmap> m_imageMap = new Dictionary<string, Bitmap>();

        /// <summary>
        /// Obtains the image corresponding to the given file path. If the image has been loaded
        /// before, retrieves it from a cache.
        /// </summary>
        /// <param name="path">Full path to the image file.</param>
        /// <returns>Bitmap representation of the image.</returns>
        public static Bitmap GetImage(string path)
        {
            if (path == null) return null;

            Bitmap result;
            if (!m_imageMap.TryGetValue(path, out result))
            {
                result = new Bitmap(path);
                m_imageMap.Add(path, result);
            }
            return result;
        }
    }
}
