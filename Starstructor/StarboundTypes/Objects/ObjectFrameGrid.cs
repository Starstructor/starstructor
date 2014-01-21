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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Newtonsoft.Json;
using Starstructor.EditorTypes;

namespace Starstructor.StarboundTypes.Objects
{
    [ReadOnly(true)]
    public class ObjectFrameGrid
    {
        [JsonProperty("size"), TypeConverter(typeof(ExpandableObjectConverter))]
        public Vec2I Size { get; set; }
        
        [JsonProperty("dimensions"), TypeConverter(typeof(ExpandableObjectConverter))]
        public Vec2I Dimensions { get; set; }

        private Dictionary<string, Vec2I> m_keyMap = new Dictionary<string, Vec2I>();

        private List<List<string>> m_names;

        [JsonProperty("names"), Browsable(false)]
        public List<List<string>> Names
        { 
            get
            {
                return m_names;
            }
            set
            {
                m_names = value;
                for ( int y = 0; y < value.Count; ++y )
                {
                    for (int x = 0; x < value[y].Count; ++x)
                    {
                        if ( value[y][x] != null )
                            m_keyMap[value[y][x]] = new Vec2I(x, y);
                    }
                }
            }
        }

        // "begin" ?? Not sure of the type, and it's never used

        public Vec2I? GetPositionFromKey(string key)
        {
            if (m_keyMap.ContainsKey(key))
                return m_keyMap[key];

            return null;
        }

        public int GetWidth(int gridFactor = Editor.DEFAULT_GRID_FACTOR)
        {
            var sizeScaleFactor = Editor.GetSizeScaleFactor(gridFactor);
            return (int)Math.Ceiling(Size.x / sizeScaleFactor);
        }
        public int GetHeight(int gridFactor = Editor.DEFAULT_GRID_FACTOR)
        {
            var sizeScaleFactor = Editor.GetSizeScaleFactor(gridFactor);
            return (int)Math.Ceiling(Size.y / sizeScaleFactor);
        }

    }
}