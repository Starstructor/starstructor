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
    partial class ImportDungeonBrush
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImportDungeonBrush));
            this.General = new System.Windows.Forms.Label();
            this.BackAssetLabel = new System.Windows.Forms.Label();
            this.FrontAssetLabel = new System.Windows.Forms.Label();
            this.RulesLabel = new System.Windows.Forms.Label();
            this.GeneralTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.CommentTextBox = new System.Windows.Forms.TextBox();
            this.LabelComment = new System.Windows.Forms.Label();
            this.ImportMainLayoutTable = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.GeneralTableLayoutPanel.SuspendLayout();
            this.ImportMainLayoutTable.SuspendLayout();
            this.SuspendLayout();
            // 
            // General
            // 
            this.General.AutoSize = true;
            this.General.BackColor = System.Drawing.Color.Transparent;
            this.General.Dock = System.Windows.Forms.DockStyle.Fill;
            this.General.Location = new System.Drawing.Point(3, 0);
            this.General.Name = "General";
            this.General.Size = new System.Drawing.Size(190, 35);
            this.General.TabIndex = 0;
            this.General.Text = "General";
            this.General.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BackAssetLabel
            // 
            this.BackAssetLabel.AutoSize = true;
            this.BackAssetLabel.BackColor = System.Drawing.Color.Transparent;
            this.BackAssetLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BackAssetLabel.Location = new System.Drawing.Point(199, 0);
            this.BackAssetLabel.Name = "BackAssetLabel";
            this.BackAssetLabel.Size = new System.Drawing.Size(190, 35);
            this.BackAssetLabel.TabIndex = 1;
            this.BackAssetLabel.Text = "Back Asset";
            this.BackAssetLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrontAssetLabel
            // 
            this.FrontAssetLabel.AutoSize = true;
            this.FrontAssetLabel.BackColor = System.Drawing.Color.Transparent;
            this.FrontAssetLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FrontAssetLabel.Location = new System.Drawing.Point(395, 0);
            this.FrontAssetLabel.Name = "FrontAssetLabel";
            this.FrontAssetLabel.Size = new System.Drawing.Size(190, 35);
            this.FrontAssetLabel.TabIndex = 2;
            this.FrontAssetLabel.Text = "Front Asset";
            this.FrontAssetLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RulesLabel
            // 
            this.RulesLabel.AutoSize = true;
            this.RulesLabel.BackColor = System.Drawing.Color.Transparent;
            this.RulesLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RulesLabel.Location = new System.Drawing.Point(591, 0);
            this.RulesLabel.Name = "RulesLabel";
            this.RulesLabel.Size = new System.Drawing.Size(190, 35);
            this.RulesLabel.TabIndex = 3;
            this.RulesLabel.Text = "Rules";
            this.RulesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GeneralTableLayoutPanel
            // 
            this.GeneralTableLayoutPanel.ColumnCount = 2;
            this.GeneralTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.GeneralTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.GeneralTableLayoutPanel.Controls.Add(this.LabelComment, 0, 0);
            this.GeneralTableLayoutPanel.Controls.Add(this.CommentTextBox, 1, 0);
            this.GeneralTableLayoutPanel.Controls.Add(this.panel1, 1, 5);
            this.GeneralTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GeneralTableLayoutPanel.Location = new System.Drawing.Point(3, 38);
            this.GeneralTableLayoutPanel.Name = "GeneralTableLayoutPanel";
            this.GeneralTableLayoutPanel.RowCount = 6;
            this.GeneralTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.GeneralTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.GeneralTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.GeneralTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.GeneralTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.GeneralTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.GeneralTableLayoutPanel.Size = new System.Drawing.Size(190, 321);
            this.GeneralTableLayoutPanel.TabIndex = 4;
            // 
            // CommentTextBox
            // 
            this.CommentTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CommentTextBox.Location = new System.Drawing.Point(63, 3);
            this.CommentTextBox.Name = "CommentTextBox";
            this.CommentTextBox.Size = new System.Drawing.Size(200, 20);
            this.CommentTextBox.TabIndex = 1;
            // 
            // LabelComment
            // 
            this.LabelComment.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LabelComment.AutoSize = true;
            this.LabelComment.BackColor = System.Drawing.Color.Transparent;
            this.LabelComment.Location = new System.Drawing.Point(3, 0);
            this.LabelComment.Name = "LabelComment";
            this.LabelComment.Size = new System.Drawing.Size(54, 26);
            this.LabelComment.TabIndex = 0;
            this.LabelComment.Text = "Comment:";
            this.LabelComment.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ImportMainLayoutTable
            // 
            this.ImportMainLayoutTable.ColumnCount = 4;
            this.ImportMainLayoutTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.ImportMainLayoutTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.ImportMainLayoutTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.ImportMainLayoutTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.ImportMainLayoutTable.Controls.Add(this.GeneralTableLayoutPanel, 0, 1);
            this.ImportMainLayoutTable.Controls.Add(this.RulesLabel, 3, 0);
            this.ImportMainLayoutTable.Controls.Add(this.FrontAssetLabel, 2, 0);
            this.ImportMainLayoutTable.Controls.Add(this.BackAssetLabel, 1, 0);
            this.ImportMainLayoutTable.Controls.Add(this.General, 0, 0);
            this.ImportMainLayoutTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ImportMainLayoutTable.Location = new System.Drawing.Point(0, 0);
            this.ImportMainLayoutTable.Name = "ImportMainLayoutTable";
            this.ImportMainLayoutTable.RowCount = 2;
            this.ImportMainLayoutTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.ImportMainLayoutTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ImportMainLayoutTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.ImportMainLayoutTable.Size = new System.Drawing.Size(784, 362);
            this.ImportMainLayoutTable.TabIndex = 0;
            this.ImportMainLayoutTable.CellPaint += new System.Windows.Forms.TableLayoutCellPaintEventHandler(this.ImportMainLayoutTable_CellPaint);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(63, 265);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 53);
            this.panel1.TabIndex = 2;
            // 
            // ImportDungeonBrush
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 362);
            this.Controls.Add(this.ImportMainLayoutTable);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 400);
            this.Name = "ImportDungeonBrush";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Import a dungeon brush";
            this.GeneralTableLayoutPanel.ResumeLayout(false);
            this.GeneralTableLayoutPanel.PerformLayout();
            this.ImportMainLayoutTable.ResumeLayout(false);
            this.ImportMainLayoutTable.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label General;
        private System.Windows.Forms.Label BackAssetLabel;
        private System.Windows.Forms.Label FrontAssetLabel;
        private System.Windows.Forms.Label RulesLabel;
        private System.Windows.Forms.TableLayoutPanel GeneralTableLayoutPanel;
        private System.Windows.Forms.Label LabelComment;
        private System.Windows.Forms.TextBox CommentTextBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel ImportMainLayoutTable;

    }
}