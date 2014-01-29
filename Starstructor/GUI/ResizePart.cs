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
using System.Windows.Forms;
using Starstructor.Data;

namespace Starstructor.GUI
{
    public partial class ResizePart : Form
    {
        public Vec2I? Dimensions
        {
            get { return m_dimensions; }     
        }

        private Vec2I? m_dimensions;
        private Vec2I m_baseDimensions;

        private const int MIN_WIDTH = 1;
        private const int MIN_HEIGHT = 1;
        private const int MAX_WIDTH = 512;
        private const int MAX_HEIGHT = 512;

        public ResizePart(int baseWidth, int baseHeight)
        {
            m_dimensions = new Vec2I(baseWidth, baseHeight);
            m_baseDimensions = new Vec2I(baseWidth, baseHeight);

            InitializeComponent();
            textBox1.Text = m_dimensions.Value.x.ToString();
            textBox2.Text = m_dimensions.Value.y.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!HandleWidthInput(textBox1.Text)) textBox1.Text = "";
            else if (ParseInt(textBox1.Text) > MAX_WIDTH) textBox1.Text = MAX_WIDTH.ToString();
            else if (ParseInt(textBox1.Text) < MIN_WIDTH) textBox1.Text = MIN_WIDTH.ToString();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (!HandleHeightInput(textBox2.Text)) textBox2.Text = "";
            else if (ParseInt(textBox2.Text) > MAX_HEIGHT) textBox2.Text = MAX_HEIGHT.ToString();
            else if (ParseInt(textBox2.Text) < MIN_HEIGHT) textBox2.Text = MIN_HEIGHT.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // If we're downsizing
            if (m_dimensions.Value.x < m_baseDimensions.x || m_dimensions.Value.y < m_baseDimensions.y)
            {
                if (MessageBox.Show(
                    "Warning: You are trying to resize a part to dimensions lower than its original dimensions. " +
                    "This may result in lost data. Are you sure you wish to continue with this operation?",
                    "Part resize warning",
                    MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }
            }

            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            m_dimensions = null;
            Close();
        }

        private bool HandleWidthInput(string input)
        {
            int value = ParseInt(input);
            if (value == -1) return false;

            Vec2I dimensions = m_dimensions.Value;
            dimensions.x = value;
            m_dimensions = dimensions;

            return true;
        }

        private bool HandleHeightInput(string input)
        {
            int value = ParseInt(input);
            if (value == -1) return false;

            Vec2I dimensions = m_dimensions.Value;
            dimensions.y = value;
            m_dimensions = dimensions;

            return true;
        }

        private int ParseInt(string input)
        {
            int value;

            if (!int.TryParse(input, out value))
                return -1;

            return value;
        }
    }
}
