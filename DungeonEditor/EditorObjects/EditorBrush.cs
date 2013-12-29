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

using System.Collections.Generic;
using DungeonEditor.StarboundObjects;
using Newtonsoft.Json;
using System.ComponentModel;

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
        [JsonIgnore] protected StarboundAsset m_backAsset;

        [JsonIgnore] protected List<string> m_brushRules = new List<string>();
        [JsonIgnore] protected List<string> m_brushTypes = new List<string>();

        [JsonIgnore] protected List<byte> m_colourKey = new List<byte>();
        [JsonIgnore] protected string m_comment;
        [JsonIgnore] protected ObjectDirection m_direction;
        [JsonIgnore] protected StarboundAsset m_frontAsset;
        [JsonIgnore] protected bool m_isSpecial;
        [JsonIgnore] protected bool m_needsBackAsset;
        [JsonIgnore] protected bool m_needsFrontAsset;

        [JsonIgnore, Browsable(false)]
        public StarboundAsset FrontAsset
        {
            get { return m_frontAsset; }
            set { m_frontAsset = value; }
        }

        [JsonIgnore, Browsable(false)]
        public StarboundAsset BackAsset
        {
            get { return m_backAsset; }
            set { m_backAsset = value; }
        }

        [JsonIgnore, Browsable(false)]
        public bool NeedsFrontAsset
        {
            get { return m_needsFrontAsset; }
            set { m_needsFrontAsset = value; }
        }

        [JsonIgnore, Browsable(false)]
        public bool NeedsBackAsset
        {
            get { return m_needsBackAsset; }
            set { m_needsBackAsset = value; }
        }

        [JsonIgnore, ReadOnly(true)]
        public bool IsSpecial
        {
            get { return m_isSpecial; }
            set { m_isSpecial = value; }
        }


        [JsonIgnore, ReadOnly(true)]
        public ObjectDirection Direction
        {
            get { return m_direction; }
            set { m_direction = value; }
        }


        [JsonIgnore, ReadOnly(true)]
        public List<string> BrushTypes
        {
            get { return m_brushTypes; }
            set { m_brushTypes = value; }
        }

        [JsonIgnore, ReadOnly(true)]
        public List<string> BrushRules
        {
            get { return m_brushRules; }
            set { m_brushRules = value; }
        }

        public virtual string Comment
        {
            get { return m_comment; }
            set { m_comment = value; }
        }

        public virtual List<byte> Colour
        {
            get { return m_colourKey; }
            set { m_colourKey = value; }
        }
    }
}