/*Starstructor, the Starbound Toolet 
Copyright (C) 2013-2014 Chris Stamford
Contact: cstamford@gmail.com

Source file contributers:
 Chris Stamford     contact: cstamford@gmail.com
 Adam Heinermann    contact: aheinerm@gmail.com

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

using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using Newtonsoft.Json;
using Starstructor.Data;
using Starstructor.StarboundTypes.Materials;

namespace Starstructor.StarboundTypes
{
    // AKA material
    [ReadOnly(true)]
    public class StarboundMaterial : StarboundAsset, IDisposable
    {
        [JsonIgnore]
        public IMaterialImageManager Frames;

        [JsonProperty("description"), Category("Description")]
        [DefaultValue("")]
        [Description("A general description of the current tile.")]
        public string Description { get; set; }

        [JsonProperty("shortdescription"), Category("Description")]
        [Description("A really short and meaningful description of the tile.")]
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

        [JsonProperty("particleColor")]
        [JsonConverter(typeof(ColorSerializer))]
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
        public string PlatformImageStr { get; set; }

        // Condition: Platform=true
        [JsonProperty("platformVariants"), Category("Platform")]
        public int? PlatformVariants { get; set; }

        // Condition: Platform=true
        [JsonProperty("stairImage"), Category("Platform")]
        public string StairImageStr { get; set; }

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
        public string FramesString { get; set; }

        // Condition: Platform=false
        [JsonProperty("variants")]
        public int? Variants { get; set; }

        [JsonProperty("health")]
        [DefaultValue(1.0)]
        public double? Health { get; set; }

        //has a damageTable attribute
        // damageTable can either link to an external file or have embedded attributes
        // default: "/tiles/defaultDamage.config"

        public override string ToString()
        {
            return MaterialName ?? ShortDescription ?? base.ToString();
        }

        public void InitializeAssets()
        {
            if (Platform)
            {
                Frames = new PlatformImageManager(
                    PlatformImageStr, 
                    PlatformVariants ?? 1, 
                    StairImageStr, 
                    StairVariants ?? 1, 
                    Path.GetDirectoryName(FullPath));
            }
            else
            {
                Frames = new MaterialImageManager(FramesString, Path.GetDirectoryName(FullPath));
            }

            Image = Frames.GetImageFrameBitmap();
        }

        public bool DrawTile(Graphics gfx, int x, int y, int gridFactor = Editor.DEFAULT_GRID_FACTOR, 
            bool background = false, float opacity = 1.0f)
        {
            if (Frames == null)
            {
                if (MaterialName != null)
                    Editor.Log.Write("Failed to draw tile for material" + MaterialName);
                else
                    Editor.Log.Write("Failed to draw tile for unknown material");

                return false;
            }
            
            //if (Transparent != null && Transparent.Value)
            //    opacity *= 0.6f;

            return Frames.DrawTile(gfx, x, y, gridFactor, background, opacity);
        }

        public void Dispose()
        {
            if (Frames == null) 
                return;

            Frames.Dispose();
            Frames = null;
        }
    }
}