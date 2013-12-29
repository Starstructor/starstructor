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
    }
}