using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace graphics_editor
{
    class SelectionList : List<Selection> { }
    abstract class Selection
    {
        Item item;
        protected Selection(Item item)
        {
            this.item = item;
        }
        abstract public void Draw(Graph graph);

    }
    class FrameSelection : Selection
    {
        Point FirstSel;
        Point SecondSel;
        Point ThirdSel;
        Point FourthtSel;

        public FrameSelection(Item item) : base(item)
        {
            int x0 = item.Frame.X1 < item.Frame.X2 ? item.Frame.X1 : item.Frame.X2;
            int y0 = item.Frame.Y1 < item.Frame.Y2 ? item.Frame.Y1 : item.Frame.Y2;
            int w = Math.Abs(item.Frame.X1 - item.Frame.X2);
            int h = Math.Abs(item.Frame.Y1 - item.Frame.Y2);

            FirstSel.X = x0;
            FirstSel.Y = y0;
            SecondSel.X = x0 + w;
            SecondSel.Y = y0;
            ThirdSel.X = x0 + w;
            ThirdSel.Y = y0 + h;
            FourthtSel.X = x0;
            FourthtSel.Y = y0 + h;
        }
        public override void Draw(Graph graph)
        {
            graph.FrameSelection(FirstSel, SecondSel, ThirdSel, FourthtSel);
        }
    }
    class LineSelection : Selection
    {
        Point FirstSel;
        Point SecondSel;
        public LineSelection(Item item): base(item) 
        {
            FirstSel.X = item.Frame.X1;
            FirstSel.Y = item.Frame.Y1;
            SecondSel.X = item.Frame.X2;
            SecondSel.Y = item.Frame.Y2;
        }
        public override void Draw(Graph graph)
        {
            graph.LineSelection(FirstSel, SecondSel);
        }
    }
}
