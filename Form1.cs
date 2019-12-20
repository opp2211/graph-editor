using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace graphics_editor
{
    public partial class Form1 : Form
    {
        Controller controller;
        public Form1()
        {
            InitializeComponent();
            controller = new Controller(new Model());
            controller.ViewPort(pictureBox1.Location.X, pictureBox1.Location.Y,
                       pictureBox1.Size.Width, pictureBox1.Size.Height,
                       pictureBox1.CreateGraphics());
            controller.InitializeProps(lineColor_label.BackColor.ToArgb(),
                                       (int)thickness_numericUpDown.Value,
                                       fillColor_label.BackColor.ToArgb());
        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            controller.MouseDown(e.X, e.Y);
        }
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            controller.MouseUp(e.X, e.Y);
        }

    }
}
