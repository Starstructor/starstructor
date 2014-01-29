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
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Starstructor.Data
{
    public class JsonParser
    {
        private readonly static JsonSerializerSettings settings = new JsonSerializerSettings()
        {
            NullValueHandling = NullValueHandling.Ignore,
            //DefaultValueHandling = DefaultValueHandling.Ignore,
            Formatting = Formatting.Indented,
            
            Converters = new List<JsonConverter> { 
                //new ColorSerializer(),     // Color object already handled internally, not sure how to replace
                new Vec2F.Serializer(),
                new Vec2I.Serializer(),
                new RectI.Serializer()
            }
        }; 

        public static T ParseJson<T>(string path)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(GetFormattedJson(path), settings);
            }
            catch (Exception e)
            {
                Editor.Log.Write(e.Message);
                return default(T);
            }
        }

        public static void SerializeJson<T>(string path, T obj)
        {
            try
            {
                string json = JsonConvert.SerializeObject(obj, settings);
                File.WriteAllText(path, json);
            }
            catch (Exception e)
            {
                Editor.Log.Write(e.Message);
                MessageBox.Show("Failed to save file " + path + ", please try again! Consult the log file for more information.");
            }
        }

        private static string GetFormattedJson(string path)
        {
            if (path == null)
                return null;

            StreamReader file = new StreamReader(path);
            string rawJson = file.ReadToEnd();
            file.Close();

            // Trim any commented lines and return formatted json
            return Regex.Replace(rawJson, "//(.*?)\r?\n", "");
        }
    }
}