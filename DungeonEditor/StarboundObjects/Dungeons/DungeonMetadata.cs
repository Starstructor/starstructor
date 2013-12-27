using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DungeonEditor.StarboundObjects.Dungeons
{
    public class DungeonMetadata
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("species")]
        public string Species { get; set; }

        [JsonProperty("rules")]
        public List<object> Rules { get; set; }

        [JsonProperty("anchor")]
        public List<string> Anchor { get; set; }

        [JsonProperty("maxRadius")]
        public int MaxRadius { get; set; }

        [JsonProperty("maxParts")]
        public int MaxParts { get; set; }
    }
}
