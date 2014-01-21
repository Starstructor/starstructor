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
using System.Drawing;
using Newtonsoft.Json;

namespace Starstructor
{
    public class ColorSerializer : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Color);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            List<byte> result = serializer.Deserialize< List<byte> >(reader);
            if (result == null || result.Count < 3 || result.Count > 4)
                return null;

            int r=0, g=0, b=0, a=255;
            if ( result.Count >= 3 )
            {
                r = result[0];
                g = result[1];
                b = result[2];
                if (result.Count > 3)
                    a = result[3];
            }
            return Color.FromArgb(a, r, g, b);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            List<byte> output = new List<byte>{ 0, 0, 0, 255 };
            if ( value is Color )
            {
                Color c = (Color)value;
                output[0] = c.R;
                output[1] = c.G;
                output[2] = c.B;
                output[3] = c.A;
            }
            serializer.Serialize(writer, output);
        }
    }
}
