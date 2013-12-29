/*Starstructor, the Starbound Toolet
Copyright (C) 2013-2014  Chris Stamford
Contact: cstamford@gmail.com

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

using System.IO;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace DungeonEditor
{
    public class JsonParser
    {
        private readonly string m_path;

        public JsonParser(string path)
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

            var file = new StreamReader(m_path);
            string rawJson = file.ReadToEnd();
            file.Close();

            // Trim any commented lines and return formatted json
            return Regex.Replace(rawJson, "//(.*?)\r?\n", "");
        }
    }
}