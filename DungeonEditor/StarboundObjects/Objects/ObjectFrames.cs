using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonEditor.StarboundObjects.Objects
{
    public class ObjectFrames
    {
        [JsonProperty("frameGrid")]
        public ObjectFrameGrid FrameGrid { get; set; }
    }
}
