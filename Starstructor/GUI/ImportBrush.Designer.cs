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
            this.TabGeneralDungeon = new System.Windows.Forms.TabPage();
            this.MainTableLayoutDungeon = new System.Windows.Forms.TableLayoutPanel();
            this.LabelInformation = new System.Windows.Forms.Label();
            this.MainLayoutTableGeneralDungeon = new System.Windows.Forms.TableLayoutPanel();
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
            this.LabelConnector = new System.Windows.Forms.Label();
            this.CheckBoxConnector = new System.Windows.Forms.CheckBox();
            this.ConnectorDirectionTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.LabelConnectorDirection = new System.Windows.Forms.Label();
            this.TextBoxConnectorDirection = new System.Windows.Forms.TextBox();
            this.LabelGeneralDungeon = new System.Windows.Forms.Label();
            this.LabelColour = new System.Windows.Forms.Label();
            this.TabFrontAssetDungeon = new System.Windows.Forms.TabPage();
            this.TabBackAssetDungeon = new System.Windows.Forms.TabPage();
            this.TabRulesDungeon = new System.Windows.Forms.TabPage();
            this.TabGeneralShip = new System.Windows.Forms.TabPage();
            this.TabFrontAssetShip = new System.Windows.Forms.TabPage();
            this.TabBackAssetShip = new System.Windows.Forms.TabPage();
            this.TabRulesShip = new System.Windows.Forms.TabPage();
            this.MainTableLayoutPanel.SuspendLayout();
            this.NavigationTableLayoutPanel.SuspendLayout();
            this.WizardTabs.SuspendLayout();
            this.TabGeneralDungeon.SuspendLayout();
            this.MainTableLayoutDungeon.SuspendLayout();
            this.MainLayoutTableGeneralDungeon.SuspendLayout();
            this.ColourInfoTableLayoutPanel.SuspendLayout();
            this.ConnectorDirectionTableLayoutPanel.SuspendLayout();
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
            this.WizardTabs.Controls.Add(this.TabGeneralDungeon);
            this.WizardTabs.Controls.Add(this.TabFrontAssetDungeon);
            this.WizardTabs.Controls.Add(this.TabBackAssetDungeon);
            this.WizardTabs.Controls.Add(this.TabRulesDungeon);
            this.WizardTabs.Controls.Add(this.TabGeneralShip);
            this.WizardTabs.Controls.Add(this.TabFrontAssetShip);
            this.WizardTabs.Controls.Add(this.TabBackAssetShip);
            this.WizardTabs.Controls.Add(this.TabRulesShip);
            this.WizardTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WizardTabs.Location = new System.Drawing.Point(3, 3);
            this.WizardTabs.Name = "WizardTabs";
            this.WizardTabs.SelectedIndex = 0;
            this.WizardTabs.Size = new System.Drawing.Size(618, 401);
            this.WizardTabs.TabIndex = 1;
            // 
            // TabGeneralDungeon
            // 
            this.TabGeneralDungeon.Controls.Add(this.MainTableLayoutDungeon);
            this.TabGeneralDungeon.Location = new System.Drawing.Point(4, 22);
            this.TabGeneralDungeon.Name = "TabGeneralDungeon";
            this.TabGeneralDungeon.Padding = new System.Windows.Forms.Padding(3);
            this.TabGeneralDungeon.Size = new System.Drawing.Size(610, 375);
            this.TabGeneralDungeon.TabIndex = 0;
            this.TabGeneralDungeon.Text = "d1";
            this.TabGeneralDungeon.UseVisualStyleBackColor = true;
            // 
            // MainTableLayoutDungeon
            // 
            this.MainTableLayoutDungeon.ColumnCount = 2;
            this.MainTableLayoutDungeon.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.MainTableLayoutDungeon.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.MainTableLayoutDungeon.Controls.Add(this.LabelInformation, 1, 0);
            this.MainTableLayoutDungeon.Controls.Add(this.MainLayoutTableGeneralDungeon, 0, 0);
            this.MainTableLayoutDungeon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTableLayoutDungeon.Location = new System.Drawing.Point(3, 3);
            this.MainTableLayoutDungeon.Name = "MainTableLayoutDungeon";
            this.MainTableLayoutDungeon.RowCount = 1;
            this.MainTableLayoutDungeon.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainTableLayoutDungeon.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 369F));
            this.MainTableLayoutDungeon.Size = new System.Drawing.Size(604, 369);
            this.MainTableLayoutDungeon.TabIndex = 0;
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
            // MainLayoutTableGeneralDungeon
            // 
            this.MainLayoutTableGeneralDungeon.ColumnCount = 1;
            this.MainLayoutTableGeneralDungeon.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainLayoutTableGeneralDungeon.Controls.Add(this.LabelComment, 0, 1);
            this.MainLayoutTableGeneralDungeon.Controls.Add(this.TextBoxComment, 0, 2);
            this.MainLayoutTableGeneralDungeon.Controls.Add(this.ColourInfoTableLayoutPanel, 0, 4);
            this.MainLayoutTableGeneralDungeon.Controls.Add(this.LabelConnector, 0, 5);
            this.MainLayoutTableGeneralDungeon.Controls.Add(this.CheckBoxConnector, 0, 6);
            this.MainLayoutTableGeneralDungeon.Controls.Add(this.ConnectorDirectionTableLayoutPanel, 0, 7);
            this.MainLayoutTableGeneralDungeon.Controls.Add(this.LabelGeneralDungeon, 0, 0);
            this.MainLayoutTableGeneralDungeon.Controls.Add(this.LabelColour, 0, 3);
            this.MainLayoutTableGeneralDungeon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainLayoutTableGeneralDungeon.Location = new System.Drawing.Point(0, 0);
            this.MainLayoutTableGeneralDungeon.Margin = new System.Windows.Forms.Padding(0);
            this.MainLayoutTableGeneralDungeon.Name = "MainLayoutTableGeneralDungeon";
            this.MainLayoutTableGeneralDungeon.RowCount = 9;
            this.MainLayoutTableGeneralDungeon.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MainLayoutTableGeneralDungeon.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MainLayoutTableGeneralDungeon.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MainLayoutTableGeneralDungeon.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MainLayoutTableGeneralDungeon.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MainLayoutTableGeneralDungeon.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MainLayoutTableGeneralDungeon.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MainLayoutTableGeneralDungeon.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MainLayoutTableGeneralDungeon.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.MainLayoutTableGeneralDungeon.Size = new System.Drawing.Size(362, 369);
            this.MainLayoutTableGeneralDungeon.TabIndex = 1;
            // 
            // LabelComment
            // 
            this.LabelComment.AutoSize = true;
            this.LabelComment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelComment.Location = new System.Drawing.Point(3, 46);
            this.LabelComment.Margin = new System.Windows.Forms.Padding(3, 20, 3, 3);
            this.LabelComment.Name = "LabelComment";
            this.LabelComment.Size = new System.Drawing.Size(65, 16);
            this.LabelComment.TabIndex = 0;
            this.LabelComment.Text = "Comment";
            // 
            // TextBoxComment
            // 
            this.TextBoxComment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextBoxComment.Location = new System.Drawing.Point(3, 68);
            this.TextBoxComment.Name = "TextBoxComment";
            this.TextBoxComment.Size = new System.Drawing.Size(356, 20);
            this.TextBoxComment.TabIndex = 1;
            // 
            // ColourInfoTableLayoutPanel
            // 
            this.ColourInfoTableLayoutPanel.AutoScroll = true;
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
            this.ColourInfoTableLayoutPanel.Location = new System.Drawing.Point(0, 130);
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
            // LabelConnector
            // 
            this.LabelConnector.AutoSize = true;
            this.LabelConnector.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelConnector.Location = new System.Drawing.Point(3, 195);
            this.LabelConnector.Margin = new System.Windows.Forms.Padding(3, 20, 3, 3);
            this.LabelConnector.Name = "LabelConnector";
            this.LabelConnector.Size = new System.Drawing.Size(69, 16);
            this.LabelConnector.TabIndex = 4;
            this.LabelConnector.Text = "Connector";
            // 
            // CheckBoxConnector
            // 
            this.CheckBoxConnector.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.CheckBoxConnector.AutoSize = true;
            this.CheckBoxConnector.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckBoxConnector.Location = new System.Drawing.Point(5, 217);
            this.CheckBoxConnector.Margin = new System.Windows.Forms.Padding(5, 3, 3, 3);
            this.CheckBoxConnector.Name = "CheckBoxConnector";
            this.CheckBoxConnector.Size = new System.Drawing.Size(94, 17);
            this.CheckBoxConnector.TabIndex = 5;
            this.CheckBoxConnector.Text = "Is a connector";
            this.CheckBoxConnector.UseVisualStyleBackColor = true;
            // 
            // ConnectorDirectionTableLayoutPanel
            // 
            this.ConnectorDirectionTableLayoutPanel.AutoSize = true;
            this.ConnectorDirectionTableLayoutPanel.ColumnCount = 2;
            this.ConnectorDirectionTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.ConnectorDirectionTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.ConnectorDirectionTableLayoutPanel.Controls.Add(this.LabelConnectorDirection, 0, 0);
            this.ConnectorDirectionTableLayoutPanel.Controls.Add(this.TextBoxConnectorDirection, 1, 0);
            this.ConnectorDirectionTableLayoutPanel.Location = new System.Drawing.Point(0, 237);
            this.ConnectorDirectionTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.ConnectorDirectionTableLayoutPanel.Name = "ConnectorDirectionTableLayoutPanel";
            this.ConnectorDirectionTableLayoutPanel.RowCount = 1;
            this.ConnectorDirectionTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.ConnectorDirectionTableLayoutPanel.Size = new System.Drawing.Size(166, 26);
            this.ConnectorDirectionTableLayoutPanel.TabIndex = 6;
            // 
            // LabelConnectorDirection
            // 
            this.LabelConnectorDirection.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LabelConnectorDirection.AutoSize = true;
            this.LabelConnectorDirection.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelConnectorDirection.Location = new System.Drawing.Point(3, 3);
            this.LabelConnectorDirection.Margin = new System.Windows.Forms.Padding(3);
            this.LabelConnectorDirection.Name = "LabelConnectorDirection";
            this.LabelConnectorDirection.Size = new System.Drawing.Size(104, 20);
            this.LabelConnectorDirection.TabIndex = 0;
            this.LabelConnectorDirection.Text = "Connector Direction:";
            this.LabelConnectorDirection.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TextBoxConnectorDirection
            // 
            this.TextBoxConnectorDirection.Location = new System.Drawing.Point(113, 3);
            this.TextBoxConnectorDirection.Name = "TextBoxConnectorDirection";
            this.TextBoxConnectorDirection.Size = new System.Drawing.Size(50, 20);
            this.TextBoxConnectorDirection.TabIndex = 1;
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
            this.LabelColour.Location = new System.Drawing.Point(3, 111);
            this.LabelColour.Margin = new System.Windows.Forms.Padding(3, 20, 3, 3);
            this.LabelColour.Name = "LabelColour";
            this.LabelColour.Size = new System.Drawing.Size(47, 16);
            this.LabelColour.TabIndex = 0;
            this.LabelColour.Text = "Colour";
            // 
            // TabFrontAssetDungeon
            // 
            this.TabFrontAssetDungeon.Location = new System.Drawing.Point(4, 22);
            this.TabFrontAssetDungeon.Name = "TabFrontAssetDungeon";
            this.TabFrontAssetDungeon.Padding = new System.Windows.Forms.Padding(3);
            this.TabFrontAssetDungeon.Size = new System.Drawing.Size(610, 375);
            this.TabFrontAssetDungeon.TabIndex = 1;
            this.TabFrontAssetDungeon.Text = "d2";
            this.TabFrontAssetDungeon.UseVisualStyleBackColor = true;
            // 
            // TabBackAssetDungeon
            // 
            this.TabBackAssetDungeon.Location = new System.Drawing.Point(4, 22);
            this.TabBackAssetDungeon.Name = "TabBackAssetDungeon";
            this.TabBackAssetDungeon.Size = new System.Drawing.Size(610, 375);
            this.TabBackAssetDungeon.TabIndex = 2;
            this.TabBackAssetDungeon.Text = "d3";
            this.TabBackAssetDungeon.UseVisualStyleBackColor = true;
            // 
            // TabRulesDungeon
            // 
            this.TabRulesDungeon.Location = new System.Drawing.Point(4, 22);
            this.TabRulesDungeon.Name = "TabRulesDungeon";
            this.TabRulesDungeon.Size = new System.Drawing.Size(610, 375);
            this.TabRulesDungeon.TabIndex = 3;
            this.TabRulesDungeon.Text = "d4";
            this.TabRulesDungeon.UseVisualStyleBackColor = true;
            // 
            // TabGeneralShip
            // 
            this.TabGeneralShip.Location = new System.Drawing.Point(4, 22);
            this.TabGeneralShip.Name = "TabGeneralShip";
            this.TabGeneralShip.Size = new System.Drawing.Size(610, 375);
            this.TabGeneralShip.TabIndex = 5;
            this.TabGeneralShip.Text = "s1";
            this.TabGeneralShip.UseVisualStyleBackColor = true;
            // 
            // TabFrontAssetShip
            // 
            this.TabFrontAssetShip.Location = new System.Drawing.Point(4, 22);
            this.TabFrontAssetShip.Name = "TabFrontAssetShip";
            this.TabFrontAssetShip.Size = new System.Drawing.Size(610, 375);
            this.TabFrontAssetShip.TabIndex = 6;
            this.TabFrontAssetShip.Text = "s2";
            this.TabFrontAssetShip.UseVisualStyleBackColor = true;
            // 
            // TabBackAssetShip
            // 
            this.TabBackAssetShip.Location = new System.Drawing.Point(4, 22);
            this.TabBackAssetShip.Name = "TabBackAssetShip";
            this.TabBackAssetShip.Size = new System.Drawing.Size(610, 375);
            this.TabBackAssetShip.TabIndex = 7;
            this.TabBackAssetShip.Text = "s3";
            this.TabBackAssetShip.UseVisualStyleBackColor = true;
            // 
            // TabRulesShip
            // 
            this.TabRulesShip.Location = new System.Drawing.Point(4, 22);
            this.TabRulesShip.Name = "TabRulesShip";
            this.TabRulesShip.Size = new System.Drawing.Size(610, 375);
            this.TabRulesShip.TabIndex = 8;
            this.TabRulesShip.Text = "s4";
            this.TabRulesShip.UseVisualStyleBackColor = true;
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
            this.TabGeneralDungeon.ResumeLayout(false);
            this.MainTableLayoutDungeon.ResumeLayout(false);
            this.MainTableLayoutDungeon.PerformLayout();
            this.MainLayoutTableGeneralDungeon.ResumeLayout(false);
            this.MainLayoutTableGeneralDungeon.PerformLayout();
            this.ColourInfoTableLayoutPanel.ResumeLayout(false);
            this.ColourInfoTableLayoutPanel.PerformLayout();
            this.ConnectorDirectionTableLayoutPanel.ResumeLayout(false);
            this.ConnectorDirectionTableLayoutPanel.PerformLayout();
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
        private System.Windows.Forms.TabPage TabGeneralDungeon;
        private System.Windows.Forms.TabPage TabFrontAssetDungeon;
        private System.Windows.Forms.TabPage TabBackAssetDungeon;
        private System.Windows.Forms.TabPage TabRulesDungeon;
        private System.Windows.Forms.TabPage TabGeneralShip;
        private System.Windows.Forms.TabPage TabFrontAssetShip;
        private System.Windows.Forms.TabPage TabBackAssetShip;
        private System.Windows.Forms.TabPage TabRulesShip;
        private System.Windows.Forms.TableLayoutPanel MainTableLayoutDungeon;
        private System.Windows.Forms.Label LabelInformation;
        private System.Windows.Forms.TableLayoutPanel MainLayoutTableGeneralDungeon;
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
        private System.Windows.Forms.Label LabelConnector;
        private System.Windows.Forms.CheckBox CheckBoxConnector;
        private System.Windows.Forms.TableLayoutPanel ConnectorDirectionTableLayoutPanel;
        private System.Windows.Forms.Label LabelConnectorDirection;
        private System.Windows.Forms.TextBox TextBoxConnectorDirection;
        private System.Windows.Forms.Label LabelGeneralDungeon;


    }
}