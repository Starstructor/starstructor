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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DungeonEditor.EditorObjects;
using DungeonEditor.StarboundObjects.Dungeons;
using DungeonEditor.StarboundObjects.Objects;
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
        public Editor m_parent;
        private EditorBrush m_selectedBrush;
        private EditorMap m_selectedMap;

        public MainWindow(Editor parent)
        {
            m_parent = parent;

            InitializeComponent();
        }

        public EditorMap SelectedMap
        {
            get { return m_selectedMap; }
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            WindowState = Editor.Settings.WindowState;
            Left = Editor.Settings.WindowX;
            Top = Editor.Settings.WindowY;
            Width = Editor.Settings.WindowWidth;
            Height = Editor.Settings.WindowHeight;
            MainPictureBox.m_parent = this;

            viewCollisionsToolStripMenuItem.Checked = Editor.Settings.ViewCollisionGrid;
            BottomBarGfxCombo.SelectedIndex = Editor.Settings.GraphicalDisplay ? 0 : 1;
        }

        private void MainWindow_Shown(object sender, EventArgs e)
        {
            Text = m_parent.Name + " v" + m_parent.Version;

            if (Editor.Settings.AssetDirPath == null)
            {
                // Try to auto-find directory
                string path = (string)Registry.GetValue(
                    @"HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall\Steam App 211820",
                    "InstallLocation", null);

                // If found
                if (path != null)
                {
                    path = Path.Combine(path, "assets");
                    Editor.Settings.AssetDirPath = path;
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
            OpenFile.InitialDirectory = Editor.Settings.AssetDirPath;
            MainPictureBox.Focus();
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!ConfirmExit())
            {
                e.Cancel = true;
                return;
            }

            Editor.Settings.WindowState = WindowState;
            Editor.Settings.WindowX = Left;
            Editor.Settings.WindowY = Top;
            Editor.Settings.WindowWidth = Width;
            Editor.Settings.WindowHeight = Height;
            Editor.Settings.GraphicalDisplay = BottomBarGfxCombo.SelectedIndex == 0;

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
            BottomBarBrushLabel.Text = "Selected Brush: ";
            BottomBarXLabel.Text = "Grid X: ";
            BottomBarYLabel.Text = "Grid Y: ";
            BottomBarZoomLabel.Text = "Zoom: ";
            m_brushNodeMap.Clear();
            m_mapNodeMap.Clear();
            m_parent.CleanUpResource();
            m_selectedBrush = null;
            m_selectedMap = null;

            // Update menu items, regardless of how we ended up here
            UpdateUndoRedoItems();
            closeToolStripMenuItem.Enabled = false;
            saveToolStripMenuItem.Enabled = false;

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
            BottomBarXLabel.Text = "Grid X: ";
            BottomBarYLabel.Text = "Grid Y: ";

            if (gridX == -1 || gridY == -1)
            {
                BottomBarXLabel.Text += "N/A";
                BottomBarYLabel.Text += "N/A";
            }
            else
            {
                BottomBarXLabel.Text += gridX;
                BottomBarYLabel.Text += gridY;
            }

            BottomBarXLabel.Refresh();
            BottomBarYLabel.Refresh();
        }


        public void SetSelectedBrush(EditorBrush brush)
        {
            m_selectedBrush = brush;
            string colour =
                "r: " + m_selectedBrush.Colour[0] +
                " g: " + m_selectedBrush.Colour[1] +
                " b: " + m_selectedBrush.Colour[2];

            // Tidy this display up at some point
            BottomBarBrushLabel.Text = "Selected Brush: " + m_selectedBrush.Comment;

            if (m_selectedBrush.FrontAsset != null)
            {
                BottomBarBrushLabel.Text += "       front: " + m_selectedBrush.FrontAsset.AssetName;
            }

            if (m_selectedBrush.BackAsset != null)
            {
                BottomBarBrushLabel.Text += "       back: " + m_selectedBrush.BackAsset.AssetName;
            }

            BottomBarBrushLabel.Text += "        " + colour;

            VisualRgbaBrushDescLabel.Text =
                "r: " + m_selectedBrush.Colour[0] +
                " g: " + m_selectedBrush.Colour[1] +
                " b: " + m_selectedBrush.Colour[2];

            // Populate the colour box
            VisualRgbaBrushImageBox.Image = EditorHelpers.GetGeneratedRectangle(1, 1,
                m_selectedBrush.Colour[0], m_selectedBrush.Colour[1],
                m_selectedBrush.Colour[2], m_selectedBrush.Colour[3]);

            Image assetImg = null;

            // Get the correct preview box asset
            if (m_selectedBrush.FrontAsset != null)
            {
                if (m_selectedBrush.FrontAsset is StarboundObject)
                {
                    StarboundObject sbObject = (StarboundObject)m_selectedBrush.FrontAsset;
                    ObjectOrientation orientation = sbObject.GetDefaultOrientation();

                    if (m_selectedBrush.Direction == ObjectDirection.DIRECTION_LEFT)
                        assetImg = orientation.LeftImage;
                    else if (m_selectedBrush.Direction == ObjectDirection.DIRECTION_RIGHT)
                        assetImg = orientation.RightImage;
                }

                if (assetImg == null)
                    assetImg = m_selectedBrush.FrontAsset.Image;

                VisualGraphicBrushDescLabel.Text = m_selectedBrush.FrontAsset.AssetName;
            }
            else if (m_selectedBrush.BackAsset != null)
            {
                if (m_selectedBrush.BackAsset is StarboundObject)
                {
                    StarboundObject sbObject = (StarboundObject)m_selectedBrush.BackAsset;
                    ObjectOrientation orientation = sbObject.GetDefaultOrientation();

                    if (m_selectedBrush.Direction == ObjectDirection.DIRECTION_LEFT)
                        assetImg = orientation.LeftImage;
                    else if (m_selectedBrush.Direction == ObjectDirection.DIRECTION_RIGHT)
                        assetImg = orientation.RightImage;
                }

                if ( assetImg == null )
                    assetImg = m_selectedBrush.BackAsset.Image;

                VisualGraphicBrushDescLabel.Text = m_selectedBrush.BackAsset.AssetName;
            }

            // Populate the tile preview box
            if (assetImg != null)
            {
                VisualGraphicBrushImageBox.Image = assetImg;
            }

            MainPictureBox.SetSelectedBrush(m_selectedBrush);
        }

        public EditorMapLayer GetSelectedLayer()
        {
            return m_selectedMap == null ? null : m_selectedMap.GetActiveLayer();
        }

        public EditorMapPart GetSelectedPart()
        {
            return m_selectedMap == null ? null : m_selectedMap.GetActivePart();
        }

        public void OnCanvasLeftClick(int gridX, int gridY, int lastGridX, int lastGridY)
        {
            if (m_selectedBrush == null || m_selectedMap == null)
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

            m_selectedMap.RedrawCanvasFromBrush(oldBrush, m_selectedBrush, gridX, gridY);
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
                UndoManager undoManager = activeLayer.UndoManager();

                undoToolStripMenuItem.Enabled = undoManager.CanUndo();
                redoToolStripMenuItem.Enabled = undoManager.CanRedo();
            }
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditorMapLayer activeLayer = GetSelectedLayer();
            if (activeLayer != null)
            {
                var lastChange = activeLayer.UndoManager().Undo();
                if (lastChange != null)
                {
                    m_selectedMap.RedrawCanvasFromBrush(lastChange.Value.m_brushAfter,
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
                var lastChange = activeLayer.UndoManager().Redo();
                if (lastChange != null)
                {
                    m_selectedMap.RedrawCanvasFromBrush(lastChange.Value.m_brushAfter,
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
                BrushesTreeView.SelectedNode = null;    // needed to reselect the previous brush
            }
        }

        // Populate the part list
        private void PopulatePartTreeView()
        {
            foreach (EditorMapPart part in m_parent.ActiveFile.ReadableParts)
            {
                List<TreeNode> childNodes = new List<TreeNode>();

                foreach (EditorMapLayer layer in part.Layers)
                {
                    TreeNode newNode = new TreeNode(layer.Name);
                    m_mapNodeMap[newNode] = layer;
                    childNodes.Add(newNode);
                }

                TreeNode parentNode = new TreeNode(part.Name, childNodes.ToArray<TreeNode>());
                m_mapNodeMap[parentNode] = part;
                PartTreeView.Nodes.Add(parentNode);
            }
        }

        private void PartTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (!m_mapNodeMap.ContainsKey(e.Node)) 
                return;

            m_selectedMap = m_mapNodeMap[e.Node];
            PartDescLabel.Text = "Parts List: " + m_selectedMap.Name;
            UpdateImageBox(true, true);
        }

        // Populate the brush list
        private void PopulateBrushList()
        {
            foreach (EditorBrush brush in m_parent.ActiveFile.BlockMap)
            {
                var children = new List<TreeNode>();
                string comment = brush.Comment;

                if (String.IsNullOrWhiteSpace(comment))
                {
                    comment = "NO COMMENT DEFINED";
                }

                if (brush is DungeonBrush)
                {
                    var dungeonBrush = (DungeonBrush) brush;

                    if (dungeonBrush.Brushes != null)
                    {
                        // Populate the brushes in the asset viewer
                        children.AddRange(from brushArray in dungeonBrush.Brushes 
                                          from brushElement in brushArray 
                                          from child in AddNodes_r(brushElement) 
                                          select child);
                    }
                }

                else if (brush is ShipBrush)
                {
                    var shipBrush = (ShipBrush) brush;

                    foreach (TreeNode child in shipBrush.BrushTypes.SelectMany(AddNodes_r))
                    {
                        if (child.Text == "back")
                        {
                            children.Add(new TreeNode("back: " + shipBrush.BackgroundMat));
                        }
                        else if (child.Text == "front")
                        {
                            children.Add(new TreeNode("front: " + shipBrush.ForegroundMat));
                        }
                        else if (child.Text == "object")
                        {
                            List<TreeNode> objChildren = new List<TreeNode>();

                            if (shipBrush.ObjectDirection != null)
                            {
                                objChildren.Add(new TreeNode("direction",
                                    AddNodes_r(shipBrush.ObjectDirection).ToArray()));
                            }

                            children.Add(new TreeNode("obj: " + shipBrush.Object, objChildren.ToArray()));
                        }
                    }

                    var blockingType = new List<TreeNode>();

                    if (shipBrush.BackgroundBlock)
                        blockingType.Add(new TreeNode("background"));

                    if (shipBrush.ForegroundBlock)
                        blockingType.Add(new TreeNode("foreground"));

                    if (blockingType.Count > 0)
                        children.Add(new TreeNode("blocks", blockingType.ToArray()));
                }

                var parentNode = new TreeNode(comment, children.ToArray<TreeNode>());
                BrushesTreeView.Nodes.Add(parentNode);

                // Add this node to the brush -> node map
                m_brushNodeMap[parentNode] = brush;
            }
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
            if (m_parent.ActiveFile == null || m_selectedMap == null)
                return;

            EditorMapPart part = GetSelectedPart();

            // If we're displaying the graphic map
            if (BottomBarGfxCombo.SelectedIndex == 0)
            {
                m_gridFactor = 8;

                if (m_selectedMap is EditorMapPart)
                {
                    part.UpdateLayerImage();
                }
                else if (m_selectedMap is EditorMapLayer)
                {
                    part.UpdateLayerImage(new List<EditorMapLayer> {(EditorMapLayer) m_selectedMap});
                }

                MainPictureBox.SetImage(part.GraphicsMap, resetZoom, resetCamera, m_gridFactor);
            }

            // If we're displaying the colour map
            else if (BottomBarGfxCombo.SelectedIndex == 1)
            {
                m_gridFactor = 1;

                if (m_selectedMap is EditorMapPart)
                {
                    MainPictureBox.SetImage(part.ColourMap, resetZoom, resetCamera, m_gridFactor);
                }
                else if (m_selectedMap is EditorMapLayer)
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
            OpenFile.ShowDialog();
        }

        // Open a new file
        private void OpenDungeonOrImageMap_FileOk(object sender, CancelEventArgs e)
        {
            if (!ConfirmExit())
                return;

            CleanUp();

            if (!Directory.Exists(Editor.Settings.AssetDirPath))
            {
                MessageBox.Show("Invalid asset directory set. Please choose a valid asset directory " +
                                "from the Starbound menu in the toolset.", "Error", MessageBoxButtons.OK);
                return;
            }

            if (!m_parent.LoadFile(OpenFile.FileName))
            {
                MessageBox.Show("Unable to load!");

                Close();
                return;
            }

            m_parent.ActiveFile.FilePath = OpenFile.FileName;
            m_parent.ScanAssetDirectory();
            m_parent.ActiveFile.GenerateBrushAndAssetMaps(m_parent);
            m_parent.ActiveFile.LoadParts(m_parent);

            PopulatePartTreeView();
            PopulateBrushList();

            if (PartTreeView.Nodes.Count > 0)
            {
                PartTreeView.SelectedNode = PartTreeView.Nodes[0];
            }

            Text = m_parent.Name + " v" + m_parent.Version + " - " + m_parent.ActiveFile.FilePath;

            closeToolStripMenuItem.Enabled = true;
            saveToolStripMenuItem.Enabled = true;
            MainPictureBox.Focus();
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
            guiPopup.ShowDialog();
            OpenFile.InitialDirectory = Editor.Settings.AssetDirPath;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void RightPanelTable_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            Color borderColor = SystemColors.ControlDarkDark;
            const int borderWidth = 1;

            ButtonBorderStyle leftBorderStyle = ButtonBorderStyle.None;
            ButtonBorderStyle topBorderStyle = ButtonBorderStyle.Dotted;
            ButtonBorderStyle rightBorderStyle = ButtonBorderStyle.None;
            ButtonBorderStyle bottomBorderStyle = ButtonBorderStyle.Dotted;

            if (e.Row == 0)
            {
                topBorderStyle = ButtonBorderStyle.Solid;
                bottomBorderStyle = ButtonBorderStyle.None;
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

        private void BottomBarTable_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            Color borderColor = SystemColors.ControlDarkDark;
            const int borderWidth = 1;

            ButtonBorderStyle leftBorderStyle = ButtonBorderStyle.None;
            ButtonBorderStyle topBorderStyle = ButtonBorderStyle.None;
            ButtonBorderStyle rightBorderStyle = ButtonBorderStyle.Dotted;
            ButtonBorderStyle bottomBorderStyle = ButtonBorderStyle.None;

            if (e.Column == 4)
                rightBorderStyle = ButtonBorderStyle.Solid;

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

        private void TreeViewVisualBrushTable_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            Color borderColor = SystemColors.ControlDarkDark;
            const int borderWidth = 1;

            ButtonBorderStyle leftBorderStyle = ButtonBorderStyle.None;
            ButtonBorderStyle topBorderStyle = ButtonBorderStyle.None;
            ButtonBorderStyle rightBorderStyle = ButtonBorderStyle.None;
            ButtonBorderStyle bottomBorderStyle = ButtonBorderStyle.None;

            if (e.Column == 0)
                rightBorderStyle = ButtonBorderStyle.Dotted;

            if (e.Row == 0 || e.Row == 1)
                bottomBorderStyle = ButtonBorderStyle.Dotted;

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

        private void MainTableLayout_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            Color borderColor = SystemColors.ControlDarkDark;
            const int borderWidth = 1;

            ButtonBorderStyle leftBorderStyle = ButtonBorderStyle.None;
            ButtonBorderStyle topBorderStyle = ButtonBorderStyle.None;
            ButtonBorderStyle rightBorderStyle = ButtonBorderStyle.None;
            ButtonBorderStyle bottomBorderStyle = ButtonBorderStyle.None;

            if (e.Column == 0)
            {
                topBorderStyle = ButtonBorderStyle.Solid;
                rightBorderStyle = ButtonBorderStyle.Solid;
                bottomBorderStyle = ButtonBorderStyle.Solid;
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

        private void SaveWork()
        {
            // test serializeation
            /*
            if (m_parent.ActiveFile is StarboundDungeon)
            {
                JsonParser parser = new JsonParser(AppDomain.CurrentDomain.BaseDirectory + Path.GetFileName(m_parent.ActiveFile.FilePath));
                parser.SerializeJson<StarboundDungeon>((StarboundDungeon)m_parent.ActiveFile);
            }
            else if (m_parent.ActiveFile is StarboundShip)
            {
                JsonParser parser = new JsonParser(AppDomain.CurrentDomain.BaseDirectory + Path.GetFileName(m_parent.ActiveFile.FilePath));
                parser.SerializeJson<StarboundShip>((StarboundShip)m_parent.ActiveFile);
            }
             * */

            foreach (EditorMapPart part in m_parent.ActiveFile.ReadableParts)
            {
                foreach (EditorMapLayer layer in part.Layers)
                {
                    if (!layer.Changed) 
                        continue;

                    string path = Path.Combine(Path.GetDirectoryName(m_parent.ActiveFile.FilePath), layer.Name);
                    Image newColourMap = layer.ColourMap;

                    try
                    {
                        newColourMap.Save(path, ImageFormat.Png);
                        layer.Changed = false;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("REPORT THIS ON THE FORUMS\n\n" + ex);
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

        private void MainPictureBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.F10 || m_selectedMap == null) 
                return;

            Image screenGrab = GetSelectedPart().GraphicsMap;
            screenGrab.Save("screengrab.png", ImageFormat.Png);
        }

        private void MainPictureBox_MouseEnter(object sender, EventArgs e)
        {
            MainPictureBox.Focus();
        }

        private void viewCollisionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (viewCollisionsToolStripMenuItem.Checked)
            {
                viewCollisionsToolStripMenuItem.Checked = false;
                Editor.Settings.ViewCollisionGrid = false;
            }
            else
            {
                viewCollisionsToolStripMenuItem.Checked = true;
                Editor.Settings.ViewCollisionGrid = true;
            }

            if (m_selectedMap != null)
            {
                GetSelectedPart().UpdateLayerImage();
            }
        }
        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateImageBox(false, false);
        }
        
    }
}