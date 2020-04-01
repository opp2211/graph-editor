using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graphics_editor
{
    abstract class Item : ICloneable
    {
        public Frame Frame { get; set; }
        protected Item (Frame frame)
        {
            Frame = frame;
        }
        protected Item()
        {
            Frame = new Frame();
        }
        public abstract void Paint(Graph graph);
        public abstract bool isInBody(int x, int y);
        public abstract Selection CreateSelection();
        abstract public object Clone();

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
        
    }
}
