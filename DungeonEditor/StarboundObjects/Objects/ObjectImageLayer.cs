using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonEditor.StarboundObjects.Objects
{
    public class ObjectImageLayer
    {
        [JsonProperty("image")]
        public string ImageName { get; set; }

        [JsonProperty("unlit")]
        public bool Unlit { get; set; }
    }
}
