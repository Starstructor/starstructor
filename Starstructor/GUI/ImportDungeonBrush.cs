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

using System.Drawing;
using System.Windows.Forms;

namespace Starstructor.GUI
{
    public partial class ImportDungeonBrush : Form
    {
        public ImportDungeonBrush()
        {
            InitializeComponent();
        }

        private void ImportMainLayoutTable_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            Color borderColor = SystemColors.ControlDarkDark;
            const int borderWidth = 1;

            ButtonBorderStyle leftBorderStyle = ButtonBorderStyle.None;
            ButtonBorderStyle topBorderStyle = ButtonBorderStyle.None;
            ButtonBorderStyle rightBorderStyle = ButtonBorderStyle.None;
            ButtonBorderStyle bottomBorderStyle = ButtonBorderStyle.None;

            if (e.Row == 0) bottomBorderStyle = ButtonBorderStyle.Dotted;
            if (e.Column == 0 || e.Column == 1 || e.Column == 2) rightBorderStyle = ButtonBorderStyle.Dotted;

            ControlPaint.DrawBorder(
                e.Graphics,
                e.CellBounds,
                borderColor,
                borderWidth,
                leftBorderStyle,
                borderColor,
                borderWidth,
                topBorderStyle,
                borderColor,
                borderWidth,
                rightBorderStyle,
                borderColor,
                borderWidth,
                bottomBorderStyle);
        }
    }
}
