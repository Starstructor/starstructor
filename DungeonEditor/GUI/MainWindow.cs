using DungeonEditor.StarboundObjects;
using DungeonEditor.StarboundObjects.Dungeons;
using DungeonEditor.StarboundObjects.Tiles;
using DungeonEditor;
using DungeonEditor.EditorObjects;
using Microsoft.Win32;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DungeonEditor.StarboundObjects.Ships;
using DungeonEditor.StarboundObjects.Objects;
using System.Drawing.Imaging;
using System.Timers;

namespace DungeonEditor.GUI
{
    public partial class MainWindow : Form
    {
        public Editor m_parent;

        private Dictionary<TreeNode, EditorBrush> m_brushNodeMap
            = new Dictionary<TreeNode, EditorBrush>();
        private Dictionary<TreeNode, EditorMap> m_mapNodeMap
            = new Dictionary<TreeNode, EditorMap>();

        private EditorMap m_selectedMap;
        private EditorBrush m_selectedBrush;

        private int m_gridFactor;

        public EditorMap SelectedMap
        {
            get
            {
                return m_selectedMap;
            }
        }

        public MainWindow(Editor parent)
        {
            m_parent = parent;

            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            this.WindowState = Editor.Settings.WindowState;
            this.Left = Editor.Settings.WindowX;
            this.Top = Editor.Settings.WindowY;
            this.Width = Editor.Settings.WindowWidth;
            this.Height = Editor.Settings.WindowHeight;
            this.MainPictureBox.m_parent = this;

            this.viewCollisionsToolStripMenuItem.Checked = Editor.Settings.ViewCollisionGrid;

            if (Editor.Settings.GraphicalDisplay)
            {
                this.BottomBarGfxCombo.SelectedIndex = 0;
            }
            else
            {
                this.BottomBarGfxCombo.SelectedIndex = 1;
            }
        }

        private void MainWindow_Shown(object sender, EventArgs e)
        {
            this.Text = m_parent.Name + " v" + m_parent.Version;

            if (Editor.Settings.AssetDirPath == null)
            {
                // Try to auto-find directory
                string path = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall\Steam App 211820", "InstallLocation", null);

                // If found
                if (path != null)
                {
                    path = Path.Combine(path, "assets");
                    Editor.Settings.AssetDirPath = path;
                }
                // Otherwise prompt the user
                else
                {
                    MessageBox.Show("Could not find Starbound folder. Please navigate to Starbound's assets directory on the next screen.");

                    DirPopup guiPopup = new DirPopup(m_parent);
                    guiPopup.ShowDialog();
                }
            }

            m_parent.SaveSettings();
            this.OpenFile.InitialDirectory = Editor.Settings.AssetDirPath;
            this.MainPictureBox.Focus();
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!ConfirmExit())
            {
                e.Cancel = true;
                return;
            }

            Editor.Settings.WindowState = this.WindowState;
            Editor.Settings.WindowX = this.Left;
            Editor.Settings.WindowY = this.Top;
            Editor.Settings.WindowWidth = this.Width;
            Editor.Settings.WindowHeight = this.Height;

            if (this.BottomBarGfxCombo.SelectedIndex == 0)
            {
                Editor.Settings.GraphicalDisplay = true;
            }
            else
            {
                Editor.Settings.GraphicalDisplay = false;
            }

            m_parent.SaveSettings();
        }

        private void CleanUp()
        {
            this.MainPictureBox.SetImage(null, m_gridFactor);
            this.MainPictureBox.SetSelectedBrush(null);
            this.VisualGraphicBrushImageBox.Image = null;
            this.VisualRgbaBrushImageBox.Image = null;
            this.PartTreeView.Nodes.Clear();
            this.BrushesTreeView.Nodes.Clear();
            this.BottomBarBrushLabel.Text = "Selected Brush: ";
            this.BottomBarXLabel.Text = "Grid X: ";
            this.BottomBarYLabel.Text = "Grid Y: ";
            this.BottomBarZoomLabel.Text = "Zoom: ";
            m_brushNodeMap.Clear();
            m_mapNodeMap.Clear();
            m_parent.CleanUpResource();
            m_selectedBrush = null;
            m_selectedMap = null;

            // Force the garbage collector to clean up
            // But it won't do it until next file load because that would be too easy
            GC.Collect();
        }

        private DialogResult PromptClosingProject()
        {
            return MessageBox.Show("Are you sure you wish to close your current opened dungeon?",
                "Exit", MessageBoxButtons.OKCancel);
        }

        private DialogResult PromptSaveWork()
        {
            return MessageBox.Show("Are you sure you would like to save all modified assets in this project?",
                "Save", MessageBoxButtons.OKCancel);
        }

        private DialogResult PromptSaveWorkWhenQuitting()
        {
            return MessageBox.Show("Your project has unsaved work. Are you sure you want to exit without saving? (you can save from the file menu.)",
                "Unsaved work", MessageBoxButtons.OKCancel);
        }

        public void UpdateBottomBar(float zoom)
        {
            this.BottomBarZoomLabel.Text = "Zoom: " + Math.Round(zoom, 1).ToString() + "x";
            this.BottomBarZoomLabel.Refresh();
        }

        public void UpdateBottomBar(int gridX, int gridY)
        {
            this.BottomBarXLabel.Text = "Grid X: ";
            this.BottomBarYLabel.Text = "Grid Y: ";

            if (gridX == -1 || gridY == -1)
            {
                this.BottomBarXLabel.Text += "N/A";
                this.BottomBarYLabel.Text += "N/A";
            }
            else
            {
                this.BottomBarXLabel.Text += gridX;
                this.BottomBarYLabel.Text += gridY;
            }

            this.BottomBarXLabel.Refresh();
            this.BottomBarYLabel.Refresh();
        }


        public void SetSelectedBrush(EditorBrush brush)
        {
            m_selectedBrush = brush;

            string colour =
                "r: " + m_selectedBrush.Colour[0] +
                " g: " + m_selectedBrush.Colour[1] +
                " b: " + m_selectedBrush.Colour[2];

            // Tidy this display up at some point
            this.BottomBarBrushLabel.Text = "Selected Brush: " + m_selectedBrush.Comment;

            if (m_selectedBrush.FrontAsset != null)
            {
                this.BottomBarBrushLabel.Text += "       front: " + m_selectedBrush.FrontAsset.AssetName;
            }

            if (m_selectedBrush.BackAsset != null)
            {
                this.BottomBarBrushLabel.Text += "       back: " + m_selectedBrush.BackAsset.AssetName;
            }

            this.BottomBarBrushLabel.Text += "        " + colour;

            this.VisualRgbaBrushDescLabel.Text =
                "r: " + m_selectedBrush.Colour[0] +
                " g: " + m_selectedBrush.Colour[1] +
                " b: " + m_selectedBrush.Colour[2];

            // Populate the colour box
            this.VisualRgbaBrushImageBox.Image = EditorHelpers.GetGeneratedRectangle(1, 1,
                m_selectedBrush.Colour[0], m_selectedBrush.Colour[1],
                m_selectedBrush.Colour[2], m_selectedBrush.Colour[3]);

            Image assetImg = null;

            // Get the correct preview box asset
            if (m_selectedBrush.FrontAsset != null)
            {
                assetImg = m_selectedBrush.FrontAsset.Image;
                this.VisualGraphicBrushDescLabel.Text = m_selectedBrush.FrontAsset.AssetName;
            }
            else if (m_selectedBrush.BackAsset != null)
            {
                assetImg = m_selectedBrush.BackAsset.Image;
                this.VisualGraphicBrushDescLabel.Text = m_selectedBrush.BackAsset.AssetName;
            }

            // Populate the tile preview box
            if (assetImg != null)
            {
                this.VisualGraphicBrushImageBox.Image = assetImg;
            }

            this.MainPictureBox.SetSelectedBrush(m_selectedBrush);
        }

        public EditorMapLayer GetSelectedLayer()
        {
            if (m_selectedMap == null)
                return null;

            EditorMapLayer activeLayer = null;

            if (m_selectedMap is EditorMapPart)
            {
                activeLayer = ((EditorMapPart)m_selectedMap).Layers.FirstOrDefault();
            }
            else if (m_selectedMap is EditorMapLayer)
            {
                activeLayer = (EditorMapLayer)m_selectedMap;
            }

            return activeLayer;
        }

        public EditorMapPart GetSelectedPart()
        {
            return GetSelectedLayer().Parent;
        }

        public void OnCanvasLeftClick(int gridX, int gridY, int lastGridX, int lastGridY)
        {
            if (m_selectedBrush == null || m_selectedMap == null)
                return;

            // Get the current layer
            EditorMapLayer activeLayer = GetSelectedLayer();

            // Get the old brush, for redrawing purposes
            EditorBrush oldBrush = GetSelectedLayer().GetBrushAt(gridX, gridY);
            ObjectOrientation oldBrushOrientation = null;

            if (oldBrush != null && oldBrush.FrontAsset != null && oldBrush.FrontAsset is StarboundObject)
            {
                oldBrushOrientation = ((StarboundObject)oldBrush.FrontAsset).GetCorrectOrientation(m_selectedMap, gridX, gridY);
            }

            // If there's nothing to change, just leave
            if (gridX == lastGridX && gridY == lastGridY)
                return;

            // Change the layer brush
            activeLayer.SetBrushAt(m_selectedBrush, gridX, gridY, true);

            // We need to selectively redraw here
            if (m_gridFactor != 1)
            {
                HashSet<List<int>> additionalRedrawList = new HashSet<List<int>>();

                int xmin = gridX;
                int xmax = gridX;

                int ymin = gridY;
                int ymax = gridY;

                // If the old brush was an object, we must redraw around it
                if (oldBrushOrientation != null)
                {
                    int sizeX = oldBrushOrientation.GetWidth(m_selectedBrush.Direction, 1);
                    int sizeY = oldBrushOrientation.GetHeight(m_selectedBrush.Direction, 1);
                    int originX = oldBrushOrientation.GetOriginX(m_selectedBrush.Direction, 1);
                    int originY = oldBrushOrientation.GetOriginY(m_selectedBrush.Direction, 1);

                    // Update the minimum and maximum bounds
                    xmin += originX;
                    xmax += sizeX + originX;

                    ymin += originY;
                    ymax += sizeY + originY;
                }
                // If the old brush isn't an object, just redraw a tile
                else
                {
                    xmax += 1;
                    ymax += 1;
                }

                // If the current brush is an object
                // Extend the range of our bounds, so we encompass the old object, AND the new object
                if (m_selectedBrush.FrontAsset != null && m_selectedBrush.FrontAsset is StarboundObject)
                {
                    ObjectOrientation orientation = ((StarboundObject)m_selectedBrush.FrontAsset).GetCorrectOrientation(m_selectedMap, gridX, gridY);

                    int sizeX = orientation.GetWidth(m_selectedBrush.Direction, 1);
                    int sizeY = orientation.GetHeight(m_selectedBrush.Direction, 1);
                    int originX = orientation.GetOriginX(m_selectedBrush.Direction, 1);
                    int originY = orientation.GetOriginY(m_selectedBrush.Direction, 1);

                    int newxmin = xmin + originX;
                    int newxmax = xmax + sizeX + originX;

                    int newymin = ymin + originY;
                    int newymax = ymax + sizeY + originY;

                    if (newxmin < xmin)
                        xmin = newxmin;

                    if (newxmax > xmax)
                        xmax = newxmax;

                    if (newymin < ymin)
                        ymin = newymin;

                    if (newymax > ymax)
                        ymax = newymax;
                }

                for (int x = xmin; x < xmax; ++x)
                {
                    for (int y = ymin; y < ymax; ++y)
                    {
                        HashSet<List<int>> collisions = null;
                        
                        if (m_selectedMap is EditorMapPart)
                        {
                            collisions = activeLayer.Parent.GetCollisionsAt(x, y);
                        }
                        else if (m_selectedMap is EditorMapLayer)
                        {
                            collisions = activeLayer.GetCollisionsAt(x, y);
                        }

                        if (collisions != null)
                        {
                            foreach (List<int> coords in collisions)
                            {
                                if ((coords[0] != x || coords[1] != y) &&
                                    (coords[0] != gridX || coords[1] != gridY))
                                {
                                    additionalRedrawList.Add(coords);
                                }
                            }
                        }
                    }
                }

                // Selectively redraw the composite image
                if (m_selectedMap is EditorMapPart)
                {
                    activeLayer.Parent.UpdateLayerImageBetween(
                        xmin, 
                        ymin, 
                        xmax, 
                        ymax);

                    foreach (List<int> coords in additionalRedrawList)
                    {
                        activeLayer.Parent.UpdateLayerImageBetween(
                            coords[0], 
                            coords[1], 
                            coords[0] + 1, 
                            coords[1] + 1);
                    }
                }

                // Only selectively redraw the active layer
                else if (m_selectedMap is EditorMapLayer)
                {
                    activeLayer.Parent.UpdateLayerImageBetween(
                        new List<EditorMapLayer>() { activeLayer },
                        xmin,
                        ymin,
                        xmax,
                        ymax);

                    foreach (List<int> coords in additionalRedrawList)
                    {
                        activeLayer.Parent.UpdateLayerImageBetween(
                            new List<EditorMapLayer>() { activeLayer }, 
                            coords[0], 
                            coords[1], 
                            coords[0] + 1, 
                            coords[1] + 1);
                    }
                }
            }
                
            // There MUST be an immediate refresh here
            // Otherwise the system will delay the refresh on large images
            this.MainPictureBox.Refresh();
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
                    m_mapNodeMap[newNode] = (EditorMap)layer;
                    childNodes.Add(newNode);
                }

                TreeNode parentNode = new TreeNode(part.Name, childNodes.ToArray<TreeNode>());
                m_mapNodeMap[parentNode] = (EditorMap)part;
                this.PartTreeView.Nodes.Add(parentNode);
            }
        }

        private void PartTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (m_mapNodeMap.ContainsKey(e.Node))
            {
                m_selectedMap = m_mapNodeMap[e.Node];
                this.PartDescLabel.Text = "Parts List: " + m_selectedMap.Name;
                UpdateImageBox(true, true);
            }
        }

        // Populate the brush list
        private void PopulateBrushList()
        {
            foreach (EditorBrush brush in m_parent.ActiveFile.BlockMap)
            {
                List<TreeNode> children = new List<TreeNode>();
                string comment = brush.Comment;

                if (String.IsNullOrWhiteSpace(comment))
                {
                    comment = "NO COMMENT DEFINED";
                }

                if (brush is DungeonBrush)
                {
                    DungeonBrush dungeonBrush = (DungeonBrush)brush;

                    if (dungeonBrush.Brushes != null)
                    {
                        // Populate the brushes in the asset viewer
                        foreach (List<object> brushArray in dungeonBrush.Brushes)
                        {
                            foreach (var brushElement in brushArray)
                            {
                                foreach (TreeNode child in AddNodes_r(brushElement))
                                {
                                    children.Add(child);
                                }
                            }
                        }
                    }
                }

                else if (brush is ShipBrush)
                {
                    ShipBrush shipBrush = (ShipBrush)brush;

                    foreach (string element in shipBrush.BrushTypes)
                    {
                        foreach (TreeNode child in AddNodes_r(element))
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
                                    objChildren.Add(new TreeNode("direction", AddNodes_r(shipBrush.ObjectDirection).ToArray()));

                                }

                                children.Add(new TreeNode("obj: " + shipBrush.Object, objChildren.ToArray()));
                            }
                        }
                    }

                    List<TreeNode> blockingType = new List<TreeNode>();

                    if (shipBrush.BackgroundBlock)
                        blockingType.Add(new TreeNode("background"));

                    if (shipBrush.ForegroundBlock)                   
                        blockingType.Add(new TreeNode("foreground"));

                    if (blockingType.Count > 0)
                        children.Add(new TreeNode("blocks", blockingType.ToArray()));
                }

                TreeNode parentNode = new TreeNode(comment, children.ToArray<TreeNode>());
                this.BrushesTreeView.Nodes.Add(parentNode);

                // Add this node to the brush -> node map
                m_brushNodeMap[parentNode] = brush;
            }

            return;
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
            if (this.BottomBarGfxCombo.SelectedIndex == 0)
            {
                m_gridFactor = 8;

                if (m_selectedMap is EditorMapPart)
                {
                    part.UpdateLayerImage();
                }
                else if (m_selectedMap is EditorMapLayer)
                {
                    part.UpdateLayerImage(new List<EditorMapLayer>() { (EditorMapLayer)m_selectedMap });
                }

                this.MainPictureBox.SetImage(part.GraphicsMap, resetZoom, resetCamera, m_gridFactor);
            }

            // If we're displaying the colour map
            else if (this.BottomBarGfxCombo.SelectedIndex == 1)
            {
                m_gridFactor = 1;

                if (m_selectedMap is EditorMapPart)
                {
                    this.MainPictureBox.SetImage(part.ColourMap, resetZoom, resetCamera, m_gridFactor);
                }
                else if (m_selectedMap is EditorMapLayer)
                {
                    this.MainPictureBox.SetImage(GetSelectedLayer().ColourMap, resetZoom, resetCamera, m_gridFactor);
                }
            }

            this.MainPictureBox.Invalidate();
        }


        // Recursively generate a list of TreeNodes
        // This needs to be improved in the future
        private List<TreeNode> AddNodes_r(object element)
        {
            List<TreeNode> nodes = new List<TreeNode>();

            if (element is JObject)
            {
                foreach (object deepElem in (JObject)element)
                {
                    foreach (TreeNode node in AddNodes_r(deepElem))
                    {
                        nodes.Add(node);
                    }
                }
            }

            else if (element is JArray)
            {
                foreach (object deepElem in (JArray)element)
                {
                    foreach (TreeNode node in AddNodes_r(deepElem))
                    {
                        nodes.Add(node);
                    }
                }
            }

            else if (element is JValue)
            {
                nodes.Add(new TreeNode(((JValue)element).ToString()));
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

        // Open a new dungeon
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

            if (Path.GetExtension(OpenFile.FileName) == ".dungeon")
            {
                StarboundDungeon.LoadFile(OpenFile.FileName, m_parent);
            }
            else if (Path.GetExtension(OpenFile.FileName) == ".structure")
            {
                StarboundShip.LoadFile(OpenFile.FileName, m_parent);
            }

            if (m_parent.ActiveFile == null)
            {
                MessageBox.Show("Unable to load!");

                this.Close();
                return;
            }

            m_parent.ActiveFile.FilePath = OpenFile.FileName;

            this.Text = m_parent.Name + " v" + m_parent.Version + " - " + m_parent.ActiveFile.FilePath;

            m_parent.ScanAssetDirectory();
            m_parent.ActiveFile.GenerateBrushAndAssetMaps(m_parent);
            m_parent.ActiveFile.LoadParts(m_parent);

            PopulatePartTreeView();
            PopulateBrushList();

            if (this.PartTreeView.Nodes.Count > 0)
            {
                this.PartTreeView.SelectedNode = this.PartTreeView.Nodes[0];
            }

            this.closeToolStripMenuItem.Enabled = true;
            this.saveToolStripMenuItem.Enabled = true;
            this.MainPictureBox.Focus();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ConfirmExit())
            {
                CleanUp();
            }

            this.closeToolStripMenuItem.Enabled = false;
            this.saveToolStripMenuItem.Enabled = false;
        }

        private bool ConfirmExit()
        {
            if (m_parent.ActiveFile != null)
            {
                if (CheckForUnsavedWork())
                {
                    // If they change their mind at the prompt, leave
                    if (PromptSaveWorkWhenQuitting() == System.Windows.Forms.DialogResult.Cancel)
                    {
                        return false;
                    }
                }
                // If they change their mind at the prompt, leave
                else if (PromptClosingProject() == DialogResult.Cancel)
                {
                    return false;
                }
            }

            return true;
        }

        private void setDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DirPopup guiPopup = new DirPopup(m_parent);
            guiPopup.ShowDialog();
            this.OpenFile.InitialDirectory = Editor.Settings.AssetDirPath;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RightPanelTable_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            var borderColor = SystemColors.ControlDarkDark;
            var borderWidth = 1;

            var leftBorderStyle = ButtonBorderStyle.None;
            var topBorderStyle = ButtonBorderStyle.Dotted;
            var rightBorderStyle = ButtonBorderStyle.None;
            var bottomBorderStyle = ButtonBorderStyle.Dotted;

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
            var borderColor = SystemColors.ControlDarkDark;
            var borderWidth = 1;

            var leftBorderStyle = ButtonBorderStyle.None;
            var topBorderStyle = ButtonBorderStyle.None;
            var rightBorderStyle = ButtonBorderStyle.Dotted;
            var bottomBorderStyle = ButtonBorderStyle.None;

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
            var borderColor = SystemColors.ControlDarkDark;
            var borderWidth = 1;

            var leftBorderStyle = ButtonBorderStyle.None;
            var topBorderStyle = ButtonBorderStyle.None;
            var rightBorderStyle = ButtonBorderStyle.None;
            var bottomBorderStyle = ButtonBorderStyle.None;

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
            var borderColor = SystemColors.ControlDarkDark;
            var borderWidth = 1;

            var leftBorderStyle = ButtonBorderStyle.None;
            var topBorderStyle = ButtonBorderStyle.None;
            var rightBorderStyle = ButtonBorderStyle.None;
            var bottomBorderStyle = ButtonBorderStyle.None;

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
                foreach (EditorMapLayer layer in part.Layers)
                {
                    if (layer.Changed)
                    {
                        workUnsaved = true;
                    }
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
                    if (layer.Changed)
                    {
                        string path = Path.Combine(Path.GetDirectoryName(m_parent.ActiveFile.FilePath), layer.Name);
                        Image newColourMap = layer.ColourMap;

                        try
                        {
                            newColourMap.Save(path, ImageFormat.Png);
                            layer.Changed = false;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("REPORT THIS ON THE FORUMS\n\n" + ex.ToString());
                        }
                    }
                }
            }
        }

        // Time to save
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (PromptSaveWork() == System.Windows.Forms.DialogResult.OK)
            {
                SaveWork();
            }
        }

        private void MainPictureBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                UpdateImageBox(false, false);
            }

            if (e.KeyCode == Keys.F10 && m_selectedMap != null)
            {
                Image screenGrab = GetSelectedPart().GraphicsMap;
                screenGrab.Save("screengrab.png", ImageFormat.Png);
            }
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
    }
}