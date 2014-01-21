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
namespace DungeonEditor.GUI
{
    partial class DirPopup
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
            this.ButtonAccept = new System.Windows.Forms.Button();
            this.ButtonBrowse = new System.Windows.Forms.Button();
            this.LabelDirectoryInfo = new System.Windows.Forms.Label();
            this.FolderBrowseStarbound = new System.Windows.Forms.FolderBrowserDialog();
            this.FolderTextbox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ButtonAccept
            // 
            this.ButtonAccept.Location = new System.Drawing.Point(12, 87);
            this.ButtonAccept.Name = "ButtonAccept";
            this.ButtonAccept.Size = new System.Drawing.Size(75, 23);
            this.ButtonAccept.TabIndex = 0;
            this.ButtonAccept.Text = "Accept";
            this.ButtonAccept.UseVisualStyleBackColor = true;
            this.ButtonAccept.Click += new System.EventHandler(this.ButtonAccept_Click);
            // 
            // ButtonBrowse
            // 
            this.ButtonBrowse.Location = new System.Drawing.Point(153, 87);
            this.ButtonBrowse.Name = "ButtonBrowse";
            this.ButtonBrowse.Size = new System.Drawing.Size(75, 23);
            this.ButtonBrowse.TabIndex = 1;
            this.ButtonBrowse.Text = "Browse";
            this.ButtonBrowse.UseVisualStyleBackColor = true;
            this.ButtonBrowse.Click += new System.EventHandler(this.ButtonBrowse_Click);
            // 
            // LabelDirectoryInfo
            // 
            this.LabelDirectoryInfo.Location = new System.Drawing.Point(12, 9);
            this.LabelDirectoryInfo.Name = "LabelDirectoryInfo";
            this.LabelDirectoryInfo.Size = new System.Drawing.Size(216, 44);
            this.LabelDirectoryInfo.TabIndex = 2;
            this.LabelDirectoryInfo.Text = "Please navigate to your Starbound ASSETS directory. Starstructor will be unable t" +
    "o load assets if this is set incorrectly.";
            // 
            // FolderBrowseStarbound
            // 
            this.FolderBrowseStarbound.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // FolderTextbox
            // 
            this.FolderTextbox.Location = new System.Drawing.Point(15, 56);
            this.FolderTextbox.Name = "FolderTextbox";
            this.FolderTextbox.Size = new System.Drawing.Size(213, 20);
            this.FolderTextbox.TabIndex = 3;
            // 
            // DirPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(240, 122);
            this.Controls.Add(this.FolderTextbox);
            this.Controls.Add(this.LabelDirectoryInfo);
            this.Controls.Add(this.ButtonBrowse);
            this.Controls.Add(this.ButtonAccept);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DirPopup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Enter directory";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DirPopup_FormClosing);
            this.Load += new System.EventHandler(this.DirPopup_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ButtonAccept;
        private System.Windows.Forms.Button ButtonBrowse;
        private System.Windows.Forms.Label LabelDirectoryInfo;
        private System.Windows.Forms.FolderBrowserDialog FolderBrowseStarbound;
        private System.Windows.Forms.TextBox FolderTextbox;
    }
}
