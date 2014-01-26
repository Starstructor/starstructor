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
    partial class AssetBrowser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AssetBrowser));
            this.AssetSearchTextBox = new System.Windows.Forms.TextBox();
            this.AssetBrowserMainLayoutTable = new System.Windows.Forms.TableLayoutPanel();
            this.AssetPreviewLayoutTable = new System.Windows.Forms.TableLayoutPanel();
            this.AssetGraphicalPreview = new Starstructor.GUI.NoAliasPictureBox();
            this.AssetPathLabel = new System.Windows.Forms.Label();
            this.AssetTypeLabel = new System.Windows.Forms.Label();
            this.AssetSearchLayoutTable = new System.Windows.Forms.TableLayoutPanel();
            this.AssetSearchTreeView = new System.Windows.Forms.TreeView();
            this.AssetButtonSelect = new System.Windows.Forms.Button();
            this.AssetButtonRefresh = new System.Windows.Forms.Button();
            this.AssetBrowserMainLayoutTable.SuspendLayout();
            this.AssetPreviewLayoutTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AssetGraphicalPreview)).BeginInit();
            this.AssetSearchLayoutTable.SuspendLayout();
            this.SuspendLayout();
            // 
            // AssetSearchTextBox
            // 
            this.AssetSearchTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AssetSearchTextBox.Location = new System.Drawing.Point(3, 3);
            this.AssetSearchTextBox.Name = "AssetSearchTextBox";
            this.AssetSearchTextBox.Size = new System.Drawing.Size(186, 20);
            this.AssetSearchTextBox.TabIndex = 1;
            this.AssetSearchTextBox.TextChanged += new System.EventHandler(this.AssetSearchTextBox_TextChanged);
            // 
            // AssetBrowserMainLayoutTable
            // 
            this.AssetBrowserMainLayoutTable.ColumnCount = 2;
            this.AssetBrowserMainLayoutTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.AssetBrowserMainLayoutTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.AssetBrowserMainLayoutTable.Controls.Add(this.AssetPreviewLayoutTable, 0, 0);
            this.AssetBrowserMainLayoutTable.Controls.Add(this.AssetSearchLayoutTable, 0, 0);
            this.AssetBrowserMainLayoutTable.Controls.Add(this.AssetButtonSelect, 0, 1);
            this.AssetBrowserMainLayoutTable.Controls.Add(this.AssetButtonRefresh, 1, 1);
            this.AssetBrowserMainLayoutTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AssetBrowserMainLayoutTable.Location = new System.Drawing.Point(0, 0);
            this.AssetBrowserMainLayoutTable.Name = "AssetBrowserMainLayoutTable";
            this.AssetBrowserMainLayoutTable.RowCount = 2;
            this.AssetBrowserMainLayoutTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.AssetBrowserMainLayoutTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.AssetBrowserMainLayoutTable.Size = new System.Drawing.Size(384, 397);
            this.AssetBrowserMainLayoutTable.TabIndex = 2;
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
            this.AssetPreviewLayoutTable.Location = new System.Drawing.Point(195, 3);
            this.AssetPreviewLayoutTable.Name = "AssetPreviewLayoutTable";
            this.AssetPreviewLayoutTable.RowCount = 3;
            this.AssetPreviewLayoutTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.AssetPreviewLayoutTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.AssetPreviewLayoutTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.AssetPreviewLayoutTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.AssetPreviewLayoutTable.Size = new System.Drawing.Size(186, 356);
            this.AssetPreviewLayoutTable.TabIndex = 1;
            this.AssetPreviewLayoutTable.CellPaint += new System.Windows.Forms.TableLayoutCellPaintEventHandler(this.AssetPreviewLayoutTable_CellPaint);
            // 
            // AssetGraphicalPreview
            // 
            this.AssetGraphicalPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AssetGraphicalPreview.Location = new System.Drawing.Point(0, 187);
            this.AssetGraphicalPreview.Margin = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.AssetGraphicalPreview.Name = "AssetGraphicalPreview";
            this.AssetGraphicalPreview.Size = new System.Drawing.Size(186, 159);
            this.AssetGraphicalPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.AssetGraphicalPreview.TabIndex = 0;
            this.AssetGraphicalPreview.TabStop = false;
            // 
            // AssetPathLabel
            // 
            this.AssetPathLabel.AutoSize = true;
            this.AssetPathLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AssetPathLabel.Location = new System.Drawing.Point(0, 10);
            this.AssetPathLabel.Margin = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.AssetPathLabel.Name = "AssetPathLabel";
            this.AssetPathLabel.Size = new System.Drawing.Size(186, 104);
            this.AssetPathLabel.TabIndex = 1;
            this.AssetPathLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AssetTypeLabel
            // 
            this.AssetTypeLabel.AutoSize = true;
            this.AssetTypeLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AssetTypeLabel.Location = new System.Drawing.Point(0, 134);
            this.AssetTypeLabel.Margin = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.AssetTypeLabel.Name = "AssetTypeLabel";
            this.AssetTypeLabel.Size = new System.Drawing.Size(186, 33);
            this.AssetTypeLabel.TabIndex = 2;
            this.AssetTypeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.AssetSearchLayoutTable.Size = new System.Drawing.Size(192, 362);
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
            this.AssetSearchTreeView.Size = new System.Drawing.Size(186, 331);
            this.AssetSearchTreeView.TabIndex = 2;
            this.AssetSearchTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.AssetSearchTreeView_AfterSelect);
            // 
            // AssetButtonSelect
            // 
            this.AssetButtonSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.AssetButtonSelect.Location = new System.Drawing.Point(3, 368);
            this.AssetButtonSelect.Name = "AssetButtonSelect";
            this.AssetButtonSelect.Size = new System.Drawing.Size(186, 23);
            this.AssetButtonSelect.TabIndex = 2;
            this.AssetButtonSelect.Text = "Select";
            this.AssetButtonSelect.UseVisualStyleBackColor = true;
            this.AssetButtonSelect.Click += new System.EventHandler(this.AssetButtonSelect_Click);
            // 
            // AssetButtonRefresh
            // 
            this.AssetButtonRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.AssetButtonRefresh.Location = new System.Drawing.Point(195, 368);
            this.AssetButtonRefresh.Name = "AssetButtonRefresh";
            this.AssetButtonRefresh.Size = new System.Drawing.Size(186, 23);
            this.AssetButtonRefresh.TabIndex = 3;
            this.AssetButtonRefresh.Text = "Refresh Asset List";
            this.AssetButtonRefresh.UseVisualStyleBackColor = true;
            this.AssetButtonRefresh.Click += new System.EventHandler(this.AssetButtonRefresh_Click);
            // 
            // AssetBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 397);
            this.Controls.Add(this.AssetBrowserMainLayoutTable);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(400, 435);
            this.MinimumSize = new System.Drawing.Size(400, 435);
            this.Name = "AssetBrowser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Asset Browser";
            this.Load += new System.EventHandler(this.ImportBrush_Load);
            this.AssetBrowserMainLayoutTable.ResumeLayout(false);
            this.AssetBrowserMainLayoutTable.PerformLayout();
            this.AssetPreviewLayoutTable.ResumeLayout(false);
            this.AssetPreviewLayoutTable.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AssetGraphicalPreview)).EndInit();
            this.AssetSearchLayoutTable.ResumeLayout(false);
            this.AssetSearchLayoutTable.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox AssetSearchTextBox;
        private System.Windows.Forms.TableLayoutPanel AssetBrowserMainLayoutTable;
        private System.Windows.Forms.TableLayoutPanel AssetSearchLayoutTable;
        private System.Windows.Forms.TreeView AssetSearchTreeView;
        private System.Windows.Forms.TableLayoutPanel AssetPreviewLayoutTable;
        private NoAliasPictureBox AssetGraphicalPreview;
        private System.Windows.Forms.Label AssetPathLabel;
        private System.Windows.Forms.Label AssetTypeLabel;
        private System.Windows.Forms.Button AssetButtonSelect;
        private System.Windows.Forms.Button AssetButtonRefresh;

    }
}