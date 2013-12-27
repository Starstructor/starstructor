using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonEditor.StarboundObjects.Ships
{
    public class ShipOverlay
    {
        [JsonProperty("image")]
        public string ImageName { get; set; }

        [JsonProperty("position")]
        public List<float> Position { get; set; }

        [JsonIgnore]
        public Image Image;
    }
}
