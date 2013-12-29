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
using System.Windows.Forms;
namespace DungeonEditor.GUI
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dungeonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.viewCollisionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dungeonToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.addObjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addDungeonMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addBrushToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.starboundToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.authorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenFile = new System.Windows.Forms.OpenFileDialog();
            this.SaveActive = new System.Windows.Forms.SaveFileDialog();
            this.ScreenLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.MainTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.MainPictureBox = new DungeonEditor.GUI.ImageBox();
            this.BottomBarTable = new System.Windows.Forms.TableLayoutPanel();
            this.BottomBarGfxModePanel = new System.Windows.Forms.Panel();
            this.BottomBarGfxCombo = new System.Windows.Forms.ComboBox();
            this.BottomBarModeLabel = new System.Windows.Forms.Label();
            this.BottomBarBrushLabel = new System.Windows.Forms.Label();
            this.BottomBarZoomLabel = new System.Windows.Forms.Label();
            this.BottomBarXLabel = new System.Windows.Forms.Label();
            this.BottomBarYLabel = new System.Windows.Forms.Label();
            this.RightPanelTable = new System.Windows.Forms.TableLayoutPanel();
            this.TreeViewVisualBrushTable = new System.Windows.Forms.TableLayoutPanel();
            this.VisualRgbaBrushLabel = new System.Windows.Forms.Label();
            this.VisualRgbaBrushDescLabel = new System.Windows.Forms.Label();
            this.VisualGraphicBrushLabel = new System.Windows.Forms.Label();
            this.VisualGraphicBrushDescLabel = new System.Windows.Forms.Label();
            this.VisualRgbaBrushImageBox = new DungeonEditor.GUI.NoAliasPictureBox();
            this.VisualGraphicBrushImageBox = new DungeonEditor.GUI.NoAliasPictureBox();
            this.PartDescLabel = new System.Windows.Forms.Label();
            this.PartTreeView = new System.Windows.Forms.TreeView();
            this.BrushesDescLabel = new System.Windows.Forms.Label();
            this.BrushesTreeView = new System.Windows.Forms.TreeView();
            this.MainMenu.SuspendLayout();
            this.ScreenLayoutPanel.SuspendLayout();
            this.MainTableLayout.SuspendLayout();
            this.BottomBarTable.SuspendLayout();
            this.BottomBarGfxModePanel.SuspendLayout();
            this.RightPanelTable.SuspendLayout();
            this.TreeViewVisualBrushTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VisualRgbaBrushImageBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VisualGraphicBrushImageBox)).BeginInit();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.BackColor = System.Drawing.SystemColors.Control;
            this.MainMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.dungeonToolStripMenuItem1,
            this.starboundToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.MainMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.MainMenu.Size = new System.Drawing.Size(1264, 24);
            this.MainMenu.TabIndex = 0;
            this.MainMenu.Text = "Menu";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.toolStripSeparator3,
            this.closeToolStripMenuItem,
            this.toolStripSeparator2,
            this.saveToolStripMenuItem,
            this.toolStripSeparator4,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.newToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dungeonToolStripMenuItem});
            this.newToolStripMenuItem.Enabled = false;
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.newToolStripMenuItem.Text = "New";
            // 
            // dungeonToolStripMenuItem
            // 
            this.dungeonToolStripMenuItem.Name = "dungeonToolStripMenuItem";
            this.dungeonToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.dungeonToolStripMenuItem.Text = "Dungeon";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(149, 6);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.closeToolStripMenuItem.Enabled = false;
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(149, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.saveToolStripMenuItem.Enabled = false;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(149, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Enabled = false;
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.undoToolStripMenuItem.Text = "Undo";
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.undoToolStripMenuItem_Click);
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Enabled = false;
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.Z)));
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.redoToolStripMenuItem.Text = "Redo";
            this.redoToolStripMenuItem.Click += new System.EventHandler(this.redoToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshToolStripMenuItem,
            this.toolStripSeparator1,
            this.viewCollisionsToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(150, 6);
            // 
            // viewCollisionsToolStripMenuItem
            // 
            this.viewCollisionsToolStripMenuItem.Name = "viewCollisionsToolStripMenuItem";
            this.viewCollisionsToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.viewCollisionsToolStripMenuItem.Text = "View Collisions";
            this.viewCollisionsToolStripMenuItem.Click += new System.EventHandler(this.viewCollisionsToolStripMenuItem_Click);
            // 
            // dungeonToolStripMenuItem1
            // 
            this.dungeonToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addObjectToolStripMenuItem,
            this.addDungeonMapToolStripMenuItem,
            this.addBrushToolStripMenuItem});
            this.dungeonToolStripMenuItem1.Name = "dungeonToolStripMenuItem1";
            this.dungeonToolStripMenuItem1.Size = new System.Drawing.Size(68, 20);
            this.dungeonToolStripMenuItem1.Text = "Dungeon";
            // 
            // addObjectToolStripMenuItem
            // 
            this.addObjectToolStripMenuItem.Enabled = false;
            this.addObjectToolStripMenuItem.Name = "addObjectToolStripMenuItem";
            this.addObjectToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.addObjectToolStripMenuItem.Text = "Add Object";
            // 
            // addDungeonMapToolStripMenuItem
            // 
            this.addDungeonMapToolStripMenuItem.Enabled = false;
            this.addDungeonMapToolStripMenuItem.Name = "addDungeonMapToolStripMenuItem";
            this.addDungeonMapToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.addDungeonMapToolStripMenuItem.Text = "Add Part";
            // 
            // addBrushToolStripMenuItem
            // 
            this.addBrushToolStripMenuItem.Enabled = false;
            this.addBrushToolStripMenuItem.Name = "addBrushToolStripMenuItem";
            this.addBrushToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.addBrushToolStripMenuItem.Text = "Add Brush";
            // 
            // starboundToolStripMenuItem
            // 
            this.starboundToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setDirectoryToolStripMenuItem});
            this.starboundToolStripMenuItem.Name = "starboundToolStripMenuItem";
            this.starboundToolStripMenuItem.Size = new System.Drawing.Size(74, 20);
            this.starboundToolStripMenuItem.Text = "Starbound";
            // 
            // setDirectoryToolStripMenuItem
            // 
            this.setDirectoryToolStripMenuItem.Name = "setDirectoryToolStripMenuItem";
            this.setDirectoryToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.setDirectoryToolStripMenuItem.Text = "Set Directory";
            this.setDirectoryToolStripMenuItem.Click += new System.EventHandler(this.setDirectoryToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.authorToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // authorToolStripMenuItem
            // 
            this.authorToolStripMenuItem.Enabled = false;
            this.authorToolStripMenuItem.Name = "authorToolStripMenuItem";
            this.authorToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.authorToolStripMenuItem.Text = "Author";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Enabled = false;
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // OpenFile
            // 
            this.OpenFile.FileName = "open";
            this.OpenFile.Filter = "All Editor Types|*.dungeon;*.structure|Dungeon Files|*.dungeon|Ship Files|*.struc" +
    "ture";
            this.OpenFile.FileOk += new System.ComponentModel.CancelEventHandler(this.OpenDungeonOrImageMap_FileOk);
            // 
            // ScreenLayoutPanel
            // 
            this.ScreenLayoutPanel.AutoSize = true;
            this.ScreenLayoutPanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ScreenLayoutPanel.ColumnCount = 2;
            this.ScreenLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ScreenLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.ScreenLayoutPanel.Controls.Add(this.MainTableLayout, 0, 0);
            this.ScreenLayoutPanel.Controls.Add(this.RightPanelTable, 1, 0);
            this.ScreenLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ScreenLayoutPanel.Location = new System.Drawing.Point(0, 24);
            this.ScreenLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.ScreenLayoutPanel.Name = "ScreenLayoutPanel";
            this.ScreenLayoutPanel.RowCount = 1;
            this.ScreenLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ScreenLayoutPanel.Size = new System.Drawing.Size(1264, 738);
            this.ScreenLayoutPanel.TabIndex = 3;
            // 
            // MainTableLayout
            // 
            this.MainTableLayout.ColumnCount = 1;
            this.MainTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainTableLayout.Controls.Add(this.MainPictureBox, 0, 0);
            this.MainTableLayout.Controls.Add(this.BottomBarTable, 0, 1);
            this.MainTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTableLayout.Location = new System.Drawing.Point(0, 0);
            this.MainTableLayout.Margin = new System.Windows.Forms.Padding(0);
            this.MainTableLayout.Name = "MainTableLayout";
            this.MainTableLayout.RowCount = 2;
            this.MainTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.MainTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.MainTableLayout.Size = new System.Drawing.Size(1064, 738);
            this.MainTableLayout.TabIndex = 2;
            this.MainTableLayout.CellPaint += new System.Windows.Forms.TableLayoutCellPaintEventHandler(this.MainTableLayout_CellPaint);
            // 
            // MainPictureBox
            // 
            this.MainPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.MainPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPictureBox.Location = new System.Drawing.Point(3, 3);
            this.MainPictureBox.Name = "MainPictureBox";
            this.MainPictureBox.Size = new System.Drawing.Size(1058, 701);
            this.MainPictureBox.TabIndex = 2;
            this.MainPictureBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainPictureBox_KeyDown);
            // 
            // BottomBarTable
            // 
            this.BottomBarTable.BackColor = System.Drawing.SystemColors.Control;
            this.BottomBarTable.ColumnCount = 5;
            this.BottomBarTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.BottomBarTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.BottomBarTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.BottomBarTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.BottomBarTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.BottomBarTable.Controls.Add(this.BottomBarGfxModePanel, 0, 0);
            this.BottomBarTable.Controls.Add(this.BottomBarBrushLabel, 1, 0);
            this.BottomBarTable.Controls.Add(this.BottomBarZoomLabel, 2, 0);
            this.BottomBarTable.Controls.Add(this.BottomBarXLabel, 3, 0);
            this.BottomBarTable.Controls.Add(this.BottomBarYLabel, 4, 0);
            this.BottomBarTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BottomBarTable.Location = new System.Drawing.Point(0, 707);
            this.BottomBarTable.Margin = new System.Windows.Forms.Padding(0);
            this.BottomBarTable.Name = "BottomBarTable";
            this.BottomBarTable.RowCount = 1;
            this.BottomBarTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.BottomBarTable.Size = new System.Drawing.Size(1064, 31);
            this.BottomBarTable.TabIndex = 1;
            this.BottomBarTable.CellPaint += new System.Windows.Forms.TableLayoutCellPaintEventHandler(this.BottomBarTable_CellPaint);
            // 
            // BottomBarGfxModePanel
            // 
            this.BottomBarGfxModePanel.AutoScroll = true;
            this.BottomBarGfxModePanel.BackColor = System.Drawing.Color.Transparent;
            this.BottomBarGfxModePanel.Controls.Add(this.BottomBarGfxCombo);
            this.BottomBarGfxModePanel.Controls.Add(this.BottomBarModeLabel);
            this.BottomBarGfxModePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BottomBarGfxModePanel.Location = new System.Drawing.Point(0, 0);
            this.BottomBarGfxModePanel.Margin = new System.Windows.Forms.Padding(0);
            this.BottomBarGfxModePanel.Name = "BottomBarGfxModePanel";
            this.BottomBarGfxModePanel.Size = new System.Drawing.Size(180, 31);
            this.BottomBarGfxModePanel.TabIndex = 1;
            // 
            // BottomBarGfxCombo
            // 
            this.BottomBarGfxCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BottomBarGfxCombo.FormattingEnabled = true;
            this.BottomBarGfxCombo.Items.AddRange(new object[] {
            "Graphical Display",
            "Colour Display"});
            this.BottomBarGfxCombo.Location = new System.Drawing.Point(45, 5);
            this.BottomBarGfxCombo.Margin = new System.Windows.Forms.Padding(0);
            this.BottomBarGfxCombo.Name = "BottomBarGfxCombo";
            this.BottomBarGfxCombo.Size = new System.Drawing.Size(125, 21);
            this.BottomBarGfxCombo.TabIndex = 5;
            this.BottomBarGfxCombo.SelectedIndexChanged += new System.EventHandler(this.BottomBarGfxCombo_SelectedIndexChanged);
            // 
            // BottomBarModeLabel
            // 
            this.BottomBarModeLabel.BackColor = System.Drawing.Color.Transparent;
            this.BottomBarModeLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BottomBarModeLabel.Location = new System.Drawing.Point(0, 0);
            this.BottomBarModeLabel.Margin = new System.Windows.Forms.Padding(0);
            this.BottomBarModeLabel.Name = "BottomBarModeLabel";
            this.BottomBarModeLabel.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.BottomBarModeLabel.Size = new System.Drawing.Size(180, 31);
            this.BottomBarModeLabel.TabIndex = 1;
            this.BottomBarModeLabel.Text = "Mode:";
            this.BottomBarModeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BottomBarBrushLabel
            // 
            this.BottomBarBrushLabel.AutoSize = true;
            this.BottomBarBrushLabel.BackColor = System.Drawing.Color.Transparent;
            this.BottomBarBrushLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BottomBarBrushLabel.Location = new System.Drawing.Point(180, 0);
            this.BottomBarBrushLabel.Margin = new System.Windows.Forms.Padding(0);
            this.BottomBarBrushLabel.Name = "BottomBarBrushLabel";
            this.BottomBarBrushLabel.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.BottomBarBrushLabel.Size = new System.Drawing.Size(634, 31);
            this.BottomBarBrushLabel.TabIndex = 3;
            this.BottomBarBrushLabel.Text = "Selected Brush:";
            this.BottomBarBrushLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BottomBarZoomLabel
            // 
            this.BottomBarZoomLabel.BackColor = System.Drawing.Color.Transparent;
            this.BottomBarZoomLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BottomBarZoomLabel.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.BottomBarZoomLabel.Location = new System.Drawing.Point(814, 0);
            this.BottomBarZoomLabel.Margin = new System.Windows.Forms.Padding(0);
            this.BottomBarZoomLabel.Name = "BottomBarZoomLabel";
            this.BottomBarZoomLabel.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.BottomBarZoomLabel.Size = new System.Drawing.Size(100, 31);
            this.BottomBarZoomLabel.TabIndex = 4;
            this.BottomBarZoomLabel.Text = "Zoom:";
            this.BottomBarZoomLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BottomBarXLabel
            // 
            this.BottomBarXLabel.BackColor = System.Drawing.Color.Transparent;
            this.BottomBarXLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BottomBarXLabel.Location = new System.Drawing.Point(914, 0);
            this.BottomBarXLabel.Margin = new System.Windows.Forms.Padding(0);
            this.BottomBarXLabel.Name = "BottomBarXLabel";
            this.BottomBarXLabel.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.BottomBarXLabel.Size = new System.Drawing.Size(75, 31);
            this.BottomBarXLabel.TabIndex = 5;
            this.BottomBarXLabel.Text = "X:";
            this.BottomBarXLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BottomBarYLabel
            // 
            this.BottomBarYLabel.AutoSize = true;
            this.BottomBarYLabel.BackColor = System.Drawing.Color.Transparent;
            this.BottomBarYLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BottomBarYLabel.Location = new System.Drawing.Point(989, 0);
            this.BottomBarYLabel.Margin = new System.Windows.Forms.Padding(0);
            this.BottomBarYLabel.Name = "BottomBarYLabel";
            this.BottomBarYLabel.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.BottomBarYLabel.Size = new System.Drawing.Size(75, 31);
            this.BottomBarYLabel.TabIndex = 6;
            this.BottomBarYLabel.Text = "Y:";
            this.BottomBarYLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // RightPanelTable
            // 
            this.RightPanelTable.BackColor = System.Drawing.SystemColors.Control;
            this.RightPanelTable.ColumnCount = 1;
            this.RightPanelTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.RightPanelTable.Controls.Add(this.TreeViewVisualBrushTable, 0, 0);
            this.RightPanelTable.Controls.Add(this.PartDescLabel, 0, 1);
            this.RightPanelTable.Controls.Add(this.PartTreeView, 0, 2);
            this.RightPanelTable.Controls.Add(this.BrushesDescLabel, 0, 3);
            this.RightPanelTable.Controls.Add(this.BrushesTreeView, 0, 4);
            this.RightPanelTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RightPanelTable.Location = new System.Drawing.Point(1064, 0);
            this.RightPanelTable.Margin = new System.Windows.Forms.Padding(0);
            this.RightPanelTable.Name = "RightPanelTable";
            this.RightPanelTable.RowCount = 5;
            this.RightPanelTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.RightPanelTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.RightPanelTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.RightPanelTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.RightPanelTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.RightPanelTable.Size = new System.Drawing.Size(200, 738);
            this.RightPanelTable.TabIndex = 3;
            this.RightPanelTable.CellPaint += new System.Windows.Forms.TableLayoutCellPaintEventHandler(this.RightPanelTable_CellPaint);
            // 
            // TreeViewVisualBrushTable
            // 
            this.TreeViewVisualBrushTable.BackColor = System.Drawing.Color.Transparent;
            this.TreeViewVisualBrushTable.ColumnCount = 2;
            this.TreeViewVisualBrushTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TreeViewVisualBrushTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TreeViewVisualBrushTable.Controls.Add(this.VisualRgbaBrushLabel, 0, 0);
            this.TreeViewVisualBrushTable.Controls.Add(this.VisualRgbaBrushDescLabel, 0, 1);
            this.TreeViewVisualBrushTable.Controls.Add(this.VisualGraphicBrushLabel, 1, 0);
            this.TreeViewVisualBrushTable.Controls.Add(this.VisualGraphicBrushDescLabel, 1, 1);
            this.TreeViewVisualBrushTable.Controls.Add(this.VisualRgbaBrushImageBox, 0, 2);
            this.TreeViewVisualBrushTable.Controls.Add(this.VisualGraphicBrushImageBox, 1, 2);
            this.TreeViewVisualBrushTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TreeViewVisualBrushTable.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.TreeViewVisualBrushTable.Location = new System.Drawing.Point(0, 0);
            this.TreeViewVisualBrushTable.Margin = new System.Windows.Forms.Padding(0);
            this.TreeViewVisualBrushTable.Name = "TreeViewVisualBrushTable";
            this.TreeViewVisualBrushTable.RowCount = 3;
            this.TreeViewVisualBrushTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TreeViewVisualBrushTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TreeViewVisualBrushTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TreeViewVisualBrushTable.Size = new System.Drawing.Size(200, 150);
            this.TreeViewVisualBrushTable.TabIndex = 5;
            this.TreeViewVisualBrushTable.CellPaint += new System.Windows.Forms.TableLayoutCellPaintEventHandler(this.TreeViewVisualBrushTable_CellPaint);
            // 
            // VisualRgbaBrushLabel
            // 
            this.VisualRgbaBrushLabel.BackColor = System.Drawing.Color.Transparent;
            this.VisualRgbaBrushLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VisualRgbaBrushLabel.Location = new System.Drawing.Point(0, 0);
            this.VisualRgbaBrushLabel.Margin = new System.Windows.Forms.Padding(0);
            this.VisualRgbaBrushLabel.Name = "VisualRgbaBrushLabel";
            this.VisualRgbaBrushLabel.Size = new System.Drawing.Size(100, 20);
            this.VisualRgbaBrushLabel.TabIndex = 5;
            this.VisualRgbaBrushLabel.Text = "Colour";
            this.VisualRgbaBrushLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // VisualRgbaBrushDescLabel
            // 
            this.VisualRgbaBrushDescLabel.AutoSize = true;
            this.VisualRgbaBrushDescLabel.BackColor = System.Drawing.Color.Transparent;
            this.VisualRgbaBrushDescLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VisualRgbaBrushDescLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VisualRgbaBrushDescLabel.Location = new System.Drawing.Point(0, 20);
            this.VisualRgbaBrushDescLabel.Margin = new System.Windows.Forms.Padding(0);
            this.VisualRgbaBrushDescLabel.Name = "VisualRgbaBrushDescLabel";
            this.VisualRgbaBrushDescLabel.Size = new System.Drawing.Size(100, 20);
            this.VisualRgbaBrushDescLabel.TabIndex = 6;
            this.VisualRgbaBrushDescLabel.Text = "no brush selected";
            this.VisualRgbaBrushDescLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // VisualGraphicBrushLabel
            // 
            this.VisualGraphicBrushLabel.BackColor = System.Drawing.Color.Transparent;
            this.VisualGraphicBrushLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VisualGraphicBrushLabel.Location = new System.Drawing.Point(100, 0);
            this.VisualGraphicBrushLabel.Margin = new System.Windows.Forms.Padding(0);
            this.VisualGraphicBrushLabel.Name = "VisualGraphicBrushLabel";
            this.VisualGraphicBrushLabel.Size = new System.Drawing.Size(100, 20);
            this.VisualGraphicBrushLabel.TabIndex = 4;
            this.VisualGraphicBrushLabel.Text = "Tile";
            this.VisualGraphicBrushLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // VisualGraphicBrushDescLabel
            // 
            this.VisualGraphicBrushDescLabel.AutoSize = true;
            this.VisualGraphicBrushDescLabel.BackColor = System.Drawing.Color.Transparent;
            this.VisualGraphicBrushDescLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VisualGraphicBrushDescLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VisualGraphicBrushDescLabel.Location = new System.Drawing.Point(100, 20);
            this.VisualGraphicBrushDescLabel.Margin = new System.Windows.Forms.Padding(0);
            this.VisualGraphicBrushDescLabel.Name = "VisualGraphicBrushDescLabel";
            this.VisualGraphicBrushDescLabel.Size = new System.Drawing.Size(100, 20);
            this.VisualGraphicBrushDescLabel.TabIndex = 7;
            this.VisualGraphicBrushDescLabel.Text = "no brush selected";
            this.VisualGraphicBrushDescLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // VisualRgbaBrushImageBox
            // 
            this.VisualRgbaBrushImageBox.BackColor = System.Drawing.SystemColors.Window;
            this.VisualRgbaBrushImageBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VisualRgbaBrushImageBox.Location = new System.Drawing.Point(5, 45);
            this.VisualRgbaBrushImageBox.Margin = new System.Windows.Forms.Padding(5);
            this.VisualRgbaBrushImageBox.Name = "VisualRgbaBrushImageBox";
            this.VisualRgbaBrushImageBox.Size = new System.Drawing.Size(90, 100);
            this.VisualRgbaBrushImageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.VisualRgbaBrushImageBox.TabIndex = 3;
            this.VisualRgbaBrushImageBox.TabStop = false;
            // 
            // VisualGraphicBrushImageBox
            // 
            this.VisualGraphicBrushImageBox.BackColor = System.Drawing.SystemColors.Window;
            this.VisualGraphicBrushImageBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VisualGraphicBrushImageBox.Location = new System.Drawing.Point(105, 45);
            this.VisualGraphicBrushImageBox.Margin = new System.Windows.Forms.Padding(5);
            this.VisualGraphicBrushImageBox.Name = "VisualGraphicBrushImageBox";
            this.VisualGraphicBrushImageBox.Size = new System.Drawing.Size(90, 100);
            this.VisualGraphicBrushImageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.VisualGraphicBrushImageBox.TabIndex = 2;
            this.VisualGraphicBrushImageBox.TabStop = false;
            // 
            // PartDescLabel
            // 
            this.PartDescLabel.BackColor = System.Drawing.Color.Transparent;
            this.PartDescLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PartDescLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PartDescLabel.Location = new System.Drawing.Point(0, 150);
            this.PartDescLabel.Margin = new System.Windows.Forms.Padding(0);
            this.PartDescLabel.Name = "PartDescLabel";
            this.PartDescLabel.Size = new System.Drawing.Size(200, 25);
            this.PartDescLabel.TabIndex = 1;
            this.PartDescLabel.Text = "Parts List";
            this.PartDescLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PartTreeView
            // 
            this.PartTreeView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PartTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PartTreeView.Indent = 12;
            this.PartTreeView.Location = new System.Drawing.Point(0, 175);
            this.PartTreeView.Margin = new System.Windows.Forms.Padding(0);
            this.PartTreeView.Name = "PartTreeView";
            this.PartTreeView.Size = new System.Drawing.Size(200, 134);
            this.PartTreeView.TabIndex = 3;
            this.PartTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.PartTreeView_AfterSelect);
            // 
            // BrushesDescLabel
            // 
            this.BrushesDescLabel.BackColor = System.Drawing.Color.Transparent;
            this.BrushesDescLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BrushesDescLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BrushesDescLabel.Location = new System.Drawing.Point(0, 309);
            this.BrushesDescLabel.Margin = new System.Windows.Forms.Padding(0);
            this.BrushesDescLabel.Name = "BrushesDescLabel";
            this.BrushesDescLabel.Size = new System.Drawing.Size(200, 25);
            this.BrushesDescLabel.TabIndex = 3;
            this.BrushesDescLabel.Text = "Brushes List";
            this.BrushesDescLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BrushesTreeView
            // 
            this.BrushesTreeView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.BrushesTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BrushesTreeView.Indent = 12;
            this.BrushesTreeView.Location = new System.Drawing.Point(0, 334);
            this.BrushesTreeView.Margin = new System.Windows.Forms.Padding(0);
            this.BrushesTreeView.Name = "BrushesTreeView";
            this.BrushesTreeView.ShowNodeToolTips = true;
            this.BrushesTreeView.Size = new System.Drawing.Size(200, 404);
            this.BrushesTreeView.TabIndex = 4;
            this.BrushesTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.BrushesTreeView_AfterSelect);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(1264, 762);
            this.Controls.Add(this.ScreenLayoutPanel);
            this.Controls.Add(this.MainMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MainMenu;
            this.MinimumSize = new System.Drawing.Size(1152, 648);
            this.Name = "MainWindow";
            this.Text = "Dungeon Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.Shown += new System.EventHandler(this.MainWindow_Shown);
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.ScreenLayoutPanel.ResumeLayout(false);
            this.MainTableLayout.ResumeLayout(false);
            this.BottomBarTable.ResumeLayout(false);
            this.BottomBarTable.PerformLayout();
            this.BottomBarGfxModePanel.ResumeLayout(false);
            this.RightPanelTable.ResumeLayout(false);
            this.TreeViewVisualBrushTable.ResumeLayout(false);
            this.TreeViewVisualBrushTable.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VisualRgbaBrushImageBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VisualGraphicBrushImageBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem authorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem starboundToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setDirectoryToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog OpenFile;
        private System.Windows.Forms.SaveFileDialog SaveActive;
        private System.Windows.Forms.ToolStripMenuItem dungeonToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem addObjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addDungeonMapToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel ScreenLayoutPanel;
        private NoAliasPictureBox VisualGraphicBrushImageBox;
        private NoAliasPictureBox VisualRgbaBrushImageBox;
        private System.Windows.Forms.Label VisualRgbaBrushLabel;
        private System.Windows.Forms.Label VisualGraphicBrushLabel;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dungeonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel MainTableLayout;
        private System.Windows.Forms.Label BottomBarModeLabel;
        private System.Windows.Forms.ComboBox BottomBarGfxCombo;
        private System.Windows.Forms.Label BottomBarBrushLabel;
        private System.Windows.Forms.TableLayoutPanel BottomBarTable;
        private System.Windows.Forms.Panel BottomBarGfxModePanel;
        private System.Windows.Forms.Label BottomBarZoomLabel;
        private System.Windows.Forms.Label BottomBarXLabel;
        private System.Windows.Forms.Label BottomBarYLabel;
        private System.Windows.Forms.TableLayoutPanel RightPanelTable;
        private System.Windows.Forms.Label PartDescLabel;
        private System.Windows.Forms.TreeView PartTreeView;
        private System.Windows.Forms.Label BrushesDescLabel;
        private System.Windows.Forms.TreeView BrushesTreeView;
        private System.Windows.Forms.TableLayoutPanel TreeViewVisualBrushTable;
        private System.Windows.Forms.Label VisualRgbaBrushDescLabel;
        private System.Windows.Forms.Label VisualGraphicBrushDescLabel;
        private System.Windows.Forms.ToolStripMenuItem addBrushToolStripMenuItem;
        private ImageBox MainPictureBox;
        private ToolStripMenuItem viewToolStripMenuItem;
        private ToolStripMenuItem viewCollisionsToolStripMenuItem;
        private ToolStripMenuItem undoToolStripMenuItem;
        private ToolStripMenuItem refreshToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;

    }
}

