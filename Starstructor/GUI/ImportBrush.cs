/*Starstructor, the Starbound Toolet 
Copyright (C) 2013-2014 Chris Stamford
Contact: cstamford@gmail.com

Source file contributers:
 Chris Stamford     contact: cstamford@gmail.com

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
using System.Windows.Forms;
using Starstructor.EditorObjects;
using Starstructor.StarboundTypes;
using Starstructor.StarboundTypes.Dungeons;
using Starstructor.StarboundTypes.Ships;

namespace Starstructor.GUI
{
    public partial class ImportBrush : Form
    {
        private readonly AssetBrowser m_assetBrowser = new AssetBrowser();
        private readonly EditorBrush m_newBrush;

        public ImportBrush(Type type)
        {
            InitializeComponent();

            if (type == typeof(StarboundDungeon)) m_newBrush = new DungeonBrush();
            else if (type == typeof(StarboundShip)) m_newBrush = new ShipBrush();
            else Close();

            WizardTabs.SelectedIndex = GetTabOffset();
            ComboBoxFrontAssetDirectionDungeon.SelectedIndex = 0;
            ComboBoxFrontAssetTypeDungeon.SelectedIndex = 0;
        }

        private int GetTabOffset()
        {
            return m_newBrush is DungeonBrush ? 0 : 4;
        }

        private void ButtonPrev_Click(object sender, System.EventArgs e)
        {
            int offset = GetTabOffset();

            if (WizardTabs.SelectedIndex >= offset) WizardTabs.SelectedIndex--;
            if (WizardTabs.SelectedIndex == offset) ButtonPrev.Enabled = false;
            if (WizardTabs.SelectedIndex < offset + 3) ButtonNext.Enabled = true;
        }

        private void ButtonNext_Click(object sender, System.EventArgs e)
        {
            int offset = GetTabOffset();

            if (WizardTabs.SelectedIndex <= offset + 3) WizardTabs.SelectedIndex++;
            if (WizardTabs.SelectedIndex > offset) ButtonPrev.Enabled = true;
            if (WizardTabs.SelectedIndex == offset + 3) ButtonNext.Enabled = false;
        }

        private void ButtonFinish_Click(object sender, System.EventArgs e)
        {
        }

        private void ButtonCancel_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void FrontAssetSelectedCallback(StarboundAsset selected)
        {
            if (selected == null) return;

            TextBoxFrontAssetNameDungeon.Text = selected.ToString();

            /*
            if (selected is StarboundObject)
            {
                StarboundObject sbObject = (StarboundObject)selected;
                FrontAssetDungeonPictureBox.Image =
                    sbObject.GetDefaultOrientation()
                        .GetImageManager(ObjectDirection.DIRECTION_NONE)
                        .GetImageFrameBitmap();
            }
            else if (selected is StarboundMaterial)
            {
                StarboundMaterial sbMaterial = (StarboundMaterial)selected;
                FrontAssetDungeonPictureBox.Image = sbMaterial.Image;
            }

            if (FrontAssetDungeonPictureBox.Image == null)
                FrontAssetDungeonPictureBox.Image = m_assetBrowser.NotFoundImage;*/
        }

        private void BackAssetSelectedCallback(StarboundAsset selected)
        {
            if (selected == null) return;

            TextBoxBackAssetNameDungeon.Text = selected.ToString();
        }

        private void ButtonFrontAssetBrowseDungeon_Click(object sender, EventArgs e)
        {
            m_assetBrowser.SetAssetSelectedCallback(FrontAssetSelectedCallback);
            m_assetBrowser.ShowDialog();
        }

        private void ButtonBackAssetBrowseDungeon_Click(object sender, EventArgs e)
        {
            m_assetBrowser.SetAssetSelectedCallback(BackAssetSelectedCallback);
            m_assetBrowser.ShowDialog();
        }
    }
}
