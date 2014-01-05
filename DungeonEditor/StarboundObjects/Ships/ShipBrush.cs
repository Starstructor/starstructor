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
using DungeonEditor.EditorObjects;
using Newtonsoft.Json;
using System.Drawing;
using System.ComponentModel;

namespace DungeonEditor.StarboundObjects.Ships
{
    public class ShipBrush : EditorBrush
    {
        [JsonIgnore]
        [ReadOnly(true)]
        public override string Comment { get; set; }

        [JsonProperty("foregroundBlock"), Category("Graphic")]
        [DefaultValue(false)]
        [ReadOnly(true)]
        public bool ForegroundBlock { get; set; }

        [JsonProperty("backgroundBlock"), Category("Graphic")]
        [DefaultValue(false)]
        [ReadOnly(true)]
        public bool BackgroundBlock { get; set; }

        [JsonProperty("foregroundMat"), Category("Graphic")]
        [DefaultValue("")]
        [ReadOnly(true)]
        public string ForegroundMat { get; set; }

        [JsonProperty("backgroundMat"), Category("Graphic")]
        [DefaultValue("")]
        [ReadOnly(true)]
        public string BackgroundMat { get; set; }

        [JsonProperty("object")]
        [DefaultValue("")]
        [ReadOnly(true)]
        public string Object { get; set; }

        // either left or right
        [JsonProperty("objectDirection"), Category("Orientation")]
        [DefaultValue("left")]
        [ReadOnly(true)]
        public string ObjectDirection { get; set; }

        [JsonProperty("objectParameters")]
        [ReadOnly(true)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public ShipObjectParams ObjectParameters { get; set; }

        [JsonProperty("flags")]
        [Browsable(false)]
        public List<string> Flags { get; set; }

        [JsonProperty("value",Required=Required.Always)]
        [JsonConverter(typeof(ColorSerializer))]
        [ReadOnly(true)]
        public override Color Colour { get; set; }

    }
}