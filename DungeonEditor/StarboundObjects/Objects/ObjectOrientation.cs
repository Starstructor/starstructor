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
using DungeonEditor.EditorObjects;
using Newtonsoft.Json;

namespace DungeonEditor.StarboundObjects.Objects
{
    public class ObjectOrientation
    {
        [JsonIgnore] public ObjectFrames LeftFrames;
        [JsonIgnore] public Image LeftImage;
        [JsonIgnore] public ObjectFrames RightFrames;
        [JsonIgnore] public Image RightImage;

        [JsonProperty("image")]
        public string ImageName { get; set; }

        [JsonProperty("dualImage")]
        public string DualImageName { get; set; }

        [JsonProperty("leftImage")]
        public string LeftImageName { get; set; }

        [JsonProperty("rightImage")]
        public string RightImageName { get; set; }

        [JsonProperty("imageLayers")]
        public List<ObjectImageLayer> ImageLayers { get; set; }

        [JsonProperty("imagePosition")]
        public List<int> ImagePosition { get; set; }

        [JsonProperty("frames")]
        public int AnimFramesCount { get; set; }

        [JsonProperty("animationCycle")]
        public double AnimationCycle { get; set; }

        [JsonProperty("spaceScan")]
        public double SpaceScan { get; set; }

        [JsonProperty("anchors")]
        public List<string> Anchors { get; set; }

        [JsonProperty("direction")]
        public string Direction { get; set; }

        [JsonProperty("lightPosition")]
        public List<int> LightPosition { get; set; }


        public int GetWidth()
        {
            return GetWidth(Editor.DEFAULT_GRID_FACTOR);
        }

        public int GetWidth(int gridFactor)
        {
            return GetWidth(ObjectDirection.DIRECTION_NONE, Editor.DEFAULT_GRID_FACTOR);
        }

        public int GetWidth(ObjectDirection direction, int gridFactor)
        {
            float sizeScaleFactor = Editor.DEFAULT_GRID_FACTOR/(float) gridFactor;

            ObjectFrames frames;

            if (direction == ObjectDirection.DIRECTION_LEFT && LeftFrames != null)
            {
                frames = LeftFrames;
            }
            else
            {
                frames = RightFrames;
            }

            return (int) Math.Ceiling(frames.FrameGrid.Size[0]/sizeScaleFactor);
        }


        public int GetHeight()
        {
            return GetHeight(Editor.DEFAULT_GRID_FACTOR);
        }

        public int GetHeight(int gridFactor)
        {
            return GetHeight(ObjectDirection.DIRECTION_NONE, gridFactor);
        }

        public int GetHeight(ObjectDirection direction, int gridFactor)
        {
            float sizeScaleFactor = Editor.DEFAULT_GRID_FACTOR/(float) gridFactor;

            ObjectFrames frames;

            if (direction == ObjectDirection.DIRECTION_LEFT && LeftFrames != null)
            {
                frames = LeftFrames;
            }
            else
            {
                frames = RightFrames;
            }

            return (int) Math.Ceiling(frames.FrameGrid.Size[1]/sizeScaleFactor);
        }


        public int GetOriginX()
        {
            return GetOriginX(Editor.DEFAULT_GRID_FACTOR);
        }

        public int GetOriginX(int gridFactor)
        {
            return GetOriginX(ObjectDirection.DIRECTION_NONE, gridFactor);
        }

        public int GetOriginX(ObjectDirection direction, int gridFactor)
        {
            float sizeScaleFactor = Editor.DEFAULT_GRID_FACTOR/(float) gridFactor;

            int originX = 0;
            originX += (int) Math.Floor(ImagePosition[0]/sizeScaleFactor);

            return originX;
        }


        public int GetOriginY()
        {
            return GetOriginY(Editor.DEFAULT_GRID_FACTOR);
        }

        public int GetOriginY(int gridFactor)
        {
            return GetOriginY(ObjectDirection.DIRECTION_NONE, gridFactor);
        }

        public int GetOriginY(ObjectDirection direction, int gridFactor)
        {
            float sizeScaleFactor = Editor.DEFAULT_GRID_FACTOR/(float) gridFactor;

            int originY = -GetHeight(direction, gridFactor) + gridFactor;
            originY -= (int) Math.Floor(ImagePosition[1]/sizeScaleFactor);

            return originY;
        }
    }
}