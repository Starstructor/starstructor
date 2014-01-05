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
        private static Dictionary<string, StarboundObject> g_ObjectMap
            = new Dictionary<string, StarboundObject>();

        private static Dictionary<string, StarboundTile> g_MaterialMap
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
            
            g_ObjectMap.Clear();
            g_MaterialMap.Clear();

            m_worker.Start();
        }
        public static void RefreshAssetsBackground()
        {
            // Scan directory based on path
            // Update this to include any mod folders
            List<string> directories = new List<String>() { Editor.Settings.ModsDirPath, Editor.Settings.AssetDirPath };

            foreach (string path in directories)
            {
                foreach (var file in Directory.EnumerateFiles(path, "*.object", SearchOption.AllDirectories))
                {
                    StarboundObject sbObject = new JsonParser(file).ParseJson<StarboundObject>();
                    if (g_ObjectMap.ContainsKey(sbObject.ObjectName))
                        continue;

                    g_ObjectMap[sbObject.ObjectName] = sbObject;
                    sbObject.FullPath = file;
                    sbObject.InitializeAssets();
                }

                foreach (var file in Directory.EnumerateFiles(path, "*.material", SearchOption.AllDirectories))
                {
                    StarboundTile sbMaterial = new JsonParser(file).ParseJson<StarboundTile>();
                    if (g_MaterialMap.ContainsKey(sbMaterial.MaterialName))
                        continue;

                    g_MaterialMap[sbMaterial.MaterialName] = sbMaterial;
                    sbMaterial.FullPath = file;
                    sbMaterial.InitializeAssets();
                }
            }
        }


        public static StarboundObject GetObject(string name)
        {
            if (m_worker != null)
                m_worker.Join();

            if ( !g_ObjectMap.ContainsKey(name) )
            {
                RefreshAssets();
                if (!g_ObjectMap.ContainsKey(name))
                {
                    System.Windows.Forms.MessageBox.Show("There was a problem retrieving an object called " + name);
                    return null;
                }
            }
            return g_ObjectMap[name];
        }

        public static StarboundTile GetMaterial(string name)
        {
            if (m_worker != null)
                m_worker.Join();

            if ( !g_MaterialMap.ContainsKey(name) )
            {
                RefreshAssets();
                if (!g_MaterialMap.ContainsKey(name))
                {
                    System.Windows.Forms.MessageBox.Show("There was a problem retrieving a material called " + name);
                    return null;
                }
            }
            return g_MaterialMap[name];
        }

    }
}
