using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonEditor.StarboundObjects.Objects
{
    public class ObjectFrameGrid
    {
        [JsonProperty("size")]
        public List<int> Size { get; set; }

        [JsonProperty("dimensions")]
        public List<int> Dimensions { get; set; }
    }
}
