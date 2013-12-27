using DungeonEditor.StarboundObjects;
using DungeonEditor.StarboundObjects.Objects;
using DungeonEditor.StarboundObjects.Ships;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonEditor.EditorObjects
{
    public struct CollisionObjectBrush
    {
        public EditorBrush m_brush;
        public int m_x;
        public int m_y;
    }

    public class EditorMapLayer : EditorMap
    {
        private Image m_colourMap;
        private EditorBrush[,] m_brushMap;
        private EditorMapPart m_parent;
        private bool m_changed;

        public EditorMapPart Parent
        {
            get
            {
                return m_parent;
            }
        }

        public Image ColourMap
        {
            get
            {
                return m_colourMap;
            }
            set
            {
                m_colourMap = value;
            }
        }

        public bool Changed
        {
            get
            {
                return m_changed;
            }
            set
            {
                m_changed = value;
            }
        }

        // This constructor populates a two dimensional list of brushes.
        // It does this by translating between the provided colour map and the collection of StarboundBrushes.
        // This layer contains the *raw* brush information as drawn on the colour map, 
        // and is not responsible for any validity checking.
        // Also sets up the collision map
        public EditorMapLayer(string layerName, Bitmap colourMap, Dictionary<List<byte>, EditorBrush> brushMap, EditorMapPart parent)
        {
            m_parent = parent;
            m_colourMap = (Image)colourMap;
            m_name = layerName;
            m_width = colourMap.Width;
            m_height = colourMap.Height;
            m_brushMap = new EditorBrush[m_width, m_height];
            m_collisionMap = new HashSet<List<int>>[m_width, m_height];

            List<CollisionObjectBrush> brushObjList = new List<CollisionObjectBrush>();

            for (int x = 0; x < m_width; ++x)
            {
                for (int y = 0; y < m_height; ++y)
                {
                    Color pixel = colourMap.GetPixel(x, y);
                    EditorBrush brush = null;

                    List<byte> rawPixelData 
                        = new List<byte>() { pixel.R, pixel.G, pixel.B, pixel.A };

                    if (brushMap.ContainsKey(rawPixelData))
                    {
                        brush = brushMap[rawPixelData];
                        m_brushMap[x, y] = brush;
                    }

                    if (brush != null && brush.FrontAsset != null && brush.FrontAsset is StarboundObject)
                    {
                        // Add the object brush to a list, to process after all other tiles
                        CollisionObjectBrush objBrush = new CollisionObjectBrush();
                        objBrush.m_brush = brush;
                        objBrush.m_x = x;
                        objBrush.m_y = y;

                        brushObjList.Add(objBrush);
                    }
                    else
                    {
                        SetCollisionAt(brush, x, y);
                    }
                }
            }

            parent.UpdateCompositeCollisionMap();

            foreach (CollisionObjectBrush objBrush in brushObjList)
            {
                SetCollisionAt(objBrush.m_brush, objBrush.m_x, objBrush.m_y);
            }
        }

        // Returns the StarboundBrush located at the provided x- and y-coords 
        // as dictated by the colour map.
        public EditorBrush GetBrushAt(int x, int y)
        {
            if (x >= m_width || x < 0 || y >= m_height || y < 0)
                return null;

            return m_brushMap[x, y];
        }

        public void SetBrushAt(EditorBrush brush, int x, int y)
        {
            SetBrushAt(brush, x, y, false);
        }

        // Sets the brush at the located area and updates the affected colour map pixel
        public void SetBrushAt(EditorBrush brush, int x, int y, bool updateComposite)
        {
            if (x >= m_width || x < 0 || y >= m_height || y < 0)
                return;

            SetCollisionAt(brush, x, y, updateComposite);
            m_brushMap[x, y] = brush;

            Bitmap colourMapBmp = (Bitmap)ColourMap;
            Color newPixel = Color.FromArgb(brush.Colour[3], brush.Colour[0], brush.Colour[1], brush.Colour[2]);

            colourMapBmp.SetPixel(x, y, newPixel);
            m_changed = true;
        }


        public void SetCollisionAt(EditorBrush brush, int x, int y)
        {
            SetCollisionAt(brush, x, y, false);
        }

        // Sets the collision at the provided x- and y- coordinates to match the provided brush
        // Also handles removing old collisions if the brush is being replaced
        public void SetCollisionAt(EditorBrush brush, int x, int y, bool updateComposite)
        {
            // First, remove the old collision
            EditorBrush oldBrush = GetBrushAt(x, y);

            // Remove references based on size if the old brush was an object
            if (oldBrush != null && oldBrush.FrontAsset != null && oldBrush.FrontAsset is StarboundObject)
            {
                StarboundObject sbObject = (StarboundObject)oldBrush.FrontAsset;
                ObjectOrientation orientation = sbObject.GetCorrectOrientation(m_parent, x, y);

                int sizeX = orientation.GetWidth(brush.Direction, 1);
                int sizeY = orientation.GetHeight(brush.Direction, 1);
                int originX = orientation.GetOriginX(brush.Direction, 1);
                int originY = orientation.GetOriginY(brush.Direction, 1);

                for (int j = originX + x; j < sizeX + originX + x; ++j)
                {
                    for (int k = originY + y; k < sizeY + originY + y; ++k)
                    {
                        HashSet<List<int>> objAnchorSet = GetCollisionsAt(j, k);

                        if (objAnchorSet != null)
                        {
                            // Remove from the set if we have a match
                            objAnchorSet.RemoveWhere(coord => coord[0] == x && coord[1] == y);
                        }
                    }
                }
            }
            // Else just remove the tile we're at
            else
            {
                HashSet<List<int>> tileAnchorSet = GetCollisionsAt(x, y); ;

                if (tileAnchorSet != null)
                {
                    // Remove from the set if we have a match
                    tileAnchorSet.RemoveWhere(coord => coord[0] == x && coord[1] == y);
                }
            }

            // If this tile has a front component, continue
            if (brush != null && brush.FrontAsset != null)
            {
                // Collisions for objects based on size
                if (brush.FrontAsset is StarboundObject)
                {
                    StarboundObject sbObject = (StarboundObject)brush.FrontAsset;
                    ObjectOrientation orientation = sbObject.GetCorrectOrientation(m_parent, x, y);

                    int sizeX = orientation.GetWidth(brush.Direction, 1);
                    int sizeY = orientation.GetHeight(brush.Direction, 1);
                    int originX = orientation.GetOriginX(brush.Direction, 1);
                    int originY = orientation.GetOriginY(brush.Direction, 1);

                    // Set the elements at j, k to point to the anchor at x, y
                    for (int j = originX + x; j < sizeX + originX + x; ++j)
                    {
                        for (int k = originY + y; k < sizeY + originY + y; ++k)
                        {
                            List<int> list = new List<int>();
                            list.Add(x);
                            list.Add(y);

                            AddCollisionAt(list, j, k);
                        }
                    }
                }
                // Collisions for non-special front tiles
                else if (!brush.IsSpecial)
                {
                    List<int> list = new List<int>();
                    list.Add(x);
                    list.Add(y);

                    AddCollisionAt(list, x, y);
                }
            }

            // Ship brushes have a special flag for things that block
            // foreground collisions
            if (brush is ShipBrush && ((ShipBrush)brush).ForegroundBlock)
            {
                List<int> list = new List<int>();
                list.Add(x);
                list.Add(y);

                AddCollisionAt(list, x, y);
            }

            // If the update composite flag is set, rebuild
            // the composite collision map.
            if (updateComposite)
            {
                Parent.UpdateCompositeCollisionMap();
            }
        }

        private void AddCollisionAt(List<int> anchor, int x, int y)
        {
            if (x >= Width || x < 0 || y >= Height || y < 0)
                return;

            if (m_collisionMap[x, y] == null)
            {
                m_collisionMap[x, y] = new HashSet<List<int>>();
            }

            m_collisionMap[x, y].Add(anchor);
        }
    }
}
