using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Drawing;
using DungeonEditor.EditorObjects;

namespace DungeonEditor.StarboundObjects.Dungeons
{
    public class DungeonPart : EditorMapPart
    {
        [JsonProperty("rules")]
        public List<List<object>> Rules { get; set; }

        [JsonProperty("def")]
        public List<object> Definition { get; set; }

        [JsonProperty("chance")]
        public double? Chance { get; set; }
    }
}
