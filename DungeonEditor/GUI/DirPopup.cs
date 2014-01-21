/*Starstructor, the Starbound Toolet 
Copyright (C) 2013-2014 Chris Stamford
Contact: cstamford@gmail.com

Source file contributers:
 Chris Stamford     contact: cstamford@gmail.com

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
using System.IO;
using System.Windows.Forms;

namespace DungeonEditor.GUI
{
    public partial class DirPopup : Form
    {
        private bool m_pathSet;

        public DirPopup()
        {
            InitializeComponent();
        }

        private void ButtonAccept_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(FolderTextbox.Text) || !Directory.Exists(FolderTextbox.Text))
            {
                MessageBox.Show("You entered an invalid directory. Please fix it.");
                return;
            }

            Editor.Editor.Settings.AssetDirPath = FolderTextbox.Text;
            m_pathSet = true;

            Close();
        }

        private void DirPopup_Load(object sender, EventArgs e)
        {
            FolderTextbox.Text = Editor.Editor.Settings.AssetDirPath;
        }

        private void ButtonBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowseStarbound.ShowDialog();

            if (FolderBrowseStarbound.SelectedPath != "")
            {
                FolderTextbox.Text = FolderBrowseStarbound.SelectedPath;
            }
        }

        private void DirPopup_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (m_pathSet || Editor.Editor.Settings.AssetDirPath != null)
                return;

            DialogResult confirmation = 
                MessageBox.Show("Are you sure you want to exit this dialog without selecting" +
                " a valid path? Dungeon Editor will be unable to load assets.",
                "Exit", MessageBoxButtons.YesNo);

            if (confirmation == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}