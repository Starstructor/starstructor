using DungeonEditor.EditorObjects;
using DungeonEditor.StarboundObjects.Objects;
using DungeonEditor.StarboundObjects.Tiles;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonEditor
{
    // Handles rendering various parts of the Starbound world
    // to the provided graphics context.
    public class Renderer
    {
        public static bool DrawObject(StarboundObject obj, int x, int y, ObjectOrientation orientation, ObjectDirection direction, Graphics gfx)
        {
            return DrawObject(obj, x, y, orientation, direction, Editor.DEFAULT_GRID_FACTOR, gfx);
        }


        public static bool DrawObject(StarboundObject obj, int x, int y, ObjectOrientation orientation, ObjectDirection direction, int gridFactor, Graphics gfx)
        {
            return DrawObject(obj, x, y, orientation, direction, gridFactor, gfx, 1.0f);
        }

        public static bool DrawObject(StarboundObject obj, int x, int y, ObjectOrientation orientation, ObjectDirection direction, int gridFactor, Graphics gfx, float opacity)
        {
            if (obj.Image == null)
                return false;

            Image objImage = orientation.RightImage;

            if (direction == ObjectDirection.DIRECTION_LEFT)
            {
                objImage = orientation.LeftImage;
            }

            int sizeX = orientation.GetWidth(direction, gridFactor);
            int sizeY = orientation.GetHeight(direction, gridFactor);
            int originX = orientation.GetOriginX(direction, gridFactor);
            int originY = orientation.GetOriginY(direction, gridFactor);

            ColorMatrix colourMatrix = new ColorMatrix();
            colourMatrix.Matrix33 = opacity;
            ImageAttributes attributes = new ImageAttributes();
            attributes.SetColorMatrix(colourMatrix);
            
            // Fix this, scaling on colour map
            gfx.DrawImage(objImage,
                new Rectangle(
                    (x * gridFactor) + originX,
                    (y * gridFactor) + originY,
                    sizeX,
                    sizeY),
                0, 0, sizeX, sizeY,
                GraphicsUnit.Pixel, attributes);

            return true;
        }



        public static bool DrawForegroundTile(StarboundTile tile, int x, int y, Graphics gfx)
        {
            return DrawForegroundTile(tile, x, y, Editor.DEFAULT_GRID_FACTOR, gfx);
        }

        public static bool DrawForegroundTile(StarboundTile tile, int x, int y, int gridFactor, Graphics gfx)
        {
            return DrawForegroundTile(tile, x, y, gridFactor, gfx, 1.0f);
        }

        public static bool DrawForegroundTile(StarboundTile tile, int x, int y, int gridFactor, Graphics gfx, float opacity)
        {
            if (tile.Image == null)
                return false;

            ColorMatrix colourMatrix = new ColorMatrix();
            colourMatrix.Matrix33 = opacity;
            ImageAttributes attributes = new ImageAttributes();
            attributes.SetColorMatrix(colourMatrix);

            // Fix this, scaling on colour map
            gfx.DrawImage(tile.Image,
                new Rectangle(
                    x * gridFactor,
                    y * gridFactor,
                    gridFactor,
                    gridFactor),
                0, 0, gridFactor, gridFactor,
                GraphicsUnit.Pixel, attributes);

            return true;
        }


        public static bool DrawBackgroundTile(StarboundTile tile, int x, int y, Graphics gfx)
        {
            return DrawForegroundTile(tile, x, y, Editor.DEFAULT_GRID_FACTOR, gfx);
        }

        public static bool DrawBackgroundTile(StarboundTile tile, int x, int y, int gridFactor, Graphics gfx)
        {
            if (tile.Image == null)
                return false;

            // How much we must scale to fit this correctly
            float sizeScaleFactor = (float)Editor.DEFAULT_GRID_FACTOR / (float)gridFactor;
            int sizeX = (int)Math.Ceiling(tile.Image.Width / sizeScaleFactor);
            int sizeY = (int)Math.Ceiling(tile.Image.Height / sizeScaleFactor);

            float[][] floatColourMatrx = 
            {
                new float[] {1, 0, 0, 0, 0},
                new float[] {0, 1, 0, 0, 0},
                new float[] {0, 0, 1, 0, 0},
                new float[] {0, 0, 0, 1, 0},
                new float[] {-0.25f, -0.25f, -0.25f, 1, 1} 
            };

            ColorMatrix colourMatrix = new ColorMatrix(floatColourMatrx);
            ImageAttributes attributes = new ImageAttributes();
            attributes.SetColorMatrix(colourMatrix);

            gfx.DrawImage(tile.Image,
                new Rectangle(
                    x * gridFactor, 
                    y * gridFactor, 
                    sizeX, 
                    sizeY),
                0, 0, sizeX, sizeY,
                GraphicsUnit.Pixel,attributes);

            attributes.Dispose();

            return true;
        }



        public static bool DrawPlatform()
        {
            return false;
        }



        public static bool DrawLiquid()
        {
            return false;
        }



        public static bool DrawNpc()
        {
            return false;
        }



        public static bool DrawBackground(List<EditorMapLayer> layers, Graphics gfx)
        {
            return DrawBackground(layers, Editor.DEFAULT_GRID_FACTOR, gfx);
        }

        public static bool DrawBackground(List<EditorMapLayer> layers, int gridFactor, Graphics gfx)
        {
            if (layers == null || layers.Count == 0)
                return false;

            int width = layers[0].Width;
            int height = layers[0].Height;

            return DrawBackgroundBetween(layers, 0, 0, width, height, gridFactor, gfx);
        }

        public static bool DrawBackgroundBetween(List<EditorMapLayer> layers, int xmin, int ymin, int xmax, int ymax, Graphics gfx)
        {
            return DrawBackgroundBetween(layers, xmin, ymin, xmax, ymax, Editor.DEFAULT_GRID_FACTOR, gfx);
        }

        public static bool DrawBackgroundBetween(List<EditorMapLayer> layers, int xmin, int ymin, int xmax, int ymax, int gridFactor, Graphics gfx)
        {
            if (layers == null || layers.Count == 0)
                return false;

            foreach (EditorMapLayer layer in layers)
            {
                for (int x = xmin; x < xmax; ++x)
                {
                    for (int y = ymin; y < ymax; ++y)
                    {
                        // Get the brush located at the provided x- and y-coordinates
                        EditorBrush brush = layer.GetBrushAt(x, y);

                        // If the brush is null, or no back asset is needed for this brush
                        if (brush == null || !brush.NeedsBackAsset || brush.BackAsset == null)
                            continue;

                        // Don't draw this brush if it isn't flagged as a back brush, or if it
                        // is also flagged as a front brush.
                        if (brush.BrushTypes.Contains("back") && !brush.BrushTypes.Contains("front"))
                        {
                            DrawBackgroundTile((StarboundTile)brush.BackAsset, x, y, gridFactor, gfx);
                        }
                    }
                }
            }

            return true;
        }



        public static bool DrawForeground(List<EditorMapLayer> layers, Graphics gfx)
        {
            return DrawForeground(layers, Editor.DEFAULT_GRID_FACTOR, gfx);
        }

        public static bool DrawForeground(List<EditorMapLayer> layers, int gridFactor, Graphics gfx)
        {
            if (layers == null || layers.Count == 0)
                return false;

            int width = layers[0].Width;
            int height = layers[0].Height;

            return DrawForegroundBetween(layers, 0, 0, width, height, gridFactor, gfx);
        }

        public static bool DrawForegroundBetween(List<EditorMapLayer> layers, int xmin, int ymin, int xmax, int ymax, Graphics gfx)
        {
            return DrawForegroundBetween(layers, xmin, ymin, xmax, ymax, Editor.DEFAULT_GRID_FACTOR, gfx);
        }

        public static bool DrawForegroundBetween(List<EditorMapLayer> layers, int xmin, int ymin, int xmax, int ymax, int gridFactor, Graphics gfx)
        {
            if (layers == null || layers.Count == 0)
                return false;

            foreach (EditorMapLayer layer in layers)
            {
                for (int x = xmin; x < xmax; ++x)
                {
                    for (int y = ymin; y < ymax; ++y)
                    {
                        // Get the brush located at the provided x- and y-coordinates
                        EditorBrush brush = layer.GetBrushAt(x, y);

                        // If the brush is null, or no front asset is needed for this brush
                        if (brush == null || !brush.NeedsFrontAsset || brush.FrontAsset == null)
                            continue;

                        if (brush.BrushTypes.Contains("object"))
                        {
                            StarboundObject obj = (StarboundObject)brush.FrontAsset;
                            ObjectOrientation orientation = obj.GetCorrectOrientation(layers[0].Parent, x, y);
                            DrawObject(obj, x, y, orientation, brush.Direction, gridFactor, gfx);
                        }
                        else if (brush.BrushTypes.Contains("front"))
                        {
                            DrawForegroundTile((StarboundTile)brush.FrontAsset, x, y, gridFactor, gfx);
                        }
                    }
                }
            }

            return true;
        }



        public static bool DrawSpecial(List<EditorMapLayer> layers, Graphics gfx)
        {
            return DrawSpecial(layers, Editor.DEFAULT_GRID_FACTOR, gfx);
        }

        public static bool DrawSpecial(List<EditorMapLayer> layers, int gridFactor, Graphics gfx)
        {
            if (layers == null || layers.Count == 0)
                return false;

            int width = layers[0].Width;
            int height = layers[0].Height;

            return DrawSpecialBetween(layers, 0, 0, width, height, gridFactor, gfx);
        }

        public static bool DrawSpecialBetween(List<EditorMapLayer> layers, int xmin, int ymin, int xmax, int ymax, Graphics gfx)
        {
            return DrawSpecialBetween(layers, xmin, ymin, xmax, ymax, Editor.DEFAULT_GRID_FACTOR, gfx);
        }

        public static bool DrawSpecialBetween(List<EditorMapLayer> layers, int xmin, int ymin, int xmax, int ymax, int gridFactor, Graphics gfx)
        {
            if (layers == null || layers.Count == 0)
                return false;

            foreach (EditorMapLayer layer in layers)
            {
                for (int x = xmin; x < xmax; ++x)
                {
                    for (int y = ymin; y < ymax; ++y)
                    {
                        // Get the brush located at the provided x- and y-coordinates
                        EditorBrush brush = layer.GetBrushAt(x, y);

                        // If the brush is null, or it is not a special brush
                        if (brush == null || !brush.IsSpecial || brush.FrontAsset == null)
                            continue;

                        gfx.DrawImage(brush.FrontAsset.Image,
                            x * gridFactor,
                            y * gridFactor,
                            brush.FrontAsset.Image.Width,
                            brush.FrontAsset.Image.Height);
                    }
                }
            }

            return true;
        }


        public static void DrawObjectCollisions(List<EditorMapLayer> layers, Graphics gfx)
        {
            DrawObjectCollisions(layers, Editor.DEFAULT_GRID_FACTOR, gfx);
        }

        public static void DrawObjectCollisions(List<EditorMapLayer> layers, int gridFactor, Graphics gfx)
        {
            if (layers == null || layers.Count == 0)
                return;

            int width = layers[0].Width;
            int height = layers[0].Height;

            DrawObjectCollisions(layers, 0, 0, width, height, gridFactor, gfx);
        }

        public static void DrawObjectCollisions(List<EditorMapLayer> layers, int xmin, int ymin, int xmax, int ymax, Graphics gfx)
        {
            DrawObjectCollisions(layers, xmin, ymin, xmax, ymax, Editor.DEFAULT_GRID_FACTOR, gfx);
        }

        public static void DrawObjectCollisions(List<EditorMapLayer> layers, int xmin, int ymin, int xmax, int ymax, int gridFactor, Graphics gfx)
        {
            // Draw object collision overlays
            for (int x = 0; x < xmax; ++x)
            {
                for (int y = ymin; y < ymax; ++y)
                {
                    HashSet<List<int>> collisions = null;

                    if (layers.Count == 1)
                    {
                        collisions = layers[0].GetCollisionsAt(x, y);
                    }
                    else
                    {
                        collisions = layers[0].Parent.GetCollisionsAt(x, y);
                    }

                    if (collisions == null || collisions.Count == 0)
                        continue;
                    
                    for (int i = 0; i < collisions.Count; ++i)
                    {
                        if (i == 0)
                        {
                            Pen bluePen = new Pen(Color.Blue);
                            bluePen.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
                            gfx.DrawRectangle(bluePen, x * Editor.DEFAULT_GRID_FACTOR, y * Editor.DEFAULT_GRID_FACTOR, Editor.DEFAULT_GRID_FACTOR, Editor.DEFAULT_GRID_FACTOR);
                            bluePen.Dispose();
                        }
                        else if (i == 1)
                        {
                            Pen greenPen = new Pen(Color.Green);
                            greenPen.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
                            gfx.DrawRectangle(greenPen, x * Editor.DEFAULT_GRID_FACTOR + 1, y * Editor.DEFAULT_GRID_FACTOR + 1, Editor.DEFAULT_GRID_FACTOR - 2, Editor.DEFAULT_GRID_FACTOR - 2);
                            greenPen.Dispose();
                        }
                        else if (i == 2)
                        {
                            Pen crimsonPen = new Pen(Color.Crimson);
                            crimsonPen.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
                            gfx.DrawRectangle(crimsonPen, x * Editor.DEFAULT_GRID_FACTOR + 2, y * Editor.DEFAULT_GRID_FACTOR + 2, Editor.DEFAULT_GRID_FACTOR - 4, Editor.DEFAULT_GRID_FACTOR - 4);
                            crimsonPen.Dispose();
                        }
                        else if (i == 3)
                        {
                            Pen yellowPen = new Pen(Color.Yellow);
                            yellowPen.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
                            gfx.DrawRectangle(yellowPen, x * Editor.DEFAULT_GRID_FACTOR + 3, y * Editor.DEFAULT_GRID_FACTOR + 3, Editor.DEFAULT_GRID_FACTOR - 6, Editor.DEFAULT_GRID_FACTOR - 6);
                            yellowPen.Dispose();
                        }
                    }
                }
            }
        }
    }
}
