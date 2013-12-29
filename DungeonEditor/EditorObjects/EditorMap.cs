/*Starstructor, the Starbound Toolet
Copyright (C) 2013-2014  Chris Stamford
Contact: cstamford@gmail.com

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
using Newtonsoft.Json;
using System.Linq;
using System;
using DungeonEditor.StarboundObjects.Objects;

namespace DungeonEditor.EditorObjects
{
    public class EditorMap
    {
        [JsonIgnore] protected HashSet<List<int>>[,] m_collisionMap;
        [JsonIgnore] protected int m_height;

        [JsonIgnore] protected string m_name;
        [JsonIgnore] protected int m_width;

        [JsonIgnore]
        public int Width
        {
            get { return m_width; }
            set { m_width = value; }
        }

        [JsonIgnore]
        public int Height
        {
            get { return m_height; }
            set { m_height = value; }
        }

        [JsonProperty("name")]
        public string Name
        {
            get { return m_name; }
            set { m_name = value; }
        }

        public HashSet<List<int>> GetCollisionsAt(int x, int y)
        {
            if (x >= Width || x < 0 || y >= Height || y < 0 || m_collisionMap == null)
                return null;

            return m_collisionMap[x, y];
        }

        public HashSet<List<int>>[,] GetRawCollisionMap()
        {
            return m_collisionMap;
        }

        public EditorMapLayer GetActiveLayer()
        {
            EditorMapLayer activeLayer = null;

            if (this is EditorMapPart)
            {
                activeLayer = ((EditorMapPart)this).Layers.FirstOrDefault();
            }
            else if (this is EditorMapLayer)
            {
                activeLayer = (EditorMapLayer)this;
            }
            return activeLayer;
        }
        public EditorMapPart GetActivePart()
        {
            EditorMapLayer activeLayer = GetActiveLayer();
            if ( activeLayer == null )
                return null;
            return activeLayer.Parent;
        }


        public void RedrawCanvasFromBrush(EditorBrush oldBrush, EditorBrush newBrush, int gridX, int gridY)
        {
            EditorMapLayer activeLayer = GetActiveLayer();

            // We need to selectively redraw here
            var additionalRedrawList = new HashSet<List<int>>();

            int xmin = gridX;
            int xmax = gridX+1;

            int ymin = gridY;
            int ymax = gridY+1;

            // If the old brush was an object, we must redraw around it
            if (oldBrush != null && oldBrush.FrontAsset is StarboundObject)
            {
                StarboundObject sbObject = (StarboundObject)oldBrush.FrontAsset;
                ObjectOrientation orientation = sbObject.GetCorrectOrientation(this, gridX, gridY);

                int sizeX = orientation.GetWidth(1, oldBrush.Direction);
                int sizeY = orientation.GetHeight(1, oldBrush.Direction);
                int originX = orientation.GetOriginX(1, oldBrush.Direction);
                int originY = orientation.GetOriginY(1, oldBrush.Direction);

                xmin = Math.Min(xmin, xmin + originX);
                xmax = Math.Max(xmax, xmax + sizeX + originX);

                ymin = Math.Min(ymin, ymin + originY);
                ymax = Math.Max(ymax, ymax + sizeY + originY);
            }

            // Extend the range of our bounds, so we encompass the old object, AND the new object
            if (newBrush != null && newBrush.FrontAsset is StarboundObject)
            {
                StarboundObject sbObject = (StarboundObject)newBrush.FrontAsset;
                ObjectOrientation orientation = sbObject.GetCorrectOrientation(this, gridX, gridY);

                int sizeX = orientation.GetWidth(1, newBrush.Direction);
                int sizeY = orientation.GetHeight(1, newBrush.Direction);
                int originX = orientation.GetOriginX(1, newBrush.Direction);
                int originY = orientation.GetOriginY(1, newBrush.Direction);

                xmin = Math.Min(xmin, xmin + originX);
                xmax = Math.Max(xmax, xmax + sizeX + originX);

                ymin = Math.Min(ymin, ymin + originY);
                ymax = Math.Max(ymax, ymax + sizeY + originY);
            }

            // Accumulate a list of coordinates to redraw?
            for (int x = xmin; x < xmax; ++x)
            {
                for (int y = ymin; y < ymax; ++y)
                {
                    HashSet<List<int>> collisions = null;
                    if (this is EditorMapPart)
                    {
                        collisions = activeLayer.Parent.GetCollisionsAt(x, y);
                    }
                    else if (this is EditorMapLayer)
                    {
                        collisions = activeLayer.GetCollisionsAt(x, y);
                    }

                    if (collisions == null)
                        continue;

                    foreach (List<int> coords in collisions.Where(coords =>
                        (coords[0] != x || coords[1] != y) &&
                        (coords[0] != gridX || coords[1] != gridY)))
                    {
                        additionalRedrawList.Add(coords);
                    }
                }
            }
            
            // Selectively redraw the composite image
            if (this is EditorMapPart)
            {
                activeLayer.Parent.UpdateLayerImageBetween(xmin, ymin, xmax, ymax);

                foreach (var coords in additionalRedrawList)
                {
                    activeLayer.Parent.UpdateLayerImageBetween(
                        coords[0],
                        coords[1],
                        coords[0] + 1,
                        coords[1] + 1);
                }
            }

            // Only selectively redraw the active layer
            else if (this is EditorMapLayer)
            {
                activeLayer.Parent.UpdateLayerImageBetween(
                    new List<EditorMapLayer> { activeLayer },
                    xmin, ymin, xmax, ymax);

                foreach (var coords in additionalRedrawList)
                {
                    activeLayer.Parent.UpdateLayerImageBetween(
                        new List<EditorMapLayer> { activeLayer },
                        coords[0],
                        coords[1],
                        coords[0] + 1,
                        coords[1] + 1);
                }
            }
        }
    }
}