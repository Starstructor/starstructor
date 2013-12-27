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
    public class ObjectOrientation
    {
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

        [JsonIgnore]
        public ObjectFrames LeftFrames;

        [JsonIgnore]
        public ObjectFrames RightFrames;

        [JsonIgnore]
        public Image LeftImage;

        [JsonIgnore]
        public Image RightImage;


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
            float sizeScaleFactor = (float)Editor.DEFAULT_GRID_FACTOR / (float)gridFactor;

            ObjectFrames frames;

            if (direction == ObjectDirection.DIRECTION_LEFT && LeftFrames != null)
            {
                frames = LeftFrames;
            }
            else
            {
                frames = RightFrames;
            }

            return (int)Math.Ceiling(frames.FrameGrid.Size[0] / sizeScaleFactor);
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
            float sizeScaleFactor = (float)Editor.DEFAULT_GRID_FACTOR / (float)gridFactor;

            ObjectFrames frames;

            if (direction == ObjectDirection.DIRECTION_LEFT && LeftFrames != null)
            {
                frames = LeftFrames;
            }
            else
            {
                frames = RightFrames;
            }

            return (int)Math.Ceiling(frames.FrameGrid.Size[1] / sizeScaleFactor);
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
            float sizeScaleFactor = (float)Editor.DEFAULT_GRID_FACTOR / (float)gridFactor;

            int originX = 0;
            originX += (int)Math.Floor(ImagePosition[0] / sizeScaleFactor);

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
            float sizeScaleFactor = (float)Editor.DEFAULT_GRID_FACTOR / (float)gridFactor;

            int originY = -GetHeight(direction, gridFactor) + gridFactor;
            originY -= (int)Math.Floor(ImagePosition[1] / sizeScaleFactor);

            return originY;
        }
    }
}
