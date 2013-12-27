using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonEditor.StarboundObjects.Ships
{
    public class ShipObjectParams
    {
        [JsonProperty("treasurePools")]
        public List<string> TreasurePools { get; set; }

        [JsonProperty("level")]
        public int Level { get; set; }

        [JsonProperty("unbreakable")]
        public bool Unbreakable { get; set; }
    }
}
