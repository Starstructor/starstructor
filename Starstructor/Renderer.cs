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

using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using Starstructor.Data;
using Starstructor.EditorObjects;
using Starstructor.StarboundTypes;
using Starstructor.StarboundTypes.Objects;

namespace Starstructor
{
    // Handles rendering various parts of the Starbound world
    // to the provided graphics context.
    public class Renderer
    {
        public static bool DrawBackgroundBetween(List<EditorMapLayer> layers, int xmin, int ymin, int xmax, int ymax,
            Graphics gfx)
        {
            return DrawBackgroundBetween(layers, xmin, ymin, xmax, ymax, Editor.DEFAULT_GRID_FACTOR, gfx);
        }

        public static bool DrawBackgroundBetween(List<EditorMapLayer> layers, int xmin, int ymin, int xmax, int ymax,
            int gridFactor, Graphics gfx)
        {
            if (layers == null || layers.Count == 0)
                return false;

            foreach (EditorMapLayer layer in layers)
            {
                float opacity = 1.0f;

                if (!layer.Selected)
                    opacity = 0.25f;

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
                        if (brush.BrushTypes.Contains("back") && !brush.BrushTypes.Contains("front") && brush.BackAsset is StarboundMaterial )
                        {
                            ((StarboundMaterial)brush.BackAsset).DrawTile(gfx, x, y, gridFactor, true, opacity);
                        }
                    }
                }
            }

            return true;
        }

        public static bool DrawForegroundBetween(List<EditorMapLayer> layers, int xmin, int ymin, int xmax, int ymax,
            Graphics gfx)
        {
            return DrawForegroundBetween(layers, xmin, ymin, xmax, ymax, Editor.DEFAULT_GRID_FACTOR, gfx);
        }

        public static bool DrawForegroundBetween(List<EditorMapLayer> layers, int xmin, int ymin, int xmax, int ymax,
            int gridFactor, Graphics gfx)
        {
            if (layers == null || layers.Count == 0)
                return false;

            foreach (EditorMapLayer layer in layers)
            {
                float opacity = 1.0f;

                if (!layer.Selected)
                    opacity = 0.25f;

                for (int x = xmin; x < xmax; ++x)
                {
                    for (int y = ymin; y < ymax; ++y)
                    {
                        // Get the brush located at the provided x- and y-coordinates
                        EditorBrush brush = layer.GetBrushAt(x, y);

                        // If the brush is null, or no front asset is needed for this brush
                        if (brush == null || !brush.NeedsFrontAsset || brush.FrontAsset == null)
                            continue;

                        if (brush.BrushTypes.Contains("object") && brush.FrontAsset is StarboundObject )
                        {
                            StarboundObject obj = brush.FrontAsset as StarboundObject;
                            ObjectOrientation orientation = obj.GetCorrectOrientation(layers[0].Parent, x, y, brush.Direction);
                            if (!orientation.DrawObject(gfx, x, y, brush.Direction, gridFactor, opacity))
                                Editor.Log.Write("DrawForeground failed for " + obj.ObjectName);
                        }
                        else if (brush.BrushTypes.Contains("front") && brush.FrontAsset is StarboundMaterial)
                        {
                            ((StarboundMaterial)brush.FrontAsset).DrawTile(gfx, x, y, gridFactor, false, opacity);
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

        public static bool DrawSpecialBetween(List<EditorMapLayer> layers, int xmin, int ymin, int xmax, int ymax,
            Graphics gfx)
        {
            return DrawSpecialBetween(layers, xmin, ymin, xmax, ymax, Editor.DEFAULT_GRID_FACTOR, gfx);
        }

        public static bool DrawSpecialBetween(List<EditorMapLayer> layers, int xmin, int ymin, int xmax, int ymax,
            int gridFactor, Graphics gfx)
        {
            if (layers == null || layers.Count == 0)
                return false;

            foreach (EditorMapLayer layer in layers)
            {
                float opacity = 1.0f;

                if (!layer.Selected)
                    opacity = 0.25f;

                for (int x = xmin; x < xmax; ++x)
                {
                    for (int y = ymin; y < ymax; ++y)
                    {
                        // Get the brush located at the provided x- and y-coordinates
                        EditorBrush brush = layer.GetBrushAt(x, y);

                        // If the brush is null, or it is not a special brush
                        if (brush == null || !brush.IsSpecial || brush.FrontAsset == null)
                            continue;

                        ColorMatrix colourMatrix = new ColorMatrix();
                        colourMatrix.Matrix33 = opacity;

                        ImageAttributes attributes = new ImageAttributes();
                        attributes.SetColorMatrix(colourMatrix);

                        // Fix this, scaling on colour map
                        gfx.DrawImage(brush.FrontAsset.Image,
                            new Rectangle(x * gridFactor, y * gridFactor, brush.FrontAsset.Image.Width, brush.FrontAsset.Image.Height),
                            0, 0, brush.FrontAsset.Image.Width, brush.FrontAsset.Image.Height,
                            GraphicsUnit.Pixel,
                            attributes);
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

        public static void DrawObjectCollisions(List<EditorMapLayer> layers, int xmin, int ymin, int xmax, int ymax,
            Graphics gfx)
        {
            DrawObjectCollisions(layers, xmin, ymin, xmax, ymax, Editor.DEFAULT_GRID_FACTOR, gfx);
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
                            gfx.DrawRectangle(bluePen, x*Editor.DEFAULT_GRID_FACTOR, y*Editor.DEFAULT_GRID_FACTOR,
                                Editor.DEFAULT_GRID_FACTOR, Editor.DEFAULT_GRID_FACTOR);
                            bluePen.Dispose();
                        }
                        else if (i == 1)
                        {
                            var greenPen = new Pen(Color.Green);
                            greenPen.Alignment = PenAlignment.Inset;
                            gfx.DrawRectangle(greenPen, x*Editor.DEFAULT_GRID_FACTOR + 1,
                                y*Editor.DEFAULT_GRID_FACTOR + 1, Editor.DEFAULT_GRID_FACTOR - 2,
                                Editor.DEFAULT_GRID_FACTOR - 2);
                            greenPen.Dispose();
                        }
                        else if (i == 2)
                        {
                            var crimsonPen = new Pen(Color.Crimson);
                            crimsonPen.Alignment = PenAlignment.Inset;
                            gfx.DrawRectangle(crimsonPen, x*Editor.DEFAULT_GRID_FACTOR + 2,
                                y*Editor.DEFAULT_GRID_FACTOR + 2, Editor.DEFAULT_GRID_FACTOR - 4,
                                Editor.DEFAULT_GRID_FACTOR - 4);
                            crimsonPen.Dispose();
                        }
                        else if (i == 3)
                        {
                            var yellowPen = new Pen(Color.Yellow);
                            yellowPen.Alignment = PenAlignment.Inset;
                            gfx.DrawRectangle(yellowPen, x*Editor.DEFAULT_GRID_FACTOR + 3,
                                y*Editor.DEFAULT_GRID_FACTOR + 3, Editor.DEFAULT_GRID_FACTOR - 6,
                                Editor.DEFAULT_GRID_FACTOR - 6);
                            yellowPen.Dispose();
                        }
                    }
                }
            }
        }
    }
}