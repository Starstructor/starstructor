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
using System.ComponentModel;
using Newtonsoft.Json;

namespace Starstructor.Data
{
    [ReadOnly(true)]
    public struct Vec2F
    {
        public double x, y;

        public Vec2F(double x = 0, double y = 0)
        {
            this.x = x;
            this.y = y;
        }

        public override string ToString()
        {
            return "(" + x + ", " + y + ")";
        }

        public class Serializer : JsonConverter
        {
            public override bool CanConvert(Type objectType)
            {
                return objectType == typeof(Vec2F);
            }

            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                List<double> result = serializer.Deserialize<List<double>>(reader);
                if (result == null || result.Count != 2)
                    return null;

                return new Vec2F(result[0], result[1]);
            }

            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                List<double> output = new List<double> { 0, 0 };
                if ( value is Vec2F )
                {
                    Vec2F vec = (Vec2F)value;
                    output[0] = vec.x;
                    output[1] = vec.y;
                }
                serializer.Serialize(writer, output);
            }
        }
    }
}
