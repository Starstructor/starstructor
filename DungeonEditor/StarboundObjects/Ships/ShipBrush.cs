using DungeonEditor.EditorObjects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonEditor.StarboundObjects.Ships
{
    public class ShipBrush : EditorBrush
    {
        [JsonProperty("value")]
        public override List<byte> Colour { get; set; }

        [JsonIgnore]
        public override string Comment { get; set; }

        [JsonProperty("foregroundBlock")]
        public bool ForegroundBlock { get; set; }

        [JsonProperty("backgroundBlock")]
        public bool BackgroundBlock { get; set; }

        [JsonProperty("foregroundMat")]
        public string ForegroundMat { get; set; }

        [JsonProperty("backgroundMat")]
        public string BackgroundMat { get; set; }

        [JsonProperty("object")]
        public string Object { get; set; }

        [JsonProperty("objectParameters")]
        public ShipObjectParams ObjectParameters { get; set; }

        [JsonProperty("flags")]
        public List<string> Flags { get; set; }

        [JsonProperty("objectDirection")]
        public string ObjectDirection { get; set; }
    }
}
