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

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using DungeonEditor.EditorObjects;
using Newtonsoft.Json;
using System.ComponentModel;

namespace DungeonEditor.StarboundObjects.Ships
{
    public class StarboundShip : EditorFile
    {
        [JsonProperty("config")]
        public ShipConfig Config { get; set; }

        [JsonProperty("backgroundOverlays")]
        public BindingList<ShipOverlay> BackgroundOverlays { get; set; }

        [JsonProperty("foregroundOverlays")]
        public BindingList<ShipOverlay> ForegroundOverlays { get; set; }

        // Missing blocksPosition? [x,y]

        [JsonProperty("blockKey")]
        public BindingList<ShipBrush> Brushes { get; set; }

        [JsonProperty("blockImage")]
        public string PartImage { get; set; }

        public override void LoadParts(Editor parent)
        {
            Editor.Log.Write("Loading part " + PartImage);

            string path = EditorHelpers.ParsePath(Path.GetDirectoryName(FilePath), PartImage);

            if (!File.Exists(path))
            {
                Editor.Log.Write("  Part image " + PartImage + "does not exist");
                return;
            }

            Image layerImg = EditorHelpers.LoadImageFromFile(path);

            // Ships don't have parts. Make a dummy one.
            ShipPart part = new ShipPart();
            part.Name = PartImage;
            part.Parent = this;
            part.Width = layerImg.Width;
            part.Height = layerImg.Height;

            part.Layers.Add(new EditorMapLayer(PartImage, (Bitmap) layerImg, parent.BrushMap, part));
            part.GraphicsMap = new Bitmap(part.Width*Editor.DEFAULT_GRID_FACTOR,
                part.Height*Editor.DEFAULT_GRID_FACTOR);
            part.UpdateCompositeCollisionMap();

            ReadableParts.Add(part);
            LoadOverlays();

            Editor.Log.Write("Completed loading part " + PartImage);
        }

        public override void GenerateBrushAndAssetMaps(Editor parent)
        {
            foreach (ShipBrush brush in BlockMap)
            {
                string backgroundType = null;
                string foregroundType = null;
                string foregroundName = null;
                string backgroundName = null;

                brush.Comment = "";

                // The thing occupying the background layer
                if (brush.BackgroundMat != null)
                {
                    brush.Comment += brush.BackgroundMat + "  ";
                    backgroundType = "back";
                    backgroundName = brush.BackgroundMat;
                    brush.BrushTypes.Add(backgroundType);
                    brush.NeedsBackAsset = true;
                }

                // The thing occupying the foreground layer
                if (brush.ForegroundMat != null)
                {
                    brush.Comment += brush.ForegroundMat;
                    foregroundType = "front";
                    foregroundName = brush.ForegroundMat;
                    brush.BrushTypes.Add(foregroundType);
                    brush.NeedsFrontAsset = true;
                }
                else if (brush.Object != null)
                {
                    brush.Comment += brush.Object;
                    foregroundType = "object";
                    foregroundName = brush.Object;

                    // Add the direction to the asset name
                    if (!String.IsNullOrWhiteSpace(brush.ObjectDirection))
                    {
                        brush.Comment += " " + brush.ObjectDirection;
                    }

                    // Populate the brush with the direction
                    if (brush.ObjectDirection != null)
                    {
                        if (brush.ObjectDirection == "left")
                        {
                            brush.Direction = ObjectDirection.DIRECTION_LEFT;
                        }
                        else if (brush.ObjectDirection == "right")
                        {
                            brush.Direction = ObjectDirection.DIRECTION_RIGHT;
                        }
                    }
                    else
                    {
                        brush.Direction = ObjectDirection.DIRECTION_NONE;
                    }

                    brush.BrushTypes.Add(foregroundType);
                    brush.NeedsFrontAsset = true;
                }

                if (String.IsNullOrWhiteSpace(brush.Comment))
                {
                    brush.Comment = "no comment defined";
                }

                base.LoadBrushWithBackAsset(brush, parent, backgroundName, backgroundType);
                base.LoadBrushWithFrontAsset(brush, parent, foregroundName, foregroundType);

                parent.BrushMap[brush.Colour] = brush;
            }

            LoadSpecialBrushes(parent);
        }

        private void LoadOverlays()
        {
            if (BackgroundOverlays != null)
            {
                foreach (ShipOverlay overlay in BackgroundOverlays)
                {
                    Editor.Log.Write("  Loading background overlay " + overlay.ImageName);
                    string path = EditorHelpers.ParsePath(Path.GetDirectoryName(FilePath), overlay.ImageName);

                    if (File.Exists(path))
                    {
                        overlay.Image = EditorHelpers.LoadImageFromFile(path);
                        Editor.Log.Write("  Completed loading background overlay " + overlay.ImageName);
                    }
                }
            }

            if (ForegroundOverlays != null)
            {
                foreach (ShipOverlay overlay in ForegroundOverlays)
                {
                    Editor.Log.Write("  Loading foreground overlay " + overlay.ImageName);
                    string path = EditorHelpers.ParsePath(Path.GetDirectoryName(FilePath), overlay.ImageName);

                    if (File.Exists(path))
                    {
                        overlay.Image = EditorHelpers.LoadImageFromFile(path);
                        Editor.Log.Write("  Completed loading foreground overlay " + overlay.ImageName);
                    }
                }
            }
        }

        private void LoadSpecialBrushes(Editor parent)
        {
        }
    }
}