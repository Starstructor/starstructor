using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonEditor.StarboundObjects.Ships
{
    public class ShipConfig
    {
        [JsonProperty("fuelMax")]
        public int FuelMax { get; set; }
    }
}
