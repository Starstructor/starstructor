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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImportBrush));
            this.AssetSearchTextBox = new System.Windows.Forms.TextBox();
            this.ImportBrushMainLayoutTable = new System.Windows.Forms.TableLayoutPanel();
            this.AssetSearchLayoutTable = new System.Windows.Forms.TableLayoutPanel();
            this.AssetSearchTreeView = new System.Windows.Forms.TreeView();
            this.AssetPreviewLayoutTable = new System.Windows.Forms.TableLayoutPanel();
            this.AssetPathLabel = new System.Windows.Forms.Label();
            this.AssetGraphicalPreview = new Starstructor.GUI.NoAliasPictureBox();
            this.AssetTypeLabel = new System.Windows.Forms.Label();
            this.ImportBrushMainLayoutTable.SuspendLayout();
            this.AssetSearchLayoutTable.SuspendLayout();
            this.AssetPreviewLayoutTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AssetGraphicalPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // AssetSearchTextBox
            // 
            this.AssetSearchTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AssetSearchTextBox.Location = new System.Drawing.Point(3, 3);
            this.AssetSearchTextBox.Name = "AssetSearchTextBox";
            this.AssetSearchTextBox.Size = new System.Drawing.Size(169, 20);
            this.AssetSearchTextBox.TabIndex = 1;
            this.AssetSearchTextBox.TextChanged += new System.EventHandler(this.AssetSearchTextBox_TextChanged);
            // 
            // ImportBrushMainLayoutTable
            // 
            this.ImportBrushMainLayoutTable.ColumnCount = 3;
            this.ImportBrushMainLayoutTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 175F));
            this.ImportBrushMainLayoutTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 175F));
            this.ImportBrushMainLayoutTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ImportBrushMainLayoutTable.Controls.Add(this.AssetSearchLayoutTable, 0, 0);
            this.ImportBrushMainLayoutTable.Controls.Add(this.AssetPreviewLayoutTable, 1, 0);
            this.ImportBrushMainLayoutTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ImportBrushMainLayoutTable.Location = new System.Drawing.Point(0, 0);
            this.ImportBrushMainLayoutTable.Name = "ImportBrushMainLayoutTable";
            this.ImportBrushMainLayoutTable.RowCount = 1;
            this.ImportBrushMainLayoutTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ImportBrushMainLayoutTable.Size = new System.Drawing.Size(784, 362);
            this.ImportBrushMainLayoutTable.TabIndex = 2;
            // 
            // AssetSearchLayoutTable
            // 
            this.AssetSearchLayoutTable.ColumnCount = 1;
            this.AssetSearchLayoutTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.AssetSearchLayoutTable.Controls.Add(this.AssetSearchTextBox, 0, 0);
            this.AssetSearchLayoutTable.Controls.Add(this.AssetSearchTreeView, 0, 1);
            this.AssetSearchLayoutTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AssetSearchLayoutTable.Location = new System.Drawing.Point(0, 0);
            this.AssetSearchLayoutTable.Margin = new System.Windows.Forms.Padding(0);
            this.AssetSearchLayoutTable.Name = "AssetSearchLayoutTable";
            this.AssetSearchLayoutTable.RowCount = 2;
            this.AssetSearchLayoutTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.AssetSearchLayoutTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.AssetSearchLayoutTable.Size = new System.Drawing.Size(175, 362);
            this.AssetSearchLayoutTable.TabIndex = 0;
            // 
            // AssetSearchTreeView
            // 
            this.AssetSearchTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AssetSearchTreeView.HideSelection = false;
            this.AssetSearchTreeView.Location = new System.Drawing.Point(3, 28);
            this.AssetSearchTreeView.Name = "AssetSearchTreeView";
            this.AssetSearchTreeView.ShowLines = false;
            this.AssetSearchTreeView.ShowPlusMinus = false;
            this.AssetSearchTreeView.ShowRootLines = false;
            this.AssetSearchTreeView.Size = new System.Drawing.Size(169, 331);
            this.AssetSearchTreeView.TabIndex = 2;
            this.AssetSearchTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.AssetSearchTreeView_AfterSelect);
            // 
            // AssetPreviewLayoutTable
            // 
            this.AssetPreviewLayoutTable.AutoSize = true;
            this.AssetPreviewLayoutTable.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.AssetPreviewLayoutTable.ColumnCount = 1;
            this.AssetPreviewLayoutTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.AssetPreviewLayoutTable.Controls.Add(this.AssetGraphicalPreview, 0, 2);
            this.AssetPreviewLayoutTable.Controls.Add(this.AssetPathLabel, 0, 0);
            this.AssetPreviewLayoutTable.Controls.Add(this.AssetTypeLabel, 0, 1);
            this.AssetPreviewLayoutTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AssetPreviewLayoutTable.Location = new System.Drawing.Point(178, 3);
            this.AssetPreviewLayoutTable.Name = "AssetPreviewLayoutTable";
            this.AssetPreviewLayoutTable.RowCount = 3;
            this.AssetPreviewLayoutTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.AssetPreviewLayoutTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.AssetPreviewLayoutTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.AssetPreviewLayoutTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.AssetPreviewLayoutTable.Size = new System.Drawing.Size(169, 356);
            this.AssetPreviewLayoutTable.TabIndex = 1;
            this.AssetPreviewLayoutTable.CellPaint += new System.Windows.Forms.TableLayoutCellPaintEventHandler(this.AssetPreviewLayoutTable_CellPaint);
            // 
            // AssetPathLabel
            // 
            this.AssetPathLabel.AutoSize = true;
            this.AssetPathLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AssetPathLabel.Location = new System.Drawing.Point(0, 10);
            this.AssetPathLabel.Margin = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.AssetPathLabel.Name = "AssetPathLabel";
            this.AssetPathLabel.Size = new System.Drawing.Size(169, 104);
            this.AssetPathLabel.TabIndex = 1;
            this.AssetPathLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AssetGraphicalPreview
            // 
            this.AssetGraphicalPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AssetGraphicalPreview.Location = new System.Drawing.Point(0, 187);
            this.AssetGraphicalPreview.Margin = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.AssetGraphicalPreview.Name = "AssetGraphicalPreview";
            this.AssetGraphicalPreview.Size = new System.Drawing.Size(169, 159);
            this.AssetGraphicalPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.AssetGraphicalPreview.TabIndex = 0;
            this.AssetGraphicalPreview.TabStop = false;
            // 
            // AssetTypeLabel
            // 
            this.AssetTypeLabel.AutoSize = true;
            this.AssetTypeLabel.Location = new System.Drawing.Point(0, 134);
            this.AssetTypeLabel.Margin = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.AssetTypeLabel.Name = "AssetTypeLabel";
            this.AssetTypeLabel.Size = new System.Drawing.Size(0, 13);
            this.AssetTypeLabel.TabIndex = 2;
            this.AssetTypeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ImportBrush
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 362);
            this.Controls.Add(this.ImportBrushMainLayoutTable);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(800, 400);
            this.MinimumSize = new System.Drawing.Size(800, 400);
            this.Name = "ImportBrush";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Import a brush";
            this.Load += new System.EventHandler(this.ImportBrush_Load);
            this.ImportBrushMainLayoutTable.ResumeLayout(false);
            this.ImportBrushMainLayoutTable.PerformLayout();
            this.AssetSearchLayoutTable.ResumeLayout(false);
            this.AssetSearchLayoutTable.PerformLayout();
            this.AssetPreviewLayoutTable.ResumeLayout(false);
            this.AssetPreviewLayoutTable.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AssetGraphicalPreview)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox AssetSearchTextBox;
        private System.Windows.Forms.TableLayoutPanel ImportBrushMainLayoutTable;
        private System.Windows.Forms.TableLayoutPanel AssetSearchLayoutTable;
        private System.Windows.Forms.TreeView AssetSearchTreeView;
        private System.Windows.Forms.TableLayoutPanel AssetPreviewLayoutTable;
        private NoAliasPictureBox AssetGraphicalPreview;
        private System.Windows.Forms.Label AssetPathLabel;
        private System.Windows.Forms.Label AssetTypeLabel;

    }
}