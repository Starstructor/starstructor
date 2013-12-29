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
    public class DungeonBrush : EditorBrush
    {
        // Override base colour list
        [JsonProperty("value")]
        public override List<byte> Colour { get; set; }

        // Override base comment field
        [JsonProperty("comment")]
        public override string Comment { get; set; }

        [JsonProperty("rules")]
        public List<List<string>> Rules { get; set; }

        [JsonProperty("brush"), ReadOnly(true)]
        public List<List<object>> Brushes { get; set; }

        [JsonProperty("connector")]
        public bool? Connector { get; set; }

        [JsonProperty("connector-value")]
        public List<byte> ConnnectorColour { get; set; }

        [JsonProperty("direction")]
        public string ConnectorDirection { get; set; }
    }
}