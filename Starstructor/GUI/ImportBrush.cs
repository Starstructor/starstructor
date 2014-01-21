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

using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Starstructor.EditorObjects;
using Starstructor.StarboundTypes;
using Starstructor.StarboundTypes.Objects;
using Starstructor.StarboundTypes.Tiles;

namespace Starstructor.GUI
{
    public partial class ImportBrush : Form
    {
        private readonly Dictionary<TreeNode, StarboundAsset> m_assetNodeMap
            = new Dictionary<TreeNode, StarboundAsset>();

        public ImportBrush()
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Release resources
                if (components != null)
                    components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void ImportBrush_Load(object sender, System.EventArgs e)
        {
            UpdateAssetTreeView();
        }

        private void UpdateAssetTreeView(string filter = null)
        {
            AssetSearchTreeView.Nodes.Clear();

            AssetSearchTreeView.ImageList = new ImageList();
            List<StarboundAsset> assets = EditorAssets.getAllAssets();
            List<TreeNode> nodes = new List<TreeNode>();

            for (int i = 0; i < assets.Count; ++i)
            {
                StarboundAsset asset = assets[i];

                if (filter != null && !asset.ToString().Contains(filter))
                    continue;

                Image assetImage = null;

                if (asset is StarboundObject)
                {
                    StarboundObject sbObject = (StarboundObject)asset;
                    assetImage = sbObject.InventoryIcon.ImageFile;
                }

                if (assetImage == null)
                    assetImage = asset.Image;

                AssetSearchTreeView.ImageList.Images.Add(i.ToString(), assetImage);

                TreeNode node = new TreeNode(asset.ToString());
                node.ImageKey = i.ToString();
                node.SelectedImageKey = i.ToString();
                m_assetNodeMap[node] = asset;
                nodes.Add(node);
            }

            AssetSearchTreeView.Nodes.AddRange(nodes.ToArray());
        }

        private void AssetSearchTextBox_TextChanged(object sender, System.EventArgs e)
        {
            UpdateAssetTreeView(AssetSearchTextBox.Text);
        }

        private void AssetSearchTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (!m_assetNodeMap.ContainsKey(e.Node))
                return;

            StarboundAsset asset = m_assetNodeMap[e.Node];

            if (asset is StarboundObject)
            {
                StarboundObject sbObject = (StarboundObject) asset;
                AssetGraphicalPreview.Image = sbObject.GetDefaultOrientation().GetImageManager(ObjectDirection.DIRECTION_NONE).GetImageFrameBitmap();
            }
            else if (asset is StarboundMaterial)
            {
                StarboundMaterial sbMaterial = (StarboundMaterial) asset;
                AssetGraphicalPreview.Image = sbMaterial.Image;
            }

            AssetPathLabel.Text = asset.FullPath;
            AssetTypeLabel.Text = asset.GetType().ToString();
            AssetGraphicalPreview.Refresh();
        }

        private void AssetPreviewLayoutTable_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            Color borderColor = SystemColors.ControlDarkDark;
            int borderWidth = 1;

            ButtonBorderStyle leftBorderStyle = ButtonBorderStyle.None;
            ButtonBorderStyle topBorderStyle = ButtonBorderStyle.None;
            ButtonBorderStyle rightBorderStyle = ButtonBorderStyle.None;
            ButtonBorderStyle bottomBorderStyle = ButtonBorderStyle.None;

            if (e.Row == 1 || e.Row == 2)
            {
                topBorderStyle = ButtonBorderStyle.Dotted;
            }

            ControlPaint.DrawBorder(
                e.Graphics,
                e.CellBounds,
                borderColor,
                borderWidth,
                leftBorderStyle,
                borderColor,
                borderWidth,
                topBorderStyle,
                borderColor,
                borderWidth,
                rightBorderStyle,
                borderColor,
                borderWidth,
                bottomBorderStyle);
        }
    }
}
