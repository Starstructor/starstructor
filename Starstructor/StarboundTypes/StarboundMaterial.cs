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
using Starstructor.StarboundTypes.Renderer;

namespace Starstructor.StarboundTypes
{
    // AKA material
    [ReadOnly(true)]
    public class StarboundMaterial : StarboundAsset
    {
        [JsonIgnore]
        private MaterialRenderer Renderer;
        //public IMaterialImageManager Frames;

        [JsonProperty("description"), Category("Description")]
        [DefaultValue("")]
        [Description("A general description of the current tile.")]
        public string Description { get; set; }

        [JsonProperty("shortdescription"), Category("Description")]
        [Description("A really short and meaningful description of the tile.")]
        public string ShortDescription { get; set; }

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

        [JsonProperty("health")]
        [DefaultValue(1.0)]
        public double? Health { get; set; }

        [JsonProperty("platform"), Category("Platform")]
        [DefaultValue(false)]
        public bool Platform { get; set; }

        // Condition: Platform=false
        [JsonProperty("transparent")]
        public bool? Transparent { get; set; }

        public RenderParameters renderParameters { get; set; }
        public string renderTemplate { get; set; }

        private bool m_isLiquid;

        public StarboundMaterial(bool isLiquid = false)
        {
            m_isLiquid = isLiquid;
        }

        public override string ToString()
        {
            return MaterialName ?? ShortDescription ?? base.ToString();
        }

        public void InitializeAssets()
        {
            if (renderTemplate != null && renderParameters != null)
            {
                Renderer = new MaterialRenderer(Path.GetDirectoryName(FullPath), renderTemplate, renderParameters);
                Image = Renderer.GetPreviewImage();
            }
        }

        public bool DrawTile(Graphics gfx, int x, int y, int gridFactor = Editor.DEFAULT_GRID_FACTOR,
            bool background = false, float opacity = 1.0f)
        {

            //if (Transparent != null && Transparent.Value)
            //    opacity *= 0.6f;
            if (m_isLiquid)
            {
                Rectangle dstRect = new Rectangle(
                    x * gridFactor,
                    y * gridFactor,
                    gridFactor,
                    gridFactor);

                // Fix this, scaling on colour map
                gfx.DrawImage(Image, dstRect);
            }
            else
            {
                if (Renderer != null)
                    Renderer.Render(gfx, x, y, gridFactor, background, opacity);
            }
            return true;
        }
    }
}