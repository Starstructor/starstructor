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
using Newtonsoft.Json;
using System.ComponentModel;
using Starstructor.Data;
using Starstructor.StarboundTypes;
using Starstructor.StarboundTypes.Objects;
using Starstructor.StarboundTypes.Ships;

namespace Starstructor.EditorObjects
{
    public struct CollisionObjectBrush
    {
        public EditorBrush m_brush;
        public int m_x;
        public int m_y;
    }

    public class EditorMapLayer : EditorMap
    {
        private readonly EditorMapPart m_parent;
        private EditorBrush[,] m_brushes;
        private UndoManager m_undoManager;
        private bool m_changed;
        private Dictionary<Color, EditorBrush> m_brushMap;

        [JsonIgnore, Browsable(false)]
        public EditorMapPart Parent
        {
            get { return m_parent; }
        }

        [JsonIgnore, ReadOnly(true)]
        public Image ColourMap { get; set; }

        [JsonIgnore, Browsable(false)]
        public bool Changed
        {
            get { return m_changed; }
            set { m_changed = value; }
        }

        [JsonIgnore, Browsable(false)]
        public bool Selected { get; set; }

        [JsonIgnore, Browsable(false)]
        public UndoManager UndoManager
        {
            get { return m_undoManager; }
        }

        // This constructor populates a two dimensional list of brushes.
        // It does this by translating between the provided colour map and the collection of StarboundBrushes.
        // This layer contains the *raw* brush information as drawn on the colour map, 
        // and is not responsible for any validity checking.
        // Also sets up the collision map
        public EditorMapLayer(string layerName, Bitmap colourMap, Dictionary<Color, EditorBrush> brushMap,
            EditorMapPart parent)
        {
            m_parent = parent;
            ColourMap = colourMap;
            m_name = layerName;
            m_brushMap = brushMap;
            
            BuildLayer();
        }

        public void BuildLayer(bool composite = true)
        {
            m_width = ColourMap.Width;
            m_height = ColourMap.Height;
            m_brushes = new EditorBrush[m_width, m_height];
            m_collisionMap = new HashSet<Vec2I>[m_width, m_height];
            m_undoManager = new UndoManager(this);
            Bitmap colourMap = (Bitmap)ColourMap;

            List<CollisionObjectBrush> brushObjList = new List<CollisionObjectBrush>();

            for (int x = 0; x < m_width; ++x)
            {
                for (int y = 0; y < m_height; ++y)
                {
                    Color pixel = colourMap.GetPixel(x, y);
                    EditorBrush brush = null;

                    if (m_brushMap.ContainsKey(pixel))
                    {
                        brush = m_brushMap[pixel];
                        m_brushes[x, y] = brush;
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

            if (composite) m_parent.UpdateCompositeCollisionMap();

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

            return m_brushes[x, y];
        }

        // Sets the brush as per SetBrushAt but triggers an action that can be stored in the Undo/Redo system
        public void SetUserBrushAt(EditorBrush brush, int x, int y, bool updateComposite = true)
        {
            EditorBrush oldBrush = GetBrushAt(x, y);
            m_undoManager.RegisterAction(oldBrush, brush, x, y);
            SetBrushAt(brush, x, y, updateComposite);
        }

        // Sets the brush at the located area and updates the affected colour map pixel
        public void SetBrushAt(EditorBrush brush, int x, int y, bool updateComposite = false)
        {
            if (x >= m_width || x < 0 || y >= m_height || y < 0)
                return;

            SetCollisionAt(brush, x, y, updateComposite);
            m_brushes[x, y] = brush;

            Bitmap colourMapBmp = (Bitmap)ColourMap;
            colourMapBmp.SetPixel(x, y, brush.Colour);
            m_changed = true;
        }

        // Sets the collision at the provided x- and y- coordinates to match the provided brush
        // Also handles removing old collisions if the brush is being replaced
        public void SetCollisionAt(EditorBrush brush, int x, int y, bool updateComposite = false)
        {
            // First, remove the old collision
            EditorBrush oldBrush = GetBrushAt(x, y);

            // Remove references based on size if the old brush was an object
            if (oldBrush != null && oldBrush.FrontAsset != null && oldBrush.FrontAsset is StarboundObject)
            {
                StarboundObject sbObject = (StarboundObject)oldBrush.FrontAsset;
                ObjectOrientation orientation = sbObject.GetCorrectOrientation(m_parent, x, y, brush.Direction);

                int sizeX = orientation.GetWidth(1, brush.Direction);
                int sizeY = orientation.GetHeight(1, brush.Direction);
                int originX = orientation.GetOriginX(1, brush.Direction);
                int originY = orientation.GetOriginY(1, brush.Direction);

                for (int j = originX + x; j < sizeX + originX + x; ++j)
                {
                    for (int k = originY + y; k < sizeY + originY + y; ++k)
                    {
                        HashSet<Vec2I> objAnchorSet = GetCollisionsAt(j, k);

                        if (objAnchorSet != null)
                        {
                            // Remove from the set if we have a match
                            objAnchorSet.RemoveWhere(coord => coord.x == x && coord.y == y);
                        }
                    }
                }
            }
            // Else just remove the tile we're at
            else
            {
                HashSet<Vec2I> tileAnchorSet = GetCollisionsAt(x, y);

                if (tileAnchorSet != null)
                {
                    // Remove from the set if we have a match
                    tileAnchorSet.RemoveWhere(coord => coord.x == x && coord.y == y);
                }
            }

            // If this tile has a front component, continue
            if (brush != null && brush.FrontAsset != null)
            {
                // Collisions for objects based on size
                if (brush.FrontAsset is StarboundObject)
                {
                    StarboundObject sbObject = (StarboundObject)brush.FrontAsset;
                    ObjectOrientation orientation = sbObject.GetCorrectOrientation(m_parent, x, y, brush.Direction);

                    int sizeX = orientation.GetWidth(1, brush.Direction);
                    int sizeY = orientation.GetHeight(1, brush.Direction);
                    int originX = orientation.GetOriginX(1, brush.Direction);
                    int originY = orientation.GetOriginY(1, brush.Direction);

                    // Set the elements at j, k to point to the anchor at x, y
                    for (int j = originX + x; j < sizeX + originX + x; ++j)
                    {
                        for (int k = originY + y; k < sizeY + originY + y; ++k)
                        {
                            AddCollisionAt(new Vec2I(x,y), j, k);
                        }
                    }
                }
                    // Collisions for non-special front tiles
                else if (!brush.IsSpecial)
                {
                    AddCollisionAt(new Vec2I(x,y), x, y);
                }
            }

            // Ship brushes have a special flag for things that block
            // foreground collisions
            if (brush is ShipBrush && ((ShipBrush) brush).ForegroundBlock)
            {
                AddCollisionAt(new Vec2I(x,y), x, y);
            }

            // If the update composite flag is set, rebuild
            // the composite collision map.
            if (updateComposite)
            {
                Parent.UpdateCompositeCollisionMap();
            }
        }

        public override void Resize(int width, int height)
        {
            Image newMap = new Bitmap(width, height);
            Graphics gfx = Graphics.FromImage(newMap);
            gfx.Clear(Color.Black);
            gfx.DrawImage(ColourMap, 0, 0);
            gfx.Dispose();
            ColourMap.Dispose();
            ColourMap = newMap;
            BuildLayer(false);
        }

        private void AddCollisionAt(Vec2I anchor, int x, int y)
        {
            if (x >= Width || x < 0 || y >= Height || y < 0)
                return;

            if (m_collisionMap[x, y] == null)
            {
                m_collisionMap[x, y] = new HashSet<Vec2I>();
            }

            m_collisionMap[x, y].Add(anchor);
        }
    }
}