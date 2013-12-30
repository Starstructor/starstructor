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

namespace DungeonEditor.StarboundObjects.Tiles
{
    [ReadOnly(true)]
    public class StarboundTile : StarboundAsset
    {
        [JsonProperty("description"), Category("Description")]
        public string Description { get; set; }

        [JsonProperty("florandescription"), Category("Description")]
        public string FloranDescription { get; set; }

        [JsonProperty("footstepSound")]
        public string FootstepSound { get; set; }

        [JsonProperty("frames")]
        public string Frames { get; set; }

        [JsonProperty("glitchdescription"), Category("Description")]
        public string GlitchDescription { get; set; }

        [JsonProperty("health")]
        public float Health { get; set; }

        [JsonProperty("itemDrop")]
        public string ItemDrop { get; set; }

        [JsonProperty("materialId")]
        public int MaterialId { get; set; }

        [JsonProperty("materialName")]
        public string MaterialName { get; set; }

        [JsonProperty("multicolored")]
        public bool Multicolored { get; set; }

        [JsonProperty("particleColor")]
        public List<int> ParticleColor { get; set; }

        [JsonProperty("platform"), Category("Platform")]
        public bool Platform { get; set; }

        [JsonProperty("platformImage"), Category("Platform")]
        public string PlatformImage { get; set; }

        [JsonProperty("platformVariants"), Category("Platform")]
        public int PlatformVariants { get; set; }

        [JsonProperty("shortdescription"), Category("Description")]
        public string ShortDescription { get; set; }

        [JsonProperty("stairImage"), Category("Platform")]
        public string StairImage { get; set; }

        [JsonProperty("stairVariants"), Category("Platform")]
        public int StairVariants { get; set; }

        [JsonProperty("transparent")]
        public bool Transparent { get; set; }

        [JsonProperty("variants")]
        public float Variants { get; set; }
    }
}