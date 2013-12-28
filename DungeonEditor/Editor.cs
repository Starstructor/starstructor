using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using DungeonEditor.StarboundObjects.Dungeons;
using System.Diagnostics;
using System.Drawing;
using DungeonEditor.StarboundObjects;
using System.Windows.Forms;
using DungeonEditor.StarboundObjects.Tiles;
using Newtonsoft.Json.Linq;
using DungeonEditor.StarboundObjects.Objects;
using System.Text.RegularExpressions;
using DungeonEditor.StarboundObjects.Ships;
using DungeonEditor;
using DungeonEditor.EditorObjects;

namespace DungeonEditor
{
    public class Editor
    {
        // Editor variables
        private string m_name = Application.ProductName;
        private Version m_version = Assembly.GetExecutingAssembly().GetName().Version;
        private EditorFile m_activeFile = null;
        private List<string> m_assetDirContents = new List<string>();
        private static EditorSettings m_settings = null;
        private Logger m_log 
            = new Logger(Path.Combine(
                Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), 
                "log.txt"));

        // Dictionaries
        private Dictionary<List<byte>, EditorBrush> m_brushMap
            = new Dictionary<List<byte>, EditorBrush>(new ByteListEqualityComparer());

        private Dictionary<string, StarboundAsset> m_assetMap
            = new Dictionary<string, StarboundAsset>();

        // Public variables
        public Editor Instance { get { return this; } }
        public string Name { get { return m_name; } }
        public Version Version { get { return m_version; } }
        public List<string> DirContents { get { return m_assetDirContents; } }
        public const int DEFAULT_GRID_FACTOR = 8;
        public Logger Log { get { return m_log; } }

        // Maps from RGBA to a specific Tile
        public Dictionary<List<byte>, EditorBrush> BrushMap { get { return m_brushMap; } }

        // Maps from a material name to a tile
        public Dictionary<string, StarboundAsset> AssetMap { get { return m_assetMap; } }

        public EditorFile ActiveFile
        {
            get
            {
                return m_activeFile;
            }
            set
            {
                m_activeFile = value;
            }
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
                    StreamReader sr = new StreamReader(path);
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

        public void LoadFile(string path)
        {
            m_log.Write("Loading " + path);

            if (Path.GetExtension(path) == ".dungeon")
            {
                m_activeFile = new JsonParser(path).ParseJson<StarboundDungeon>();

                foreach (DungeonPart part in ((StarboundDungeon)m_activeFile).Parts)
                {
                    m_activeFile.ReadableParts.Add(part);
                }

                foreach (DungeonBrush brush in ((StarboundDungeon)m_activeFile).Tiles)
                {
                    m_activeFile.BlockMap.Add(brush);
                }
            }
            else if (Path.GetExtension(path) == ".structure")
            {
                m_activeFile = new JsonParser(path).ParseJson<StarboundShip>();

                foreach (ShipBrush brush in ((StarboundShip)m_activeFile).Brushes)
                {
                    m_activeFile.BlockMap.Add(brush);
                }
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
            if (Editor.Settings.AssetDirPath != null)
            {
                m_log.Write("Populating asset list with assets from assets folder at " + Editor.Settings.AssetDirPath);

                m_assetDirContents = Directory.EnumerateFiles(Editor.Settings.AssetDirPath, "*.*", SearchOption.AllDirectories)
                    .Where(s => s.EndsWith(".material") || s.EndsWith(".object") ||  
                                s.EndsWith(".frames") || s.EndsWith(".npctype")).ToList();

                string modDir = Path.Combine(Directory.GetParent(Editor.Settings.AssetDirPath).ToString(), "mods");

                if (Directory.Exists(modDir))
                {
                    m_log.Write("Populating asset list with assets from mod folder at " + modDir);

                    foreach (string path in (Directory.EnumerateFiles(modDir, "*.*", SearchOption.AllDirectories)
                        .Where(s => s.EndsWith(".material") || s.EndsWith(".object") ||
                                    s.EndsWith(".frames") || s.EndsWith(".npctype"))))
                    {
                        m_assetDirContents.Add(path);
                    }
                }
            }
        }
      
        public StarboundAsset LoadAsset(string name, string rawType)
        {
            m_log.Write("Loading asset " + name + " of type " + rawType);

            StarboundAsset newAsset = null;
            string ext = EditorHelpers.GetExtensionFromBrushType(rawType);
            string path = m_assetDirContents.Find(file => Path.GetFileName(file) == name + ext);

            if (path != null)
            {
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

                        Bitmap croppedBmp = imageAsBmp.Clone(new Rectangle(originX, originY, Editor.DEFAULT_GRID_FACTOR, Editor.DEFAULT_GRID_FACTOR), imageAsBmp.PixelFormat);
                        tempAsset.Image = (Image)croppedBmp;
                        tempAsset.AssetName = name + ext;
                    }
                    else
                    {
                        m_log.Write("Image for asset " + name + " at location " + imagePath + " not found!");
                    }

                    newAsset = (StarboundAsset)tempAsset;
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
                        else if (orientation.LeftImageName != null)
                        {
                            imageNameLeft = orientation.LeftImageName;
                        }
                        else if (orientation.RightImageName != null)
                        {
                            imageNameRight = orientation.RightImageName;
                        }
                        else if (orientation.ImageLayers != null)
                        {
                            // Potentially improve to use all image layers
                            imageName = orientation.ImageLayers.First().ImageName;
                        }

                        // Loading with separate right and left images
                        if (imageNameLeft != null && imageNameRight != null)
                        {
                            int leftIndex = imageNameLeft.LastIndexOf(".png");
                            int rightIndex = imageNameRight.LastIndexOf(".png");

                            if (leftIndex > 0)
                            {
                                imageNameLeft = imageNameLeft.Substring(0, leftIndex + 4);
                            }

                            if (rightIndex > 0)
                            {
                                imageNameRight = imageNameRight.Substring(0, rightIndex + 4);
                            }

                            string leftFramesPath = m_assetDirContents.Find(file => Path.GetFileName(file) == Path.GetFileNameWithoutExtension(imageNameLeft) + ".frames");
                            string rightFramesPath = m_assetDirContents.Find(file => Path.GetFileName(file) == Path.GetFileNameWithoutExtension(imageNameLeft) + ".frames");

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
                                int leftWidth = orientation.LeftFrames.FrameGrid.Size[0];
                                int leftHeight = orientation.LeftFrames.FrameGrid.Size[1];

                                // Load the image
                                Image tempImage = EditorHelpers.LoadImageFromFile(leftPath);
                                Bitmap imageAsBmp = new Bitmap(tempImage);

                                // Crop the image (remove any animation frames)
                                Bitmap croppedBmp = imageAsBmp.Clone(new Rectangle(0, 0, leftWidth, leftHeight), imageAsBmp.PixelFormat);

                                orientation.LeftImage = (Image)croppedBmp;
                            }
                            else
                            {
                                m_log.Write("Left image for asset " + name + " at location " + leftPath + " not found!");
                            }

                            // Load the right image
                            if (File.Exists(rightPath) && orientation.RightFrames != null)
                            {
                                int rightWidth = orientation.RightFrames.FrameGrid.Size[0];
                                int rightHeight = orientation.RightFrames.FrameGrid.Size[1];

                                // Load the image
                                Image tempImage = EditorHelpers.LoadImageFromFile(rightPath);
                                Bitmap imageAsBmp = new Bitmap(tempImage);

                                // Crop the image (remove any animation frames)
                                Bitmap croppedBmp = imageAsBmp.Clone(new Rectangle(0, 0, rightWidth, rightHeight), imageAsBmp.PixelFormat);

                                orientation.RightImage = (Image)croppedBmp;
                            }
                            else
                            {
                                m_log.Write("Right image for asset " + name + " at location " + rightPath + " not found!");
                            }
                        }
                        // Loading with just one image
                        else if (imageName != null)
                        {
                            int index = imageName.LastIndexOf(".png");

                            if (index > 0)
                            {
                                imageName = imageName.Substring(0, index + 4);
                            }

                            // If the frames file is in our asset list
                            string framesPath = m_assetDirContents.Find(file => Path.GetFileName(file) == Path.GetFileNameWithoutExtension(imageName) + ".frames");

                            if (framesPath == null)
                                return null;

                            // Find the frames associated with this object
                            orientation.RightFrames = new JsonParser(framesPath).ParseJson<ObjectFrames>();
                            orientation.LeftFrames = orientation.RightFrames;

                            if (orientation.RightFrames == null)
                                return null;

                            // Get the size of the asset
                            int width = orientation.RightFrames.FrameGrid.Size[0];
                            int height = orientation.RightFrames.FrameGrid.Size[1];

                            string imagePath = Path.Combine(Path.GetDirectoryName(path), imageName);

                            if (File.Exists(imagePath) && orientation.RightFrames != null)
                            {
                                // Load the image
                                Image tempImage = EditorHelpers.LoadImageFromFile(imagePath);
                                Bitmap imageAsBmp = new Bitmap(tempImage);

                                // Crop the image (remove any animation frames)
                                Bitmap croppedBmp = imageAsBmp.Clone(new Rectangle(0, 0, width, height), imageAsBmp.PixelFormat);

                                // The right image (default) is the one we load
                                orientation.RightImage = (Image)croppedBmp;

                                // The left image is a flipped version of the right
                                orientation.LeftImage = (Bitmap)orientation.RightImage.Clone();
                                orientation.LeftImage.RotateFlip(RotateFlipType.Rotate180FlipY);
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
                    newAsset = (StarboundAsset)sbObject;
                }
                else if (ext == ".npctype")
                {

                }
            }

            return newAsset;
        }
    }
}
