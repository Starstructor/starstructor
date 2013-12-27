using DungeonEditor.StarboundObjects.Objects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonEditor.EditorObjects
{
    public class EditorMap
    {
        [JsonIgnore]
        protected int m_width;

        [JsonIgnore]
        protected int m_height;

        [JsonIgnore]
        protected HashSet<List<int>>[,] m_collisionMap;

        [JsonIgnore]
        protected string m_name;

        [JsonIgnore]
        public int Width
        {
            get
            {
                return m_width;
            }
            set
            {
                m_width = value;
            }
        }

        [JsonIgnore]
        public int Height
        {
            get
            {
                return m_height;
            }
            set
            {
                m_height = value;
            }
        }

        [JsonProperty("name")]
        public string Name
        {
            get
            {
                return m_name;
            }
            set
            {
                m_name = value;
            }
        }

        public HashSet<List<int>> GetCollisionsAt(int x, int y)
        {
            if (x >= Width || x < 0 || y >= Height || y < 0 || m_collisionMap == null)
                return null;

            return m_collisionMap[x, y];
        }

        public HashSet<List<int>>[,] GetRawCollisionMap()
        {
            return m_collisionMap;
        }
    }
}
