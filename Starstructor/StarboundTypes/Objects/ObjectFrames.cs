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
using System.ComponentModel;
using System.Drawing;
using Newtonsoft.Json;
using Starstructor.EditorTypes;

namespace Starstructor.StarboundTypes.Objects
{
    [ReadOnly(true)]
    public class ObjectFrames
    {
        [JsonProperty("frameGrid"), TypeConverter(typeof(ExpandableObjectConverter))]
        public ObjectFrameGrid FrameGrid { get; set; }

        [JsonProperty("frameList"), Browsable(false)]
        public Dictionary<string, RectI> FrameList { get; set; }

        [JsonProperty("grouped"), TypeConverter(typeof(ExpandableObjectConverter))]
        public ObjectFrameGrouped Grouped { get; set; }

        [JsonProperty("aliases"), Browsable(false)]
        public Dictionary<string, string> Aliases { get; set; }

        public Vec2I? GetPositionFromKey(string key)
        {
            // Resolve alias, if any
            while (Aliases != null && Aliases.ContainsKey(key))
                key = Aliases[key];

            if (FrameGrid != null)
                return FrameGrid.GetPositionFromKey(key);

            return null;
        }

        public Rectangle GetFrameRectangle(Vec2I framePos)
        {
            return new Rectangle(
                framePos.x * FrameGrid.Size.x,
                framePos.y * FrameGrid.Size.y,
                FrameGrid.Size.x,
                FrameGrid.Size.y);
        }
    }
}