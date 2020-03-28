using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graphics_editor
{
    class Rectangle : Figure
    {
        public Rectangle(Frame frame, Props props) : base(frame, props) { }
        protected override void PaintGeom(Graph graph)
        {
            graph.Rectangle(Frame.X1, Frame.Y1, Frame.X2, Frame.Y2);
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
        public override object Clone()
        {
            return new Line((Frame)Frame.Clone(), (Props)Props.Clone());
        }
    }
    class Group : Item
    {
        List<Item> list;
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
                Frame.JoinFrame(Frame);
            }
        }
        public override void Paint(Graph graph)
        {
            foreach (Item item in list)
            {
                item.Paint(graph);
            }
        }
        public override object Clone()
        {
            return new Group(list);
        }
    }
}
