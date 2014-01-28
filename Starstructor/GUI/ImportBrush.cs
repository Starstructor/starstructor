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
        public delegate void BrushImportedFunc(EditorBrush brush);

        private readonly AssetBrowser m_assetBrowser = new AssetBrowser();
        private readonly EditorBrush m_newBrush;
        private StarboundAsset m_frontAsset;
        private StarboundAsset m_backAsset;

        private BrushImportedFunc m_callback;

        public ImportBrush(Type type, BrushImportedFunc func = null)
        {
            m_callback = func;

            InitializeComponent();

            if (type == typeof(StarboundDungeon)) m_newBrush = new DungeonBrush();
            else if (type == typeof(StarboundShip)) m_newBrush = new ShipBrush();
            else Close();

            WizardTabs.SelectedIndex = 0;
            FrontAssetPictureBox.Image = m_assetBrowser.NotFoundImage;
            BackAssetPictureBox.Image = m_assetBrowser.NotFoundImage;
            ComboBoxFrontAssetDirectionDungeon.SelectedIndex = 0;
            ComboBoxFrontAssetTypeDungeon.SelectedIndex = 0;
        }

        public void SetBrushImportedCallback(BrushImportedFunc func)
        {
            m_callback = func;
        }

        private void ButtonPrev_Click(object sender, System.EventArgs e)
        {
            if (WizardTabs.SelectedIndex >= 0) WizardTabs.SelectedIndex--;
            if (WizardTabs.SelectedIndex == 0) ButtonPrev.Enabled = false;
            if (WizardTabs.SelectedIndex < 3) ButtonNext.Enabled = true;
        }

        private void ButtonNext_Click(object sender, System.EventArgs e)
        {
            if (WizardTabs.SelectedIndex <= 3) WizardTabs.SelectedIndex++;
            if (WizardTabs.SelectedIndex > 0) ButtonPrev.Enabled = true;
            if (WizardTabs.SelectedIndex == 3) ButtonNext.Enabled = false;
        }

        private void BuildBrushFromUserInput()
        {
            Type brushType = m_newBrush.GetType();

            if (brushType == typeof (DungeonBrush)) BuildDungeonBrushFromUserInput();
            else if (brushType == typeof (ShipBrush)) BuildShioBrushFromUserInput();
        }

        private void BuildDungeonBrushFromUserInput()
        {

            DispatchBrush();
        }

        private void BuildShioBrushFromUserInput()
        {


            DispatchBrush();
        }

        private void DispatchBrush()
        {
            if (m_callback != null) m_callback.Invoke(m_newBrush);
        }

        private void ButtonFinish_Click(object sender, System.EventArgs e)
        {
            BuildBrushFromUserInput();
        }

        private void ButtonCancel_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void FrontAssetSelectedCallback(StarboundAsset selected)
        {
            if (selected == null) return;

            TextBoxFrontAssetNameDungeon.Text = selected.ToString();
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

        private void ComboBoxFrontAssetTypeDungeon_SelectedValueChanged(object sender, EventArgs e)
        {
            HandleChangedFrontAssetType((string)ComboBoxFrontAssetTypeDungeon.SelectedItem);
        }

        private void ComboBoxFrontAssetDirectionDungeon_SelectedValueChanged(object sender, EventArgs e)
        {
            HandleFrontAssetUpdated(m_frontAsset, GetFrontAssetDirection());
        }

        private void TextBoxFrontAssetNameDungeon_TextChanged(object sender, EventArgs e)
        {
            HandleFrontAssetUpdated(EditorAssets.GetAsset(TextBoxFrontAssetNameDungeon.Text), GetFrontAssetDirection());
        }

        private void TextBoxBackAssetNameDungeon_TextChanged(object sender, EventArgs e)
        {
            HandleBackAssetUpdated(EditorAssets.GetMaterial(TextBoxBackAssetNameDungeon.Text));
        }

        private ObjectDirection GetFrontAssetDirection()
        {
            string value = (string)ComboBoxFrontAssetDirectionDungeon.SelectedItem;

            if (value == "Left") return ObjectDirection.DIRECTION_LEFT;
            if (value == "Right") return ObjectDirection.DIRECTION_RIGHT;

            return ObjectDirection.DIRECTION_NONE;
        }

        private void HandleChangedFrontAssetType(string newType)
        {
        }

        private void HandleFrontAssetUpdated(StarboundAsset newAsset, ObjectDirection direction = ObjectDirection.DIRECTION_NONE)
        {
            m_frontAsset = newAsset;

            if (m_frontAsset != null)
            {
                Type newAssetType = newAsset.GetType();

                if (newAssetType == typeof (StarboundObject))
                {
                    StarboundObject sbObject = (StarboundObject)m_frontAsset;
                    FrontAssetPictureBox.Image =
                        sbObject.GetDefaultOrientation()
                            .GetImageManager(direction)
                            .GetImageFrameBitmap();
                }
                else if (newAssetType == typeof (StarboundMaterial))
                {
                    StarboundMaterial sbMaterial = (StarboundMaterial)m_frontAsset;
                    FrontAssetPictureBox.Image = sbMaterial.Image;
                }
            }

            if (m_frontAsset == null || FrontAssetPictureBox.Image == null)
                FrontAssetPictureBox.Image = m_assetBrowser.NotFoundImage;
            
        }

        private void HandleBackAssetUpdated(StarboundAsset newAsset)
        {
            m_backAsset = newAsset;

            if (m_backAsset != null)
            {
                StarboundMaterial sbMaterial = (StarboundMaterial)m_backAsset;
                BackAssetPictureBox.Image = sbMaterial.Image;
            }

            if (m_backAsset == null || BackAssetPictureBox.Image == null)
                BackAssetPictureBox.Image = m_assetBrowser.NotFoundImage;
        }
    }
}
