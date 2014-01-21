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
using System.Collections.Generic;
using System.Drawing;
using Starstructor.EditorObjects;
using Newtonsoft.Json;
using System.ComponentModel;
using Starstructor.EditorTypes;
using System.Windows.Forms;

namespace Starstructor.StarboundObjects.Objects
{
    [ReadOnly(true)]
    public class ObjectOrientation : IDisposable
    {
        [JsonIgnore]
        public ObjectImageManager MainImage;
        [JsonIgnore]
        public ObjectImageManager DualImage;
        [JsonIgnore]
        public ObjectImageManager LeftImage;
        [JsonIgnore]
        public ObjectImageManager RightImage;

        [JsonProperty("image")]
        public string ImageName { get; set; }

        [JsonProperty("dualImage")]
        public string DualImageName { get; set; }

        [JsonProperty("leftImage")]
        public string LeftImageName { get; set; }

        [JsonProperty("rightImage")]
        public string RightImageName { get; set; }

        [JsonProperty("imageLayers"), Browsable(false)]
        public List<ObjectImageLayer> ImageLayers { get; set; }

        // only if imageLayers is not found
        [JsonProperty("unlit")]
        [DefaultValue(false)]
        public bool? Unlit { get; set; }

        [JsonProperty("flipImages")]
        [DefaultValue(false)]
        public bool? FlipImages { get; set; }

        // Default: 0,0
        // Vec2F, so should be double
        [JsonProperty("imagePosition"), TypeConverter(typeof(ExpandableObjectConverter))]
        public Vec2F ImagePosition { get; set; }
        //public List<double> ImagePosition { get; set; }

        [JsonProperty("frames")]
        [DefaultValue(1)]
        public int? AnimFramesCount { get; set; }

        [JsonProperty("animationCycle")]
        [DefaultValue(1.0)]
        public double? AnimationCycle { get; set; }

        // List<Vec2I>
        [JsonProperty("spaces")]
        public BindingList<Vec2I> Spaces { get; set; }

        [JsonProperty("spaceScan")]
        public double? SpaceScan { get; set; }

        [JsonProperty("requireTilledAnchors")]
        [DefaultValue(false)]
        public bool? RequireTilledAnchors { get; set; }

        [JsonProperty("requireSoilAnchors")]
        [DefaultValue(false)]
        public bool? RequireSoilAnchors { get; set; }

        // Contains "left", "bottom", "right", "top", "background"
        [JsonProperty("anchors")]
        public List<string> Anchors { get; set; }

        // List<Vec2I>
        [JsonProperty("bgAnchors")]
        public BindingList<Vec2I> BackgroundAnchors { get; set; }

        // List<Vec2I>
        [JsonProperty("fgAnchors")]
        public BindingList<Vec2I> ForegroundAnchors { get; set; }

        // either "left" or "right", defaults to right if rightImage
        [JsonProperty("direction")]
        [DefaultValue("left")]
        public string Direction { get; set; }

        // either "none", "solid", or "platform"
        [JsonProperty("collision")]
        [DefaultValue("none")]
        public string Collision { get; set; }

        // Vec2F
        [JsonProperty("lightPosition"), TypeConverter(typeof(ExpandableObjectConverter))]
        public Vec2F LightPosition { get; set; }
        //public List<double> LightPosition { get; set; }

        [JsonProperty("pointAngle")]
        [DefaultValue(0.0)]
        public double PointAngle { get; set; }

        //particleEmitter       optional, object with more properties
        //particleEmitters      optional, list of particleEmitter

        public void InitializeAssets(string assetDirectory)
        {
            // @TODO: Don't use image copies, go deeper and make the ImageLoader cache its own results
            if (ImageName != null)
                MainImage = new ObjectImageManager(ImageName, assetDirectory, false);
            if (DualImageName != null)
                DualImage = new ObjectImageManager(DualImageName, assetDirectory, false);
            if (LeftImageName != null)
                LeftImage = new ObjectImageManager(LeftImageName, assetDirectory, false);
            if (RightImageName != null)
                RightImage = new ObjectImageManager(RightImageName, assetDirectory, false);

            if ( ImageLayers != null && ImageLayers.Count > 0 )
            {
                // @TODO: Layers not supported
                MainImage = new ObjectImageManager(ImageLayers[0].ImageName, assetDirectory, false);
            }

            if ( DualImage != null )
            {
                if (RightImage == null)
                {
                    RightImage = DualImage;
                }
                if ( LeftImage == null )
                {
                    // @TODO: Deal with this, useless copy invokes ImageLoader to load the image
                    LeftImage = new ObjectImageManager(DualImageName, assetDirectory, true);
                }
                if ( MainImage == null )
                {
                    MainImage = DualImage;
                }
            }
        }

        public ObjectImageManager GetImageManager(ObjectDirection direction)
        {
            ObjectImageManager manager = null;
            if ((direction == ObjectDirection.DIRECTION_LEFT || direction == ObjectDirection.DIRECTION_NONE) && LeftImage != null)
                manager = LeftImage;
            else if ((direction == ObjectDirection.DIRECTION_RIGHT || direction == ObjectDirection.DIRECTION_NONE) && RightImage != null)
                manager = RightImage;
            else if (MainImage != null)
                manager = MainImage;

            return manager;
        }

        public int GetWidth(int gridFactor = Editor.Editor.DEFAULT_GRID_FACTOR, ObjectDirection direction = ObjectDirection.DIRECTION_NONE)
        {
            var manager = GetImageManager(direction);
            return manager != null && manager.Frames != null ? manager.Frames.FrameGrid.GetWidth(gridFactor) : 0;
        }

        public int GetHeight(int gridFactor = Editor.Editor.DEFAULT_GRID_FACTOR, ObjectDirection direction = ObjectDirection.DIRECTION_NONE)
        {
            var manager = GetImageManager(direction);
            return manager != null && manager.Frames != null ? manager.Frames.FrameGrid.GetHeight(gridFactor) : 0;
        }

        public int GetOriginX(int gridFactor = Editor.Editor.DEFAULT_GRID_FACTOR, ObjectDirection direction = ObjectDirection.DIRECTION_NONE)
        {
            var sizeScaleFactor = Editor.Editor.GetSizeScaleFactor(gridFactor);

            int originX = 0;
            originX += (int) Math.Floor(ImagePosition.x/sizeScaleFactor);

            return originX;
        }

        public int GetOriginY(int gridFactor = Editor.Editor.DEFAULT_GRID_FACTOR, ObjectDirection direction = ObjectDirection.DIRECTION_NONE)
        {
            var sizeScaleFactor = Editor.Editor.GetSizeScaleFactor(gridFactor);

            int originY = -GetHeight(gridFactor, direction) + gridFactor;
            originY -= (int) Math.Floor(ImagePosition.y/sizeScaleFactor);

            return originY;
        }

        //public static bool DrawObject(StarboundObject obj, int x, int y, ObjectOrientation orientation,
          //  ObjectDirection direction, int gridFactor, Graphics gfx, float opacity)
        public bool DrawObject(Graphics gfx, int x, int y, ObjectDirection direction, 
            int gridFactor = Editor.Editor.DEFAULT_GRID_FACTOR, float opacity = 1.0f)
        {
            var manager = GetImageManager(direction);
            if (manager == null)
            {
                MessageBox.Show("Manager is null");
                return false;
            }

            int sizeX = GetWidth(gridFactor, direction);
            int sizeY = GetHeight(gridFactor, direction);
            int originX = GetOriginX(gridFactor, direction);
            int originY = GetOriginY(gridFactor, direction);

            return manager.DrawObject(gfx, x, y, originX, originY, sizeX, sizeY, gridFactor, opacity);
        }

        public void Dispose()
        {
            if ( MainImage != null )
            {
                MainImage.Dispose();
                MainImage = null;
            }
            if ( DualImage != null )
            {
                DualImage.Dispose();
                DualImage = null;
            }
            if ( LeftImage != null )
            {
                LeftImage.Dispose();
                LeftImage = null;
            }
            if ( RightImage != null )
            {
                RightImage.Dispose();
                RightImage = null;
            }
        }
    }
}