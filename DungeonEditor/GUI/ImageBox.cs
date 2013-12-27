using DungeonEditor.EditorObjects;
using DungeonEditor.StarboundObjects;
using DungeonEditor.StarboundObjects.Objects;
using DungeonEditor.StarboundObjects.Tiles;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace DungeonEditor.GUI
{
    public class ImageBox : UserControl
    {
        // Owner
        public MainWindow m_parent;

        // The images
        private Image m_image;

        // The currently selected brush and its asset
        private EditorBrush m_selectedBrush;
        private StarboundAsset m_selectedAsset;

        // The location the mouse was scrolled at
        private Point m_mouseScrollLocation;

        // Where the mouse was clicked
        private float m_clickStartX = 0.0f;
        private float m_clickStartY = 0.0f;

        // The current image offset
        private float m_imageX = 0.0f;
        private float m_imageY = 0.0f;

        // The current mouse location in world units (not scaled for grid factor)
        private float m_mouseInWorldX = 0.0f;
        private float m_mouseInWorldY = 0.0f;

        // Mouse position in grid space
        private int m_mouseGridX = 0;
        private int m_mouseGridY = 0;

        // Last mouse grid location
        private int m_lastMouseGridX = 0;
        private int m_lastMouseGridY = 0;

        // The size of grid in the world
        private int m_gridFactor;

        // Mouse clicked flags
        private bool m_mouseLeftPressed = false;
        private bool m_mouseRightPressed = false;
        private bool m_mouseMiddlePressed = false;

        // Zoom factor
        private float m_zoomFactor = 1.0f;

        public ImageBox()
        {
            // Set up double buffering and make this control selectable
            this.SetStyle(ControlStyles.UserPaint | 
                ControlStyles.AllPaintingInWmPaint | 
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.Selectable, true);

            SetSelectedBrush(null);
        }

        public Image GetImage()
        {
            return m_image;
        }

        public void SetImage(Image image, int gridFactor)
        {
            SetImage(image, true, true, gridFactor);
        }

        public void SetImage(Image image, bool resetZoom, bool resetCamera, int gridFactor)
        {
            m_gridFactor = gridFactor;
            m_image = image;

            if (m_image == null)
            {
                this.Invalidate();
                return;
            }

            // Just set the image DPI to match the image box DPI
            // To much hassle to convert between DPIs otherwise
            ((Bitmap)m_image).SetResolution(96, 96);


            if (resetZoom)
            {
                // Scale the image so it fits the viewport
                // Use the lowest scale factor - so one side doesn't overflow
                m_zoomFactor = Math.Min(
                    (float)(this.Height / (float)m_image.Height), 
                    (float)this.Width / (float)m_image.Width);

                m_parent.UpdateBottomBar(m_zoomFactor);
            }

            if (resetCamera)
            {
                // Enter code to centre image
                m_imageX = 0;
                m_imageY = 0;
            }

            this.Invalidate();
        }

        public void SetSelectedBrush(EditorBrush brush)
        {
            StarboundAsset asset = null;

            if (brush != null && brush.NeedsFrontAsset && brush.FrontAsset != null)
            {
                asset = brush.FrontAsset;
            }
            else if (brush != null && brush.NeedsBackAsset && brush.BackAsset != null)
            {
                asset = brush.BackAsset;
            }
            else
            {
                asset = new StarboundTile();
                asset.AssetName = "gridAsset.INTERNAL";
                asset.Image = EditorHelpers.GetGeneratedRectangle(8, 8, 255, 255, 255, 128);
            }

            m_selectedBrush = brush;
            m_selectedAsset = asset;

            this.Invalidate();
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            if (m_image == null)
                return;

            e.Graphics.PixelOffsetMode = PixelOffsetMode.Half;
            e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;

            // Identity matrix
            Matrix trans = new Matrix();

            // Uniform scale by zoom factor
            trans.Scale(m_zoomFactor, m_zoomFactor, MatrixOrder.Append);

            // Translate to the correct image location
            trans.Translate(m_imageX, m_imageY, MatrixOrder.Prepend);

            // Set the graphics transformation matrix 
            e.Graphics.Transform = trans;

            // Draw the image in the world
            e.Graphics.DrawImage(m_image, 0, 0, m_image.Width, m_image.Height);
            
            // Draw border
            if (m_gridFactor > 1)
            {
                ControlPaint.DrawBorder(
                    e.Graphics, 
                    new Rectangle(
                        0,
                        0,
                        (int)m_image.Width,
                        (int)m_image.Height),
                    SystemColors.ControlDarkDark,
                    ButtonBorderStyle.Dashed);
            }

            // Only proceed if the mouse is in bounds, and there is a selected asset
            // If so, draw the preview image of the currently selected brush
            if (m_selectedAsset != null && m_selectedAsset.Image != null && 
                m_mouseGridX != -1 && m_mouseGridY != -1)
            {  
                if (m_selectedAsset is StarboundObject)
                {
                    ObjectOrientation orientation = ((StarboundObject)m_selectedAsset).GetCorrectOrientation(m_parent.SelectedMap, m_mouseGridX, m_mouseGridY);

                    Renderer.DrawObject(
                        (StarboundObject)m_selectedAsset, 
                        (int)m_mouseGridX, 
                        (int)m_mouseGridY, 
                        orientation,
                        m_selectedBrush.Direction,
                        m_gridFactor, 
                        e.Graphics,
                        0.5f);
                }
                else if (m_selectedAsset is StarboundTile)
                {
                    Renderer.DrawForegroundTile(
                        (StarboundTile)m_selectedAsset, 
                        (int)m_mouseGridX, 
                        (int)m_mouseGridY, 
                        m_gridFactor, 
                        e.Graphics,
                        0.5f);
                }
                else
                {
                    e.Graphics.DrawImage(m_selectedAsset.Image, m_mouseGridX * 8, m_mouseGridY * 8, 8, 8);
                }
            } 
        }

        protected override void OnMouseMove(MouseEventArgs e)
        { 
            if (m_image == null)
                return;

            UpdateMouseLocation(e.X, e.Y);

            // Navigate by holding middle mouse or right + left mouse
            if (m_mouseMiddlePressed || (m_mouseLeftPressed && m_mouseRightPressed))
            {
                Point mousePosNow = e.Location;

                // The distance the mouse has been moved
                int deltaX =    mousePosNow.X - m_mouseScrollLocation.X;
                int deltaY =    mousePosNow.Y - m_mouseScrollLocation.Y;

                // Reposition the image by how much the mouse has moved
                // Use initial click location so the image doesn't warp
                m_imageX =      (deltaX / m_zoomFactor) + m_clickStartX;
                m_imageY =      (deltaY / m_zoomFactor) + m_clickStartY;

                this.Invalidate();
            }
            else if (m_mouseLeftPressed && !m_mouseRightPressed)
            {
                m_parent.OnCanvasLeftClick(m_mouseGridX, m_mouseGridY, m_lastMouseGridX, m_lastMouseGridY);
            }

            if (m_lastMouseGridX != m_mouseGridX || m_lastMouseGridY != m_mouseGridY)
            {
                m_lastMouseGridX = m_mouseGridX;
                m_lastMouseGridY = m_mouseGridY;

                m_parent.UpdateBottomBar(m_mouseGridX, m_mouseGridY);

                // Only force a repaint if the selection has moved to another grid
                this.Invalidate();
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            this.Focus();

            if (m_image == null)
                return;

            UpdateMouseLocation(e.X, e.Y);

            if (e.Button == MouseButtons.Left)
            {
                m_mouseLeftPressed = true;
            }
            else if (e.Button == MouseButtons.Right)
            {
                m_mouseRightPressed = true;
            }
            else if (e.Button == MouseButtons.Middle)
            {
                m_mouseMiddlePressed = true;
            }

            if (m_mouseLeftPressed || m_mouseRightPressed || m_mouseMiddlePressed)
            {
                m_mouseScrollLocation = e.Location;
                m_clickStartX = m_imageX;
                m_clickStartY = m_imageY;
            }
            
            if (m_mouseLeftPressed && !m_mouseRightPressed)
            {
                m_parent.OnCanvasLeftClick(m_mouseGridX, m_mouseGridY, -1, -1);
            }

            if (m_mouseRightPressed && !m_mouseLeftPressed)
            {
                m_parent.OnCanvasRightClick(m_mouseGridX, m_mouseGridY, -1, -1);
            }

            this.Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                m_mouseLeftPressed = false;
            }
            else if (e.Button == MouseButtons.Right)
            {
                m_mouseRightPressed = false;
            }
            else if (e.Button == MouseButtons.Middle)
            {
                m_mouseMiddlePressed = false;
            }
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            float oldZoomFactor = m_zoomFactor;

            if (e.Delta > 0)
            {
                m_zoomFactor = Math.Min(m_zoomFactor * 1.25f, 200.0f);
            }

            else if (e.Delta < 0)
            {
                m_zoomFactor = Math.Max(m_zoomFactor / 1.25f, 0.25f);
            }

            if (oldZoomFactor == m_zoomFactor)
                return;

            // The mouse location in screen space
            float mouseX =      e.Location.X;
            float mouseY =      e.Location.Y;

            // The image location - based on the old zoom factor
            float oldImageX =   mouseX / oldZoomFactor;
            float oldImageY =   mouseY / oldZoomFactor;

            // The image location with the new zoom factor
            float newImageX =   mouseX / m_zoomFactor; 
            float newImageY =   mouseY / m_zoomFactor;

            // Move the image so the view is still on the same spot
            m_imageX =          newImageX - oldImageX + m_imageX;
            m_imageY =          newImageY - oldImageY + m_imageY;

            m_parent.UpdateBottomBar(m_zoomFactor);

            this.Invalidate();
        }

        private void UpdateMouseLocation(int dx, int dy)
        {
            m_mouseInWorldX = dx - (m_imageX * m_zoomFactor);
            m_mouseInWorldX /= m_zoomFactor;
            m_mouseInWorldY = dy - (m_imageY * m_zoomFactor);
            m_mouseInWorldY /= m_zoomFactor;

            if (m_mouseInWorldX < 0 || m_mouseInWorldX > m_image.Width)
            {
                m_mouseGridX = -1;
            }
            else
            {
                m_mouseGridX = (int)Math.Floor(m_mouseInWorldX / m_gridFactor);
            }

            if (m_mouseInWorldY < 0 || m_mouseInWorldY > m_image.Height)
            {
                m_mouseGridY = -1;
            }
            else
            {
                m_mouseGridY = (int)Math.Floor(m_mouseInWorldY / m_gridFactor);
            }
        }
    }
}
