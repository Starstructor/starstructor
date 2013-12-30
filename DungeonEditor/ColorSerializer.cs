using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Newtonsoft.Json;

namespace DungeonEditor
{
    public class ColorSerializer : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return true;    // not sure
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            List<byte> result = serializer.Deserialize< List<byte> >(reader);

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
