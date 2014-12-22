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
using Newtonsoft.Json;

namespace Starstructor.StarboundTypes.Dungeons
{
    public class DungeonMetadata
    {
        [JsonProperty("name",Required=Required.Always)]
        [Description("The name of the dungeon.")]
        public string Name { get; set; }

        [JsonProperty("species",Required=Required.Always)]
        [Description("The race that the dungeon belongs to.")]
        public string Species { get; set; }

        [Browsable(false)]      // can't display in the property grid yet
        [JsonProperty("rules")]
        public List<object> Rules { get; set; }

        [JsonProperty("maxRadius")]
        [Description("The maximum radius that the dungeon can spread.")]
        [DefaultValue(100)]
        public int? MaxRadius { get; set; }

        [JsonProperty("maxParts")]
        [DefaultValue(100)]
        public int? MaxParts { get; set; }

        [Browsable(false)]
        [JsonProperty("anchor", Required = Required.Always)]
        public BindingList<string> Anchor { get; set; }

        [JsonProperty("gravity")]
        [Description("The gravity within the dungeon area. Dungeon gravity")]
        public int? Gravity { get; set; }

        [JsonProperty("protected")]
        public bool IsProtected { get; set; }

        public override string ToString()
        {
            return "[Options]";
        }
    }
}