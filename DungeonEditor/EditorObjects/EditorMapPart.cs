using DungeonEditor.StarboundObjects.Objects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonEditor.EditorObjects
{
    public class EditorMapPart : EditorMap
    {
        [JsonIgnore]
        protected EditorFile m_parent;

        [JsonIgnore]
        protected List<EditorMapLayer> m_partLayers = new List<EditorMapLayer>();

        [JsonIgnore]
        protected Image m_graphicsMap;

        [JsonIgnore]
        protected Graphics m_graphicsContext;

        [JsonIgnore]
        public EditorFile Parent
        {
            get
            {
                return m_parent;
            }
            set
            {
                m_parent = value;
            }
        }

        [JsonIgnore]
        public List<EditorMapLayer> Layers
        {
            get
            {
                return m_partLayers;
            }
        }

        [JsonIgnore]
        public virtual Image GraphicsMap
        {
            get
            {
                return m_graphicsMap;
            }
            set
            {
                if (m_graphicsContext != null)
                    m_graphicsContext.Dispose();

                m_graphicsMap = value;

                if (m_graphicsMap != null)
                    m_graphicsContext = Graphics.FromImage(m_graphicsMap);
            }
        }

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
                else
                {
                    return null;
                }
            }
        }

        public void UpdateCompositeCollisionMap()
        {
            // If the composite collision map hasn't been made yet
            if (m_collisionMap == null)
            {
                m_collisionMap = new HashSet<List<int>>[m_width, m_height];
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
            foreach (EditorMapLayer layer in m_partLayers)
            {
                HashSet<List<int>>[,] layerCollisions = layer.GetRawCollisionMap();

                for (int x = 0; x < m_width; ++x)
                {
                    for (int y = 0; y < m_height; ++y)
                    {
                        if (layerCollisions[x, y] != null)
                        {
                            // If there are no elements here yet
                            if (m_collisionMap[x, y] == null)
                            {
                                m_collisionMap[x, y] = new HashSet<List<int>>();
                            }

                            foreach (List<int> element in layerCollisions[x, y])
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

        public virtual void UpdateLayerImage(List<EditorMapLayer> layers, bool noFront, bool noBack, bool noSpecial, bool noClear)
        {
            UpdateLayerImageBetween(layers, 0, 0, Width, Height, noFront, noBack, noSpecial, noClear);
        }



        public virtual void UpdateLayerImageBetween(int xmin, int ymin, int xmax, int ymax)
        {
            UpdateLayerImageBetween(xmin, ymin, xmax, ymax, false, false, false, false);
        }

        public virtual void UpdateLayerImageBetween(int xmin, int ymin, int xmax, int ymax, bool noFront, bool noBack, bool noSpecial, bool noClear)
        {
            UpdateLayerImageBetween(m_partLayers, xmin, ymin, xmax, ymax, noFront, noBack, noSpecial, noClear);
        }

        public virtual void UpdateLayerImageBetween(List<EditorMapLayer> layers, int xmin, int ymin, int xmax, int ymax)
        {
            UpdateLayerImageBetween(layers, xmin, ymin, xmax, ymax, false, false, false, false);
        }

        public virtual void UpdateLayerImageBetween(List<EditorMapLayer> layers, int xmin, int ymin, int xmax, int ymax, bool noFront, bool noBack, bool noSpecial, bool noClear)
        {
            if (!noClear)
                m_graphicsContext.FillRectangle(SystemBrushes.ControlDark,
                    xmin * Editor.DEFAULT_GRID_FACTOR,
                    ymin * Editor.DEFAULT_GRID_FACTOR,
                    (xmax - xmin) * Editor.DEFAULT_GRID_FACTOR,
                    (ymax - ymin) * Editor.DEFAULT_GRID_FACTOR);

            if (!noBack)
                DrawBackgroundBetween(layers, xmin, ymin, xmax, ymax, m_graphicsContext);

            if (!noFront)
                DrawForegroundBetween(layers, xmin, ymin, xmax, ymax, m_graphicsContext);

            if (!noSpecial)
                DrawSpecialBrushesBetween(layers, xmin, ymin, xmax, ymax, m_graphicsContext);

            if (Editor.Settings.ViewCollisionGrid)
                Renderer.DrawObjectCollisions(layers, xmin, ymin, xmax, ymax, m_graphicsContext);
        }



        protected virtual void DrawBackground(List<EditorMapLayer> layers, Graphics gfx)
        {
            DrawBackgroundBetween(layers, 0, 0, Width, Height, gfx);
        }

        protected virtual void DrawBackgroundBetween(List<EditorMapLayer> layers, int xmin, int ymin, int xmax, int ymax, Graphics gfx)
        {
            Renderer.DrawBackgroundBetween(layers, xmin, ymin, xmax, ymax, gfx);
        }



        protected virtual void DrawForeground(List<EditorMapLayer> layers, Graphics gfx)
        {
            DrawForegroundBetween(layers, 0, 0, Width, Height, gfx);
        }

        protected virtual void DrawForegroundBetween(List<EditorMapLayer> layers, int xmin, int ymin, int xmax, int ymax, Graphics gfx)
        {
            Renderer.DrawForegroundBetween(layers, xmin, ymin, xmax, ymax, gfx);
        }



        protected virtual void DrawSpecialBrushes(List<EditorMapLayer> layers, Graphics gfx)
        {
            DrawSpecialBrushesBetween(layers, 0, 0, Width, Height, gfx);
        }

        protected virtual void DrawSpecialBrushesBetween(List<EditorMapLayer> layers, int xmin, int ymin, int xmax, int ymax, Graphics gfx)
        {
            Renderer.DrawSpecialBetween(layers, xmin, ymin, xmax, ymax, gfx);
        }
    }
}
