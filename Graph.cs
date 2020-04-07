using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graphics_editor
{
    class Graph
    {
        Graphics graphics;
        int x0, y0;
        int width, height;

        public int PenColor { get; set; }
        public int PenWidth { get; set; }
        public int BrushColor { get; set; }

        public void ViewPort(int x0, int y0, int w, int h, Graphics graphics)
        {
            this.graphics = graphics;
            this.x0 = x0;
            this.y0 = y0;
            width = w;
            height = h;
        }
        public void Line(float x1, float y1, float x2, float y2)
        {
            graphics.DrawLine(new Pen(Color.FromArgb(PenColor), PenWidth), x1, y1, x2, y2);
        }
        public void LineSelection(PointF p1, PointF p2)
        {
            graphics.DrawRectangle(new Pen(Color.Black, 1), p1.X - 5, p1.Y - 5, 10, 10);
            graphics.DrawRectangle(new Pen(Color.Black, 1), p2.X - 5, p2.Y - 5, 10, 10);

            Pen pen = new Pen(Color.Black, 1);
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;

            graphics.DrawLine(pen, p1, p2);
        }
        public void FrameSelection(PointF p1, PointF p2, PointF p3, PointF p4)
        {
            // p1 - p4 по порядку от левого перхнего угла
            graphics.DrawRectangle(new Pen(Color.Black, 1), p1.X - 5, p1.Y - 5, 10, 10);
            graphics.DrawRectangle(new Pen(Color.Black, 1), p2.X - 5, p2.Y - 5, 10, 10);
            graphics.DrawRectangle(new Pen(Color.Black, 1), p3.X - 5, p3.Y - 5, 10, 10);
            graphics.DrawRectangle(new Pen(Color.Black, 1), p4.X - 5, p4.Y - 5, 10, 10);

            float x0 = p1.X < p3.X ? p1.X : p3.X;
            float y0 = p1.Y < p3.Y ? p1.Y : p3.Y;
            float x00 = x0 == p1.X ? p3.X : p1.X;
            float y00 = y0 == p1.Y ? p3.Y : p1.Y;
            float w = Math.Abs(x0 - x00);
            float h = Math.Abs(y0 - y00);

            Pen pen = new Pen(Color.Black, 1);
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;

            graphics.DrawRectangle(pen, x0, y0, w, h);
        }
        public void Rectangle(float x1, float y1, float x2, float y2)
        {
            float x0 = x1 < x2 ? x1 : x2;
            float y0 = y1 < y2 ? y1 : y2;
            float w = Math.Abs(x1 - x2);
            float h = Math.Abs(y1 - y2);

            graphics.FillRectangle(new SolidBrush(Color.FromArgb(BrushColor)), x0, y0, w, h);
            graphics.DrawRectangle(new Pen(Color.FromArgb(PenColor), PenWidth), x0, y0, w, h);
        }
        public void Ellipse(float x1, float y1, float x2, float y2)
        {
            float x0 = x1 < x2 ? x1 : x2;
            float y0 = y1 < y2 ? y1 : y2;
            float w = x1 < x2 ? x2 - x1 : x1 - x2;
            float h = y1 < y2 ? y2 - y1 : y1 - y2;

            graphics.FillEllipse(new SolidBrush(Color.FromArgb(BrushColor)), x0, y0, w, h);
            graphics.DrawEllipse(new Pen(Color.FromArgb(PenColor), PenWidth), x0, y0, w, h);
        }
        public void Wipe()
        {
            if (graphics != null)
                graphics.FillRectangle(new SolidBrush(Color.White), 0, 0, width, height);
        }
    }
}
