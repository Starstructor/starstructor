// Format .material

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Drawing;

namespace DungeonEditor.StarboundObjects.Tiles
{
    public class StarboundTile : StarboundAsset
    {
        [JsonProperty("materialId")]
        public int MaterialId;

        [JsonProperty("materialName")]
        public string MaterialName;

        [JsonProperty("frames")]
        public string Frames;

        [JsonProperty("particleColor")]
        public List<int> ParticleColor;

        [JsonProperty("platform")]
        public bool Platform;

        [JsonProperty("transparent")]
        public bool Transparent;

        [JsonProperty("stairVariants")]
        public int StairVariants;

        [JsonProperty("stairImage")]
        public string StairImage;

        [JsonProperty("platformVariants")]
        public int PlatformVariants;

        [JsonProperty("platformImage")]
        public string PlatformImage;

        [JsonProperty("variants")]
        public float Variants;

        [JsonProperty("shortdescription")]
        public string ShortDescription;

        [JsonProperty("description")]
        public string Description;

        [JsonProperty("glitchdescription")]
        public string GlitchDescription;

        [JsonProperty("florandescription")]
        public string FloranDescription;

        [JsonProperty("itemDrop")]
        public string ItemDrop;

        [JsonProperty("multicolored")]
        public bool Multicolored;

        [JsonProperty("footstepSound")]
        public string FootstepSound;

        [JsonProperty("health")]
        public float Health;
    }
}
