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

using System.Collections.Generic;
using System.Linq;
using Starstructor.EditorObjects;
using Newtonsoft.Json;
using System.Drawing;
using System.ComponentModel;
using System;
using Starstructor.EditorTypes;
using System.IO;

namespace Starstructor.StarboundObjects.Objects
{
    [ReadOnly(true)]
    public class StarboundObject : StarboundAsset
    {
        [JsonProperty("objectName", Required = Required.Always)]
        [Description("The name of the object.")]
        public string ObjectName { get; set; }

        [JsonProperty("objectType")]
        [DefaultValue("object")]
        public string ObjectType { get; set; }

        // Can also be list of string containing categories
        // Must contain at least one category
        [JsonProperty("category")]
        public string Category { get; set; }

        private uint m_Price;

        [JsonProperty("price")]
        [DefaultValue(1)]
        [Description("Price of the object. Should always be greater than 0.")]
        public uint Price { get { return m_Price; } set { m_Price = Math.Max(1, value); } }

        // objectItem: optional, contains item descriptor

        // requires objectItem to be undefined
        // 'all' and '3dprinter' are defined somewhere if this is true
        [JsonProperty("printable")]
        [DefaultValue(true)]
        public bool? Printable { get; set; }
        
        // requires objectItem to be undefined
        [JsonProperty("race")]
        [DefaultValue("")]
        public string Race { get; set; }

        [JsonProperty("retainObjectParametersInItem")]
        [DefaultValue(false)]
        public bool? RetainObjectParametersInItem { get; set; }

        //breakDropOptions, a list of item descriptors, optional
        //smashDropOptions, a list of item descriptors, optional
        
        [JsonProperty("smashSounds")]
        [Description("The sound bank used when the object is smashed or broken. A random sound is selected.")]
        public List<string> SmashSounds { get; set; }

        [JsonProperty("unbreakable")]
        [DefaultValue(false)]
        [Description("Indicates that the object is indestructible.")]
        public bool? Unbreakable { get; set; }

        // damageTable (stuff)

        [JsonProperty("damageShakeMagnitude")]
        [DefaultValue(0.2)]
        public double? DamageShakeMagnitude { get; set; }

        [JsonProperty("damageMaterialKind")]
        [DefaultValue("solid")]
        public string DamageMaterialKind { get; set; }

        //damageTeam, an object, optional, with the following members:
        //  type: string, optional, possible values: [null,friendly,enemy,pvp,passive,ghostly,emitter,indiscriminate], default: emitter
        //  team: unsigned integer, optional, default: 0
        
        [JsonProperty("rarity")]
        public string Rarity { get; set; }

        // NOTE! If this value isn't present, then it checks for lightColors (with an s), which is a list of colours
        [JsonProperty("lightColor"), Category("Lighting")]
        [JsonConverter(typeof(ColorSerializer))]
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
        public bool? PointLight { get; set; }

        [JsonProperty("pointBeam"), Category("Lighting")]
        [DefaultValue(0.0)]
        public double? PointBeam { get; set; }

        [JsonProperty("soundEffect"), Category("Sound")]
        [DefaultValue("")]
        public string SoundEffect { get; set; }

        [JsonProperty("soundEffectRadius"), Category("Sound")]
        [DefaultValue(100.0)]
        public double? SoundEffectRadius { get; set; }

        [JsonProperty("autoBrokenCheck")]
        [DefaultValue(5)]
        public uint? AutoBrokenCheck { get; set; }

        //statusEffects, optional, list of object
        //touchDamage, optional, object containing information about touching the object (not to be confused with using the object)

        [JsonProperty("hydrophobic")]
        [DefaultValue(false)]
        public bool? Hydrophobic { get; set; }

        [JsonProperty("hydrophilic")]
        [DefaultValue(false)]
        public bool? Hydrophilic { get; set; }

        [JsonProperty("health")]
        [DefaultValue(1.0)]
        public double? Health { get; set; }

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
        public string ShortDescription { get; set; }

        [JsonIgnore]
        public ImageLoader InventoryIcon { get; set; }

        [JsonProperty("inventoryIcon")]
        [DefaultValue("/interface/inventory/x.png")]
        public string InventoryIconStr { get; set; }

        public void InitializeAssets()
        {
            if ( Orientations != null )
            {
                foreach (var orientation in Orientations)
                    orientation.InitializeAssets(Path.GetDirectoryName(FullPath));
            }

            // Get the inventory icon
            string iconStr = InventoryIconStr ?? "/interface/inventory/x.png";
            string inventoryPath = EditorHelpers.FindAsset(Path.GetDirectoryName(FullPath), iconStr) ??
                                   EditorHelpers.FindAsset(Path.GetDirectoryName(FullPath), "/interface/inventory/x.png");

            InventoryIcon = new ImageLoader(inventoryPath);
        }
        
        public ObjectOrientation GetDefaultOrientation()
        {
            return Orientations.FirstOrDefault();
        }

        public ObjectOrientation GetCorrectOrientation(EditorMap map, int x, int y, ObjectDirection direction)
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

                if (anchors.Contains("top") && !CheckCollisionMapAtOffset(part, x, y - orientation.GetHeight(1)))
                    continue;

                if (anchors.Contains("left") && !CheckCollisionMapAtOffset(part, x - 1, y))
                    continue;

                if (anchors.Contains("right") && !CheckCollisionMapAtOffset(part, x + 1, y))
                    continue;

                if (anchors.Contains("bottom") && !CheckCollisionMapAtOffset(part, x, y + orientation.GetHeight(1)))
                    continue;

                if (orientation.Direction == "left" && direction != ObjectDirection.DIRECTION_LEFT)
                    continue;

                if (orientation.Direction == "right" && direction != ObjectDirection.DIRECTION_RIGHT)
                    continue;

                //if ( anchors.Contains("background") )
                //    return orientation;

                return orientation;
            }

            return Orientations.FirstOrDefault();
        }

        private static bool CheckCollisionMapAtOffset(EditorMapPart part, int x, int y)
        {
            HashSet<Vec2I> collisions = part.GetCollisionsAt(x, y);

            if (collisions == null)
                return false;

            // Check each list of coordinates.
            // The collision is only valid if the list doesn't point to an object
            return (from coords in collisions 
                    from layer in part.Layers 
                    select layer.GetBrushAt(coords.x, coords.y)).Any(brush => 
                        brush != null && 
                        brush.FrontAsset != null && 
                        !(brush.FrontAsset is StarboundObject));
        }

        public override string ToString()
        {
            return ObjectName ?? ShortDescription ?? Description ?? base.ToString();
        }
    }
}