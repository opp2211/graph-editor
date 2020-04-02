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
        public bool Grabbed
        {
            get
            {
                return grabbed;
            }
        }
        protected bool grabbed = false;
        protected Point grabbedPoint;

        protected Selection(Item item)
        {
            this.item = item;
        }
        abstract public void Draw(Graph graph);
        abstract public void Move(int dx, int dy);
        public void TryGrab(Point point)
        {
            if (item.isInBody(point))
            {
                grabbed = true;
                grabbedPoint = point;
            }
        }
        public void DragTo(Point point)
        {
            int dx = point.X - grabbedPoint.X;
            int dy = point.Y - grabbedPoint.Y;
            grabbedPoint = point;

            item.Frame.Move(dx, dy);
            Move(dx, dy);
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
            FourthSel.X = x0;
            FourthSel.Y = y0 + h;
        }
        public override void Move(int dx, int dy)
        {
            FirstSel.Offset(dx, dy);
            SecondSel.Offset(dx, dy);
            ThirdSel.Offset(dx, dy);
            FourthSel.Offset(dx, dy);
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
        public LineSelection(Item item) : base(item)
        {
            FirstSel.X = item.Frame.X1;
            FirstSel.Y = item.Frame.Y1;
            SecondSel.X = item.Frame.X2;
            SecondSel.Y = item.Frame.Y2;
        }
        public override void Move(int dx, int dy)
        {
            FirstSel.Offset(dx, dy);
            SecondSel.Offset(dx, dy);
        }
        public override void Draw(Graph graph)
        {
            graph.LineSelection(FirstSel, SecondSel);
        }
    }
}
