using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace graphics_editor
{
    class Rectangle : Figure
    {
        public Rectangle(Frame frame, Props props) : base(frame, props) { }
        protected override void PaintGeom(Graph graph)
        {
            graph.Rectangle(Frame.X1, Frame.Y1, Frame.X2, Frame.Y2);
        }
        public override bool isInBody(Point point)
        {
            int x0 = Frame.X1 < Frame.X2 ? Frame.X1 : Frame.X2;
            int y0 = Frame.Y1 < Frame.Y2 ? Frame.Y1 : Frame.Y2;
            int w = Math.Abs(Frame.X1 - Frame.X2);
            int h = Math.Abs(Frame.Y1 - Frame.Y2);
            return point.X >= x0 && point.X <= x0 + w && point.Y >= y0 && point.Y <= y0 + h;
        }
        public override Selection CreateSelection()
        {
            return new FrameSelection(this);
        }
        public override object Clone()
        {
            return new Rectangle((Frame)Frame.Clone(), (Props)Props.Clone());
        }
    }
    class Ellipse : Figure
    {
        public Ellipse(Frame frame, Props props) : base(frame, props) { }
        protected override void PaintGeom(Graph graph)
        {
            graph.Ellipse(Frame.X1, Frame.Y1, Frame.X2, Frame.Y2);
        }
        public override bool isInBody(Point point)
        {
            Point centre = new Point((Frame.X2 + Frame.X1) / 2, (Frame.Y2 + Frame.Y1) / 2);
            return Math.Pow(point.X - centre.X, 2) / Math.Pow(((Frame.X2 - Frame.X1) / 2), 2) + Math.Pow(point.Y - centre.Y, 2) / Math.Pow(((Frame.Y2 - Frame.Y1) / 2), 2) <= 1;
        }
        public override Selection CreateSelection()
        {
            return new FrameSelection(this);
        }
        public override object Clone()
        {
            return new Ellipse((Frame)Frame.Clone(), (Props)Props.Clone());
        }
    }
    class Line : Figure
    {
        public Line(Frame frame, Props props) : base(frame, props) { }
        protected override void PaintGeom(Graph graph)
        {
            graph.Line(Frame.X1, Frame.Y1, Frame.X2, Frame.Y2);
        }
        public override bool isInBody(Point point)
        {
            int x1 = Frame.X1 < Frame.X2 ? Frame.X1 : Frame.X2;
            int x2 = x1 == Frame.X1 ? Frame.X2 : Frame.X1;
            int y1 = x1 == Frame.X1 ? Frame.Y1 : Frame.Y2;
            int y2 = x2 == Frame.X2 ? Frame.Y2 : Frame.Y1;

            int delta = 5;

            bool left = point.X >= x1 - delta;
            bool right = point.X <= x2 + delta;

            bool top, bottom;
            if (y1 < y2)
            {
                top = point.Y >= y1 - delta;
                bottom = point.Y <= y2 + delta;
            }
            else
            {
                top = point.Y >= y2 - delta;
                bottom = point.Y <= y1 + delta;
            }

            return top && bottom && left && right;
        }
        public override Selection CreateSelection()
        {
            return new LineSelection(this);
        }
        public override object Clone()
        {
            return new Line((Frame)Frame.Clone(), (Props)Props.Clone());
        }
    }
    class Group : Item
    {
        List<Item> list;
        public List<Item> GetItems { get { return list; } }

        public Group(List<Item> items)
        {
            list = new List<Item>();
            foreach (Item item in items)
            {
                list.Add((Item)item.Clone());
            }
            Frame = (Frame)list[0].Frame.Clone();
            foreach (Item item in list)
            {
                Frame.JoinFrame(item.Frame);
            }
            foreach (Item item in list)
            {
                item.RelX1 = (float)(item.Frame.X1 - Frame.X2) / (Frame.X2 - Frame.X1);
                item.RelX2 = (float)(item.Frame.X2 - Frame.X2) / (Frame.X2 - Frame.X1);
                item.RelY1 = (float)(item.Frame.Y1 - Frame.Y2) / (Frame.X2 - Frame.X1);
                item.RelY2 = (float)(item.Frame.Y2 - Frame.Y2) / (Frame.X2 - Frame.X1);
            }
        }
        public override bool isInBody(Point point)
        {
            foreach (Item item in list)
            {
                if (item.isInBody(point))
                    return true;
            }
            return false;
        }
        public override void Paint(Graph graph)
        {
            foreach (Item item in list)
            {
                item.Paint(graph);
            }
        }
        public void ClearSelectionsForItems()
        {
            foreach (Item item in list)
            {
                item.Selected = false;
            }
        }
        public override Selection CreateSelection()
        {
            return new FrameSelection(this);
        }
        public override void Move(int dx, int dy)
        {
            Frame.Move(dx, dy);
            foreach (Item item in list)
            {
                item.Move(dx, dy);
            }
        }
        public override void Resize_1(int dx, int dy)
        {
            Frame.Resize_1(dx, dy);
            foreach (Item item in list)
            {
                item.Frame.X1 = (int)(item.RelX1 * (Frame.X2 - Frame.X1) + Frame.X2);
                item.Frame.X2 = (int)(item.RelX2 * (Frame.X2 - Frame.X1) + Frame.X2);
                item.Frame.Y1 = (int)(item.RelY1 * (Frame.Y2 - Frame.Y1) + Frame.Y2);
                item.Frame.Y2 = (int)(item.RelY2 * (Frame.Y2 - Frame.Y1) + Frame.Y2);
            }
        }
        public override void Resize_2(int dx, int dy)
        {
            Frame.Resize_2(dx, dy);
            foreach (Item item in list)
            {
                item.Frame.X1 = (int)(item.RelX1 * (Frame.X2 - Frame.X1) + Frame.X2);
                item.Frame.X2 = (int)(item.RelX2 * (Frame.X2 - Frame.X1) + Frame.X2);
                item.Frame.Y1 = (int)(item.RelY1 * (Frame.Y2 - Frame.Y1) + Frame.Y2);
                item.Frame.Y2 = (int)(item.RelY2 * (Frame.Y2 - Frame.Y1) + Frame.Y2);
            }
        }
        public override void Resize_3(int dx, int dy)
        {
            Frame.Resize_3(dx, dy);
            foreach (Item item in list)
            {
                item.Frame.X1 = (int)(item.RelX1 * (Frame.X2 - Frame.X1) + Frame.X2);
                item.Frame.X2 = (int)(item.RelX2 * (Frame.X2 - Frame.X1) + Frame.X2);
                item.Frame.Y1 = (int)(item.RelY1 * (Frame.Y2 - Frame.Y1) + Frame.Y2);
                item.Frame.Y2 = (int)(item.RelY2 * (Frame.Y2 - Frame.Y1) + Frame.Y2);
            }
        }
        public override void Resize_4(int dx, int dy)
        {
            Frame.Resize_4(dx, dy);
            foreach (Item item in list)
            {
                item.Frame.X1 = (int)(item.RelX1 * (Frame.X2 - Frame.X1) + Frame.X2);
                item.Frame.X2 = (int)(item.RelX2 * (Frame.X2 - Frame.X1) + Frame.X2);
                item.Frame.Y1 = (int)(item.RelY1 * (Frame.Y2 - Frame.Y1) + Frame.Y2);
                item.Frame.Y2 = (int)(item.RelY2 * (Frame.Y2 - Frame.Y1) + Frame.Y2);
            }
        }
        public override object Clone()
        {
            return new Group(list);
        }
    }
}
