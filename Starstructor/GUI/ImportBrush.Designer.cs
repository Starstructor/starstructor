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
            this.TabFrontAssetDungeon = new System.Windows.Forms.TabPage();
            this.TabBackAssetDungeon = new System.Windows.Forms.TabPage();
            this.TabRulesDungeon = new System.Windows.Forms.TabPage();
            this.TabGeneralShip = new System.Windows.Forms.TabPage();
            this.TabFrontAssetShip = new System.Windows.Forms.TabPage();
            this.TabBackAssetShip = new System.Windows.Forms.TabPage();
            this.TabRulesShip = new System.Windows.Forms.TabPage();
            this.MainLayoutTableGeneralDungeon = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.noAliasPictureBox1 = new Starstructor.GUI.NoAliasPictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.MainTableLayoutPanel.SuspendLayout();
            this.NavigationTableLayoutPanel.SuspendLayout();
            this.WizardTabs.SuspendLayout();
            this.TabGeneralDungeon.SuspendLayout();
            this.MainTableLayoutDungeon.SuspendLayout();
            this.MainLayoutTableGeneralDungeon.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.noAliasPictureBox1)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
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
            // MainLayoutTableGeneralDungeon
            // 
            this.MainLayoutTableGeneralDungeon.ColumnCount = 1;
            this.MainLayoutTableGeneralDungeon.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainLayoutTableGeneralDungeon.Controls.Add(this.label1, 0, 0);
            this.MainLayoutTableGeneralDungeon.Controls.Add(this.textBox1, 0, 1);
            this.MainLayoutTableGeneralDungeon.Controls.Add(this.tableLayoutPanel1, 0, 2);
            this.MainLayoutTableGeneralDungeon.Controls.Add(this.tableLayoutPanel2, 0, 3);
            this.MainLayoutTableGeneralDungeon.Controls.Add(this.label7, 0, 4);
            this.MainLayoutTableGeneralDungeon.Controls.Add(this.checkBox1, 0, 5);
            this.MainLayoutTableGeneralDungeon.Controls.Add(this.tableLayoutPanel3, 0, 6);
            this.MainLayoutTableGeneralDungeon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainLayoutTableGeneralDungeon.Location = new System.Drawing.Point(0, 0);
            this.MainLayoutTableGeneralDungeon.Margin = new System.Windows.Forms.Padding(0);
            this.MainLayoutTableGeneralDungeon.Name = "MainLayoutTableGeneralDungeon";
            this.MainLayoutTableGeneralDungeon.RowCount = 7;
            this.MainLayoutTableGeneralDungeon.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.MainLayoutTableGeneralDungeon.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.MainLayoutTableGeneralDungeon.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.MainLayoutTableGeneralDungeon.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.MainLayoutTableGeneralDungeon.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.MainLayoutTableGeneralDungeon.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.MainLayoutTableGeneralDungeon.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.MainLayoutTableGeneralDungeon.Size = new System.Drawing.Size(362, 369);
            this.MainLayoutTableGeneralDungeon.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(3, 55);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.noAliasPictureBox1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 104);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(362, 52);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label4, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label5, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.label6, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.textBox2, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.textBox3, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.textBox4, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.textBox5, 3, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 156);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(362, 52);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "label2";
            // 
            // noAliasPictureBox1
            // 
            this.noAliasPictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.noAliasPictureBox1.Location = new System.Drawing.Point(44, 3);
            this.noAliasPictureBox1.MaximumSize = new System.Drawing.Size(10, 10);
            this.noAliasPictureBox1.Name = "noAliasPictureBox1";
            this.noAliasPictureBox1.Size = new System.Drawing.Size(10, 10);
            this.noAliasPictureBox1.TabIndex = 1;
            this.noAliasPictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "label3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(93, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "label4";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(183, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "label5";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(273, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "label6";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(3, 29);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(84, 20);
            this.textBox2.TabIndex = 4;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(93, 29);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(84, 20);
            this.textBox3.TabIndex = 5;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(183, 29);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(84, 20);
            this.textBox4.TabIndex = 6;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(273, 29);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(86, 20);
            this.textBox5.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 208);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "label7";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(3, 263);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(80, 17);
            this.checkBox1.TabIndex = 5;
            this.checkBox1.Text = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.label8, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.textBox6, 1, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 315);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(200, 51);
            this.tableLayoutPanel3.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "label8";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(103, 3);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(94, 20);
            this.textBox6.TabIndex = 1;
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
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.noAliasPictureBox1)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private NoAliasPictureBox noAliasPictureBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox6;


    }
}