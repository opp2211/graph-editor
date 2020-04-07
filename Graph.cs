﻿using System;
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
        public void Line(int x1, int y1, int x2, int y2)
        {
            graphics.DrawLine(new Pen(Color.FromArgb(PenColor), PenWidth), x1, y1, x2, y2);
        }
        public void LineSelection(Point p1, Point p2)
        {
            graphics.DrawRectangle(new Pen(Color.Black, 1), p1.X - 5, p1.Y - 5, 10, 10);
            graphics.DrawRectangle(new Pen(Color.Black, 1), p2.X - 5, p2.Y - 5, 10, 10);

            Pen pen = new Pen(Color.Black, 1);
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;

            graphics.DrawLine(pen, p1, p2);
        }
        public void FrameSelection(Point p1, Point p2, Point p3, Point p4)
        {
            // p1 - p4 по порядку от левого перхнего угла
            graphics.DrawRectangle(new Pen(Color.Black, 1), p1.X - 5, p1.Y - 5, 10, 10);
            graphics.DrawRectangle(new Pen(Color.Black, 1), p2.X - 5, p2.Y - 5, 10, 10);
            graphics.DrawRectangle(new Pen(Color.Black, 1), p3.X - 5, p3.Y - 5, 10, 10);
            graphics.DrawRectangle(new Pen(Color.Black, 1), p4.X - 5, p4.Y - 5, 10, 10);

            int x0 = p1.X < p3.X ? p1.X : p3.X;
            int y0 = p1.Y < p3.Y ? p1.Y : p3.Y;
            int x00 = x0 == p1.X ? p3.X : p1.X;
            int y00 = y0 == p1.Y ? p3.Y : p1.Y;
            int w = Math.Abs(x0 - x00);
            int h = Math.Abs(y0 - y00);

            Pen pen = new Pen(Color.Black, 1);
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;

            graphics.DrawRectangle(pen, x0, y0, w, h);
        }
        public void Rectangle(int x1, int y1, int x2, int y2)
        {
            int x0 = x1 < x2 ? x1 : x2;
            int y0 = y1 < y2 ? y1 : y2;
            int w = Math.Abs(x1 - x2);
            int h = Math.Abs(y1 - y2);

            graphics.FillRectangle(new SolidBrush(Color.FromArgb(BrushColor)), x0, y0, w, h);
            graphics.DrawRectangle(new Pen(Color.FromArgb(PenColor), PenWidth), x0, y0, w, h);
        }
        public void Ellipse(int x1, int y1, int x2, int y2)
        {
            int x0 = x1 < x2 ? x1 : x2;
            int y0 = y1 < y2 ? y1 : y2;
            int w = x1 < x2 ? x2 - x1 : x1 - x2;
            int h = y1 < y2 ? y2 - y1 : y1 - y2;

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
