/*Starstructor, the Starbound Toolet 
Copyright (C) 2013-2014 Chris Stamford
Contact: cstamford@gmail.com

Source file contributers:
 Chris Stamford     contact: cstamford@gmail.com
 Adam Heinermann    contact: aheinerm@gmail.com

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
using System.Linq;
using Newtonsoft.Json;
using System.ComponentModel;
using DungeonEditor.EditorTypes;
using System.Collections.ObjectModel;

namespace DungeonEditor.EditorObjects
{
    public class EditorMapPart : EditorMap
    {
        [JsonIgnore] 
        protected Graphics m_graphicsContext;

        [JsonIgnore]
        protected Bitmap m_graphicsMap;

        [JsonIgnore] 
        protected EditorFile m_parent;

        [JsonIgnore] protected List<EditorMapLayer> m_partLayers = new List<EditorMapLayer>();

        [JsonIgnore, Browsable(false)]
        public EditorFile Parent
        {
            get { return m_parent; }
            set { m_parent = value; }
        }

        [Browsable(false)]
        [JsonIgnore]
        public List<EditorMapLayer> Layers
        {
            get { return m_partLayers; }
        }

        [JsonIgnore, DisplayName("Layers"), ReadOnly(true)]
        public ReadOnlyCollection<EditorMapLayer> ReadOnlyLayers
        {
            get { return m_partLayers.AsReadOnly(); }
        }

        [JsonIgnore, Browsable(false)]
        public virtual Bitmap GraphicsMap
        {
            get { return m_graphicsMap; }
            set
            {
                if (m_graphicsContext != null)
                {
                    m_graphicsContext.Dispose();
                }

                m_graphicsMap = value;

                if (m_graphicsMap != null)
                {
                    m_graphicsContext = Graphics.FromImage(m_graphicsMap);
                    
                    m_graphicsContext.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighSpeed;
                    m_graphicsContext.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                    m_graphicsContext.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
                    m_graphicsContext.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
                }
            }
        }

        [ReadOnly(true)]
        [JsonIgnore]
        public Image ColourMap
        {
            get
            {
                EditorMapLayer firstLayer = m_partLayers.FirstOrDefault();

                if (firstLayer != null)
                {
                    return firstLayer.ColourMap;
                }

                return null;
            }
        }

        public void UpdateCompositeCollisionMap()
        {
            // If the composite collision map hasn't been made yet
            if (m_collisionMap == null)
            {
                m_collisionMap = new HashSet<Vec2I>[m_width, m_height];
            }

            // Clear the current list
            for (int x = 0; x < m_width; ++x)
            {
                for (int y = 0; y < m_height; ++y)
                {
                    if (m_collisionMap[x, y] != null)
                    {
                        m_collisionMap[x, y].Clear();
                    }
                }
            }

            // Composite all layers collisions
            foreach (HashSet<Vec2I>[,] layerCollisions in m_partLayers.Select(layer => layer.GetRawCollisionMap()))
            {
                for (int x = 0; x < m_width; ++x)
                {
                    for (int y = 0; y < m_height; ++y)
                    {
                        if (layerCollisions[x, y] != null)
                        {
                            // If there are no elements here yet
                            if (m_collisionMap[x, y] == null)
                            {
                                m_collisionMap[x, y] = new HashSet<Vec2I>();
                            }

                            foreach (var element in layerCollisions[x, y])
                            {
                                m_collisionMap[x, y].Add(element);
                            }
                        }
                    }
                }
            }
        }


        public virtual void UpdateLayerImage()
        {
            UpdateLayerImage(false, false, false, false);
        }

        public virtual void UpdateLayerImage(bool noFront, bool noBack, bool noSpecial, bool noClear)
        {
            UpdateLayerImageBetween(0, 0, Width, Height, noFront, noBack, noSpecial, noClear);
        }

        public virtual void UpdateLayerImage(List<EditorMapLayer> layers)
        {
            UpdateLayerImage(layers, false, false, false, false);
        }

        public virtual void UpdateLayerImage(List<EditorMapLayer> layers, bool noFront, bool noBack, bool noSpecial,
            bool noClear)
        {
            UpdateLayerImageBetween(layers, 0, 0, Width, Height, noFront, noBack, noSpecial, noClear);
        }


        public virtual void UpdateLayerImageBetween(int xmin, int ymin, int xmax, int ymax)
        {
            UpdateLayerImageBetween(xmin, ymin, xmax, ymax, false, false, false, false);
        }

        public virtual void UpdateLayerImageBetween(int xmin, int ymin, int xmax, int ymax, bool noFront, bool noBack,
            bool noSpecial, bool noClear)
        {
            UpdateLayerImageBetween(m_partLayers, xmin, ymin, xmax, ymax, noFront, noBack, noSpecial, noClear);
        }

        public virtual void UpdateLayerImageBetween(List<EditorMapLayer> layers, int xmin, int ymin, int xmax, int ymax)
        {
            UpdateLayerImageBetween(layers, xmin, ymin, xmax, ymax, false, false, false, false);
        }

        public virtual void UpdateLayerImageBetween(List<EditorMapLayer> layers, int xmin, int ymin, int xmax, int ymax,
            bool noFront, bool noBack, bool noSpecial, bool noClear)
        {
            if (!noClear)
                m_graphicsContext.FillRectangle(SystemBrushes.ControlDark,
                    xmin*Editor.Editor.DEFAULT_GRID_FACTOR,
                    ymin*Editor.Editor.DEFAULT_GRID_FACTOR,
                    (xmax - xmin)*Editor.Editor.DEFAULT_GRID_FACTOR,
                    (ymax - ymin)*Editor.Editor.DEFAULT_GRID_FACTOR);

            if (!noBack)
                DrawBackgroundBetween(layers, xmin, ymin, xmax, ymax, m_graphicsContext);

            if (!noFront)
                DrawForegroundBetween(layers, xmin, ymin, xmax, ymax, m_graphicsContext);

            if (!noSpecial)
                DrawSpecialBrushesBetween(layers, xmin, ymin, xmax, ymax, m_graphicsContext);

            if (Editor.Editor.Settings.ViewCollisionGrid)
                Renderer.DrawObjectCollisions(layers, xmin, ymin, xmax, ymax, m_graphicsContext);
        }

        protected virtual void DrawBackgroundBetween(List<EditorMapLayer> layers, int xmin, int ymin, int xmax, int ymax,
            Graphics gfx)
        {
            Renderer.DrawBackgroundBetween(layers, xmin, ymin, xmax, ymax, gfx);
        }

        protected virtual void DrawForegroundBetween(List<EditorMapLayer> layers, int xmin, int ymin, int xmax, int ymax,
            Graphics gfx)
        {
            Renderer.DrawForegroundBetween(layers, xmin, ymin, xmax, ymax, gfx);
        }


        protected virtual void DrawSpecialBrushes(List<EditorMapLayer> layers, Graphics gfx)
        {
            DrawSpecialBrushesBetween(layers, 0, 0, Width, Height, gfx);
        }

        protected virtual void DrawSpecialBrushesBetween(List<EditorMapLayer> layers, int xmin, int ymin, int xmax,
            int ymax, Graphics gfx)
        {
            Renderer.DrawSpecialBetween(layers, xmin, ymin, xmax, ymax, gfx);
        }
    }
}