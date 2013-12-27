using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DungeonEditor;

namespace DungeonEditor.GUI
{
    public partial class DirPopup : Form
    {
        private bool m_pathSet;
        private Editor m_parent;

        public DirPopup(Editor parent)
        {
            m_parent = parent;
            InitializeComponent();
        }

        private void ButtonAccept_Click(object sender, EventArgs e)
        {
            Editor.Settings.AssetDirPath = FolderTextbox.Text;
            m_pathSet = true;

            this.Close();
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
            if (m_pathSet || Editor.Settings.AssetDirPath != null)
                return;

            DialogResult confirmation = MessageBox.Show("Are you sure you want to exit this dialog without selecting" +
                " a valid path? Dungeon Editor will be unable to load assets.",
                "Exit", MessageBoxButtons.YesNo);

            if (confirmation == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
