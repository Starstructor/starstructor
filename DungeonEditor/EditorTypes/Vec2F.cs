using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Newtonsoft.Json;

namespace DungeonEditor.EditorTypes
{
    [ReadOnly(true)]
    public struct Vec2F
    {
        private double m_x, m_y;

        public double x
        { 
            get { return m_x; } 
            set { m_x = value; } 
        }
        public double y
        {
            get { return m_y; }
            set { m_y = value; }
        }

        public Vec2F(double x_ = 0, double y_ = 0)
        {
            m_x = x_;
            m_y = y_;
        }
        public Vec2F(List<double> source)
        {
            m_x = 0;
            if (source.Count > 0)
                m_x = source[0];

            m_y = 0;
            if (source.Count > 1)
                m_y = source[1];
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
