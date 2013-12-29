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

namespace DungeonEditor.StarboundObjects.Objects
{
    public class StarboundObject : StarboundAsset
    {
        [JsonProperty("objectName")]
        public string ObjectName { get; set; }

        [JsonProperty("rarity")]
        public string Rarity { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("lightColor")]
        public List<int> LightColour { get; set; }

        [JsonProperty("flickerDistance")]
        public double FlickerDistance { get; set; }

        [JsonProperty("flickerStrength")]
        public double FlickerStrength { get; set; }

        [JsonProperty("flickerTiming")]
        public double FlickerTiming { get; set; }

        [JsonProperty("unlit")]
        public bool Unlit { get; set; }

        [JsonProperty("price")]
        public string Price { get; set; }

        [JsonProperty("apexDescription")]
        public string ApexDescription { get; set; }

        [JsonProperty("avianDescription")]
        public string AvianDescription { get; set; }

        [JsonProperty("floranDescription")]
        public string FloranDescription { get; set; }

        [JsonProperty("glitchDescription")]
        public string GlitchDescription { get; set; }

        [JsonProperty("humanDescription")]
        public string HumanDescription { get; set; }

        [JsonProperty("hylotlDescription")]
        public string HylotlDescription { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("shortdescription")]
        public string Shortdescription { get; set; }

        [JsonProperty("race")]
        public string Race { get; set; }

        [JsonProperty("inventoryIcon")]
        public string InventoryIcon { get; set; }

        [JsonProperty("orientations")]
        public List<ObjectOrientation> Orientations { get; set; }

        [JsonProperty("soundEffect")]
        public string SoundEffect { get; set; }

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