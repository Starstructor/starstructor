using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DungeonEditor.StarboundObjects.Objects;
using DungeonEditor.StarboundObjects.Tiles;
using System.IO;

namespace DungeonEditor.Editor
{
    public static class EditorAssets
    {
        private static Dictionary<string, StarboundObject> g_ObjectMap
            = new Dictionary<string, StarboundObject>();

        private static Dictionary<string, StarboundTile> g_MaterialMap
            = new Dictionary<string, StarboundTile>();

        public static void RefreshAssets()
        {
            g_ObjectMap.Clear();
            g_MaterialMap.Clear();

            if (Editor.Settings.AssetDirPath == null)
            {
                System.Windows.Forms.MessageBox.Show("Asset directory not specified.");
                return;
            }

            // Scan directory based on path
            // Update this to include any mod folders
            string baseDir = Editor.Settings.AssetDirPath;
            string modDir = Path.Combine(Directory.GetParent(baseDir).ToString(), "mods");

            List<string> directories = new List<String>() { modDir, baseDir };

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
