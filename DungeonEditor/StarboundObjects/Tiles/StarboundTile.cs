/*Starstructor, the Starbound Toolet
Copyright (C) 2013-2014  Chris Stamford
Contact: cstamford@gmail.com

This program is free software; you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation; either version 2 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License along
with this program; if not, write to the Free Software Foundation, Inc.,
51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA.
*/
// Format .material

using System.Collections.Generic;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Drawing;

namespace DungeonEditor.StarboundObjects.Tiles
{
    [ReadOnly(true)]
    public class StarboundTile : StarboundAsset
    {
        [JsonProperty("description"), Category("Description")]
        [DefaultValue("")]
        [Description("A general description of the current tile.")]
        public string Description { get; set; }

        [JsonProperty("shortdescription"), Category("Description")]
        [Description("A short and meaningful description of the tile.")]
        public string ShortDescription { get; set; }

        [JsonProperty("apexDescription"), Category("Description")]
        public string ApexDescription { get; set; }

        [JsonProperty("avianDescription"), Category("Description")]
        public string AvianDescription { get; set; }

        [JsonProperty("floranDescription"), Category("Description")]
        public string FloranDescription { get; set; }

        [JsonProperty("glitchDescription"), Category("Description")]
        public string GlitchDescription { get; set; }

        [JsonProperty("humanDescription"), Category("Description")]
        public string HumanDescription { get; set; }

        [JsonProperty("hylotlDescription"), Category("Description")]
        public string HylotlDescription { get; set; }

        [JsonProperty("materialName", Required = Required.Always)]
        [Description("The name of the material used for rendering the tile.")]
        public string MaterialName { get; set; }

        [JsonProperty("materialId", Required = Required.Always)]
        public int MaterialId { get; set; }

        [JsonProperty("itemDrop")]
        [DefaultValue("")]
        public string ItemDrop { get; set; }

        // Either "breathable", "notBreathable", or "default"
        [JsonProperty("breathable")]
        [DefaultValue("")]
        public string Breathable { get; set; }

        [JsonProperty("particleColor"), JsonConverter(typeof(ColorSerializer))]
        public Color? ParticleColor { get; set; }
        
        [JsonProperty("footstepSound")]
        public string FootstepSound { get; set; }

        [JsonProperty("tillableMod")]
        [DefaultValue(65535)]
        public uint? TillableMod { get; set; }

        [JsonProperty("soil")]
        [DefaultValue(false)]
        public bool? Soil { get; set; }

        [JsonProperty("falling")]
        [DefaultValue(false)]
        public bool? Falling { get; set; }

        [JsonProperty("cascading")]
        [DefaultValue(false)]
        public bool? Cascading { get; set; }

        [JsonProperty("platform"), Category("Platform")]
        [DefaultValue(false)]
        public bool Platform { get; set; }

        // Condition: Platform=true
        [JsonProperty("platformImage"), Category("Platform")]
        public string PlatformImage { get; set; }

        // Condition: Platform=true
        [JsonProperty("platformVariants"), Category("Platform")]
        public int? PlatformVariants { get; set; }

        // Condition: Platform=true
        [JsonProperty("stairImage"), Category("Platform")]
        public string StairImage { get; set; }

        // Condition: Platform=true
        [JsonProperty("stairVariants"), Category("Platform")]
        public int? StairVariants { get; set; }

        [JsonProperty("multicolored")]
        public bool? Multicolored { get; set; }

        // Condition: Platform=false
        [JsonProperty("transparent")]
        public bool? Transparent { get; set; }

        // Condition: Platform=false
        [JsonProperty("frames")]
        public string Frames { get; set; }

        // Condition: Platform=false
        [JsonProperty("variants")]
        public int? Variants { get; set; }

        [JsonProperty("health")]
        [DefaultValue(1.0)]
        public double? Health { get; set; }

        //has a damageTable attribute
        // damageTable can either link to an external file or have embedded attributes
        // default: "/tiles/defaultDamage.config"

    }
}