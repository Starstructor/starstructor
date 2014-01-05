using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
