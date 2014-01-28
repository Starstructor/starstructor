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

        private int m_tabCount;
        private readonly AssetBrowser m_assetBrowser = new AssetBrowser();
        private readonly EditorBrush m_newBrush;
        private StarboundAsset m_frontAsset;
        private StarboundAsset m_backAsset;
        private BrushImportedFunc m_callback;

        public ImportBrush(Type type, BrushImportedFunc func = null)
        {
            InitializeComponent();
            m_callback = func;
            m_tabCount = TabControlWizard.TabCount;

            if (type == typeof(StarboundDungeon)) m_newBrush = new DungeonBrush();
            else if (type == typeof (StarboundShip))
            {
                m_newBrush = new ShipBrush();

                // Hide dungeon things
                CheckboxConnectorGeneralTab.Visible = false;
                CheckboxBackAssetSurfaceAssetTab.Visible = false;
                CheckboxFrontAssetSurfaceAssetTab.Visible = false;
                m_tabCount--;
            }

            else Close();

            TabControlWizard.SelectedIndex = 0;
            PictureBoxFrontAsset.Image = m_assetBrowser.NotFoundImage;
            PictureBoxBackAsset.Image = m_assetBrowser.NotFoundImage;
            ComboboxFrontAssetDirectionAssetTab.SelectedIndex = 0;
            ComboboxFrontAssetTypeAssetTab.SelectedIndex = 0;
        }

        public void SetBrushImportedCallback(BrushImportedFunc func)
        {
            m_callback = func;
        }

        private void ButtonPrev_Click(object sender, System.EventArgs e)
        {
            if (TabControlWizard.SelectedIndex >= 0) TabControlWizard.SelectedIndex--;
            if (TabControlWizard.SelectedIndex == 0) ButtonPrev.Enabled = false;
            if (TabControlWizard.SelectedIndex < m_tabCount - 1) ButtonNext.Enabled = true;
        }

        private void ButtonNext_Click(object sender, System.EventArgs e)
        {
            if (TabControlWizard.SelectedIndex <= m_tabCount - 1) TabControlWizard.SelectedIndex++;
            if (TabControlWizard.SelectedIndex > 0) ButtonPrev.Enabled = true;
            if (TabControlWizard.SelectedIndex == m_tabCount - 1) ButtonNext.Enabled = false;
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

            TextBoxFrontAssetNameAssetTab.Text = selected.ToString();
        }

        private void BackAssetSelectedCallback(StarboundAsset selected)
        {
            if (selected == null) return;

            TextBoxBackAssetNameAssetTab.Text = selected.ToString();
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
            HandleChangedFrontAssetType((string)ComboboxFrontAssetTypeAssetTab.SelectedItem);
        }

        private void ComboBoxFrontAssetDirectionDungeon_SelectedValueChanged(object sender, EventArgs e)
        {
            HandleFrontAssetUpdated(m_frontAsset, GetFrontAssetDirection());
        }

        private void TextBoxFrontAssetNameDungeon_TextChanged(object sender, EventArgs e)
        {
            HandleFrontAssetUpdated(EditorAssets.GetAsset(TextBoxFrontAssetNameAssetTab.Text), GetFrontAssetDirection());
        }

        private void TextBoxBackAssetNameDungeon_TextChanged(object sender, EventArgs e)
        {
            HandleBackAssetUpdated(EditorAssets.GetMaterial(TextBoxBackAssetNameAssetTab.Text));
        }

        private ObjectDirection GetFrontAssetDirection()
        {
            string value = (string)ComboboxFrontAssetDirectionAssetTab.SelectedItem;

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
                    PictureBoxFrontAsset.Image =
                        sbObject.GetDefaultOrientation()
                            .GetImageManager(direction)
                            .GetImageFrameBitmap();
                }
                else if (newAssetType == typeof (StarboundMaterial))
                {
                    StarboundMaterial sbMaterial = (StarboundMaterial)m_frontAsset;
                    PictureBoxFrontAsset.Image = sbMaterial.Image;
                }
            }

            if (m_frontAsset == null || PictureBoxFrontAsset.Image == null)
                PictureBoxFrontAsset.Image = m_assetBrowser.NotFoundImage;
            
        }

        private void HandleBackAssetUpdated(StarboundAsset newAsset)
        {
            m_backAsset = newAsset;

            if (m_backAsset != null)
            {
                StarboundMaterial sbMaterial = (StarboundMaterial)m_backAsset;
                PictureBoxBackAsset.Image = sbMaterial.Image;
            }

            if (m_backAsset == null || PictureBoxBackAsset.Image == null)
                PictureBoxBackAsset.Image = m_assetBrowser.NotFoundImage;
        }

        private void CheckboxConnectorGeneralTab_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckboxConnectorGeneralTab.Checked)
            {
                if (CheckboxBackAssetAssetTab.Checked) CheckboxBackAssetAssetTab.Checked = false;
                if (CheckboxBackAssetSurfaceAssetTab.Checked) CheckboxBackAssetSurfaceAssetTab.Checked = false;
                if (CheckboxFrontAssetAssetTab.Checked) CheckboxFrontAssetAssetTab.Checked = false;
                if (CheckboxFrontAssetSurfaceAssetTab.Checked) CheckboxFrontAssetSurfaceAssetTab.Checked = false;
            }
        }

        private void CheckboxBackAssetAssetTab_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckboxConnectorGeneralTab.Checked && CheckboxBackAssetAssetTab.Checked)
            {
                MessageBox.Show("This brush is a connector, it cannot have a back asset.");
                CheckboxBackAssetAssetTab.Checked = false;
            }
            else
            {
                bool enable = CheckboxBackAssetAssetTab.Checked;

                if (enable && CheckboxBackAssetSurfaceAssetTab.Checked)
                    CheckboxBackAssetSurfaceAssetTab.Checked = false;

                TextBoxBackAssetNameAssetTab.Enabled = enable;
                ButtonBackAssetBrowseAssetTab.Enabled = enable;
            }
        }

        private void CheckboxFrontAssetAssetTab_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckboxConnectorGeneralTab.Checked && CheckboxFrontAssetAssetTab.Checked)
            {
                MessageBox.Show("This brush is a connector, it cannot have a front asset.");
                CheckboxFrontAssetAssetTab.Checked = false;
            }
            else
            {
                bool enable = CheckboxFrontAssetAssetTab.Checked;

                if (enable && CheckboxFrontAssetSurfaceAssetTab.Checked)
                    CheckboxFrontAssetSurfaceAssetTab.Checked = false;

                TextBoxFrontAssetNameAssetTab.Enabled = enable;
                ButtonFrontAssetBrowseAssetTab.Enabled = enable;
                ComboboxFrontAssetDirectionAssetTab.Enabled = enable;
                ComboboxFrontAssetTypeAssetTab.Enabled = enable;
            }
        }


        private void CheckboxBackAssetSurfaceAssetTab_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckboxConnectorGeneralTab.Checked && CheckboxBackAssetSurfaceAssetTab.Checked)
            {
                MessageBox.Show("This brush is a connector, it cannot have a back asset.");
                CheckboxBackAssetSurfaceAssetTab.Checked = false;
            }
            else
            {
                if (CheckboxBackAssetSurfaceAssetTab.Checked && CheckboxBackAssetAssetTab.Checked)
                {
                    CheckboxBackAssetAssetTab.Checked = false;
                }
            }
        }

        private void CheckboxFrontAssetSurfaceAssetTab_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckboxConnectorGeneralTab.Checked && CheckboxFrontAssetSurfaceAssetTab.Checked)
            {
                MessageBox.Show("This brush is a connector, it cannot have a front asset.");
                CheckboxFrontAssetSurfaceAssetTab.Checked = false;
            }
            else
            {
                if (CheckboxFrontAssetSurfaceAssetTab.Checked && CheckboxFrontAssetAssetTab.Checked)
                {
                    CheckboxFrontAssetAssetTab.Checked = false;
                }
            }
        }
    }
}
