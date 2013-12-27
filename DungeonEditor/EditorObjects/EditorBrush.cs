using DungeonEditor.StarboundObjects;
using DungeonEditor.StarboundObjects.Objects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonEditor.EditorObjects
{
    public enum ObjectDirection
    {
        DIRECTION_NONE,
        DIRECTION_LEFT,
        DIRECTION_RIGHT,
        DIRECTION_ANCHORED
    }

    public class EditorBrush
    {
        [JsonIgnore]
        protected StarboundAsset m_frontAsset;

        [JsonIgnore]
        protected StarboundAsset m_backAsset;

        [JsonIgnore]
        protected bool m_needsFrontAsset;

        [JsonIgnore]
        protected bool m_needsBackAsset;

        [JsonIgnore]
        protected bool m_isSpecial;

        [JsonIgnore]
        protected ObjectDirection m_direction;

        [JsonIgnore]
        protected List<string> m_brushTypes = new List<string>();

        [JsonIgnore]
        protected List<string> m_brushRules = new List<string>();

        [JsonIgnore]
        protected string m_comment;

        [JsonIgnore]
        protected List<byte> m_colourKey = new List<byte>();

        [JsonIgnore]
        public StarboundAsset FrontAsset
        {
            get
            {
                return m_frontAsset;
            }
            set
            {
                m_frontAsset = value;
            }
        }

        [JsonIgnore]
        public StarboundAsset BackAsset
        {
            get
            {
                return m_backAsset;
            }
            set
            {
                m_backAsset = value;
            }
        }

        [JsonIgnore]
        public bool NeedsFrontAsset
        {
            get
            {
                return m_needsFrontAsset;
            }
            set
            {
                m_needsFrontAsset = true;
            }
        }

        [JsonIgnore]
        public bool NeedsBackAsset
        {
            get
            {
                return m_needsBackAsset;
            }
            set
            {
                m_needsBackAsset = true;
            }
        }

        [JsonIgnore]
        public bool IsSpecial
        {
            get
            {
                return m_isSpecial;
            }
            set
            {
                m_isSpecial = true;
            }
        }


        [JsonIgnore]
        public ObjectDirection Direction
        {
            get
            {
                return m_direction;
            }
            set
            {
                m_direction = value;
            }
        }


        [JsonIgnore]
        public List<string> BrushTypes
        {
            get
            {
                return m_brushTypes;
            }
            set
            {
                m_brushTypes = value;
            }
        }

        [JsonIgnore]
        public List<string> BrushRules
        {
            get
            {
                return m_brushRules;
            }
            set
            {
                m_brushRules = value;
            }
        }

        public virtual string Comment
        {
            get
            {
                return m_comment;
            }
            set
            {
                m_comment = value;
            }
        }

        public virtual List<byte> Colour
        {
            get
            {
                return m_colourKey;
            }
            set
            {
                m_colourKey = value;
            }
        }
    }
}
