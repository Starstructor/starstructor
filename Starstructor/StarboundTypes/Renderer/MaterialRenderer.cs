using Starstructor.Data;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;

namespace Starstructor.StarboundTypes.Renderer
{
    /// <summary>
    /// A class used to render materials.
    /// </summary>
    public class MaterialRenderer
    {
        private RenderTemplate m_renderTemplate;
        private RenderParameters m_renderParameters;
        private Bitmap m_image;

        /// <summary>
        /// Expected constructor.
        /// </summary>
        /// <param name="baseDirectory">The directory containing the material file.</param>
        /// <param name="template">The filename of the template file.</param>
        /// <param name="parameters">The render parameters determined by the material.</param>
        public MaterialRenderer(string baseDirectory, string template, RenderParameters parameters)
        {
            // Parse template file
            string templateFile = EditorHelpers.FindAsset(baseDirectory, template);
            m_renderTemplate = JsonParser.ParseJson<RenderTemplate>(templateFile);

            // Store parameters
            m_renderParameters = parameters;

            // Obtain base image file
            m_image = ImageManager.GetImage(EditorHelpers.FindAsset(baseDirectory, m_renderParameters.TextureFilename));
        }

        private Rectangle GetImageFrame()
        {
            // TODO this part is simply a workaround, it might not be "base" all the time.
            TextureInfo info = m_renderTemplate.getPiece("base") ?? m_renderTemplate.pieces.First().Value;
            return new Rectangle(info.texturePosition.x, info.texturePosition.y,
                info.textureSize.x, info.textureSize.y);
        }

        public Bitmap GetPreviewImage()
        {
            if (m_image == null) return null;
            Rectangle srcRect = GetImageFrame();
            return m_image.Clone(srcRect, m_image.PixelFormat);
        }

        public void Render(Graphics gfx, int x, int y, int gridFactor = Editor.DEFAULT_GRID_FACTOR,
            bool background = false, float opacity = 1.0f)
        {
            if (m_image == null) return;

            Rectangle srcRect = GetImageFrame();

            if (srcRect == null) return;

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
            gfx.DrawImage(m_image,
                dstRect,
                srcRect.X,
                srcRect.Y,
                srcRect.Width,
                srcRect.Height,
                GraphicsUnit.Pixel,
                attributes);
        }
    }
}
