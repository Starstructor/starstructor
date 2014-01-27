/*Starstructor, the Starbound Toolet 
Copyright (C) 2013-2014 Chris Stamford
Contact: cstamford@gmail.com

Source file contributers:
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
using Newtonsoft.Json;
using Starstructor.Data;

namespace Starstructor.StarboundTypes.Objects
{
    [ReadOnly(true)]
    public class ObjectFrameGrouped
    {
        [JsonProperty("offset")]
        public Vec2I Offset { get; set; }

        [JsonProperty("names"), Browsable(false)]
        public List<string> Names { get; set; }

        [JsonProperty("nested"), TypeConverter(typeof(ExpandableObjectConverter))]
        public ObjectFrames Nested { get; set; }
    }
}
