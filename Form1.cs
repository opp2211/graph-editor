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

        private void button_line_Click(object sender, EventArgs e)
        {
            controller.SetCreatedObjType(0);
        }

        private void button_rect_Click(object sender, EventArgs e)
        {
            controller.SetCreatedObjType(1);
        }

        private void button_ellipse_Click(object sender, EventArgs e)
        {
            controller.SetCreatedObjType(2);
        }

        private void thickness_numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            int t_value = (int)thickness_numericUpDown.Value;
            thickness_trackBar.Value = t_value > 10 ? 10 : t_value;
            controller.SetPenProps(lineColor_label.BackColor.ToArgb(), t_value);
        }

        private void thickness_trackBar_ValueChanged(object sender, EventArgs e)
        {
            int t_value = thickness_trackBar.Value;
            thickness_numericUpDown.Value = t_value;
            controller.SetPenProps(lineColor_label.BackColor.ToArgb(), t_value);
        }

        private void lineColor_label_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                lineColor_label.BackColor = colorDialog1.Color;
                controller.SetPenProps(lineColor_label.BackColor.ToArgb(), (int)thickness_numericUpDown.Value);
            }
        }

        private void fillColor_label_Click(object sender, EventArgs e)
        {
            if (colorDialog2.ShowDialog() == DialogResult.OK)
            {
                fillColor_label.BackColor = colorDialog2.Color;
                controller.SetBrushProps(fillColor_label.BackColor.ToArgb());
            }
        }

        private void button_wipe_Click(object sender, EventArgs e)
        {
            controller.Wipe();
        }
    }
}
