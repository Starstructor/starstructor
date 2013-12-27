using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Newtonsoft.Json;
using DungeonEditor.StarboundObjects.Dungeons;
using DungeonEditor.StarboundObjects.Tiles;

namespace DungeonEditor
{
    class JsonParser
    {
        private string m_path;

        public JsonParser (string path)
        {
            m_path = path;
        }

        public T ParseJson<T>()
        {
            return JsonConvert.DeserializeObject<T>(GetFormattedJson());
        }

        // todo
        public bool SerializeJson<T>(T obj)
        {
            File.AppendAllText(m_path, JsonConvert.SerializeObject(obj, Formatting.Indented));
            return false;
        }

        private string GetFormattedJson()
        {
            if (m_path == null)
                return null;

            StreamReader file = new StreamReader(m_path);
            string rawJson = file.ReadToEnd();
            file.Close();

            // Trim any commented lines and return formatted json
            return Regex.Replace(rawJson, "//(.*?)\r?\n", "");
        }
    }
}
