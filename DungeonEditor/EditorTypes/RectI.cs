/*Starstructor, the Starbound Toolet 
Copyright (C) 2013-2014 Chris Stamford
Contact: cstamford@gmail.com

Source file contributers:
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
using Newtonsoft.Json;

namespace DungeonEditor.EditorTypes
{
    public struct RectI
    {
        public int left, top, right, bottom;

        public RectI(int left = 0, int top = 0, int right = 0, int bottom = 0)
        {
            this.left = left;
            this.top = top;
            this.right = right;
            this.bottom = bottom;
        }

        public override string ToString()
        {
            return "(" + left + ", " + top + ", " + right + ", " + bottom + ")";
        }

        public class Serializer : JsonConverter
        {
            public override bool CanConvert(Type objectType)
            {
                return objectType == typeof(RectI);
            }

            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                List<int> result = serializer.Deserialize<List<int>>(reader);
                if (result == null || result.Count != 4)
                    return null;

                return new RectI(result[0], result[1], result[2], result[3]);
            }

            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                List<int> output = new List<int> { 0, 0, 0, 0 };
                if (value is RectI)
                {
                    RectI vec = (RectI)value;
                    output[0] = vec.left;
                    output[1] = vec.top;
                    output[2] = vec.right;
                    output[3] = vec.bottom;
                }
                serializer.Serialize(writer, output);
            }
        }
    }
}
