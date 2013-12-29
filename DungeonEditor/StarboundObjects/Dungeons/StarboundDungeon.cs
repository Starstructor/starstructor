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

// Format .dungeon

using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using DungeonEditor.EditorObjects;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DungeonEditor.StarboundObjects.Dungeons
{
    public class StarboundDungeon : EditorFile
    {
        [JsonProperty("metadata")] public DungeonMetadata Metadata;

        [JsonProperty("parts")] public List<DungeonPart> Parts;
        [JsonProperty("tiles")] public List<DungeonBrush> Tiles;

        public static void LoadFile(string path, Editor parent)
        {
            parent.ActiveFile = new JsonParser(path).ParseJson<StarboundDungeon>();

            foreach (DungeonPart part in ((StarboundDungeon) parent.ActiveFile).Parts)
            {
                parent.ActiveFile.ReadableParts.Add(part);
            }

            foreach (DungeonBrush brush in ((StarboundDungeon) parent.ActiveFile).Tiles)
            {
                parent.ActiveFile.BlockMap.Add(brush);
            }
        }

        public override void LoadParts(Editor parent)
        {
            foreach (DungeonPart part in Parts)
            {
                object imageList = part.Definition[1];

                // If the format isn't strictly correct, assume there's only one layer in this part
                // We must do this because some dungeon authors do not create an array if there
                // is only one layer to their part.
                if (imageList is string)
                {
                    JArray tempArray = new JArray {imageList};
                    imageList = tempArray;
                }

                // For each defined image
                foreach (string fileName in (JArray) imageList)
                {
                    string path = EditorHelpers.ParsePath(Path.GetDirectoryName(FilePath), fileName);

                    if (!File.Exists(path)) 
                        continue;

                    Image layerImg = EditorHelpers.LoadImageFromFile(path);

                    // Set the width and height of the part to match the blockmap
                    part.Width = layerImg.Width;
                    part.Height = layerImg.Height;

                    part.Layers.Add(new EditorMapLayer(fileName, (Bitmap) layerImg, parent.BrushMap, part));
                }

                // Create the graphics image
                part.GraphicsMap = new Bitmap(part.Width*Editor.DEFAULT_GRID_FACTOR,
                    part.Height*Editor.DEFAULT_GRID_FACTOR);

                // Update the composite collision map, now that all layers have been loaded
                part.UpdateCompositeCollisionMap();

                part.Parent = this;
            }
        }

        public override void GenerateBrushAndAssetMaps(Editor parent)
        {
            Dictionary<List<byte>, EditorBrush> map = parent.BrushMap;

            foreach (DungeonBrush brush in BlockMap)
            {
                // Populate brush comment
                if (brush.Comment == null)
                {
                    brush.Comment = "no comment defined";
                }

                if (brush.Connector == null)
                {
                    brush.Connector = false;
                }

                // Populate the rules
                if (brush.Rules != null)
                {
                    foreach (string rule in brush.Rules.SelectMany(rulesArray => rulesArray))
                    {
                        brush.BrushRules.Add(rule);
                    }
                }

                // Populate the brushes
                if (brush.Brushes != null)
                {
                    foreach (var brushArray in brush.Brushes)
                    {
                        for (int i = 0; i < brushArray.Count; ++i)
                        {
                            if (!(brushArray[i] is string))
                                continue;

                            var type = (string) brushArray[i];
                            string name = null;

                            if (type == "back")
                            {
                                brush.NeedsBackAsset = true;
                                name = (string) brushArray[i + 1];
                            }

                            else if (type == "front" || type == "object")
                            {
                                brush.NeedsFrontAsset = true;
                                name = (string) brushArray[i + 1];

                                if (type == "object" && brushArray.Count > i + 2 && brushArray[i + 2] is JObject)
                                {
                                    var objectParams = (JObject) brushArray[i + 2];
                                    var rawDirection = objectParams.Value<string>("direction");

                                    if (rawDirection == "left")
                                    {
                                        brush.Direction = ObjectDirection.DIRECTION_LEFT;
                                    }
                                    else if (rawDirection == "right")
                                    {
                                        brush.Direction = ObjectDirection.DIRECTION_RIGHT;
                                    }
                                }
                            }

                            // if it is a liquid
                            else if (type == "lava" || type == "water" || type == "acid" ||
                                     type == "liquidtar" || type == "tentaclejuice")
                            {
                                brush.BrushTypes.Add("back");
                                brush.NeedsBackAsset = true;
                                name = type;
                            }

                            // If an asset is needed but we don't have one!
                            if (name == null && (brush.NeedsBackAsset || brush.NeedsFrontAsset))
                                continue;

                            // Add the current asset type to the list of types for this brush
                            brush.BrushTypes.Add(type);

                            // Stop if the brush doesn't need an asset
                            if (!brush.NeedsBackAsset && !brush.NeedsFrontAsset)
                                continue;

                            base.LoadBrushWithBackAsset(brush, parent, name, type);
                            base.LoadBrushWithFrontAsset(brush, parent, name, type);
                        }
                    }
                }

                map[brush.Colour] = brush;
            }

            LoadSpecialBrushes(parent);
        }

        // This function is one big wall of useless repeated code
        // Fix it at some point
        private void LoadSpecialBrushes(Editor parent)
        {
            // Get all collision blocks
            foreach (DungeonBrush brush in BlockMap)
            {
                // If this brush is a connector
                if (brush.Connector != null && (bool) brush.Connector)
                {
                    string assetName = brush.Comment + ".INTERNAL";
                    StarboundAsset asset = null;

                    if (parent.AssetMap.ContainsKey(assetName))
                    {
                        asset = parent.AssetMap[assetName];
                    }
                    else
                    {
                        asset = new StarboundAsset();
                        asset.AssetName = assetName;
                        asset.Image = EditorHelpers.GetGeneratedRectangle(8, 8,
                            brush.Colour[0],
                            brush.Colour[1],
                            brush.Colour[2],
                            brush.Colour[3]);

                        parent.AssetMap[asset.AssetName] = asset;
                    }

                    brush.NeedsFrontAsset = true;
                    brush.FrontAsset = asset;
                    brush.IsSpecial = true;
                }

                // If this brush is surface foreground
                else if (brush.BrushTypes.Contains("surface"))
                {
                    string assetName = Editor.Settings.SurfaceForegroundTile;
                    StarboundAsset asset = null;

                    if (parent.AssetMap.ContainsKey(assetName))
                    {
                        asset = parent.AssetMap[assetName];
                    }
                    else
                    {
                        if (assetName.Contains("INTERNAL"))
                        {
                            asset = new StarboundAsset();
                            asset.AssetName = assetName;
                            asset.Image = EditorHelpers.GetGeneratedRectangle(8, 8,
                                87, 59, 12, 255);
                        }
                        else
                        {
                            asset = parent.LoadAsset(assetName, "surface");
                        }

                        parent.AssetMap[assetName] = asset;
                    }

                    brush.FrontAsset = asset;
                    brush.BrushTypes.Add("front");
                    brush.NeedsFrontAsset = true;
                }

                // If this brush is surface background
                else if (brush.BrushTypes.Contains("surfacebackground"))
                {
                    string assetName = Editor.Settings.SurfaceBackgroundTile;
                    StarboundAsset asset = null;

                    if (parent.AssetMap.ContainsKey(assetName))
                    {
                        asset = parent.AssetMap[assetName];
                    }
                    else
                    {
                        if (assetName.Contains("INTERNAL"))
                        {
                            asset = new StarboundAsset();
                            asset.AssetName = assetName;
                            asset.Image = EditorHelpers.GetGeneratedRectangle(8, 8,
                                87, 59, 12, 255);
                        }
                        else
                        {
                            asset = parent.LoadAsset(assetName, "surfacebackground");
                        }

                        parent.AssetMap[assetName] = asset;
                    }

                    brush.BackAsset = asset;
                    brush.BrushTypes.Add("back");
                    brush.NeedsBackAsset = true;
                }
            }
        }
    }
}