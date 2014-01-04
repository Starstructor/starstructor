/*Starstructor, the Starbound Toolet 
Copyright (C) 2013-2014 Chris Stamford
Contact: cstamford@gmail.com

Source file contributers:
 Chris Stamford     contact: cstamford@gmail.com

This program is free software; you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation; either version 2 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License along
with this program; if not, write to the Free Software Foundation, Inc.,
51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA.
*/

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using DungeonEditor.EditorObjects;
using DungeonEditor.StarboundObjects.Objects;
using DungeonEditor.StarboundObjects.Tiles;
using DungeonEditor.EditorTypes;

namespace DungeonEditor
{
    // Handles rendering various parts of the Starbound world
    // to the provided graphics context.
    public class Renderer
    {
        public static bool DrawObject(StarboundObject obj, int x, int y, ObjectOrientation orientation,
            ObjectDirection direction, Graphics gfx)
        {
            return DrawObject(obj, x, y, orientation, direction, Editor.Editor.DEFAULT_GRID_FACTOR, gfx);
        }


        public static bool DrawObject(StarboundObject obj, int x, int y, ObjectOrientation orientation,
            ObjectDirection direction, int gridFactor, Graphics gfx)
        {
            return DrawObject(obj, x, y, orientation, direction, gridFactor, gfx, 1.0f);
        }

        public static bool DrawObject(StarboundObject obj, int x, int y, ObjectOrientation orientation,
            ObjectDirection direction, int gridFactor, Graphics gfx, float opacity)
        {
            if (obj.Image == null)
                return false;

            Image objImage = orientation.RightImage;

            if (direction == ObjectDirection.DIRECTION_LEFT)
            {
                objImage = orientation.LeftImage;
            }

            int sizeX = orientation.GetWidth(gridFactor, direction);
            int sizeY = orientation.GetHeight(gridFactor, direction);
            int originX = orientation.GetOriginX(gridFactor, direction);
            int originY = orientation.GetOriginY(gridFactor, direction);

            var colourMatrix = new ColorMatrix();
            colourMatrix.Matrix33 = opacity;
            var attributes = new ImageAttributes();
            attributes.SetColorMatrix(colourMatrix);

            // Fix this, scaling on colour map
            gfx.DrawImage(objImage,
                new Rectangle(
                    (x*gridFactor) + originX,
                    (y*gridFactor) + originY,
                    sizeX,
                    sizeY),
                0, 0, sizeX, sizeY,
                GraphicsUnit.Pixel, attributes);

            return true;
        }


        public static bool DrawForegroundTile(StarboundTile tile, int x, int y, Graphics gfx)
        {
            return DrawForegroundTile(tile, x, y, Editor.Editor.DEFAULT_GRID_FACTOR, gfx);
        }

        public static bool DrawForegroundTile(StarboundTile tile, int x, int y, int gridFactor, Graphics gfx)
        {
            return DrawForegroundTile(tile, x, y, gridFactor, gfx, 1.0f);
        }

        public static bool DrawForegroundTile(StarboundTile tile, int x, int y, int gridFactor, Graphics gfx,
            float opacity)
        {
            if (tile.Image == null)
                return false;

            var colourMatrix = new ColorMatrix();
            colourMatrix.Matrix33 = opacity;
            var attributes = new ImageAttributes();
            attributes.SetColorMatrix(colourMatrix);

            // Fix this, scaling on colour map
            gfx.DrawImage(tile.Image,
                new Rectangle(
                    x*gridFactor,
                    y*gridFactor,
                    gridFactor,
                    gridFactor),
                0, 0, gridFactor, gridFactor,
                GraphicsUnit.Pixel, attributes);

            return true;
        }


        public static bool DrawBackgroundTile(StarboundTile tile, int x, int y, Graphics gfx)
        {
            return DrawForegroundTile(tile, x, y, Editor.Editor.DEFAULT_GRID_FACTOR, gfx);
        }

        public static bool DrawBackgroundTile(StarboundTile tile, int x, int y, int gridFactor, Graphics gfx)
        {
            if (tile.Image == null)
                return false;

            // How much we must scale to fit this correctly
            float sizeScaleFactor = Editor.Editor.DEFAULT_GRID_FACTOR/(float) gridFactor;
            var sizeX = (int) Math.Ceiling(tile.Image.Width/sizeScaleFactor);
            var sizeY = (int) Math.Ceiling(tile.Image.Height/sizeScaleFactor);

            float[][] floatColourMatrx =
            {
                new float[] {1, 0, 0, 0, 0},
                new float[] {0, 1, 0, 0, 0},
                new float[] {0, 0, 1, 0, 0},
                new float[] {0, 0, 0, 1, 0},
                new[] {-0.25f, -0.25f, -0.25f, 1, 1}
            };

            var colourMatrix = new ColorMatrix(floatColourMatrx);
            var attributes = new ImageAttributes();
            attributes.SetColorMatrix(colourMatrix);

            gfx.DrawImage(tile.Image,
                new Rectangle(
                    x*gridFactor,
                    y*gridFactor,
                    sizeX,
                    sizeY),
                0, 0, sizeX, sizeY,
                GraphicsUnit.Pixel, attributes);

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
            return DrawBackground(layers, Editor.Editor.DEFAULT_GRID_FACTOR, gfx);
        }

        public static bool DrawBackground(List<EditorMapLayer> layers, int gridFactor, Graphics gfx)
        {
            if (layers == null || layers.Count == 0)
                return false;

            int width = layers[0].Width;
            int height = layers[0].Height;

            return DrawBackgroundBetween(layers, 0, 0, width, height, gridFactor, gfx);
        }

        public static bool DrawBackgroundBetween(List<EditorMapLayer> layers, int xmin, int ymin, int xmax, int ymax,
            Graphics gfx)
        {
            return DrawBackgroundBetween(layers, xmin, ymin, xmax, ymax, Editor.Editor.DEFAULT_GRID_FACTOR, gfx);
        }

        public static bool DrawBackgroundBetween(List<EditorMapLayer> layers, int xmin, int ymin, int xmax, int ymax,
            int gridFactor, Graphics gfx)
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
                            DrawBackgroundTile((StarboundTile) brush.BackAsset, x, y, gridFactor, gfx);
                        }
                    }
                }
            }

            return true;
        }


        public static bool DrawForeground(List<EditorMapLayer> layers, Graphics gfx)
        {
            return DrawForeground(layers, Editor.Editor.DEFAULT_GRID_FACTOR, gfx);
        }

        public static bool DrawForeground(List<EditorMapLayer> layers, int gridFactor, Graphics gfx)
        {
            if (layers == null || layers.Count == 0)
                return false;

            int width = layers[0].Width;
            int height = layers[0].Height;

            return DrawForegroundBetween(layers, 0, 0, width, height, gridFactor, gfx);
        }

        public static bool DrawForegroundBetween(List<EditorMapLayer> layers, int xmin, int ymin, int xmax, int ymax,
            Graphics gfx)
        {
            return DrawForegroundBetween(layers, xmin, ymin, xmax, ymax, Editor.Editor.DEFAULT_GRID_FACTOR, gfx);
        }

        public static bool DrawForegroundBetween(List<EditorMapLayer> layers, int xmin, int ymin, int xmax, int ymax,
            int gridFactor, Graphics gfx)
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
                            var obj = (StarboundObject) brush.FrontAsset;
                            ObjectOrientation orientation = obj.GetCorrectOrientation(layers[0].Parent, x, y);
                            DrawObject(obj, x, y, orientation, brush.Direction, gridFactor, gfx);
                        }
                        else if (brush.BrushTypes.Contains("front"))
                        {
                            DrawForegroundTile((StarboundTile) brush.FrontAsset, x, y, gridFactor, gfx);
                        }
                    }
                }
            }

            return true;
        }


        public static bool DrawSpecial(List<EditorMapLayer> layers, Graphics gfx)
        {
            return DrawSpecial(layers, Editor.Editor.DEFAULT_GRID_FACTOR, gfx);
        }

        public static bool DrawSpecial(List<EditorMapLayer> layers, int gridFactor, Graphics gfx)
        {
            if (layers == null || layers.Count == 0)
                return false;

            int width = layers[0].Width;
            int height = layers[0].Height;

            return DrawSpecialBetween(layers, 0, 0, width, height, gridFactor, gfx);
        }

        public static bool DrawSpecialBetween(List<EditorMapLayer> layers, int xmin, int ymin, int xmax, int ymax,
            Graphics gfx)
        {
            return DrawSpecialBetween(layers, xmin, ymin, xmax, ymax, Editor.Editor.DEFAULT_GRID_FACTOR, gfx);
        }

        public static bool DrawSpecialBetween(List<EditorMapLayer> layers, int xmin, int ymin, int xmax, int ymax,
            int gridFactor, Graphics gfx)
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
                            x*gridFactor,
                            y*gridFactor,
                            brush.FrontAsset.Image.Width,
                            brush.FrontAsset.Image.Height);
                    }
                }
            }

            return true;
        }


        public static void DrawObjectCollisions(List<EditorMapLayer> layers, Graphics gfx)
        {
            DrawObjectCollisions(layers, Editor.Editor.DEFAULT_GRID_FACTOR, gfx);
        }

        public static void DrawObjectCollisions(List<EditorMapLayer> layers, int gridFactor, Graphics gfx)
        {
            if (layers == null || layers.Count == 0)
                return;

            int width = layers[0].Width;
            int height = layers[0].Height;

            DrawObjectCollisions(layers, 0, 0, width, height, gridFactor, gfx);
        }

        public static void DrawObjectCollisions(List<EditorMapLayer> layers, int xmin, int ymin, int xmax, int ymax,
            Graphics gfx)
        {
            DrawObjectCollisions(layers, xmin, ymin, xmax, ymax, Editor.Editor.DEFAULT_GRID_FACTOR, gfx);
        }

        public static void DrawObjectCollisions(List<EditorMapLayer> layers, int xmin, int ymin, int xmax, int ymax,
            int gridFactor, Graphics gfx)
        {
            // Draw object collision overlays
            for (int x = 0; x < xmax; ++x)
            {
                for (int y = ymin; y < ymax; ++y)
                {
                    HashSet<Vec2I> collisions = null;

                    collisions = layers.Count == 1 ? layers[0].GetCollisionsAt(x, y) : layers[0].Parent.GetCollisionsAt(x, y);

                    if (collisions == null || collisions.Count == 0)
                        continue;

                    for (int i = 0; i < collisions.Count; ++i)
                    {
                        if (i == 0)
                        {
                            var bluePen = new Pen(Color.Blue);
                            bluePen.Alignment = PenAlignment.Inset;
                            gfx.DrawRectangle(bluePen, x*Editor.Editor.DEFAULT_GRID_FACTOR, y*Editor.Editor.DEFAULT_GRID_FACTOR,
                                Editor.Editor.DEFAULT_GRID_FACTOR, Editor.Editor.DEFAULT_GRID_FACTOR);
                            bluePen.Dispose();
                        }
                        else if (i == 1)
                        {
                            var greenPen = new Pen(Color.Green);
                            greenPen.Alignment = PenAlignment.Inset;
                            gfx.DrawRectangle(greenPen, x*Editor.Editor.DEFAULT_GRID_FACTOR + 1,
                                y*Editor.Editor.DEFAULT_GRID_FACTOR + 1, Editor.Editor.DEFAULT_GRID_FACTOR - 2,
                                Editor.Editor.DEFAULT_GRID_FACTOR - 2);
                            greenPen.Dispose();
                        }
                        else if (i == 2)
                        {
                            var crimsonPen = new Pen(Color.Crimson);
                            crimsonPen.Alignment = PenAlignment.Inset;
                            gfx.DrawRectangle(crimsonPen, x*Editor.Editor.DEFAULT_GRID_FACTOR + 2,
                                y*Editor.Editor.DEFAULT_GRID_FACTOR + 2, Editor.Editor.DEFAULT_GRID_FACTOR - 4,
                                Editor.Editor.DEFAULT_GRID_FACTOR - 4);
                            crimsonPen.Dispose();
                        }
                        else if (i == 3)
                        {
                            var yellowPen = new Pen(Color.Yellow);
                            yellowPen.Alignment = PenAlignment.Inset;
                            gfx.DrawRectangle(yellowPen, x*Editor.Editor.DEFAULT_GRID_FACTOR + 3,
                                y*Editor.Editor.DEFAULT_GRID_FACTOR + 3, Editor.Editor.DEFAULT_GRID_FACTOR - 6,
                                Editor.Editor.DEFAULT_GRID_FACTOR - 6);
                            yellowPen.Dispose();
                        }
                    }
                }
            }
        }
    }
}