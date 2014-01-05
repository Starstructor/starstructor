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

using DungeonEditor.StarboundObjects;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Drawing;
using DungeonEditor.StarboundObjects.Objects;
using System;
using System.Windows.Forms;

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
        protected StarboundAsset m_backAsset;

        [JsonIgnore]
        protected BindingList<string> m_brushRules = new BindingList<string>();

        [JsonIgnore]
        protected BindingList<string> m_brushTypes = new BindingList<string>();

        [JsonIgnore] 
        protected Color m_colourKey;

        [JsonIgnore] 
        protected string m_comment;

        [JsonIgnore] 
        protected ObjectDirection m_direction;

        [JsonIgnore] 
        protected StarboundAsset m_frontAsset;

        [JsonIgnore] 
        protected bool m_isSpecial;

        [JsonIgnore] 
        protected bool m_needsBackAsset;

        [JsonIgnore] 
        protected bool m_needsFrontAsset;

        private string m_brushKey;
        private static Random g_randKey = new Random();

        [JsonIgnore, ReadOnly(true), TypeConverter(typeof(ExpandableObjectConverter))]
        public StarboundAsset FrontAsset
        {
            get { return m_frontAsset; }
            set { m_frontAsset = value; }
        }

        [JsonIgnore, ReadOnly(true), TypeConverter(typeof(ExpandableObjectConverter))]
        public StarboundAsset BackAsset
        {
            get { return m_backAsset; }
            set { m_backAsset = value; }
        }

        [JsonIgnore, ReadOnly(true)]
        public bool NeedsFrontAsset
        {
            get { return m_needsFrontAsset; }
            set { m_needsFrontAsset = value; }
        }

        [JsonIgnore, ReadOnly(true)]
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


        [JsonIgnore, Category("Orientation"), ReadOnly(true)]
        public ObjectDirection Direction
        {
            get { return m_direction; }
            set { m_direction = value; }
        }


        [JsonIgnore, Browsable(false)]
        public BindingList<string> BrushTypes
        {
            get { return m_brushTypes; }
            set { m_brushTypes = value; }
        }
        
        [JsonIgnore, Browsable(false)]
        public BindingList<string> BrushRules
        {
            get { return m_brushRules; }
            set { m_brushRules = value; }
        }

        [ReadOnly(true)]
        public virtual string Comment
        {
            get { return m_comment; }
            set { m_comment = value; }
        }

        [JsonConverter(typeof(ColorSerializer)), ReadOnly(true)]
        public virtual Color Colour
        {
            get { return m_colourKey; }
            set { m_colourKey = value; }
        }

        public EditorBrush()
        {
            m_brushKey = "b" + g_randKey.Next();
        }

        public Image GetAssetPreview()
        {
            Image assetImg = null;

            // Get the correct preview box asset
            if (FrontAsset != null)
            {
                if (FrontAsset is StarboundObject)
                {
                    StarboundObject sbObject = (StarboundObject)FrontAsset;
                    //ObjectOrientation orientation = sbObject.GetDefaultOrientation();

                    assetImg = sbObject.InventoryIcon.ImageFile;
                    //ObjectImageManager manager = orientation.GetImageManager(Direction);
                    //if ( manager != null )
                      //  assetImg = manager.GetImageFrameBitmap();
                }

                if (assetImg == null)
                    assetImg = FrontAsset.Image;
            }
            else if (BackAsset != null)
            {
                if (BackAsset is StarboundObject)
                {
                    StarboundObject sbObject = (StarboundObject)BackAsset;
                    //ObjectOrientation orientation = sbObject.GetDefaultOrientation();

                    assetImg = sbObject.InventoryIcon.ImageFile;
                    //ObjectImageManager manager = orientation.GetImageManager(Direction);
                    //if (manager != null)
                      //  assetImg = manager.GetImageFrameBitmap();
                }

                if (assetImg == null)
                    assetImg = BackAsset.Image;
            }
            return assetImg;
        }

        // Used as a mapping from brush tree view to editor brush
        public string GetKey()
        {
            return m_brushKey;
        }
    }
}