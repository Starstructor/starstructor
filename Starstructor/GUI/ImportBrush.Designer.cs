/*Starstructor, the Starbound Toolet 
Copyright (C) 2013-2014 Chris Stamford
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

namespace Starstructor.GUI
{
    partial class ImportBrush
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImportBrush));
            this.MainTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.NavigationTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.ButtonFinish = new System.Windows.Forms.Button();
            this.ButtonNext = new System.Windows.Forms.Button();
            this.ButtonPrev = new System.Windows.Forms.Button();
            this.WizardTabs = new Starstructor.GUI.WizardTabControl();
            this.TabGeneral = new System.Windows.Forms.TabPage();
            this.MainTableLayoutGeneralDungeon = new System.Windows.Forms.TableLayoutPanel();
            this.LabelInformation = new System.Windows.Forms.Label();
            this.MainTableLayoutGeneralDungeonBrushInfo = new System.Windows.Forms.TableLayoutPanel();
            this.LabelComment = new System.Windows.Forms.Label();
            this.TextBoxComment = new System.Windows.Forms.TextBox();
            this.ColourInfoTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.LabelRed = new System.Windows.Forms.Label();
            this.LabelGreen = new System.Windows.Forms.Label();
            this.LabelBlue = new System.Windows.Forms.Label();
            this.LabelAlpha = new System.Windows.Forms.Label();
            this.TextBoxRed = new System.Windows.Forms.TextBox();
            this.TextBoxGreen = new System.Windows.Forms.TextBox();
            this.TextBoxBlue = new System.Windows.Forms.TextBox();
            this.TextBoxAlpha = new System.Windows.Forms.TextBox();
            this.CheckBoxConnector = new System.Windows.Forms.CheckBox();
            this.LabelGeneralDungeon = new System.Windows.Forms.Label();
            this.LabelColour = new System.Windows.Forms.Label();
            this.TabAssets = new System.Windows.Forms.TabPage();
            this.MainTableLayoutFrontAssetDungeon = new System.Windows.Forms.TableLayoutPanel();
            this.BackAssetPictureBox = new Starstructor.GUI.NoAliasPictureBox();
            this.MainTableLayoutBackAssetDungeonBrushInfo = new System.Windows.Forms.TableLayoutPanel();
            this.LabelBackAsset = new System.Windows.Forms.Label();
            this.LabelBackAssetAsset = new System.Windows.Forms.Label();
            this.TableLayoutBackAssetDungeonPanel = new System.Windows.Forms.TableLayoutPanel();
            this.TextBoxBackAssetNameDungeon = new System.Windows.Forms.TextBox();
            this.ButtonBackAssetBrowseDungeon = new System.Windows.Forms.Button();
            this.MainTableLayoutFrontAssetDungeonBrushInfo = new System.Windows.Forms.TableLayoutPanel();
            this.TableLayoutFrontAssetOptionsDungeon = new System.Windows.Forms.TableLayoutPanel();
            this.LabelFrontAssetType = new System.Windows.Forms.Label();
            this.ComboBoxFrontAssetTypeDungeon = new System.Windows.Forms.ComboBox();
            this.LabelFrontAssetDirection = new System.Windows.Forms.Label();
            this.ComboBoxFrontAssetDirectionDungeon = new System.Windows.Forms.ComboBox();
            this.LabelFrontAsset = new System.Windows.Forms.Label();
            this.LabelFrontAssetAsset = new System.Windows.Forms.Label();
            this.TableLayoutFrontAssetDungeonPanel = new System.Windows.Forms.TableLayoutPanel();
            this.TextBoxFrontAssetNameDungeon = new System.Windows.Forms.TextBox();
            this.ButtonFrontAssetBrowseDungeon = new System.Windows.Forms.Button();
            this.FrontAssetPictureBox = new Starstructor.GUI.NoAliasPictureBox();
            this.TabRules = new System.Windows.Forms.TabPage();
            this.TabOverview = new System.Windows.Forms.TabPage();
            this.MainTableLayoutPanel.SuspendLayout();
            this.NavigationTableLayoutPanel.SuspendLayout();
            this.WizardTabs.SuspendLayout();
            this.TabGeneral.SuspendLayout();
            this.MainTableLayoutGeneralDungeon.SuspendLayout();
            this.MainTableLayoutGeneralDungeonBrushInfo.SuspendLayout();
            this.ColourInfoTableLayoutPanel.SuspendLayout();
            this.TabAssets.SuspendLayout();
            this.MainTableLayoutFrontAssetDungeon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BackAssetPictureBox)).BeginInit();
            this.MainTableLayoutBackAssetDungeonBrushInfo.SuspendLayout();
            this.TableLayoutBackAssetDungeonPanel.SuspendLayout();
            this.MainTableLayoutFrontAssetDungeonBrushInfo.SuspendLayout();
            this.TableLayoutFrontAssetOptionsDungeon.SuspendLayout();
            this.TableLayoutFrontAssetDungeonPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FrontAssetPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // MainTableLayoutPanel
            // 
            this.MainTableLayoutPanel.ColumnCount = 1;
            this.MainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainTableLayoutPanel.Controls.Add(this.NavigationTableLayoutPanel, 0, 1);
            this.MainTableLayoutPanel.Controls.Add(this.WizardTabs, 0, 0);
            this.MainTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.MainTableLayoutPanel.Name = "MainTableLayoutPanel";
            this.MainTableLayoutPanel.RowCount = 2;
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.MainTableLayoutPanel.Size = new System.Drawing.Size(624, 442);
            this.MainTableLayoutPanel.TabIndex = 0;
            // 
            // NavigationTableLayoutPanel
            // 
            this.NavigationTableLayoutPanel.ColumnCount = 5;
            this.NavigationTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.NavigationTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.NavigationTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.NavigationTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.NavigationTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.NavigationTableLayoutPanel.Controls.Add(this.ButtonCancel, 4, 0);
            this.NavigationTableLayoutPanel.Controls.Add(this.ButtonFinish, 3, 0);
            this.NavigationTableLayoutPanel.Controls.Add(this.ButtonNext, 2, 0);
            this.NavigationTableLayoutPanel.Controls.Add(this.ButtonPrev, 1, 0);
            this.NavigationTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NavigationTableLayoutPanel.Location = new System.Drawing.Point(3, 410);
            this.NavigationTableLayoutPanel.Name = "NavigationTableLayoutPanel";
            this.NavigationTableLayoutPanel.RowCount = 1;
            this.NavigationTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.NavigationTableLayoutPanel.Size = new System.Drawing.Size(618, 29);
            this.NavigationTableLayoutPanel.TabIndex = 0;
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.Location = new System.Drawing.Point(543, 3);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(72, 23);
            this.ButtonCancel.TabIndex = 0;
            this.ButtonCancel.Text = "Cancel";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            this.ButtonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // ButtonFinish
            // 
            this.ButtonFinish.Location = new System.Drawing.Point(466, 3);
            this.ButtonFinish.Name = "ButtonFinish";
            this.ButtonFinish.Size = new System.Drawing.Size(71, 23);
            this.ButtonFinish.TabIndex = 1;
            this.ButtonFinish.Text = "Finish";
            this.ButtonFinish.UseVisualStyleBackColor = true;
            this.ButtonFinish.Click += new System.EventHandler(this.ButtonFinish_Click);
            // 
            // ButtonNext
            // 
            this.ButtonNext.Location = new System.Drawing.Point(389, 3);
            this.ButtonNext.Name = "ButtonNext";
            this.ButtonNext.Size = new System.Drawing.Size(71, 23);
            this.ButtonNext.TabIndex = 2;
            this.ButtonNext.Text = "Next >";
            this.ButtonNext.UseVisualStyleBackColor = true;
            this.ButtonNext.Click += new System.EventHandler(this.ButtonNext_Click);
            // 
            // ButtonPrev
            // 
            this.ButtonPrev.Enabled = false;
            this.ButtonPrev.Location = new System.Drawing.Point(312, 3);
            this.ButtonPrev.Name = "ButtonPrev";
            this.ButtonPrev.Size = new System.Drawing.Size(71, 23);
            this.ButtonPrev.TabIndex = 3;
            this.ButtonPrev.Text = "< Previous";
            this.ButtonPrev.UseVisualStyleBackColor = true;
            this.ButtonPrev.Click += new System.EventHandler(this.ButtonPrev_Click);
            // 
            // WizardTabs
            // 
            this.WizardTabs.Controls.Add(this.TabGeneral);
            this.WizardTabs.Controls.Add(this.TabAssets);
            this.WizardTabs.Controls.Add(this.TabRules);
            this.WizardTabs.Controls.Add(this.TabOverview);
            this.WizardTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WizardTabs.Location = new System.Drawing.Point(3, 3);
            this.WizardTabs.Name = "WizardTabs";
            this.WizardTabs.SelectedIndex = 0;
            this.WizardTabs.Size = new System.Drawing.Size(618, 401);
            this.WizardTabs.TabIndex = 1;
            // 
            // TabGeneral
            // 
            this.TabGeneral.Controls.Add(this.MainTableLayoutGeneralDungeon);
            this.TabGeneral.Location = new System.Drawing.Point(4, 22);
            this.TabGeneral.Name = "TabGeneral";
            this.TabGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.TabGeneral.Size = new System.Drawing.Size(610, 375);
            this.TabGeneral.TabIndex = 0;
            this.TabGeneral.Text = "TabGeneral";
            this.TabGeneral.UseVisualStyleBackColor = true;
            // 
            // MainTableLayoutGeneralDungeon
            // 
            this.MainTableLayoutGeneralDungeon.AutoScroll = true;
            this.MainTableLayoutGeneralDungeon.ColumnCount = 2;
            this.MainTableLayoutGeneralDungeon.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.MainTableLayoutGeneralDungeon.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.MainTableLayoutGeneralDungeon.Controls.Add(this.LabelInformation, 1, 0);
            this.MainTableLayoutGeneralDungeon.Controls.Add(this.MainTableLayoutGeneralDungeonBrushInfo, 0, 0);
            this.MainTableLayoutGeneralDungeon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTableLayoutGeneralDungeon.Location = new System.Drawing.Point(3, 3);
            this.MainTableLayoutGeneralDungeon.Name = "MainTableLayoutGeneralDungeon";
            this.MainTableLayoutGeneralDungeon.RowCount = 1;
            this.MainTableLayoutGeneralDungeon.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainTableLayoutGeneralDungeon.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 369F));
            this.MainTableLayoutGeneralDungeon.Size = new System.Drawing.Size(604, 369);
            this.MainTableLayoutGeneralDungeon.TabIndex = 0;
            // 
            // LabelInformation
            // 
            this.LabelInformation.AutoSize = true;
            this.LabelInformation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabelInformation.Location = new System.Drawing.Point(365, 0);
            this.LabelInformation.Name = "LabelInformation";
            this.LabelInformation.Size = new System.Drawing.Size(236, 369);
            this.LabelInformation.TabIndex = 0;
            this.LabelInformation.Text = resources.GetString("LabelInformation.Text");
            this.LabelInformation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MainTableLayoutGeneralDungeonBrushInfo
            // 
            this.MainTableLayoutGeneralDungeonBrushInfo.AutoSize = true;
            this.MainTableLayoutGeneralDungeonBrushInfo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.MainTableLayoutGeneralDungeonBrushInfo.ColumnCount = 1;
            this.MainTableLayoutGeneralDungeonBrushInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainTableLayoutGeneralDungeonBrushInfo.Controls.Add(this.LabelComment, 0, 1);
            this.MainTableLayoutGeneralDungeonBrushInfo.Controls.Add(this.TextBoxComment, 0, 2);
            this.MainTableLayoutGeneralDungeonBrushInfo.Controls.Add(this.ColourInfoTableLayoutPanel, 0, 4);
            this.MainTableLayoutGeneralDungeonBrushInfo.Controls.Add(this.CheckBoxConnector, 0, 5);
            this.MainTableLayoutGeneralDungeonBrushInfo.Controls.Add(this.LabelGeneralDungeon, 0, 0);
            this.MainTableLayoutGeneralDungeonBrushInfo.Controls.Add(this.LabelColour, 0, 3);
            this.MainTableLayoutGeneralDungeonBrushInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTableLayoutGeneralDungeonBrushInfo.Location = new System.Drawing.Point(0, 0);
            this.MainTableLayoutGeneralDungeonBrushInfo.Margin = new System.Windows.Forms.Padding(0);
            this.MainTableLayoutGeneralDungeonBrushInfo.Name = "MainTableLayoutGeneralDungeonBrushInfo";
            this.MainTableLayoutGeneralDungeonBrushInfo.RowCount = 6;
            this.MainTableLayoutGeneralDungeonBrushInfo.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MainTableLayoutGeneralDungeonBrushInfo.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MainTableLayoutGeneralDungeonBrushInfo.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MainTableLayoutGeneralDungeonBrushInfo.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MainTableLayoutGeneralDungeonBrushInfo.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MainTableLayoutGeneralDungeonBrushInfo.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MainTableLayoutGeneralDungeonBrushInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.MainTableLayoutGeneralDungeonBrushInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.MainTableLayoutGeneralDungeonBrushInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.MainTableLayoutGeneralDungeonBrushInfo.Size = new System.Drawing.Size(362, 369);
            this.MainTableLayoutGeneralDungeonBrushInfo.TabIndex = 1;
            // 
            // LabelComment
            // 
            this.LabelComment.AutoSize = true;
            this.LabelComment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelComment.Location = new System.Drawing.Point(3, 41);
            this.LabelComment.Margin = new System.Windows.Forms.Padding(3, 15, 3, 3);
            this.LabelComment.Name = "LabelComment";
            this.LabelComment.Size = new System.Drawing.Size(65, 16);
            this.LabelComment.TabIndex = 0;
            this.LabelComment.Text = "Comment";
            // 
            // TextBoxComment
            // 
            this.TextBoxComment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextBoxComment.Location = new System.Drawing.Point(3, 63);
            this.TextBoxComment.Name = "TextBoxComment";
            this.TextBoxComment.Size = new System.Drawing.Size(356, 20);
            this.TextBoxComment.TabIndex = 1;
            // 
            // ColourInfoTableLayoutPanel
            // 
            this.ColourInfoTableLayoutPanel.AutoScroll = true;
            this.ColourInfoTableLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ColourInfoTableLayoutPanel.ColumnCount = 5;
            this.ColourInfoTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.ColourInfoTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.ColourInfoTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.ColourInfoTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.ColourInfoTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.ColourInfoTableLayoutPanel.Controls.Add(this.LabelRed, 0, 0);
            this.ColourInfoTableLayoutPanel.Controls.Add(this.LabelGreen, 1, 0);
            this.ColourInfoTableLayoutPanel.Controls.Add(this.LabelBlue, 2, 0);
            this.ColourInfoTableLayoutPanel.Controls.Add(this.LabelAlpha, 3, 0);
            this.ColourInfoTableLayoutPanel.Controls.Add(this.TextBoxRed, 0, 1);
            this.ColourInfoTableLayoutPanel.Controls.Add(this.TextBoxGreen, 1, 1);
            this.ColourInfoTableLayoutPanel.Controls.Add(this.TextBoxBlue, 2, 1);
            this.ColourInfoTableLayoutPanel.Controls.Add(this.TextBoxAlpha, 3, 1);
            this.ColourInfoTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ColourInfoTableLayoutPanel.Location = new System.Drawing.Point(0, 120);
            this.ColourInfoTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.ColourInfoTableLayoutPanel.Name = "ColourInfoTableLayoutPanel";
            this.ColourInfoTableLayoutPanel.RowCount = 2;
            this.ColourInfoTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.ColourInfoTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.ColourInfoTableLayoutPanel.Size = new System.Drawing.Size(362, 45);
            this.ColourInfoTableLayoutPanel.TabIndex = 3;
            // 
            // LabelRed
            // 
            this.LabelRed.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LabelRed.AutoSize = true;
            this.LabelRed.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelRed.Location = new System.Drawing.Point(3, 3);
            this.LabelRed.Margin = new System.Windows.Forms.Padding(3);
            this.LabelRed.Name = "LabelRed";
            this.LabelRed.Size = new System.Drawing.Size(35, 13);
            this.LabelRed.TabIndex = 0;
            this.LabelRed.Text = "Red";
            this.LabelRed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LabelGreen
            // 
            this.LabelGreen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LabelGreen.AutoSize = true;
            this.LabelGreen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelGreen.Location = new System.Drawing.Point(44, 3);
            this.LabelGreen.Margin = new System.Windows.Forms.Padding(3);
            this.LabelGreen.Name = "LabelGreen";
            this.LabelGreen.Size = new System.Drawing.Size(36, 13);
            this.LabelGreen.TabIndex = 1;
            this.LabelGreen.Text = "Green";
            this.LabelGreen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LabelBlue
            // 
            this.LabelBlue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LabelBlue.AutoSize = true;
            this.LabelBlue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelBlue.Location = new System.Drawing.Point(86, 3);
            this.LabelBlue.Margin = new System.Windows.Forms.Padding(3);
            this.LabelBlue.Name = "LabelBlue";
            this.LabelBlue.Size = new System.Drawing.Size(35, 13);
            this.LabelBlue.TabIndex = 2;
            this.LabelBlue.Text = "Blue";
            this.LabelBlue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LabelAlpha
            // 
            this.LabelAlpha.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LabelAlpha.AutoSize = true;
            this.LabelAlpha.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelAlpha.Location = new System.Drawing.Point(127, 3);
            this.LabelAlpha.Margin = new System.Windows.Forms.Padding(3);
            this.LabelAlpha.Name = "LabelAlpha";
            this.LabelAlpha.Size = new System.Drawing.Size(35, 13);
            this.LabelAlpha.TabIndex = 3;
            this.LabelAlpha.Text = "Alpha";
            this.LabelAlpha.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TextBoxRed
            // 
            this.TextBoxRed.Location = new System.Drawing.Point(3, 22);
            this.TextBoxRed.Name = "TextBoxRed";
            this.TextBoxRed.Size = new System.Drawing.Size(35, 20);
            this.TextBoxRed.TabIndex = 4;
            // 
            // TextBoxGreen
            // 
            this.TextBoxGreen.Location = new System.Drawing.Point(44, 22);
            this.TextBoxGreen.Name = "TextBoxGreen";
            this.TextBoxGreen.Size = new System.Drawing.Size(35, 20);
            this.TextBoxGreen.TabIndex = 5;
            // 
            // TextBoxBlue
            // 
            this.TextBoxBlue.Location = new System.Drawing.Point(86, 22);
            this.TextBoxBlue.Name = "TextBoxBlue";
            this.TextBoxBlue.Size = new System.Drawing.Size(35, 20);
            this.TextBoxBlue.TabIndex = 6;
            // 
            // TextBoxAlpha
            // 
            this.TextBoxAlpha.Location = new System.Drawing.Point(127, 22);
            this.TextBoxAlpha.Name = "TextBoxAlpha";
            this.TextBoxAlpha.Size = new System.Drawing.Size(35, 20);
            this.TextBoxAlpha.TabIndex = 7;
            // 
            // CheckBoxConnector
            // 
            this.CheckBoxConnector.AutoSize = true;
            this.CheckBoxConnector.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckBoxConnector.Location = new System.Drawing.Point(3, 180);
            this.CheckBoxConnector.Margin = new System.Windows.Forms.Padding(3, 15, 3, 3);
            this.CheckBoxConnector.Name = "CheckBoxConnector";
            this.CheckBoxConnector.Size = new System.Drawing.Size(94, 17);
            this.CheckBoxConnector.TabIndex = 5;
            this.CheckBoxConnector.Text = "Is a connector";
            this.CheckBoxConnector.UseVisualStyleBackColor = true;
            // 
            // LabelGeneralDungeon
            // 
            this.LabelGeneralDungeon.AutoSize = true;
            this.LabelGeneralDungeon.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelGeneralDungeon.Location = new System.Drawing.Point(3, 3);
            this.LabelGeneralDungeon.Margin = new System.Windows.Forms.Padding(3);
            this.LabelGeneralDungeon.Name = "LabelGeneralDungeon";
            this.LabelGeneralDungeon.Size = new System.Drawing.Size(197, 20);
            this.LabelGeneralDungeon.TabIndex = 7;
            this.LabelGeneralDungeon.Text = "General Brush Information";
            // 
            // LabelColour
            // 
            this.LabelColour.AutoSize = true;
            this.LabelColour.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelColour.Location = new System.Drawing.Point(3, 101);
            this.LabelColour.Margin = new System.Windows.Forms.Padding(3, 15, 3, 3);
            this.LabelColour.Name = "LabelColour";
            this.LabelColour.Size = new System.Drawing.Size(47, 16);
            this.LabelColour.TabIndex = 0;
            this.LabelColour.Text = "Colour";
            // 
            // TabAssets
            // 
            this.TabAssets.Controls.Add(this.MainTableLayoutFrontAssetDungeon);
            this.TabAssets.Location = new System.Drawing.Point(4, 22);
            this.TabAssets.Name = "TabAssets";
            this.TabAssets.Padding = new System.Windows.Forms.Padding(3);
            this.TabAssets.Size = new System.Drawing.Size(610, 375);
            this.TabAssets.TabIndex = 1;
            this.TabAssets.Text = "TabAssets";
            this.TabAssets.UseVisualStyleBackColor = true;
            // 
            // MainTableLayoutFrontAssetDungeon
            // 
            this.MainTableLayoutFrontAssetDungeon.ColumnCount = 2;
            this.MainTableLayoutFrontAssetDungeon.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.MainTableLayoutFrontAssetDungeon.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.MainTableLayoutFrontAssetDungeon.Controls.Add(this.BackAssetPictureBox, 1, 0);
            this.MainTableLayoutFrontAssetDungeon.Controls.Add(this.MainTableLayoutBackAssetDungeonBrushInfo, 0, 0);
            this.MainTableLayoutFrontAssetDungeon.Controls.Add(this.MainTableLayoutFrontAssetDungeonBrushInfo, 0, 1);
            this.MainTableLayoutFrontAssetDungeon.Controls.Add(this.FrontAssetPictureBox, 1, 1);
            this.MainTableLayoutFrontAssetDungeon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTableLayoutFrontAssetDungeon.Location = new System.Drawing.Point(3, 3);
            this.MainTableLayoutFrontAssetDungeon.Name = "MainTableLayoutFrontAssetDungeon";
            this.MainTableLayoutFrontAssetDungeon.RowCount = 2;
            this.MainTableLayoutFrontAssetDungeon.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.MainTableLayoutFrontAssetDungeon.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.MainTableLayoutFrontAssetDungeon.Size = new System.Drawing.Size(604, 369);
            this.MainTableLayoutFrontAssetDungeon.TabIndex = 1;
            // 
            // BackAssetPictureBox
            // 
            this.BackAssetPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BackAssetPictureBox.Location = new System.Drawing.Point(377, 15);
            this.BackAssetPictureBox.Margin = new System.Windows.Forms.Padding(15);
            this.BackAssetPictureBox.Name = "BackAssetPictureBox";
            this.BackAssetPictureBox.Size = new System.Drawing.Size(212, 154);
            this.BackAssetPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.BackAssetPictureBox.TabIndex = 4;
            this.BackAssetPictureBox.TabStop = false;
            // 
            // MainTableLayoutBackAssetDungeonBrushInfo
            // 
            this.MainTableLayoutBackAssetDungeonBrushInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.MainTableLayoutBackAssetDungeonBrushInfo.AutoSize = true;
            this.MainTableLayoutBackAssetDungeonBrushInfo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.MainTableLayoutBackAssetDungeonBrushInfo.ColumnCount = 1;
            this.MainTableLayoutBackAssetDungeonBrushInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainTableLayoutBackAssetDungeonBrushInfo.Controls.Add(this.LabelBackAsset, 0, 0);
            this.MainTableLayoutBackAssetDungeonBrushInfo.Controls.Add(this.LabelBackAssetAsset, 0, 3);
            this.MainTableLayoutBackAssetDungeonBrushInfo.Controls.Add(this.TableLayoutBackAssetDungeonPanel, 0, 4);
            this.MainTableLayoutBackAssetDungeonBrushInfo.Location = new System.Drawing.Point(0, 0);
            this.MainTableLayoutBackAssetDungeonBrushInfo.Margin = new System.Windows.Forms.Padding(0);
            this.MainTableLayoutBackAssetDungeonBrushInfo.Name = "MainTableLayoutBackAssetDungeonBrushInfo";
            this.MainTableLayoutBackAssetDungeonBrushInfo.RowCount = 7;
            this.MainTableLayoutBackAssetDungeonBrushInfo.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MainTableLayoutBackAssetDungeonBrushInfo.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MainTableLayoutBackAssetDungeonBrushInfo.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MainTableLayoutBackAssetDungeonBrushInfo.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MainTableLayoutBackAssetDungeonBrushInfo.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MainTableLayoutBackAssetDungeonBrushInfo.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MainTableLayoutBackAssetDungeonBrushInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.MainTableLayoutBackAssetDungeonBrushInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.MainTableLayoutBackAssetDungeonBrushInfo.Size = new System.Drawing.Size(362, 184);
            this.MainTableLayoutBackAssetDungeonBrushInfo.TabIndex = 2;
            // 
            // LabelBackAsset
            // 
            this.LabelBackAsset.AutoSize = true;
            this.LabelBackAsset.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelBackAsset.Location = new System.Drawing.Point(3, 3);
            this.LabelBackAsset.Margin = new System.Windows.Forms.Padding(3);
            this.LabelBackAsset.Name = "LabelBackAsset";
            this.LabelBackAsset.Size = new System.Drawing.Size(90, 20);
            this.LabelBackAsset.TabIndex = 7;
            this.LabelBackAsset.Text = "Back Asset";
            // 
            // LabelBackAssetAsset
            // 
            this.LabelBackAssetAsset.AutoSize = true;
            this.LabelBackAssetAsset.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelBackAssetAsset.Location = new System.Drawing.Point(3, 41);
            this.LabelBackAssetAsset.Margin = new System.Windows.Forms.Padding(3, 15, 3, 3);
            this.LabelBackAssetAsset.Name = "LabelBackAssetAsset";
            this.LabelBackAssetAsset.Size = new System.Drawing.Size(42, 16);
            this.LabelBackAssetAsset.TabIndex = 12;
            this.LabelBackAssetAsset.Text = "Asset";
            // 
            // TableLayoutBackAssetDungeonPanel
            // 
            this.TableLayoutBackAssetDungeonPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TableLayoutBackAssetDungeonPanel.AutoSize = true;
            this.TableLayoutBackAssetDungeonPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.TableLayoutBackAssetDungeonPanel.ColumnCount = 2;
            this.TableLayoutBackAssetDungeonPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutBackAssetDungeonPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TableLayoutBackAssetDungeonPanel.Controls.Add(this.TextBoxBackAssetNameDungeon, 0, 0);
            this.TableLayoutBackAssetDungeonPanel.Controls.Add(this.ButtonBackAssetBrowseDungeon, 1, 0);
            this.TableLayoutBackAssetDungeonPanel.Location = new System.Drawing.Point(0, 60);
            this.TableLayoutBackAssetDungeonPanel.Margin = new System.Windows.Forms.Padding(0);
            this.TableLayoutBackAssetDungeonPanel.Name = "TableLayoutBackAssetDungeonPanel";
            this.TableLayoutBackAssetDungeonPanel.RowCount = 1;
            this.TableLayoutBackAssetDungeonPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayoutBackAssetDungeonPanel.Size = new System.Drawing.Size(362, 29);
            this.TableLayoutBackAssetDungeonPanel.TabIndex = 13;
            // 
            // TextBoxBackAssetNameDungeon
            // 
            this.TextBoxBackAssetNameDungeon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxBackAssetNameDungeon.Location = new System.Drawing.Point(3, 3);
            this.TextBoxBackAssetNameDungeon.Name = "TextBoxBackAssetNameDungeon";
            this.TextBoxBackAssetNameDungeon.Size = new System.Drawing.Size(275, 20);
            this.TextBoxBackAssetNameDungeon.TabIndex = 0;
            this.TextBoxBackAssetNameDungeon.TextChanged += new System.EventHandler(this.TextBoxBackAssetNameDungeon_TextChanged);
            // 
            // ButtonBackAssetBrowseDungeon
            // 
            this.ButtonBackAssetBrowseDungeon.Location = new System.Drawing.Point(284, 3);
            this.ButtonBackAssetBrowseDungeon.Name = "ButtonBackAssetBrowseDungeon";
            this.ButtonBackAssetBrowseDungeon.Size = new System.Drawing.Size(75, 23);
            this.ButtonBackAssetBrowseDungeon.TabIndex = 1;
            this.ButtonBackAssetBrowseDungeon.Text = "Browse";
            this.ButtonBackAssetBrowseDungeon.UseVisualStyleBackColor = true;
            this.ButtonBackAssetBrowseDungeon.Click += new System.EventHandler(this.ButtonBackAssetBrowseDungeon_Click);
            // 
            // MainTableLayoutFrontAssetDungeonBrushInfo
            // 
            this.MainTableLayoutFrontAssetDungeonBrushInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.MainTableLayoutFrontAssetDungeonBrushInfo.AutoSize = true;
            this.MainTableLayoutFrontAssetDungeonBrushInfo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.MainTableLayoutFrontAssetDungeonBrushInfo.ColumnCount = 1;
            this.MainTableLayoutFrontAssetDungeonBrushInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainTableLayoutFrontAssetDungeonBrushInfo.Controls.Add(this.TableLayoutFrontAssetOptionsDungeon, 0, 3);
            this.MainTableLayoutFrontAssetDungeonBrushInfo.Controls.Add(this.LabelFrontAsset, 0, 0);
            this.MainTableLayoutFrontAssetDungeonBrushInfo.Controls.Add(this.LabelFrontAssetAsset, 0, 1);
            this.MainTableLayoutFrontAssetDungeonBrushInfo.Controls.Add(this.TableLayoutFrontAssetDungeonPanel, 0, 2);
            this.MainTableLayoutFrontAssetDungeonBrushInfo.Location = new System.Drawing.Point(0, 184);
            this.MainTableLayoutFrontAssetDungeonBrushInfo.Margin = new System.Windows.Forms.Padding(0);
            this.MainTableLayoutFrontAssetDungeonBrushInfo.Name = "MainTableLayoutFrontAssetDungeonBrushInfo";
            this.MainTableLayoutFrontAssetDungeonBrushInfo.RowCount = 4;
            this.MainTableLayoutFrontAssetDungeonBrushInfo.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MainTableLayoutFrontAssetDungeonBrushInfo.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MainTableLayoutFrontAssetDungeonBrushInfo.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MainTableLayoutFrontAssetDungeonBrushInfo.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MainTableLayoutFrontAssetDungeonBrushInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.MainTableLayoutFrontAssetDungeonBrushInfo.Size = new System.Drawing.Size(362, 185);
            this.MainTableLayoutFrontAssetDungeonBrushInfo.TabIndex = 1;
            // 
            // TableLayoutFrontAssetOptionsDungeon
            // 
            this.TableLayoutFrontAssetOptionsDungeon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TableLayoutFrontAssetOptionsDungeon.AutoSize = true;
            this.TableLayoutFrontAssetOptionsDungeon.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.TableLayoutFrontAssetOptionsDungeon.ColumnCount = 3;
            this.TableLayoutFrontAssetOptionsDungeon.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TableLayoutFrontAssetOptionsDungeon.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TableLayoutFrontAssetOptionsDungeon.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TableLayoutFrontAssetOptionsDungeon.Controls.Add(this.LabelFrontAssetType, 0, 0);
            this.TableLayoutFrontAssetOptionsDungeon.Controls.Add(this.ComboBoxFrontAssetTypeDungeon, 0, 1);
            this.TableLayoutFrontAssetOptionsDungeon.Controls.Add(this.LabelFrontAssetDirection, 1, 0);
            this.TableLayoutFrontAssetOptionsDungeon.Controls.Add(this.ComboBoxFrontAssetDirectionDungeon, 1, 1);
            this.TableLayoutFrontAssetOptionsDungeon.Location = new System.Drawing.Point(3, 92);
            this.TableLayoutFrontAssetOptionsDungeon.Name = "TableLayoutFrontAssetOptionsDungeon";
            this.TableLayoutFrontAssetOptionsDungeon.RowCount = 2;
            this.TableLayoutFrontAssetOptionsDungeon.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayoutFrontAssetOptionsDungeon.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayoutFrontAssetOptionsDungeon.Size = new System.Drawing.Size(356, 61);
            this.TableLayoutFrontAssetOptionsDungeon.TabIndex = 4;
            // 
            // LabelFrontAssetType
            // 
            this.LabelFrontAssetType.AutoSize = true;
            this.LabelFrontAssetType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelFrontAssetType.Location = new System.Drawing.Point(3, 15);
            this.LabelFrontAssetType.Margin = new System.Windows.Forms.Padding(3, 15, 3, 3);
            this.LabelFrontAssetType.Name = "LabelFrontAssetType";
            this.LabelFrontAssetType.Size = new System.Drawing.Size(40, 16);
            this.LabelFrontAssetType.TabIndex = 8;
            this.LabelFrontAssetType.Text = "Type";
            // 
            // ComboBoxFrontAssetTypeDungeon
            // 
            this.ComboBoxFrontAssetTypeDungeon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxFrontAssetTypeDungeon.FormattingEnabled = true;
            this.ComboBoxFrontAssetTypeDungeon.Items.AddRange(new object[] {
            "Object",
            "Material"});
            this.ComboBoxFrontAssetTypeDungeon.Location = new System.Drawing.Point(3, 37);
            this.ComboBoxFrontAssetTypeDungeon.Name = "ComboBoxFrontAssetTypeDungeon";
            this.ComboBoxFrontAssetTypeDungeon.Size = new System.Drawing.Size(80, 21);
            this.ComboBoxFrontAssetTypeDungeon.TabIndex = 10;
            this.ComboBoxFrontAssetTypeDungeon.SelectedValueChanged += new System.EventHandler(this.ComboBoxFrontAssetTypeDungeon_SelectedValueChanged);
            // 
            // LabelFrontAssetDirection
            // 
            this.LabelFrontAssetDirection.AutoSize = true;
            this.LabelFrontAssetDirection.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelFrontAssetDirection.Location = new System.Drawing.Point(89, 15);
            this.LabelFrontAssetDirection.Margin = new System.Windows.Forms.Padding(3, 15, 3, 3);
            this.LabelFrontAssetDirection.Name = "LabelFrontAssetDirection";
            this.LabelFrontAssetDirection.Size = new System.Drawing.Size(61, 16);
            this.LabelFrontAssetDirection.TabIndex = 9;
            this.LabelFrontAssetDirection.Text = "Direction";
            // 
            // ComboBoxFrontAssetDirectionDungeon
            // 
            this.ComboBoxFrontAssetDirectionDungeon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxFrontAssetDirectionDungeon.FormattingEnabled = true;
            this.ComboBoxFrontAssetDirectionDungeon.Items.AddRange(new object[] {
            "None",
            "Left",
            "Right"});
            this.ComboBoxFrontAssetDirectionDungeon.Location = new System.Drawing.Point(89, 37);
            this.ComboBoxFrontAssetDirectionDungeon.Name = "ComboBoxFrontAssetDirectionDungeon";
            this.ComboBoxFrontAssetDirectionDungeon.Size = new System.Drawing.Size(80, 21);
            this.ComboBoxFrontAssetDirectionDungeon.TabIndex = 14;
            this.ComboBoxFrontAssetDirectionDungeon.SelectedValueChanged += new System.EventHandler(this.ComboBoxFrontAssetDirectionDungeon_SelectedValueChanged);
            // 
            // LabelFrontAsset
            // 
            this.LabelFrontAsset.AutoSize = true;
            this.LabelFrontAsset.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelFrontAsset.Location = new System.Drawing.Point(3, 3);
            this.LabelFrontAsset.Margin = new System.Windows.Forms.Padding(3);
            this.LabelFrontAsset.Name = "LabelFrontAsset";
            this.LabelFrontAsset.Size = new System.Drawing.Size(92, 20);
            this.LabelFrontAsset.TabIndex = 7;
            this.LabelFrontAsset.Text = "Front Asset";
            // 
            // LabelFrontAssetAsset
            // 
            this.LabelFrontAssetAsset.AutoSize = true;
            this.LabelFrontAssetAsset.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelFrontAssetAsset.Location = new System.Drawing.Point(3, 41);
            this.LabelFrontAssetAsset.Margin = new System.Windows.Forms.Padding(3, 15, 3, 3);
            this.LabelFrontAssetAsset.Name = "LabelFrontAssetAsset";
            this.LabelFrontAssetAsset.Size = new System.Drawing.Size(42, 16);
            this.LabelFrontAssetAsset.TabIndex = 12;
            this.LabelFrontAssetAsset.Text = "Asset";
            // 
            // TableLayoutFrontAssetDungeonPanel
            // 
            this.TableLayoutFrontAssetDungeonPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TableLayoutFrontAssetDungeonPanel.AutoSize = true;
            this.TableLayoutFrontAssetDungeonPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.TableLayoutFrontAssetDungeonPanel.ColumnCount = 2;
            this.TableLayoutFrontAssetDungeonPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutFrontAssetDungeonPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TableLayoutFrontAssetDungeonPanel.Controls.Add(this.TextBoxFrontAssetNameDungeon, 0, 0);
            this.TableLayoutFrontAssetDungeonPanel.Controls.Add(this.ButtonFrontAssetBrowseDungeon, 1, 0);
            this.TableLayoutFrontAssetDungeonPanel.Location = new System.Drawing.Point(0, 60);
            this.TableLayoutFrontAssetDungeonPanel.Margin = new System.Windows.Forms.Padding(0);
            this.TableLayoutFrontAssetDungeonPanel.Name = "TableLayoutFrontAssetDungeonPanel";
            this.TableLayoutFrontAssetDungeonPanel.RowCount = 1;
            this.TableLayoutFrontAssetDungeonPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayoutFrontAssetDungeonPanel.Size = new System.Drawing.Size(362, 29);
            this.TableLayoutFrontAssetDungeonPanel.TabIndex = 13;
            // 
            // TextBoxFrontAssetNameDungeon
            // 
            this.TextBoxFrontAssetNameDungeon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxFrontAssetNameDungeon.Location = new System.Drawing.Point(3, 3);
            this.TextBoxFrontAssetNameDungeon.Name = "TextBoxFrontAssetNameDungeon";
            this.TextBoxFrontAssetNameDungeon.Size = new System.Drawing.Size(275, 20);
            this.TextBoxFrontAssetNameDungeon.TabIndex = 0;
            this.TextBoxFrontAssetNameDungeon.TextChanged += new System.EventHandler(this.TextBoxFrontAssetNameDungeon_TextChanged);
            // 
            // ButtonFrontAssetBrowseDungeon
            // 
            this.ButtonFrontAssetBrowseDungeon.Location = new System.Drawing.Point(284, 3);
            this.ButtonFrontAssetBrowseDungeon.Name = "ButtonFrontAssetBrowseDungeon";
            this.ButtonFrontAssetBrowseDungeon.Size = new System.Drawing.Size(75, 23);
            this.ButtonFrontAssetBrowseDungeon.TabIndex = 1;
            this.ButtonFrontAssetBrowseDungeon.Text = "Browse";
            this.ButtonFrontAssetBrowseDungeon.UseVisualStyleBackColor = true;
            this.ButtonFrontAssetBrowseDungeon.Click += new System.EventHandler(this.ButtonFrontAssetBrowseDungeon_Click);
            // 
            // FrontAssetPictureBox
            // 
            this.FrontAssetPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FrontAssetPictureBox.Location = new System.Drawing.Point(377, 199);
            this.FrontAssetPictureBox.Margin = new System.Windows.Forms.Padding(15);
            this.FrontAssetPictureBox.Name = "FrontAssetPictureBox";
            this.FrontAssetPictureBox.Size = new System.Drawing.Size(212, 155);
            this.FrontAssetPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.FrontAssetPictureBox.TabIndex = 3;
            this.FrontAssetPictureBox.TabStop = false;
            // 
            // TabRules
            // 
            this.TabRules.Location = new System.Drawing.Point(4, 22);
            this.TabRules.Name = "TabRules";
            this.TabRules.Size = new System.Drawing.Size(610, 375);
            this.TabRules.TabIndex = 2;
            this.TabRules.Text = "TabRules";
            this.TabRules.UseVisualStyleBackColor = true;
            // 
            // TabOverview
            // 
            this.TabOverview.Location = new System.Drawing.Point(4, 22);
            this.TabOverview.Name = "TabOverview";
            this.TabOverview.Size = new System.Drawing.Size(610, 375);
            this.TabOverview.TabIndex = 3;
            this.TabOverview.Text = "TabOverview";
            this.TabOverview.UseVisualStyleBackColor = true;
            // 
            // ImportBrush
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 442);
            this.Controls.Add(this.MainTableLayoutPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(640, 480);
            this.Name = "ImportBrush";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Import a brush";
            this.MainTableLayoutPanel.ResumeLayout(false);
            this.NavigationTableLayoutPanel.ResumeLayout(false);
            this.WizardTabs.ResumeLayout(false);
            this.TabGeneral.ResumeLayout(false);
            this.MainTableLayoutGeneralDungeon.ResumeLayout(false);
            this.MainTableLayoutGeneralDungeon.PerformLayout();
            this.MainTableLayoutGeneralDungeonBrushInfo.ResumeLayout(false);
            this.MainTableLayoutGeneralDungeonBrushInfo.PerformLayout();
            this.ColourInfoTableLayoutPanel.ResumeLayout(false);
            this.ColourInfoTableLayoutPanel.PerformLayout();
            this.TabAssets.ResumeLayout(false);
            this.MainTableLayoutFrontAssetDungeon.ResumeLayout(false);
            this.MainTableLayoutFrontAssetDungeon.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BackAssetPictureBox)).EndInit();
            this.MainTableLayoutBackAssetDungeonBrushInfo.ResumeLayout(false);
            this.MainTableLayoutBackAssetDungeonBrushInfo.PerformLayout();
            this.TableLayoutBackAssetDungeonPanel.ResumeLayout(false);
            this.TableLayoutBackAssetDungeonPanel.PerformLayout();
            this.MainTableLayoutFrontAssetDungeonBrushInfo.ResumeLayout(false);
            this.MainTableLayoutFrontAssetDungeonBrushInfo.PerformLayout();
            this.TableLayoutFrontAssetOptionsDungeon.ResumeLayout(false);
            this.TableLayoutFrontAssetOptionsDungeon.PerformLayout();
            this.TableLayoutFrontAssetDungeonPanel.ResumeLayout(false);
            this.TableLayoutFrontAssetDungeonPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FrontAssetPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel MainTableLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel NavigationTableLayoutPanel;
        private System.Windows.Forms.Button ButtonCancel;
        private System.Windows.Forms.Button ButtonFinish;
        private System.Windows.Forms.Button ButtonNext;
        private System.Windows.Forms.Button ButtonPrev;
        private WizardTabControl WizardTabs;
        private System.Windows.Forms.TabPage TabGeneral;
        private System.Windows.Forms.TabPage TabAssets;
        private System.Windows.Forms.TabPage TabRules;
        private System.Windows.Forms.TabPage TabOverview;
        private System.Windows.Forms.TableLayoutPanel MainTableLayoutGeneralDungeon;
        private System.Windows.Forms.Label LabelInformation;
        private System.Windows.Forms.TableLayoutPanel MainTableLayoutGeneralDungeonBrushInfo;
        private System.Windows.Forms.Label LabelComment;
        private System.Windows.Forms.TextBox TextBoxComment;
        private System.Windows.Forms.Label LabelColour;
        private System.Windows.Forms.TableLayoutPanel ColourInfoTableLayoutPanel;
        private System.Windows.Forms.Label LabelRed;
        private System.Windows.Forms.Label LabelGreen;
        private System.Windows.Forms.Label LabelBlue;
        private System.Windows.Forms.Label LabelAlpha;
        private System.Windows.Forms.TextBox TextBoxRed;
        private System.Windows.Forms.TextBox TextBoxGreen;
        private System.Windows.Forms.TextBox TextBoxBlue;
        private System.Windows.Forms.TextBox TextBoxAlpha;
        private System.Windows.Forms.CheckBox CheckBoxConnector;
        private System.Windows.Forms.Label LabelGeneralDungeon;
        private System.Windows.Forms.TableLayoutPanel MainTableLayoutFrontAssetDungeon;
        private System.Windows.Forms.TableLayoutPanel MainTableLayoutFrontAssetDungeonBrushInfo;
        private System.Windows.Forms.Label LabelFrontAsset;
        private System.Windows.Forms.Label LabelFrontAssetType;
        private System.Windows.Forms.Label LabelFrontAssetDirection;
        private System.Windows.Forms.ComboBox ComboBoxFrontAssetTypeDungeon;
        private System.Windows.Forms.Label LabelFrontAssetAsset;
        private System.Windows.Forms.TableLayoutPanel TableLayoutFrontAssetDungeonPanel;
        private System.Windows.Forms.TextBox TextBoxFrontAssetNameDungeon;
        private System.Windows.Forms.Button ButtonFrontAssetBrowseDungeon;
        private System.Windows.Forms.ComboBox ComboBoxFrontAssetDirectionDungeon;
        private System.Windows.Forms.TableLayoutPanel TableLayoutFrontAssetOptionsDungeon;
        private System.Windows.Forms.TableLayoutPanel MainTableLayoutBackAssetDungeonBrushInfo;
        private System.Windows.Forms.Label LabelBackAsset;
        private System.Windows.Forms.Label LabelBackAssetAsset;
        private System.Windows.Forms.TableLayoutPanel TableLayoutBackAssetDungeonPanel;
        private System.Windows.Forms.TextBox TextBoxBackAssetNameDungeon;
        private System.Windows.Forms.Button ButtonBackAssetBrowseDungeon;
        private NoAliasPictureBox BackAssetPictureBox;
        private NoAliasPictureBox FrontAssetPictureBox;


    }
}