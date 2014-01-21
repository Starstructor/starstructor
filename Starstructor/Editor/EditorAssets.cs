/*Starstructor, the Starbound Toolet 
Copyright (C) 2013-2014 Chris Stamford
Contact: cstamford@gmail.com

Source file contributers:
 Adam Heinermann    contact: aheinerm@gmail.com
 Chris Stamford     contact: cstamford@gmail.com

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
using Starstructor.StarboundObjects.Objects;
using Starstructor.StarboundObjects.Tiles;
using System.IO;
using System.Threading;

namespace Starstructor.Editor
{
    public static class EditorAssets
    {
        private static readonly Dictionary<string, StarboundObject> m_objectMap
            = new Dictionary<string, StarboundObject>();

        private static readonly Dictionary<string, StarboundMaterial> m_materialMap
            = new Dictionary<string, StarboundMaterial>();

        private static Thread m_worker = null;

        public static void RefreshAssets()
        {
            try
            {
                if (m_worker != null)
                    m_worker.Abort();
            }
            catch (Exception e)// Abort() threw an exception, in which case it's probably already terminated
            {
                Editor.Log.Write(e.Message);
            }

            // Check for asset path
            if (Editor.Settings.AssetDirPath == null)
            {
                System.Windows.Forms.MessageBox.Show("Asset directory not specified.");
                return;
            }

            m_worker = new Thread(RefreshAssetsBackground);
            
            m_objectMap.Clear();
            m_materialMap.Clear();

            Editor.Log.Write("Asset loading thread started");
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

        public static StarboundMaterial GetMaterial(string name)
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

            // remove directories that do not exist
            for (int i = directories.Count; i != 0; --i)
            {
                if (!Directory.Exists(directories[i - 1]))
                    directories.RemoveAt(i - 1);
            }

            // Iterate through directories 
            foreach (string path in directories)
            {
                foreach (string file in Directory.EnumerateFiles(path, "*.object", SearchOption.AllDirectories))
                {
                    StarboundObject sbObject = JsonParser.ParseJson<StarboundObject>(file);

                    if (m_objectMap.ContainsKey(sbObject.ObjectName))
                        continue;

                    m_objectMap[sbObject.ObjectName] = sbObject;
                    sbObject.FullPath = file;
                    sbObject.InitializeAssets();
                }

                foreach (string file in Directory.EnumerateFiles(path, "*.material", SearchOption.AllDirectories))
                {
                    StarboundMaterial sbMaterial = JsonParser.ParseJson<StarboundMaterial>(file);

                    if (m_materialMap.ContainsKey(sbMaterial.MaterialName))
                        continue;

                    m_materialMap[sbMaterial.MaterialName] = sbMaterial;
                    sbMaterial.FullPath = file;
                    sbMaterial.InitializeAssets();
                }
            }

            Editor.Log.Write("Asset loading thread ended");
        }
    }
}
