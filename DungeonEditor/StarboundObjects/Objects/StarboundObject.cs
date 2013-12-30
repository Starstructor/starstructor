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

using System.Collections.Generic;
using System.Linq;
using DungeonEditor.EditorObjects;
using Newtonsoft.Json;
using System.Drawing;
using System.ComponentModel;
using System;

namespace DungeonEditor.StarboundObjects.Objects
{
    [ReadOnly(true)]
    public class StarboundObject : StarboundAsset
    {
        [JsonProperty("objectName")]
        [Description("The name of the object.")]
        public string ObjectName { get; set; }

        [JsonProperty("objectType")]
        [DefaultValue("object")]
        public string ObjectType { get; set; }

        // Can also be list of string containing categories
        [JsonProperty("category")]
        public string Category { get; set; }

        private uint m_Price;

        [JsonProperty("price")]
        [DefaultValue(1)]
        [Description("Price of the object. Should never be 0.")]
        public uint Price { get { return m_Price; } set { m_Price = Math.Max(1, value); } }

        // objectItem
        // printable
        
        [JsonProperty("race")]
        [DefaultValue("")]
        public string Race { get; set; }

        [JsonProperty("retainObjectParametersInItem")]
        [DefaultValue(false)]
        public bool RetainObjectParametersInItem { get; set; }

        //breakDropOptions
        //smashDropOptions
        //smashSounds

        [JsonProperty("unbreakable")]
        [DefaultValue(false)]
        [Description("Indicates that the object is indestructible.")]
        public bool Unbreakable { get; set; }

        // damageTable (stuff)

        [JsonProperty("damageShakeMagnitude")]
        [DefaultValue(0.2)]
        public double DamageShakeMagnitude { get; set; }

        [JsonProperty("damageMaterialKind")]
        [DefaultValue("solid")]
        public string DamageMaterialKind { get; set; }

        //damageTeam
        
        [JsonProperty("rarity")]
        public string Rarity { get; set; }

        // NOTE! If this value isn't present, then it checks for lightColors (with an s)
        [JsonProperty("lightColor"), JsonConverter(typeof(ColorSerializer)), Category("Lighting")]
        public Color LightColour { get; set; }

        [JsonProperty("flickerDistance"), Category("Lighting")]
        [DefaultValue(0.0)]
        public double FlickerDistance { get; set; }

        [JsonProperty("flickerStrength"), Category("Lighting")]
        [DefaultValue(0.0)]
        public double FlickerStrength { get; set; }

        [JsonProperty("flickerTiming"), Category("Lighting")]
        [DefaultValue(10.0)]
        public double FlickerTiming { get; set; }

        [JsonProperty("pointLight"), Category("Lighting")]
        [DefaultValue(false)]
        public bool PointLight { get; set; }

        [JsonProperty("pointBeam"), Category("Lighting")]
        [DefaultValue(0.0)]
        public double PointBeam { get; set; }

        [JsonProperty("soundEffect"), Category("Sound")]
        [DefaultValue("")]
        public string SoundEffect { get; set; }

        [JsonProperty("soundEffectRadius"), Category("Sound")]
        [DefaultValue(100.0)]
        public double SoundEffectRadius { get; set; }

        [JsonProperty("autoBrokenCheck")]
        [DefaultValue(5)]
        public uint AutoBrokenCheck { get; set; }

        //statusEffects
        //touchDamage

        [JsonProperty("hydrophobic")]
        [DefaultValue(false)]
        public bool Hydrophobic { get; set; }

        [JsonProperty("hydrophilic")]
        [DefaultValue(false)]
        public bool Hydrophilic { get; set; }

        [JsonProperty("health")]
        [DefaultValue(1.0)]
        public double Health { get; set; }

        [JsonProperty("orientations")]
        public List<ObjectOrientation> Orientations { get; set; }

        //particleEmitter
        //particleEmitters
        /*
        [JsonProperty("unlit"), Category("Lighting")]
        public bool Unlit { get; set; }*/

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

        [JsonProperty("description"), Category("Description")]
        public string Description { get; set; }

        [JsonProperty("shortdescription"), Category("Description")]
        public string Shortdescription { get; set; }

        [JsonProperty("inventoryIcon")]
        [DefaultValue("/interface/inventory/x.png")]
        public string InventoryIcon { get; set; }

        
        public ObjectOrientation GetDefaultOrientation()
        {
            return Orientations.FirstOrDefault();
        }

        public ObjectOrientation GetCorrectOrientation(EditorMap map, int x, int y)
        {
            EditorMapPart part = null;

            if (map is EditorMapPart)
            {
                part = (EditorMapPart) map;
            }
            else if (map is EditorMapLayer)
            {
                part = ((EditorMapLayer) map).Parent;
            }

            // This is inherently flawed as it does not take into account the
            // anchor position of objects. TODO Fix this at some point
            foreach (ObjectOrientation orientation in Orientations)
            {
                List<string> anchors = orientation.Anchors;

                // TODO implement fgAnchor
                if (anchors == null)
                    continue;

                if (anchors.Contains("top") && anchors.Contains("left"))
                {
                    if (CheckCollisionMapAtOffset(part, x, y - orientation.GetHeight(1)) &&
                        CheckCollisionMapAtOffset(part, x - 1, y))
                    {
                        return orientation;
                    }
                }

                else if (anchors.Contains("top") && anchors.Contains("right"))
                {
                    if (CheckCollisionMapAtOffset(part, x, y - orientation.GetHeight(1)) &&
                        CheckCollisionMapAtOffset(part, x + 1, y))
                    {
                        return orientation;
                    }
                }

                else if (anchors.Contains("bottom") && anchors.Contains("left"))
                {
                    if (CheckCollisionMapAtOffset(part, x, y + orientation.GetHeight(1)) &&
                        CheckCollisionMapAtOffset(part, x - 1, y))
                    {
                        return orientation;
                    }
                }

                else if (anchors.Contains("bottom") && anchors.Contains("right"))
                {
                    if (CheckCollisionMapAtOffset(part, x, y + orientation.GetHeight(1)) &&
                        CheckCollisionMapAtOffset(part, x + 1, y))
                        return orientation;
                }

                else if (anchors.Contains("top"))
                {
                    if (CheckCollisionMapAtOffset(part, x, y - orientation.GetHeight(1)))
                        return orientation;
                }

                else if (anchors.Contains("bottom"))
                {
                    if (CheckCollisionMapAtOffset(part, x, y + orientation.GetHeight(1)))
                        return orientation;
                }

                else if (anchors.Contains("left"))
                {
                    if (CheckCollisionMapAtOffset(part, x - 1, y))
                        return orientation;
                }

                else if (anchors.Contains("right"))
                {
                    if (CheckCollisionMapAtOffset(part, x + 1, y))
                        return orientation;
                }

                else if (anchors.Contains("background"))
                {
                    return orientation;
                }
            }

            return Orientations.FirstOrDefault();
        }

        private bool CheckCollisionMapAtOffset(EditorMapPart part, int x, int y)
        {
            HashSet<List<int>> collisions = part.GetCollisionsAt(x, y);

            if (collisions == null)
                return false;

            // Check each list of coordinates.
            // The collision is only valid if the list doesn't point to an object
            return (from coords in collisions 
                    from layer in part.Layers 
                    select layer.GetBrushAt(coords[0], coords[1])).Any(brush => 
                        brush != null && 
                        brush.FrontAsset != null && 
                        !(brush.FrontAsset is StarboundObject));
        }
    }
}