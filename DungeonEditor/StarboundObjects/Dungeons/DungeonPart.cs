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
using DungeonEditor.EditorObjects;
using Newtonsoft.Json;
using System.ComponentModel;

namespace DungeonEditor.StarboundObjects.Dungeons
{
    public class DungeonPart : EditorMapPart
    {
        // name is inherited from EditorMap

        // Index 0 must contain the string "image"?
        [JsonProperty("def", Required = Required.Always)]
        public List<object> Definition { get; set; }

        [JsonProperty("rules", Required = Required.Always)]
        public List<List<object>> Rules { get; set; }

        [JsonProperty("chance")]
        [DefaultValue(1.0)]
        public double? Chance { get; set; }

        [JsonProperty("overrideAllowAlways")]
        [DefaultValue(false)]
        public bool? OverrideAllowAlways { get; set; }
    }
}