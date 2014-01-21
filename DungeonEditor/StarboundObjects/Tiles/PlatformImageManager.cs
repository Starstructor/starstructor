using System.ComponentModel;
using DungeonEditor.EditorTypes;
using System.Drawing;
using System.Drawing.Imaging;

namespace DungeonEditor.StarboundObjects.Tiles
{
    [ReadOnly(true)]
    public class PlatformImageManager : MaterialImageManager
    {
        private ImageLoader m_platformImage;
        private readonly string m_platformFileName;
        private readonly int m_platformVariants;

        private ImageLoader m_stairImage;
        private readonly string m_stairsFileName;
        private int m_stairVariants;

        // Internal frames definition
        public static Vec2I FRAME_SIZE = new Vec2I(8,8);    // size of each frame
        public static Vec2I TILE_BASE = new Vec2I(0,0);      // offset to center of tile
        public static Vec2I TILE_SIZE = new Vec2I(8,8);       // size of a tile

        public PlatformImageManager(string platformName, int platformVariants, string stairsName, int stairVariants, string framesDir)
        {
            // Get the image file
            m_platformImage = new ImageLoader(Editor.EditorHelpers.FindAsset(framesDir, platformName));
            m_platformFileName = platformName;
            m_platformVariants = platformVariants;

            m_stairImage = new ImageLoader(Editor.EditorHelpers.FindAsset(framesDir, stairsName));
            m_stairsFileName = stairsName;
            m_stairVariants = stairVariants;
        }

        public Rectangle? GetImageFrame(int variant = 1, int colour = 0)
        {
            if (m_platformImage.ImageFile == null)
                return null;

            return new Rectangle(
                FRAME_SIZE.x * variant * m_platformVariants + TILE_BASE.x,
                FRAME_SIZE.y * colour + TILE_BASE.y,
                TILE_SIZE.x,
                TILE_SIZE.y);
        }

        public Bitmap GetImageFrameBitmap(int variant = 1, int colour = 0)
        {
            Rectangle? frameRect = GetImageFrame(variant, colour);
            return frameRect == null ? null : m_platformImage.ImageFile.Clone(frameRect.Value, m_platformImage.ImageFile.PixelFormat);
        }

        public bool DrawTile(Graphics gfx, int x, int y, int gridFactor = Editor.Editor.DEFAULT_GRID_FACTOR, 
            bool background = false, float opacity = 1.0f)
        {
            if (m_platformImage == null || m_platformImage.ImageFile == null)
                return false;

            Rectangle? srcRect = GetImageFrame();
            if (srcRect == null)
                return false;

            Rectangle dstRect = new Rectangle(
                x * gridFactor,
                y * gridFactor,
                gridFactor,
                gridFactor);

            ColorMatrix colourMatrix = new ColorMatrix();
            colourMatrix.Matrix33 = opacity;

            ImageAttributes attributes = new ImageAttributes();
            attributes.SetColorMatrix(colourMatrix);

            // Fix this, scaling on colour map
            gfx.DrawImage(m_platformImage.ImageFile,
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
            if ( m_platformImage != null )
            {
                m_platformImage.Dispose();
                m_platformImage = null;
            }

            if ( m_stairImage != null )
            {
                m_stairImage.Dispose();
                m_stairImage = null;
            }
        }
    }
}
