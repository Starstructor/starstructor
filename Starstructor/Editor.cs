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
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Newtonsoft.Json;
using Starstructor.EditorObjects;
using Starstructor.StarboundObjects;
using Starstructor.StarboundObjects.Dungeons;
using Starstructor.StarboundObjects.Ships;

namespace Starstructor
{
    public class Editor
    {
        // Editor variables
        public const int DEFAULT_GRID_FACTOR = 8;

        private static EditorSettings m_settings;

        private readonly Dictionary<Color, EditorBrush> m_brushMap
            = new Dictionary<Color, EditorBrush>();

        private static readonly Logger m_log
            = new Logger(Path.Combine(
                Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                "log.txt"));

        private readonly string m_name = Application.ProductName;
        private readonly Version m_version = Assembly.GetExecutingAssembly().GetName().Version;
        private EditorFile m_activeFile;

        // Public fields
        public string Name
        {
            get { return m_name; }
        }

        public Version Version
        {
            get { return m_version; }
        }

        public static Logger Log
        {
            get { return m_log; }
        }

        public Dictionary<Color, EditorBrush> BrushMap
        {
            get { return m_brushMap; }
        }

        public EditorFile ActiveFile
        {
            get { return m_activeFile; }
            set { m_activeFile = value; }
        }

        public static EditorSettings Settings
        {
            get
            {
                if (m_settings != null)
                {
                    return m_settings;
                }

                m_settings = new EditorSettings();

                string path = AppDomain.CurrentDomain.BaseDirectory + "settings.json";

                if (!File.Exists(path))
                {
                    File.AppendAllText(path, JsonConvert.SerializeObject((object) m_settings, Formatting.Indented));
                }
                else
                {
                    var sr = new StreamReader(path);
                    m_settings = JsonConvert.DeserializeObject<EditorSettings>(sr.ReadToEnd());
                    sr.Close();
                }

                return m_settings;
            }
        }

        public static double GetSizeScaleFactor(int gridFactor)
        {
            return DEFAULT_GRID_FACTOR / (double)gridFactor;
        }

        public void SaveSettings()
        {
            m_log.Write("Saving settings.json");
            string path = AppDomain.CurrentDomain.BaseDirectory + "settings.json";

            StreamWriter sw = new StreamWriter(path);
            sw.Write(JsonConvert.SerializeObject(m_settings, Formatting.Indented));
            sw.Close();
        }

        public bool LoadFile(string path)
        {
            m_log.Write("Parsing " + path);
            if ( !File.Exists(path) )
            {
                m_log.Write("File " + path + " does not exist!");
                Settings.RecentFiles.Remove(path);
                return false;
            }

            if (Path.GetExtension(path) == ".dungeon")
            {
                m_activeFile = JsonParser.ParseJson<StarboundDungeon>(path);

                m_log.Write("  Parsing " + ((StarboundDungeon)m_activeFile).Parts.Count + " parts");
                m_activeFile.ReadableParts.AddRange(((StarboundDungeon)m_activeFile).Parts);
                
                m_log.Write("  Parsing " + ((StarboundDungeon)m_activeFile).Tiles.Count + " brushes");
                m_activeFile.BlockMap.AddRange(((StarboundDungeon)m_activeFile).Tiles);
            }
            else if (Path.GetExtension(path) == ".structure")
            {
                m_activeFile = JsonParser.ParseJson<StarboundShip>(path);

                m_log.Write("  Parsing " + ((StarboundShip)m_activeFile).Brushes.Count + " brushes");
                m_activeFile.BlockMap.AddRange(((StarboundShip) m_activeFile).Brushes);
            }

            if (m_activeFile == null)
            {
                m_log.Write("Failed to parse " + path);
                return false;
            }

            ActiveFile.FilePath = path;
            ActiveFile.GenerateBrushAndAssetMaps(this);
            ActiveFile.LoadParts(this);

            m_log.Write("Completed parsing " + path);
            Settings.RecentFiles.Remove(path);
            Settings.RecentFiles.Insert(0, path);    // Insert the newest element at the beginning
            while (Settings.RecentFiles.Count > 10)  // Remove last elements over the max number of recent files
                Settings.RecentFiles.RemoveAt(Settings.RecentFiles.Count - 1);
            return true;
        }

        public void SaveFile()
        {
            SaveFile(ActiveFile.FilePath);
        }

        public void SaveFile(string path)
        {
            m_log.Write("Saving " + path);

            ActiveFile.FilePath = path;

            if (ActiveFile is StarboundDungeon)
                JsonParser.SerializeJson(path, (StarboundDungeon)ActiveFile);

            else if (ActiveFile is StarboundShip)
                JsonParser.SerializeJson(path, (StarboundShip)ActiveFile);
        }

        // clean up all resources
        public void CleanUpResource()
        {
            m_activeFile = null;
            BrushMap.Clear();
        }

        public StarboundAsset LoadAsset(string name, string rawType)
        {
            m_log.Write("Loading asset " + name + " of type " + rawType);

            StarboundAsset newAsset = null;
            string ext = EditorHelpers.GetExtensionFromBrushType(rawType);

            if ( ext == ".object" )
            {
                newAsset = EditorAssets.GetObject(name);
            }
            else if ( ext == ".material" )
            {
                newAsset = EditorAssets.GetMaterial(name);
            }

            return newAsset;
        }
    }
}