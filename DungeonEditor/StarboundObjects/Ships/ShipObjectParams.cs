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
using Newtonsoft.Json;
using System.ComponentModel;

namespace DungeonEditor.StarboundObjects.Ships
{
    public class ShipObjectParams
    {
        [JsonProperty("treasurePools")]
        [Browsable(false)]
        public BindingList<string> TreasurePools { get; set; }

        [JsonProperty("level")]
        public double? Level { get; set; }

        [JsonProperty("levelAdjustment")]
        [DefaultValue(0.0)]
        public double? LevelAdjustment { get; set; }

        //initialItems
        //treasurePools

        // color ??? (not sure)

        [JsonProperty("unbreakable")]
        [Description("Indicates that the object cannot be broken and is permanently in place.")]
        public bool? Unbreakable { get; set; }

        public override string ToString()
        {
            return "[ShipObjectParams]";
        }
    }
}