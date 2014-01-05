using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.IO;
using System.Drawing;
using DungeonEditor.EditorTypes;
using System.Windows.Forms;
using DungeonEditor.EditorObjects;
using System.Drawing.Imaging;

namespace DungeonEditor.StarboundObjects.Objects
{
    [ReadOnly(true)]
    public class ObjectImageManager
    {
        private ImageLoader m_image;
        private ObjectFrames m_frames;
        private string m_parseName;
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

        public ObjectImageManager(string name, string framesDir)
        {
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
            string imagePath = Editor.EditorHelpers.FindAsset(framesDir, m_fileName);
            if ( imagePath == null )
            {
                MessageBox.Show("Asset not found.\n" + m_fileName + "\nIn active directory: " + framesDir);
            }
            m_image = imagePath != null ? new ImageLoader(imagePath) : null;

            // Get frames file
            string framePath = Editor.EditorHelpers.FindAsset(framesDir, Path.GetFileNameWithoutExtension(m_fileName) + ".frames");
            if ( framePath == null )
                framePath = Editor.EditorHelpers.FindAsset(framesDir, "default.frames");
            m_frames = framePath != null ? new JsonParser(framePath).ParseJson<ObjectFrames>() : null;
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
            if (framePos == null)   // key does not exist
                return null;

            return m_frames.GetFrameRectangle(framePos.Value);
        }

        public Bitmap GetImageFrameBitmap(string frame = "default", string colour = "default", string key = "default")
        {
            Rectangle? frameRect = GetImageFrame(frame, colour, key);

            if ( frameRect == null )
                return null;

            return m_image.ImageFile.Clone(frameRect.Value, m_image.ImageFile.PixelFormat);
        }

        public bool DrawObject(Graphics gfx, int x, int y, int originX, int originY, int sizeX, int sizeY, 
            int gridFactor = Editor.Editor.DEFAULT_GRID_FACTOR, float opacity = 1.0f)
        {
            if (m_image == null || m_image.ImageFile == null || m_frames == null)
                return false;

            Rectangle? srcRect = GetImageFrame();
            if ( srcRect == null )
                return false;
            
            Rectangle dstRect = new Rectangle(
                x*gridFactor + originX,
                y*gridFactor + originY,
                sizeX,
                sizeY);

            var colourMatrix = new ColorMatrix();
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
