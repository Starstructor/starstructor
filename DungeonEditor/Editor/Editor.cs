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
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using DungeonEditor.EditorObjects;
using DungeonEditor.StarboundObjects;
using DungeonEditor.StarboundObjects.Dungeons;
using DungeonEditor.StarboundObjects.Objects;
using DungeonEditor.StarboundObjects.Ships;
using DungeonEditor.StarboundObjects.Tiles;
using Newtonsoft.Json;

namespace DungeonEditor.Editor
{
    public class Editor
    {
        // Editor variables
        public const int DEFAULT_GRID_FACTOR = 8;
        private static EditorSettings m_settings;

        private readonly Dictionary<string, StarboundAsset> m_assetMap
            = new Dictionary<string, StarboundAsset>();

        private readonly Dictionary<Color, EditorBrush> m_brushMap
            = new Dictionary<Color, EditorBrush>();

        private static readonly Logger m_log
            = new Logger(Path.Combine(
                Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                "log.txt"));

        private readonly string m_name = Application.ProductName;
        private readonly Version m_version = Assembly.GetExecutingAssembly().GetName().Version;
        private EditorFile m_activeFile;
        private List<string> m_assetDirContents = new List<string>();

        // Public variables
        public string Name
        {
            get { return m_name; }
        }

        public Version Version
        {
            get { return m_version; }
        }

        public List<string> DirContents
        {
            get { return m_assetDirContents; }
        }

        public static Logger Log
        {
            get { return m_log; }
        }

        // Maps from RGBA to a specific Tile
        public Dictionary<Color, EditorBrush> BrushMap
        {
            get { return m_brushMap; }
        }

        // Maps from a material name to a tile
        public Dictionary<string, StarboundAsset> AssetMap
        {
            get { return m_assetMap; }
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
                    File.AppendAllText(path, JsonConvert.SerializeObject(m_settings, Formatting.Indented));
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
                Editor.Settings.RecentFiles.Remove(path);
                return false;
            }

            if (Path.GetExtension(path) == ".dungeon")
            {
                m_activeFile = new JsonParser(path).ParseJson<StarboundDungeon>();

                m_log.Write("  Parsing " + ((StarboundDungeon)m_activeFile).Parts.Count + " parts");
                m_activeFile.ReadableParts.AddRange(((StarboundDungeon)m_activeFile).Parts);
                
                m_log.Write("  Parsing " + ((StarboundDungeon)m_activeFile).Tiles.Count + " brushes");
                m_activeFile.BlockMap.AddRange(((StarboundDungeon)m_activeFile).Tiles);
            }
            else if (Path.GetExtension(path) == ".structure")
            {
                m_activeFile = new JsonParser(path).ParseJson<StarboundShip>();

                m_log.Write("  Parsing " + ((StarboundShip)m_activeFile).Brushes.Count + " brushes");
                m_activeFile.BlockMap.AddRange(((StarboundShip) m_activeFile).Brushes);
            }

            if (m_activeFile == null)
            {
                m_log.Write("Failed to parse " + path);
                return false;
            }

            ActiveFile.FilePath = path;
            ScanAssetDirectory();
            ActiveFile.GenerateBrushAndAssetMaps(this);
            ActiveFile.LoadParts(this);

            m_log.Write("Completed parsing " + path);
            Editor.Settings.RecentFiles.Remove(path);
            Editor.Settings.RecentFiles.Insert(0, path);    // Insert the newest element at the beginning
            while (Editor.Settings.RecentFiles.Count > 10)  // Remove last elements over the max number of recent files
                Editor.Settings.RecentFiles.RemoveAt(Editor.Settings.RecentFiles.Count - 1);
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
            File.Delete(path);
            if (ActiveFile is StarboundDungeon)
            {
                JsonParser parser = new JsonParser(path);
                parser.SerializeJson<StarboundDungeon>((StarboundDungeon)ActiveFile);
            }
            else if (ActiveFile is StarboundShip)
            {
                JsonParser parser = new JsonParser(path);
                parser.SerializeJson<StarboundShip>((StarboundShip)ActiveFile);
            }
        }

        // clean up all resources
        public void CleanUpResource()
        {
            m_activeFile = null;
            m_assetDirContents.Clear();
            BrushMap.Clear();
            AssetMap.Clear();
        }

        public void ScanAssetDirectory()
        {
            // Scan directory based on path
            // Update this to include any mod folders
            if (Settings.AssetDirPath == null) 
                return;

            string baseDir = Settings.AssetDirPath;
            string modDir = Path.Combine(Directory.GetParent(baseDir).ToString(), "mods");

            List<string> directories = new List<String>() {baseDir, modDir};

            foreach (string path in directories)
            {
                if (!Directory.Exists(path))
                {
                    m_log.Write("Directory doesn't exist at " + path + ", unable to search for assets");
                    return;
                }

                m_log.Write("Populating asset list with assets from " + path);

                m_assetDirContents.AddRange((Directory.EnumerateFiles(path, "*.*", SearchOption.AllDirectories)
                    .Where(s => s.EndsWith(".material") || s.EndsWith(".object") ||
                                s.EndsWith(".frames") || s.EndsWith(".npctype"))));
            }
        }

        public StarboundAsset LoadAsset(string name, string rawType)
        {
            m_log.Write("Loading asset " + name + " of type " + rawType);

            StarboundAsset newAsset = null;
            string ext = EditorHelpers.GetExtensionFromBrushType(rawType);
            string path = m_assetDirContents.Find(file => Path.GetFileName(file) == name + ext);

            if (path == null) 
                return null;

            if (ext == ".material")
            {
                StarboundTile tempAsset = new JsonParser(path).ParseJson<StarboundTile>();

                int originX = 0;
                int originY = 0;
                string imagePath = null;

                if (tempAsset.Platform)
                {
                    imagePath = Path.Combine(Path.GetDirectoryName(path), tempAsset.PlatformImage);
                    originX = 24;
                }
                else
                {
                    imagePath = Path.Combine(Path.GetDirectoryName(path), tempAsset.Frames);
                    originX = 4;
                    originY = 12;
                }

                if (File.Exists(imagePath))
                {
                    Image tempImage = EditorHelpers.LoadImageFromFile(imagePath);
                    Bitmap imageAsBmp = new Bitmap(tempImage);

                    Bitmap croppedBmp =
                        imageAsBmp.Clone(new Rectangle(originX, originY, DEFAULT_GRID_FACTOR, DEFAULT_GRID_FACTOR),
                            imageAsBmp.PixelFormat);

                    tempAsset.Image = croppedBmp;
                    tempAsset.AssetName = name + ext;

                    m_log.Write("  Image loaded at " + imagePath);
                }
                else
                {
                    m_log.Write("Image for asset " + name + " at location " + imagePath + " not found!");
                }

                newAsset = tempAsset;
            }

            // four types of objects:
            //   1. With ImageName
            //   2. With DualImageName
            //   3. With LeftImage and RightImage
            //   4. With ImageLayers
            else if (ext == ".object")
            {
                StarboundObject sbObject = new JsonParser(path).ParseJson<StarboundObject>();
                sbObject.AssetName = name + ext;

                foreach (ObjectOrientation orientation in sbObject.Orientations)
                {
                    string imageName = null;
                    string imageNameLeft = null;
                    string imageNameRight = null;

                    if (orientation.ImageName != null)
                    {
                        imageName = orientation.ImageName;
                    }
                    else if (orientation.DualImageName != null)
                    {
                        imageName = orientation.DualImageName;
                    }
                    else if (orientation.LeftImageName != null || orientation.RightImageName != null)
                    {
                        if (orientation.LeftImageName != null)
                        {
                            imageNameLeft = orientation.LeftImageName;
                        }

                        if (orientation.RightImageName != null)
                        {
                            imageNameRight = orientation.RightImageName;
                        }
                    }
                    else if (orientation.ImageLayers != null)
                    {
                        // Potentially improve to use all image layers
                        imageName = orientation.ImageLayers.First().ImageName;
                    }

                    // Loading with separate right and left images
                    if (imageNameLeft != null && imageNameRight != null)
                    {
                        int leftIndex = imageNameLeft.LastIndexOf(".png", StringComparison.Ordinal);
                        int rightIndex = imageNameRight.LastIndexOf(".png", StringComparison.Ordinal);

                        if (leftIndex > 0)
                        {
                            imageNameLeft = imageNameLeft.Substring(0, leftIndex + 4);
                        }

                        if (rightIndex > 0)
                        {
                            imageNameRight = imageNameRight.Substring(0, rightIndex + 4);
                        }

                        string leftFramesPath =
                            m_assetDirContents.Find(
                                file =>
                                    Path.GetFileName(file) ==
                                    Path.GetFileNameWithoutExtension(imageNameLeft) + ".frames");

                        string rightFramesPath =
                            m_assetDirContents.Find(
                                file =>
                                    Path.GetFileName(file) ==
                                    Path.GetFileNameWithoutExtension(imageNameRight) + ".frames");

                        if (leftFramesPath != null)
                        {
                            orientation.LeftFrames = new JsonParser(leftFramesPath).ParseJson<ObjectFrames>();
                        }

                        if (rightFramesPath != null)
                        {
                            orientation.RightFrames = new JsonParser(rightFramesPath).ParseJson<ObjectFrames>();
                        }

                        string leftPath = Path.Combine(Path.GetDirectoryName(path), imageNameLeft);
                        string rightPath = Path.Combine(Path.GetDirectoryName(path), imageNameRight);

                        // Load the left image
                        if (File.Exists(leftPath) && orientation.LeftFrames != null)
                        {
                            int leftWidth = orientation.LeftFrames.FrameGrid.Size.x;
                            int leftHeight = orientation.LeftFrames.FrameGrid.Size.y;

                            // Load the image
                            Image tempImage = EditorHelpers.LoadImageFromFile(leftPath);
                            Bitmap imageAsBmp = new Bitmap(tempImage);

                            // Crop the image (remove any animation frames)
                            Bitmap croppedBmp = imageAsBmp.Clone(new Rectangle(0, 0, leftWidth, leftHeight),
                                imageAsBmp.PixelFormat);

                            orientation.LeftImage = croppedBmp;

                            m_log.Write("  Left image loaded at " + leftPath);
                        }
                        else
                        {
                            m_log.Write("  Left image for asset " + name + " at location " + leftPath + "" +
                                        " not found!");
                        }

                        // Load the right image
                        if (File.Exists(rightPath) && orientation.RightFrames != null)
                        {
                            int rightWidth = orientation.RightFrames.FrameGrid.Size.x;
                            int rightHeight = orientation.RightFrames.FrameGrid.Size.y;

                            // Load the image
                            Image tempImage = EditorHelpers.LoadImageFromFile(rightPath);
                            Bitmap imageAsBmp = new Bitmap(tempImage);

                            // Crop the image (remove any animation frames)
                            Bitmap croppedBmp = imageAsBmp.Clone(new Rectangle(0, 0, rightWidth, rightHeight),
                                imageAsBmp.PixelFormat);

                            orientation.RightImage = croppedBmp;

                            m_log.Write("  Right image loaded at " + rightPath);
                        }
                        else
                        {
                            m_log.Write("  Right image for asset " + name + " at location " + rightPath +
                                        " not found!");
                        }
                    }
                    // Loading with just one image
                    else if (imageName != null)
                    {
                        int index = imageName.LastIndexOf(".png", StringComparison.Ordinal);

                        if (index > 0)
                        {
                            imageName = imageName.Substring(0, index + 4);
                        }

                        // If the frames file is in our asset list
                        string framesPath =
                            m_assetDirContents.Find(
                                file =>
                                    Path.GetFileName(file) ==
                                    Path.GetFileNameWithoutExtension(imageName) + ".frames");

                        if (framesPath == null)
                            return null;

                        // Find the frames associated with this object
                        orientation.RightFrames = new JsonParser(framesPath).ParseJson<ObjectFrames>();
                        orientation.LeftFrames = orientation.RightFrames;

                        if (orientation.RightFrames == null)
                            return null;

                        // Get the size of the asset
                        int width = orientation.RightFrames.FrameGrid.Size.x;
                        int height = orientation.RightFrames.FrameGrid.Size.y;

                        string imagePath = Path.Combine(Path.GetDirectoryName(path), imageName);

                        if (File.Exists(imagePath) && orientation.RightFrames != null)
                        {
                            // Load the image
                            Image tempImage = EditorHelpers.LoadImageFromFile(imagePath);
                            Bitmap imageAsBmp = new Bitmap(tempImage);

                            // Crop the image (remove any animation frames)
                            Bitmap croppedBmp = imageAsBmp.Clone(new Rectangle(0, 0, width, height),
                                imageAsBmp.PixelFormat);

                            // The right image (default) is the one we load
                            orientation.RightImage = croppedBmp;

                            // The left image is a flipped version of the right
                            orientation.LeftImage = (Bitmap) orientation.RightImage.Clone();
                            orientation.LeftImage.RotateFlip(RotateFlipType.Rotate180FlipY);

                            m_log.Write("  Image loaded at " + imagePath);
                        }
                        else
                        {
                            m_log.Write("Image for asset " + name + " at location " + imagePath + " not found!");
                        }
                    }
                    // No image has been found, this isn't a valid object, leave
                    else
                    {
                        return null;
                    }
                }

                // The default image will just be the first orientation's default image
                sbObject.Image = sbObject.Orientations[0].RightImage;
                newAsset = sbObject;
            }
            else if (ext == ".npctype")
            {
            }

            return newAsset;
        }
    }
}