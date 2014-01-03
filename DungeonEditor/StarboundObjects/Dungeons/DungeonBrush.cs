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
using System.Drawing;

namespace DungeonEditor.StarboundObjects.Dungeons
{
    public class DungeonBrush : EditorBrush
    {
        // Override base colour list
        [ReadOnly(true)]
        [JsonProperty("value", Required = Required.Always)]
        [JsonConverter(typeof(ColorSerializer))]
        [Description("The colour mapped to this brush.")]
        public override Color Colour { get; set; }

        // Override base comment field
        [ReadOnly(true)]
        [JsonProperty("comment")]
        [DefaultValue("")]
        [Description("A user-defined comment. This is only used for the editor.")]
        public override string Comment { get; set; }

        [Browsable(false)]  // brushes currently not viewable in property grid
        [JsonProperty("brush")]
        public List<List<object>> Brushes { get; set; }

        [Browsable(false)] // rules currently not viewable in propertygrid
        [JsonProperty("rules")]
        public List<List<string>> Rules { get; set; }

        // Note this property can also be a string with values [t, true, y, yes, f, false, n, no]
        // It may be possible to convert from integer or float to bool as well
        [ReadOnly(true)]
        [JsonProperty("connector"), Category("Connector")]
        [DefaultValue(false)]
        [Description("Indicates that the current brush is a connector used for connecting two different dungeon parts together.")]
        public bool? Connector { get; set; }

        [ReadOnly(true)]
        [JsonProperty("connector-value"), Category("Connector")]
        [JsonConverter(typeof(ColorSerializer))]
        public Color ConnnectorColour { get; set; }
        
        // left, right, up, down, and unknown
        [ReadOnly(true)]
        [JsonProperty("direction"), Category("Connector")]
        [DefaultValue("unknown")]
        public string ConnectorDirection { get; set; }
    }
}