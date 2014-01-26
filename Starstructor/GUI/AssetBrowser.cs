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
using System.Threading;
using System.Windows.Forms;
using Starstructor.EditorObjects;
using Starstructor.StarboundTypes;
using Image = System.Drawing.Image;
using TreeNode = System.Windows.Forms.TreeNode;

namespace Starstructor.GUI
{
    public partial class AssetBrowser : Form
    {
        public delegate void AssetSelectedFunc(StarboundAsset asset);

        private bool m_buttonsShown = true;
        private readonly Image m_notFoundImage = EditorHelpers.GetGeneratedRectangle(8, 8, 255, 105, 180, 255);
        private readonly List<TreeNode> m_nodeList = new List<TreeNode>();
        private readonly Dictionary<int, Image> m_imageList = new Dictionary<int, Image>();
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

        private void ImportBrush_Load(object sender, System.EventArgs e)
        {
            StartTreeViewThread();
        }

        private void UpdateAssetTreeView(string filter = null, List<StarboundAsset> assets = null)
        {
            // If we haven't provided a list to work from, get the list from editor assets
            if (assets == null) assets = EditorAssets.GetAllAssets();

            m_imageList.Clear();
            m_nodeList.Clear();
            m_assetNodeMap.Clear();

            for (int i = 0; i < assets.Count; ++i)
            {
                StarboundAsset asset = assets[i];

                if (filter != null && !asset.ToString().Contains(filter)) continue;

                Image assetImage = null;

                if (asset is StarboundObject)
                {
                    StarboundObject sbObject = (StarboundObject)asset;

                    // Use inventory icon, if it exists
                    if (sbObject.InventoryIcon.ImageFile != null)
                        assetImage = sbObject.InventoryIcon.ImageFile;
                }

                // Otherwise, use main image
                if (assetImage == null && asset.Image != null) assetImage = asset.Image;

                // Otherwise, use the not found image
                if (assetImage == null) assetImage = m_notFoundImage;

                m_imageList[i] = assetImage;

                TreeNode node = new TreeNode(asset.ToString())
                {
                    ImageKey = i.ToString(),
                    SelectedImageKey = i.ToString()
                };

                m_nodeList.Add(node);
                m_assetNodeMap[node] = asset;
            }

            TreeNode[] nodeArray = m_nodeList.ToArray();

            AssetSearchTreeView.Invoke((MethodInvoker) delegate
            {
                AssetSearchTreeView.BeginUpdate();
                AssetSearchTreeView.Nodes.Clear();

                if (AssetSearchTreeView.ImageList == null) AssetSearchTreeView.ImageList = new ImageList();

                foreach (KeyValuePair<int, Image> pair in m_imageList)
                {
                    AssetSearchTreeView.ImageList.Images.Add(pair.Key.ToString(), pair.Value);
                }

                AssetSearchTreeView.Nodes.AddRange(nodeArray);
                AssetSearchTreeView.EndUpdate();

                ClearSelection();
            });
        }

        private void AssetSearchTextBox_TextChanged(object sender, System.EventArgs e)
        {
            StartTreeViewThread();
        }

        private void AssetSearchTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (!m_assetNodeMap.ContainsKey(e.Node)) return;

            StarboundAsset asset = m_assetNodeMap[e.Node];

            if (asset is StarboundObject)
            {
                StarboundObject sbObject = (StarboundObject) asset;
                AssetGraphicalPreview.Image =
                    sbObject.GetDefaultOrientation()
                        .GetImageManager(ObjectDirection.DIRECTION_NONE)
                        .GetImageFrameBitmap();
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

        private void RefreshTreeView(bool refreshAssets)
        {
            if (refreshAssets) EditorAssets.RefreshAssets();

            while (EditorAssets.IsAssetThreadWorking())
            {
                Thread.Sleep(50);
                UpdateAssetTreeView(AssetSearchTextBox.Text, EditorAssets.GetAllAssets(false));
            }

            UpdateAssetTreeView(AssetSearchTextBox.Text, EditorAssets.GetAllAssets());
        }

        private void StartTreeViewThread(bool refreshAssets = false)
        {
            if (m_worker == null) m_worker = new Thread(() => RefreshTreeView(refreshAssets));

            if (m_worker.IsAlive)
            {
                m_worker.Abort();
                m_worker.Join();
            }

            m_worker = new Thread(() => RefreshTreeView(refreshAssets));
            m_worker.Start();
        }

        private void AssetButtonSelect_Click(object sender, System.EventArgs e)
        {
            if (m_callback != null) m_callback.Invoke(GetSelectedAsset());
        }

        private void AssetButtonRefresh_Click(object sender, System.EventArgs e)
        {
            StartTreeViewThread(true);
        }

        private void AssetBrowser_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Abort the thread
            if (m_worker.IsAlive)
            {
                m_worker.Abort();
                m_worker.Join();
            }
        }
    }
}
