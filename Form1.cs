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
        public Form1()
        {
            InitializeComponent();
        }
        int x1, y1, x2, y2;
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            x1 = e.X;
            y1 = e.Y;
        }
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            Graph g = new Graph();
            g.ViewPort(pictureBox1.Location.X, pictureBox1.Location.Y,
                       pictureBox1.Size.Width, pictureBox1.Size.Height,
                       pictureBox1.CreateGraphics());

            x2 = e.X;
            y2 = e.Y;

            //g.Wipe();
            //g.Line(x1, y1, x2, y2);
            //g.Rectangle(x1, y1, x2, y2);
            Props props1 = new Props();
            PenProps penProps = new PenProps(Color.Khaki.ToArgb(), 3);
            BrushProps brushProps = new BrushProps(Color.Yellow.ToArgb());
            props1.Add(penProps);
            props1.Add(brushProps);

            Props props2 = new Props();
            penProps = new PenProps(Color.Red.ToArgb(), 3);
            brushProps = new BrushProps(Color.Green.ToArgb());
            props2.Add(penProps);
            props2.Add(brushProps);

            Rectangle r = new Rectangle(new Frame(x1, y1, x2, y2), props1);
            Ellipse ellipse = new Ellipse(new Frame(x1 + 10, y1 + 10, x2, y2), props2);
            List<Item> list = new List<Item>();
            list.Add(r);
            list.Add(ellipse);

            Group group = new Group(list);
            list.Clear();
            group.Paint(g);
        }

    }
}
