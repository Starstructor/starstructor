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
    [ReadOnly(true)]
    public class ShipBrush : EditorBrush
    {
        [JsonIgnore]
        public override string Comment { get; set; }

        [JsonProperty("foregroundBlock"), Category("Graphic")]
        [DefaultValue(false)]
        public bool ForegroundBlock { get; set; }

        [JsonProperty("backgroundBlock"), Category("Graphic")]
        [DefaultValue(false)]
        public bool BackgroundBlock { get; set; }

        [JsonProperty("foregroundMat"), Category("Graphic")]
        [DefaultValue("")]
        public string ForegroundMat { get; set; }

        [JsonProperty("backgroundMat"), Category("Graphic")]
        [DefaultValue("")]
        public string BackgroundMat { get; set; }

        [JsonProperty("object")]
        [DefaultValue("")]
        public string Object { get; set; }

        // either left or right
        [JsonProperty("objectDirection"), Category("Orientation")]
        [DefaultValue("left")]
        public string ObjectDirection { get; set; }

        [JsonProperty("objectParameters")]
        public ShipObjectParams ObjectParameters { get; set; }

        [JsonProperty("flags")]
        public List<string> Flags { get; set; }

        [JsonProperty("value",Required=Required.Always)]
        [JsonConverter(typeof(ColorSerializer))]
        public override Color Colour { get; set; }

    }
}