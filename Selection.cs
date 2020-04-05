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
        protected Item item;
        public Item Item { get { return item; } }

        protected bool grabbed = false;
        protected static Point grabbedPoint;
        public bool Grabbed
        {
            get
            {
                return grabbed;
            }
        }

        protected Selection(Item item)
        {
            this.item = item;
            ResetSelection();
        }

        abstract public void ResetSelection();
        abstract public void Draw(Graph graph);

        public bool TryGrab(Point point)
        {
            if (item.isInBody(point))
            {
                grabbed = true;
                grabbedPoint = point;
                return true;
            }
            return false;
        }
        public void SetGrabbedPoint(Point point)
        {
            grabbedPoint = point;
        }
        public void DragTo(Point point)
        {
            int dx = point.X - grabbedPoint.X;
            int dy = point.Y - grabbedPoint.Y;

            item.Move(dx, dy);
            ResetSelection();
        }
        public void Release()
        {
            grabbed = false;
        }
    }
    class FrameSelection : Selection
    {
        Point FirstSel;
        Point SecondSel;
        Point ThirdSel;
        Point FourthSel;

        public FrameSelection(Item item) : base(item) { }

        public override void ResetSelection()
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
            FourthSel.X = x0;
            FourthSel.Y = y0 + h;
        }
        public override void Draw(Graph graph)
        {
            graph.FrameSelection(FirstSel, SecondSel, ThirdSel, FourthSel);
        }
    }
    class LineSelection : Selection
    {
        Point FirstSel;
        Point SecondSel;
        public LineSelection(Item item) : base(item) { }
        public override void ResetSelection()
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
