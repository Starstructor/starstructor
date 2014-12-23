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
    public partial class NewPart : Form
    {
        public string PartName { get; set; }

        public Vec2I? Dimensions
        {
            get { return m_dimensions; }     
        }

        private Vec2I? m_dimensions = new Vec2I();

        private const int MIN_WIDTH = 1;
        private const int MIN_HEIGHT = 1;
        private const int MAX_WIDTH = 4096;
        private const int MAX_HEIGHT = 4096;

        public NewPart()
        {
            InitializeComponent();
            textBox1.Text = "100";
            textBox2.Text = "100";
            textBox3.Text = "";
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
            if (String.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("Please enter a valid part name.");
                return;
            }

            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PartName = null;
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

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            PartName = textBox3.Text;
        }
    }
}
