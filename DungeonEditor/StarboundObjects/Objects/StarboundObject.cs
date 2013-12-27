using DungeonEditor.EditorObjects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
 
        public ObjectOrientation GetCorrectOrientation(EditorMap map, int x, int y)
        {
            EditorMapPart part = null;

            if (map is EditorMapPart)
            {
                part = (EditorMapPart)map;
            }
            else if (map is EditorMapLayer)
            {
                part = ((EditorMapLayer)map).Parent;
            }

            foreach (ObjectOrientation orientation in Orientations)
            {
                List<string> anchors = orientation.Anchors;

                // TODO implement fgAnchor
                if (anchors != null)
                {
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
            }

            return Orientations.FirstOrDefault();
        }

        private bool CheckCollisionMapAtOffset(EditorMapPart part, int x, int y)
        {
            return CheckCollisionMapAtOffset(part, x, y, false);
        }

        private bool CheckCollisionMapAtOffset(EditorMapPart part, int x, int y, bool checkObjects)
        {
            HashSet<List<int>> collisions = part.GetCollisionsAt(x, y);

            if (collisions == null)
                return false;

            bool notMyCoords = false;

            // Check each list of coordinates.
            foreach (List<int> coords in collisions)
            {
                if (!checkObjects)
                {
                    foreach (EditorMapLayer layer in part.Layers)
                    {
                        EditorBrush brush = layer.GetBrushAt(coords[0], coords[1]);

                        if (brush != null && brush.FrontAsset != null)
                        {
                            if (brush.FrontAsset is StarboundObject)
                            {
                                continue;
                            }
                            else
                            {
                                notMyCoords = true;
                            }
                        }
                    }
                }
            }

            return notMyCoords;
        }
    }
}