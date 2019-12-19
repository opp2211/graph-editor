using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graphics_editor
{
    class Props : List<SubProps>, ICloneable
    {
        public object Clone()
        {
            Props props = new Props();
            foreach (SubProps item in this)
            {
                props.Add((SubProps)item.Clone());
            }
            return props;
        }
        public void Apply (Graph graph)
        {
            foreach (SubProps subProp in this)
            {
                subProp.Apply(graph);
            }
        }
    }
    abstract class SubProps : ICloneable
    {
        abstract public void Apply(Graph graph);
        abstract public object Clone();
    }
    class PenProps : SubProps
    {
        int PenColor { get; set; }
        int PenWidth { get; set; }

        public PenProps(int penColor, int penWidth)
        {
            PenColor = penColor;
            PenWidth = penWidth;
        }
        public PenProps(int penColor)
        {
            PenColor = penColor;
            PenWidth = 1;
        }
        public PenProps()
        {
            PenColor = Color.Black.ToArgb();
            PenWidth = 1;
        }
        public override void Apply(Graph graph)
        {
            graph.PenColor = PenColor;
            graph.PenWidth = PenWidth;
        }
        override public object Clone()
        {
            return (PenProps)MemberwiseClone();
        }
    }
    class BrushProps : SubProps
    {
        int BrushColor { get; set; }
        public BrushProps(int brushColor)
        {
            BrushColor = brushColor;
        }
        public BrushProps()
        {
            BrushColor = Color.Black.ToArgb();
        }
        public override void Apply(Graph graph)
        {
            graph.BrushColor = BrushColor;
        }
        override public object Clone()
        {
            return (BrushProps)MemberwiseClone();
        }
    }
}
