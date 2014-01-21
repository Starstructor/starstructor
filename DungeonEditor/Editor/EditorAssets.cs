using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DungeonEditor.StarboundObjects.Objects;
using DungeonEditor.StarboundObjects.Tiles;
using System.IO;
using System.Threading;

namespace DungeonEditor.Editor
{
    public static class EditorAssets
    {
        private static readonly Dictionary<string, StarboundObject> m_objectMap
            = new Dictionary<string, StarboundObject>();

        private static readonly Dictionary<string, StarboundTile> m_materialMap
            = new Dictionary<string, StarboundTile>();

        private static Thread m_worker = null;

        public static void RefreshAssets()
        {
            try
            {
                if (m_worker != null)
                    m_worker.Abort();
            }
            catch   // Abort() threw an exception, in which case it's probably already terminated
            { }

            // Check for asset path
            if (Editor.Settings.AssetDirPath == null)
            {
                System.Windows.Forms.MessageBox.Show("Asset directory not specified.");
                return;
            }

            m_worker = new Thread(RefreshAssetsBackground);
            
            m_objectMap.Clear();
            m_materialMap.Clear();

            m_worker.Start();
        }

        public static StarboundObject GetObject(string name)
        {
            // Block until assets fully loaded
            if (m_worker != null)
                m_worker.Join();

            if (m_objectMap.ContainsKey(name))
                return m_objectMap[name];

            Editor.Log.Write("Unable to retrieve object " + name);
            return null;
        }

        public static StarboundTile GetMaterial(string name)
        {
            // Block until assets fully loaded
            if (m_worker != null)
                m_worker.Join();

            if (m_materialMap.ContainsKey(name))
                return m_materialMap[name];

            Editor.Log.Write("Unable to retrieve material " + name);
            return null;
        }

        private static void RefreshAssetsBackground()
        {
            // Scan directory based on path
            // Update this to include any mod folders
            List<string> directories = new List<String>() { Editor.Settings.ModsDirPath, Editor.Settings.AssetDirPath };

            foreach (string path in directories)
            {
                foreach (var file in Directory.EnumerateFiles(path, "*.object", SearchOption.AllDirectories))
                {
                    StarboundObject sbObject = new JsonParser(file).ParseJson<StarboundObject>();
                    if (m_objectMap.ContainsKey(sbObject.ObjectName))
                        continue;

                    m_objectMap[sbObject.ObjectName] = sbObject;
                    sbObject.FullPath = file;
                    sbObject.InitializeAssets();
                }

                foreach (var file in Directory.EnumerateFiles(path, "*.material", SearchOption.AllDirectories))
                {
                    StarboundTile sbMaterial = new JsonParser(file).ParseJson<StarboundTile>();
                    if (m_materialMap.ContainsKey(sbMaterial.MaterialName))
                        continue;

                    m_materialMap[sbMaterial.MaterialName] = sbMaterial;
                    sbMaterial.FullPath = file;
                    sbMaterial.InitializeAssets();
                }
            }
        }
    }
}
