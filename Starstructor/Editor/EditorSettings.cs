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
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;

namespace Starstructor.Editor
{
    public class EditorSettings
    {
        private string m_assetPath;

        [JsonProperty("dir")] 
        public string AssetDirPath
        {
            get
            {
                return m_assetPath;
            }
            set
            {
                m_assetPath = value;
                //EditorAssets.RefreshAssets();        // This doesn't seem to work, AssetDirPath still returns null here
            }
        }

        [JsonIgnore]
        public string ModsDirPath
        {
            get
            {
                return Path.Combine(Directory.GetParent(m_assetPath).ToString(), "mods");
            }
        }

        [JsonProperty("graphicalDisplay")] 
        public bool GraphicalDisplay = true;

        [JsonProperty("surfaceBackTile")] 
        public string SurfaceBackgroundTile = "dirt";

        [JsonProperty("surfaceFrontTile")] 
        public string SurfaceForegroundTile = "dirt";

        [JsonProperty("viewCollisionGrid")] 
        public bool ViewCollisionGrid = false;

        [JsonProperty("windowHeight")] 
        public int WindowHeight = 800;

        [JsonProperty("windowState")] 
        public FormWindowState WindowState;

        [JsonProperty("windowWidth")] 
        public int WindowWidth = 1280;

        [JsonProperty("windowx")] 
        public int WindowX = 25;

        [JsonProperty("windowy")] 
        public int WindowY = 25;

        [JsonProperty("recentFiles")]
        public List<string> RecentFiles = new List<string>();
    }
}