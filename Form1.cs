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
            this.KeyPreview = true;
        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            controller.MouseDown(e.Location);
        }
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            controller.MouseUp(e.Location);
        }
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            controller.MouseMove(e.Location);
        }
        private void button_select_Click(object sender, EventArgs e)
        {
            controller.ChangeState(0);
        }
        private void button_line_Click(object sender, EventArgs e)
        {
            controller.ChangeState(1);
            controller.SetCreatedObjType(0);
        }

        private void button_rect_Click(object sender, EventArgs e)
        {
            controller.ChangeState(1);
            controller.SetCreatedObjType(1);
        }

        private void button_ellipse_Click(object sender, EventArgs e)
        {
            controller.ChangeState(1);
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
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
                controller.ControlOn();
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
                controller.ControlOff();
        }
    }
}
