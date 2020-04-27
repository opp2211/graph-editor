using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace graphics_editor
{
    abstract class Item 
    {
        public Frame Frame { get; set; }
        public float RelX1 { get; set; }
        public float RelX2 { get; set; }
        public float RelY1 { get; set; }
        public float RelY2 { get; set; }
        public bool Selected { get; set; } = false;
        protected Item (Frame frame)
        {
            Frame = frame;
        }
        protected Item()
        {
            Frame = new Frame();
        }
        public abstract void Paint(Graph graph);
        public abstract bool isInBody(Point point);
        public abstract Selection CreateSelection();
        public abstract void Move(int dx, int dy);
        public abstract void Resize_1(int dx, int dy);
        public abstract void Resize_2(int dx, int dy);
        public abstract void Resize_3(int dx, int dy);
        public abstract void Resize_4(int dx, int dy);
        abstract public Item Clone();

    }
    abstract class Figure : Item
    {
        public Props Props;
        protected Figure (Frame frame, Props props) : base(frame)
        {
            Props = (Props)props.Clone();
        }
        public override void Paint(Graph graph)
        {
            Props.Apply(graph);
            PaintGeom(graph);
        }
        abstract protected void PaintGeom(Graph graph);
        public override void Move(int dx, int dy)
        {
            Frame.Move(dx, dy);
        }
        public override void Resize_1(int dx, int dy)
        {
            Frame.Resize_1(dx, dy);
        }
        public override void Resize_2(int dx, int dy)
        {
            Frame.Resize_2(dx, dy);
        }
        public override void Resize_3(int dx, int dy)
        {
            Frame.Resize_3(dx, dy);
        }
        public override void Resize_4(int dx, int dy)
        {
            Frame.Resize_4(dx, dy);
        }
        public override Item Clone()
        {
            var clone = (Figure)this.MemberwiseClone();
            clone.Frame = (Frame)Frame.Clone();
            clone.Props = (Props)Props.Clone();
            return clone;
        }
    }
}
