using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.ComponentModel;
using DungeonEditor.EditorObjects;

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

        [JsonProperty("brush")]
        public List<List<object>> Brushes { get; set; }

        [JsonProperty("connector")]
        public bool? Connector { get; set; }

        [JsonProperty("connector-value")]
        public List<byte> ConnnectorColour { get; set; }

        [JsonProperty("direction")]
        public string ConnectorDirection { get; set; }
    }
}
