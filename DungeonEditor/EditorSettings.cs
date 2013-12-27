using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DungeonEditor
{
    public class EditorSettings
    {
        [JsonProperty("dir")]
        public string AssetDirPath;

        [JsonProperty("windowState")]
        public FormWindowState WindowState;

        [JsonProperty("windowx")]
        public int WindowX = 25;

        [JsonProperty("windowy")]
        public int WindowY = 25;

        [JsonProperty("windowWidth")]
        public int WindowWidth = 1280;

        [JsonProperty("windowHeight")]
        public int WindowHeight = 800;

        [JsonProperty("graphicalDisplay")]
        public bool GraphicalDisplay = true;

        [JsonProperty("surfaceBackTile")]
        public string SurfaceBackgroundTile = "dirt";

        [JsonProperty("surfaceFrontTile")]
        public string SurfaceForegroundTile = "dirt";

        [JsonProperty("viewCollisionGrid")]
        public bool ViewCollisionGrid = false;
    }
}
