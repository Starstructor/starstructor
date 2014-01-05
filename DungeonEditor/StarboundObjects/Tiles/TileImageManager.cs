using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using DungeonEditor.EditorTypes;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace DungeonEditor.StarboundObjects.Tiles
{
    [ReadOnly(true)]
    public class TileImageManager
    {
        private ImageLoader m_image;
        private string m_fileName;

        // Internal frames definition
        public static Vec2I FRAME_SIZE = new Vec2I(16,24);    // size of each frame
        public static Vec2I TILE_BASE = new Vec2I(4,12);      // offset to center of tile
        public static Vec2I TILE_SIZE = new Vec2I(8,8);       // size of a tile

        public TileImageManager(string name, string framesDir)
        {
            // Get the image file
            m_fileName = Editor.EditorHelpers.FindAsset(framesDir, name);
            if ( m_fileName == null )
            {
                System.Windows.Forms.MessageBox.Show("Failed asset acquisition of " + framesDir + " " + name);
            }
            m_image = new ImageLoader(m_fileName);
        }

        public Rectangle? GetImageFrame(int variant = 0, int colour = 0)
        {
            if (m_image.ImageFile == null)
                return null;

            return new Rectangle(
                FRAME_SIZE.x * variant + TILE_BASE.x,
                FRAME_SIZE.y * colour + TILE_BASE.y,
                TILE_SIZE.x,
                TILE_SIZE.y);
        }

        public Bitmap GetImageFrameBitmap(int variant = 0, int colour = 0)
        {
            Rectangle? frameRect = GetImageFrame(variant, colour);

            if (frameRect == null)
                return null;

            return m_image.ImageFile.Clone(frameRect.Value, m_image.ImageFile.PixelFormat);
        }

        public bool DrawTile(Graphics gfx, int x, int y, int gridFactor = Editor.Editor.DEFAULT_GRID_FACTOR, 
            bool background = false, float opacity = 1.0f)
        {
            if (m_image == null || m_image.ImageFile == null)
            {
                System.Windows.Forms.MessageBox.Show("Failed tile frame drawing for " + m_fileName);
                return false;
            }

            Rectangle? srcRect = GetImageFrame();
            if (srcRect == null)
            {
                System.Windows.Forms.MessageBox.Show("Src rect fail");
                return false;
            }

            Rectangle dstRect = new Rectangle(
                x * gridFactor,
                y * gridFactor,
                gridFactor,
                gridFactor);


            float[][] floatColourMatrx =
            {
                new float[] {1, 0, 0, 0, 0},
                new float[] {0, 1, 0, 0, 0},
                new float[] {0, 0, 1, 0, 0},
                new float[] {0, 0, 0, 1, 0},
                new[] {-0.25f, -0.25f, -0.25f, 1, 1}
            };

            var colourMatrix = background ? new ColorMatrix(floatColourMatrx) : new ColorMatrix();
            colourMatrix.Matrix33 = opacity;

            var attributes = new ImageAttributes();
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
    }
}
