using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Newtonsoft.Json;
using DungeonEditor.EditorTypes;
namespace DungeonEditor.StarboundObjects.Objects
{
    [ReadOnly(true)]
    public class ObjectFrameGrouped
    {
        [JsonProperty("offset")]
        public Vec2I Offset { get; set; }

        [JsonProperty("names"), Browsable(false)]
        public List<string> Names { get; set; }

        [JsonProperty("nested"), TypeConverter(typeof(ExpandableObjectConverter))]
        public ObjectFrames Nested { get; set; }
    }
}
