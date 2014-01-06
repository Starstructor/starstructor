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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DungeonEditor.Editor;
using DungeonEditor.EditorObjects;
using DungeonEditor.StarboundObjects.Dungeons;
using DungeonEditor.StarboundObjects.Ships;
using Microsoft.Win32;
using Newtonsoft.Json.Linq;

namespace DungeonEditor.GUI
{
    public partial class MainWindow : Form
    {
        private readonly Dictionary<TreeNode, EditorBrush> m_brushNodeMap
            = new Dictionary<TreeNode, EditorBrush>();

        private readonly Dictionary<TreeNode, EditorMap> m_mapNodeMap
            = new Dictionary<TreeNode, EditorMap>();

        private int m_gridFactor;
        public Editor.Editor m_parent;
        private EditorBrush m_selectedBrush;
        private EditorMap m_pselectedMap;

        public EditorMap SelectedMap
        {
            get { return m_pselectedMap; }
            private set
            {
                if (m_pselectedMap != value)
                {
                    EditorMap parentNext = value;
                    if (parentNext is EditorMapLayer)
                        parentNext = (parentNext as EditorMapLayer).Parent;

                    EditorMap parentPrev = m_pselectedMap;
                    if (parentPrev is EditorMapLayer)
                        parentPrev = (parentPrev as EditorMapLayer).Parent;

                    bool wantReset = parentNext != parentPrev;
                    m_pselectedMap = value;

                    // Update the work area
                    UpdateImageBox(wantReset, wantReset);

                    // Update menus/properties
                    takeScreenshotToolStripMenuItem.Enabled = (value != null);
                    UpdatePropertiesPanel();

                    TreeNode desiredNode = null;
                    if (value != null)
                    {
                        try
                        {
                            desiredNode = m_mapNodeMap.First(x => x.Value == value).Key;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("OOPS! Something bad happened. Report this.\n\n" + ex);
                        }
                    }
                    PartTreeView.SelectedNode = desiredNode;
                }
            }
        }

        public MainWindow(Editor.Editor parent)
        {
            m_parent = parent;

            InitializeComponent();

            // Callbacks added here since the designer enjoys making life miserable
            this.MainPictureBox.MouseEnter += new System.EventHandler(this.MainPictureBox_MouseEnter);
            
            this.BottomBarGfxCombo.SelectedIndexChanged += new System.EventHandler(this.BottomBarGfxCombo_SelectedIndexChanged);

            this.RightPanelTabControl.Selected += new System.Windows.Forms.TabControlEventHandler(this.RightPanelTabControl_Selected);

            this.PartTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.PartTreeView_AfterSelect);
            this.BrushesTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.BrushesTreeView_AfterSelect);

        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            WindowState = Editor.Editor.Settings.WindowState;
            Left = Editor.Editor.Settings.WindowX;
            Top = Editor.Editor.Settings.WindowY;
            Width = Editor.Editor.Settings.WindowWidth;
            Height = Editor.Editor.Settings.WindowHeight;
            MainPictureBox.m_parent = this;

            viewCollisionsToolStripMenuItem.Checked = Editor.Editor.Settings.ViewCollisionGrid;
            BottomBarGfxCombo.SelectedIndex = Editor.Editor.Settings.GraphicalDisplay ? 0 : 1;
            UpdateRecentHistoryList();
        }

        private void UpdateRecentHistoryList()
        {
            recentFilesToolStripMenuItem.DropDownItems.Clear();
            recentFilesToolStripMenuItem.Enabled = Editor.Editor.Settings.RecentFiles.Count > 0;
            foreach (var file in Editor.Editor.Settings.RecentFiles)
            {
                var newItem = recentFilesToolStripMenuItem.DropDownItems.Add(file);
                newItem.Click += new System.EventHandler(recentFileHistory_Click);
            }
        }
        private void recentFileHistory_Click(object sender, EventArgs e)
        {
            if ( sender is ToolStripMenuItem )
            {
                var item = sender as ToolStripMenuItem;
                OpenFile(item.Text);
            }
        }

        private void MainWindow_Shown(object sender, EventArgs e)
        {
            Text = m_parent.Name + " v" + m_parent.Version;

            if (Editor.Editor.Settings.AssetDirPath == null)
            {
				string path = string.Empty;

				try
				{
	                // Try to auto-find directory
	                path = (string)Registry.GetValue(
	                    @"HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall\Steam App 211820",
	                    "InstallLocation", null);
				}
				catch(Exception ex) {
				}

                // If found
				if (path != string.Empty)
                {
                    path = Path.Combine(path, "assets");
                    Editor.Editor.Settings.AssetDirPath = path;
                }
                // Otherwise prompt the user
                else
                {
                    MessageBox.Show(
                        "Could not find Starbound folder. Please navigate to Starbound's assets directory on the next screen.");

                    DirPopup guiPopup = new DirPopup(m_parent);
                    guiPopup.ShowDialog();
                }
            }

            m_parent.SaveSettings();
            OpenFileDlg.InitialDirectory = Editor.Editor.Settings.AssetDirPath;
            MainPictureBox.Focus();
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!ConfirmExit())
            {
                e.Cancel = true;
                return;
            }

            Editor.Editor.Settings.WindowState = WindowState;
            Editor.Editor.Settings.WindowX = Left;
            Editor.Editor.Settings.WindowY = Top;
            Editor.Editor.Settings.WindowWidth = Width;
            Editor.Editor.Settings.WindowHeight = Height;
            Editor.Editor.Settings.GraphicalDisplay = BottomBarGfxCombo.SelectedIndex == 0;

            m_parent.SaveSettings();
        }

        private void CleanUp()
        {
            MainPictureBox.SetImage(null, m_gridFactor);
            MainPictureBox.SetSelectedBrush(null);
            VisualGraphicBrushImageBox.Image = null;
            VisualRgbaBrushImageBox.Image = null;
            PartTreeView.Nodes.Clear();
            BrushesTreeView.Nodes.Clear();
            BottomBarBrushLabel.Text = "";
            BottomBarPositionLabel.Text = "Grid: ";
            BottomBarZoomLabel.Text = "Zoom: ";
            m_brushNodeMap.Clear();
            m_mapNodeMap.Clear();
            m_parent.CleanUpResource();
            m_selectedBrush = null;
            SelectedMap = null;
            RightPanelProperties.SelectedObject = null;

            // Update menu items, regardless of how we ended up here
            UpdateUndoRedoItems();
            closeToolStripMenuItem.Enabled = false;
            saveToolStripMenuItem.Enabled = false;
            saveAsToolStripMenuItem.Enabled = false;

            // Force the garbage collector to clean up
            // But it won't do it until next file load because that would be too easy
            GC.Collect();
        }

        private static DialogResult PromptClosingProject()
        {
            return MessageBox.Show(
                "Are you sure you wish to close your current opened dungeon?",
                "Exit", MessageBoxButtons.OKCancel);
        }

        private static DialogResult PromptSaveWork()
        {
            return MessageBox.Show(
                "Are you sure you would like to save all modified assets in this project?",
                "Save", MessageBoxButtons.OKCancel);
        }

        private static DialogResult PromptSaveWorkWhenQuitting()
        {
            return MessageBox.Show(
                "Your project has unsaved work. Are you sure you want to exit without saving? (you can save from the file menu.)",
                "Unsaved work", MessageBoxButtons.OKCancel);
        }

        public void UpdateBottomBar(float zoom)
        {
            BottomBarZoomLabel.Text = "Zoom: " + Math.Round(zoom, 1) + "x";
            BottomBarZoomLabel.Refresh();
        }

        public void UpdateBottomBar(int gridX, int gridY)
        {
            BottomBarPositionLabel.Text = "Grid: ";
            
            if (gridX == -1 || gridY == -1)
            {
                BottomBarPositionLabel.Text += "N/A";
            }
            else
            {
                BottomBarPositionLabel.Text += "(" + gridX + ", " + gridY + ")";
            }

            BottomBarPositionLabel.Refresh();
        }


        public void SetSelectedBrush(EditorBrush brush)
        {
            m_selectedBrush = brush;
            string colour = m_selectedBrush.Colour.ToString();

            // Tidy this display up at some point
            BottomBarBrushLabel.Text = m_selectedBrush.Comment;

            if (m_selectedBrush.FrontAsset != null)
            {
                BottomBarBrushLabel.Text += "       front: " + m_selectedBrush.FrontAsset.ToString();
            }

            if (m_selectedBrush.BackAsset != null)
            {
                BottomBarBrushLabel.Text += "       back: " + m_selectedBrush.BackAsset.ToString();
            }

            BottomBarBrushLabel.Text += "        " + colour;

            // Populate the colour box
            VisualRgbaBrushImageBox.Image = EditorHelpers.GetGeneratedRectangle(1, 1,
                m_selectedBrush.Colour.R, m_selectedBrush.Colour.G,
                m_selectedBrush.Colour.B, m_selectedBrush.Colour.A);

            VisualGraphicBrushImageBox.Image = m_selectedBrush.GetAssetPreview();

            MainPictureBox.SetSelectedBrush(m_selectedBrush);
            UpdatePropertiesPanel();
        }

        public EditorMapLayer GetSelectedLayer()
        {
            return SelectedMap == null ? null : SelectedMap.GetActiveLayer();
        }

        public EditorMapPart GetSelectedPart()
        {
            return SelectedMap == null ? null : SelectedMap.GetActivePart();
        }

        public void OnCanvasLeftClick(int gridX, int gridY, int lastGridX, int lastGridY)
        {
            if (m_selectedBrush == null || SelectedMap == null)
                return;

            // If there's nothing to change, just leave
            if (gridX == lastGridX && gridY == lastGridY)
                return;

            // Get the current layer
            EditorMapLayer activeLayer = GetSelectedLayer();

            // Change the layer brush
            EditorBrush oldBrush = activeLayer.GetBrushAt(gridX, gridY);
            activeLayer.SetUserBrushAt(m_selectedBrush, gridX, gridY);
            UpdateUndoRedoItems();

            SelectedMap.RedrawCanvasFromBrush(oldBrush, m_selectedBrush, gridX, gridY);
            MainPictureBox.Refresh();
        }

        // Updates the undo/redo items by changing their enabled state correctly
        private void UpdateUndoRedoItems()
        {
            EditorMapLayer activeLayer = GetSelectedLayer();
            if (activeLayer == null)
            {
                undoToolStripMenuItem.Enabled = false;
                redoToolStripMenuItem.Enabled = false;
            }
            else
            {
                UndoManager undoManager = activeLayer.UndoManager;

                undoToolStripMenuItem.Enabled = undoManager.CanUndo();
                redoToolStripMenuItem.Enabled = undoManager.CanRedo();
            }
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditorMapLayer activeLayer = GetSelectedLayer();
            if (activeLayer != null)
            {
                var lastChange = activeLayer.UndoManager.Undo();
                if (lastChange != null)
                {
                    SelectedMap.RedrawCanvasFromBrush(lastChange.Value.m_brushAfter,
                                                        lastChange.Value.m_brushBefore,
                                                        lastChange.Value.m_x,
                                                        lastChange.Value.m_y);
                    MainPictureBox.Refresh();
                }
            }
            UpdateUndoRedoItems();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditorMapLayer activeLayer = GetSelectedLayer();
            if (activeLayer != null)
            {
                var lastChange = activeLayer.UndoManager.Redo();
                if (lastChange != null)
                {
                    SelectedMap.RedrawCanvasFromBrush(lastChange.Value.m_brushAfter,
                                                        lastChange.Value.m_brushBefore,
                                                        lastChange.Value.m_x,
                                                        lastChange.Value.m_y);
                    MainPictureBox.Refresh();
                }
            }
            UpdateUndoRedoItems();
        }

        public void OnCanvasRightClick(int gridX, int gridY, int lastGridX, int lastGridY)
        {
            EditorMapLayer activeLayer = GetSelectedLayer();

            if (activeLayer == null)
                return;

            // eyedropper tool

            EditorBrush brush = activeLayer.GetBrushAt(gridX, gridY);

            if (brush != null)
            {
                SetSelectedBrush(brush);

                // Select the brush in the treeview
                TreeNode brushNode = null;
                foreach ( var m in m_brushNodeMap )
                {
                    if ( m.Value == brush )
                    {
                        brushNode = m.Key;
                        break;
                    }
                    
                }
                BrushesTreeView.SelectedNode = brushNode;
            }
        }

        // Populate the part list
        private void PopulatePartTreeView()
        {
            List<TreeNode> anchorNodes = new List<TreeNode>();
            List<TreeNode> extensionNodes = new List<TreeNode>();
            List<TreeNode> baseNodes = new List<TreeNode>();

            foreach (EditorMapPart part in m_parent.ActiveFile.ReadableParts)
            {
                List<TreeNode> childNodes = new List<TreeNode>();

                // Add layers as children
                foreach (EditorMapLayer layer in part.Layers)
                {
                    TreeNode newNode = new TreeNode(layer.Name);
                    m_mapNodeMap[newNode] = layer;
                    childNodes.Add(newNode);
                }

                // Create the part node
                TreeNode parentNode = new TreeNode(part.Name, childNodes.ToArray());
                m_mapNodeMap[parentNode] = part;

                // Dungeon-specific, split parts into Anchors and Extensions
                if (m_parent != null && m_parent.ActiveFile is StarboundDungeon)
                {
                    var dungeon = m_parent.ActiveFile as StarboundDungeon;
                    if ( dungeon.Metadata.Anchor.Contains(part.Name) )
                        anchorNodes.Add(parentNode);
                    else
                        extensionNodes.Add(parentNode);
                }
                else
                {
                    PartTreeView.Nodes.Add(parentNode);
                }
            }
            PartTreeView.Nodes.AddRange(baseNodes.ToArray());

            // If this is a dungeon, create the anchors and extensions
            if (m_parent != null && m_parent.ActiveFile is StarboundDungeon)
            {
                var anchorsNode = new TreeNode("Anchors", anchorNodes.ToArray());
                var extensionsNode = new TreeNode("Extensions", extensionNodes.ToArray());
                anchorsNode.Expand();
                extensionsNode.Expand();
                PartTreeView.Nodes.Add(anchorsNode);
                PartTreeView.Nodes.Add(extensionsNode);
            }
        }

        private void PartTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            SelectPartNode(e.Node);
        }

        private void UpdatePropertiesPanel()
        {
            TabPage tab = RightPanelTabControl.SelectedTab;
            if ( tab == MainTab )
            {
                if (m_parent.ActiveFile is StarboundDungeon)
                    RightPanelProperties.SelectedObject = ((StarboundDungeon)m_parent.ActiveFile).Metadata;
                else
                    RightPanelProperties.SelectedObject = m_parent.ActiveFile;
            }
            else if ( tab == PartsTab )
            {
                RightPanelProperties.SelectedObject = GetSelectedPart();
            }
            else if ( tab == BrushesTab )
            {
                RightPanelProperties.SelectedObject = m_selectedBrush;
            }
            else
            {
                RightPanelProperties.SelectedObject = null;
            }
        }

        private void RightPanelTabControl_Selected(object sender, TabControlEventArgs e)
        {
            UpdatePropertiesPanel();
        }

        // Populate the brush list
        private void PopulateBrushList()
        {
            List<TreeNode> baseNodes = new List<TreeNode>();
            BrushesTreeView.ImageList = new ImageList();
            BrushesTreeView.ImageList.Images.Add("default", EditorHelpers.GetGeneratedRectangle(8,8,255,255,255,255));
            foreach (EditorBrush brush in m_parent.ActiveFile.BlockMap)
            {
                string comment = brush.Comment;

                if (String.IsNullOrWhiteSpace(comment))
                    comment = "NO COMMENT DEFINED";

                TreeNode parentNode = new TreeNode(comment);
                if (brush.GetAssetPreview() != null)
                {
                    BrushesTreeView.ImageList.Images.Add(brush.GetKey(), brush.GetAssetPreview());
                    parentNode.ImageKey = brush.GetKey();
                    parentNode.SelectedImageKey = brush.GetKey();
                }
                baseNodes.Add(parentNode);
                                
                // Add this node to the brush -> node map
                m_brushNodeMap[parentNode] = brush;
            }
            BrushesTreeView.Nodes.AddRange(baseNodes.ToArray());
        }

        private void BrushesTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // If the node is in the map
            if (m_brushNodeMap.ContainsKey(e.Node))
            {
                SetSelectedBrush(m_brushNodeMap[e.Node]);
            }
        }

        private void UpdateImageBox(bool resetZoom, bool resetCamera)
        {
            // If no file is loaded, leave
            if (m_parent.ActiveFile == null || SelectedMap == null)
                return;

            EditorMapPart part = GetSelectedPart();

            // If we're displaying the graphic map
            if (BottomBarGfxCombo.SelectedIndex == 0)
            {
                m_gridFactor = 8;

                if (SelectedMap is EditorMapPart)
                {
                    part.UpdateLayerImage();
                }
                else if (SelectedMap is EditorMapLayer)
                {
                    part.UpdateLayerImage(new List<EditorMapLayer> { (EditorMapLayer)SelectedMap });
                }

                MainPictureBox.SetImage(part.GraphicsMap, resetZoom, resetCamera, m_gridFactor);
            }

            // If we're displaying the colour map
            else if (BottomBarGfxCombo.SelectedIndex == 1)
            {
                m_gridFactor = 1;

                if (SelectedMap is EditorMapPart)
                {
                    MainPictureBox.SetImage(part.ColourMap, resetZoom, resetCamera, m_gridFactor);
                }
                else if (SelectedMap is EditorMapLayer)
                {
                    MainPictureBox.SetImage(GetSelectedLayer().ColourMap, resetZoom, resetCamera, m_gridFactor);
                }
            }

            MainPictureBox.Invalidate();
        }


        // Recursively generate a list of TreeNodes
        // This needs to be improved in the future
        private List<TreeNode> AddNodes_r(object element)
        {
            List<TreeNode> nodes = new List<TreeNode>();

            if (element is JObject)
            {
                foreach (KeyValuePair<string, JToken> deepElem in (JObject) element)
                {
                    nodes.AddRange(AddNodes_r(deepElem));
                }
            }

            else if (element is JArray)
            {
                nodes.AddRange(((JArray)element).Cast<object>().SelectMany(AddNodes_r));
            }

            else if (element is JValue)
            {
                nodes.Add(new TreeNode(element.ToString()));
            }

            else if (element is KeyValuePair<string, JToken>)
            {
                KeyValuePair<string, JToken> deepElem = (KeyValuePair<string, JToken>)element;
                List<TreeNode> tokenChildren = AddNodes_r(deepElem.Value);

                nodes.Add(new TreeNode(deepElem.Key, tokenChildren.ToArray<TreeNode>()));
            }

            else
            {
                nodes.Add(new TreeNode(element.ToString()));
            }

            return nodes;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDlg.ShowDialog();
        }

        // Open an existing file
        private void OpenFile(string fileName)
        {
            if (!ConfirmExit())
                return;

            CleanUp();

            if (!Directory.Exists(Editor.Editor.Settings.AssetDirPath))
            {
                MessageBox.Show("Invalid asset directory set. Please choose a valid asset directory " +
                                "from the Starbound menu in the toolset.", "Error", MessageBoxButtons.OK);
                return;
            }

            if (!m_parent.LoadFile(fileName))
            {
                MessageBox.Show("Unable to load!");
                UpdateRecentHistoryList();

                //Close();
                return;
            }

            PopulatePartTreeView();
            PopulateBrushList();

            if (PartTreeView.Nodes.Count > 0)
            {
                if (m_parent != null && m_parent.ActiveFile is StarboundDungeon)
                {
                    var dungeon = m_parent.ActiveFile as StarboundDungeon;
                    string desired = dungeon.Metadata.Anchor.First();
                    SelectPartNode(desired);
                }
                else
                {
                    TreeNode node = m_mapNodeMap.First().Key;
                    SelectPartNode(node);
                    PartTreeView.SelectedNode = node;
                }
            }

            Text = m_parent.Name + " v" + m_parent.Version + " - " + m_parent.ActiveFile.FilePath;

            closeToolStripMenuItem.Enabled = true;
            saveToolStripMenuItem.Enabled = true;
            saveAsToolStripMenuItem.Enabled = true;
            MainPictureBox.Focus();

            UpdatePropertiesPanel();
            UpdateRecentHistoryList();
        }

        // When the open file dialog presses OK
        private void OpenDungeonOrImageMap_FileOk(object sender, CancelEventArgs e)
        {
            OpenFile(OpenFileDlg.FileName);
        }

        private void SelectPartNode(string name)
        {
            SelectedMap = m_parent.ActiveFile.FindPart(name);
        }
        private void SelectPartNode(TreeNode node)
        {
            if ( !m_mapNodeMap.ContainsKey(node) )
                return;

            SelectedMap = m_mapNodeMap[node];
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ConfirmExit())
            {
                CleanUp();
            }
        }

        private bool ConfirmExit()
        {
            if (m_parent.ActiveFile == null) 
                return true;

            if (CheckForUnsavedWork())
            {
                // If they change their mind at the prompt, leave
                if (PromptSaveWorkWhenQuitting() == DialogResult.Cancel)
                {
                    return false;
                }
            }
                // If they change their mind at the prompt, leave
            else if (PromptClosingProject() == DialogResult.Cancel)
            {
                return false;
            }

            return true;
        }

        private void setDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var guiPopup = new DirPopup(m_parent);
            guiPopup.ShowDialog();      // What is going on here???
            OpenFileDlg.InitialDirectory = Editor.Editor.Settings.AssetDirPath;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BottomBarGfxCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateImageBox(true, true);
        }

        private bool CheckForUnsavedWork()
        {
            bool workUnsaved = false;

            foreach (EditorMapPart part in m_parent.ActiveFile.ReadableParts)
            {
                foreach (EditorMapLayer layer in part.Layers.Where(layer => layer.Changed))
                {
                    workUnsaved = true;
                }
            }

            return workUnsaved;
        }

        private void SaveWork(string path = null, bool overwrite = false)
        {
            if (path == null)
                path = m_parent.ActiveFile.FilePath;

            m_parent.ActiveFile.FilePath = path;
            m_parent.SaveFile(path);
            foreach (EditorMapPart part in m_parent.ActiveFile.ReadableParts)
            {
                foreach (EditorMapLayer layer in part.Layers)
                {
                    if (!overwrite && !layer.Changed) 
                        continue;

                    string layerPath = Path.Combine(Path.GetDirectoryName(m_parent.ActiveFile.FilePath), layer.Name);
                    Image newColourMap = layer.ColourMap;

                    try
                    {
                        newColourMap.Save(layerPath, ImageFormat.Png);
                        layer.Changed = false;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("REPORT THIS ON THE FORUMS\n\n" + ex);
                    }
                }
            }
            if ( m_parent.ActiveFile is StarboundShip )
            {
                foreach ( ShipOverlay overlay in ((StarboundShip)m_parent.ActiveFile).BackgroundOverlays )
                {
                    string overlayPath = Path.Combine(Path.GetDirectoryName(m_parent.ActiveFile.FilePath), overlay.ImageName);
                    try
                    {
                        overlay.Image.Save(overlayPath, ImageFormat.Png);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("REPORT THIS ON THE FORUMS (#2)\n\n" + ex);
                    }
                }
            }
        }

        // Time to save
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (PromptSaveWork() == DialogResult.OK)
            {
                SaveWork();
            }
        }

        private void MainPictureBox_MouseEnter(object sender, EventArgs e)
        {
            MainPictureBox.Focus();
        }

        private void viewCollisionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            viewCollisionsToolStripMenuItem.Checked = !viewCollisionsToolStripMenuItem.Checked;
            Editor.Editor.Settings.ViewCollisionGrid = viewCollisionsToolStripMenuItem.Checked;
            
            if (SelectedMap != null)
                GetSelectedPart().UpdateLayerImage();
        }
        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateImageBox(false, false);
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDlg.InitialDirectory   = Path.GetDirectoryName(m_parent.ActiveFile.FilePath);
            SaveFileDlg.FileName           = Path.GetFileNameWithoutExtension(m_parent.ActiveFile.FilePath);
            
            if ( m_parent.ActiveFile is StarboundDungeon )
            {
                SaveFileDlg.DefaultExt = ".dungeon";
                SaveFileDlg.Filter = "Dungeon Files|*.dungeon";
            }
            else if ( m_parent.ActiveFile is StarboundShip )
            {
                SaveFileDlg.DefaultExt = ".structure";
                SaveFileDlg.Filter = "Ship Files|*.structure";
            }
            else
            {
                SaveFileDlg.DefaultExt = "";
                SaveFileDlg.Filter = "All Files|*.*";
            }

            SaveFileDlg.ShowDialog();
        }

        private void SaveFile_FileOk(object sender, CancelEventArgs e)
        {
            SaveWork(SaveFileDlg.FileName, true);
            Text = m_parent.Name + " v" + m_parent.Version + " - " + m_parent.ActiveFile.FilePath;
        }

        private void takeScreenshotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveScreenshotDlg.ShowDialog();
        }

        private void SaveScreenshotDlg_FileOk(object sender, CancelEventArgs e)
        {
            EditorMapPart part = GetSelectedPart();
            if (part != null)
            {
                part.GraphicsMap.Save(SaveScreenshotDlg.FileName, ImageFormat.Png);
            }
        }
        
    }
}