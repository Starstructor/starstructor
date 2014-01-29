using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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

        private const int MIN_WIDTH = 1;
        private const int MIN_HEIGHT = 1;
        private const int MAX_WIDTH = 1024;
        private const int MAX_HEIGHT = 1024;

        public ResizePart(int baseWidth, int baseHeight)
        {
            m_dimensions = new Vec2I(baseWidth, baseHeight);
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
