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

        public void ViewPort (int x0, int y0, int w, int h, Graphics graphics)
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
        public void Rectangle(int x1, int y1, int x2, int y2)
        {
            int x0 = x1 < x2 ? x1 : x2;
            int y0 = y1 < y2 ? y1 : y2;
            int w = x1 < x2 ? x2 - x1 : x1 - x2;
            int h = y1 < y2 ? y2 - y1 : y1 - y2;

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
            graphics.FillRectangle(new SolidBrush(Color.White), 0, 0, width, height);
        }
    }
}
