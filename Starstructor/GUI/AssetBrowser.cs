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
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Starstructor.EditorObjects;
using Starstructor.StarboundTypes;

namespace Starstructor.GUI
{
    public partial class AssetBrowser : Form
    {
        public delegate void AssetSelectedFunc(StarboundAsset asset);

        private bool m_buttonsShown = true;
        private readonly Image m_notFoundImage = EditorHelpers.GetGeneratedRectangle(8, 8, 255, 105, 180, 255);
        private readonly Dictionary<TreeNode, StarboundAsset> m_assetNodeMap
            = new Dictionary<TreeNode, StarboundAsset>();

        private AssetSelectedFunc m_callback;
        private Thread m_worker;

        public AssetBrowser()
        {
            InitializeComponent();
        }

        public void HideButtons()
        {
            if (!m_buttonsShown) return;

            // remove the buttons, remove the table row
            Controls.Remove(AssetButtonSelect);
            AssetButtonSelect.Dispose();
            Controls.Remove(AssetButtonRefresh);
            AssetButtonRefresh.Dispose();
            AssetBrowserMainLayoutTable.RowCount = 1;

            m_buttonsShown = false;
        }

        public void SetAssetSelectedCallback(AssetSelectedFunc func)
        {
            m_callback = func;
        }

        public StarboundAsset GetSelectedAsset()
        {
            return m_assetNodeMap[AssetSearchTreeView.SelectedNode];
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
            StartTreeViewThread();
        }

        private void UpdateAssetTreeView(string filter = null, List<StarboundAsset> assets = null)
        {
            // If we haven't provided a list to work from, get the list from editor assets
            if (assets == null) assets = EditorAssets.GetAllAssets();

            AssetSearchTreeView.Nodes.Clear();

            if (AssetSearchTreeView.ImageList == null)
                AssetSearchTreeView.ImageList = new ImageList();

            AssetSearchTreeView.ImageList.Images.Clear();

            ClearSelection();

            for (int i = 0; i < assets.Count; ++i)
            {
                StarboundAsset asset = assets[i];

                if (filter != null && !asset.ToString().Contains(filter)) continue;

                Image assetImage = null;

                if (asset is StarboundObject)
                {
                    StarboundObject sbObject = (StarboundObject)asset;

                    // Use inventory icon, if it exists
                    if (assetImage == null && sbObject.InventoryIcon.ImageFile != null) 
                        assetImage = sbObject.InventoryIcon.ImageFile;
                }

                // Otherwise, use main image
                if (assetImage == null && asset.Image != null) assetImage = asset.Image;

                // Otherwise, use the not found image
                if (assetImage == null) assetImage = m_notFoundImage;

                AssetSearchTreeView.ImageList.Images.Add(i.ToString(), assetImage);

                TreeNode node = new TreeNode(asset.ToString());
                node.ImageKey = i.ToString();
                node.SelectedImageKey = i.ToString();
                m_assetNodeMap[node] = asset;
            }

            AssetSearchTreeView.Nodes.AddRange(m_assetNodeMap.Keys.ToArray());
        }

        private void UpdateAssetTreeViewThreadSafe(string filter = null, List<StarboundAsset> assets = null)
        {
            if (!IsDisposed)
                AssetSearchTreeView.Invoke((MethodInvoker) (() => UpdateAssetTreeView(filter, assets)));
        }

        private void AssetSearchTextBox_TextChanged(object sender, System.EventArgs e)
        {
            UpdateAssetTreeView(AssetSearchTextBox.Text);
        }

        private void AssetSearchTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (!m_assetNodeMap.ContainsKey(e.Node)) return;

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

            if (AssetGraphicalPreview.Image == null)
                AssetGraphicalPreview.Image = m_notFoundImage;

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

        private void ClearSelection()
        {
            AssetGraphicalPreview.Image = m_notFoundImage;
            AssetPathLabel.Text = "No asset selected";
            AssetTypeLabel.Text = "No asset selected";
        }

        private void RefreshTreeView()
        {
            EditorAssets.RefreshAssets();

            while (EditorAssets.IsAssetThreadWorking())
            {
                Thread.Sleep(50);
                UpdateAssetTreeViewThreadSafe(AssetSearchTextBox.Text, EditorAssets.GetAllAssets(false));
            }
        }

        private void StartTreeViewThread()
        {
            m_worker = new Thread(RefreshTreeView);
            m_worker.Start();
        }

        private void AssetButtonSelect_Click(object sender, System.EventArgs e)
        {
            if (m_callback != null) m_callback.Invoke(GetSelectedAsset());
        }

        private void AssetButtonRefresh_Click(object sender, System.EventArgs e)
        {
            if (!m_worker.IsAlive) StartTreeViewThread();
        }
    }
}
