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
        protected delegate void Changer(int dx, int dy);
        protected Changer changer;
        public int changerIndex;
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
        abstract public bool TryGrabMarker(Point point);
        abstract public void Draw(Graph graph);

        public bool TryGrab(Point point)
        {
            if (TryGrabMarker(point))
            {
                grabbedPoint = point;
                return true;
            }
            else if (item.isInBody(point))
            {
                grabbed = true;
                grabbedPoint = point;
                changer = item.Move;
                changerIndex = 0;
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

            changer(dx, dy);
            ResetSelection();
        }
        public void Release()
        {
            grabbed = false;
        }
        public void ChangeChanger(int changerIndex)
        {
            this.changerIndex = changerIndex;
            switch (changerIndex)
            {
                case 0:
                    changer = item.Move;
                    break;
                case 1:
                    changer = item.Resize_1;
                    break;
                case 2:
                    changer = item.Resize_2;
                    break;
                case 3:
                    changer = item.Resize_3;
                    break;
                case 4:
                    changer = item.Resize_4;
                    break;
            }
        }
    }
    class FrameSelection : Selection
    {
        PointF FirstSel;
        PointF SecondSel;
        PointF ThirdSel;
        PointF FourthSel;

        public FrameSelection(Item item) : base(item) { }

        public override void ResetSelection()
        {

            FirstSel.X = item.Frame.X1;
            FirstSel.Y = item.Frame.Y1;
            SecondSel.X = item.Frame.X2;
            SecondSel.Y = item.Frame.Y1;
            ThirdSel.X = item.Frame.X2;
            ThirdSel.Y = item.Frame.Y2;
            FourthSel.X = item.Frame.X1;
            FourthSel.Y = item.Frame.Y2;
        }
        public override bool TryGrabMarker(Point point)
        {
            if (FirstSel.X + 5 > point.X && FirstSel.X - 5 < point.X && FirstSel.Y + 5 > point.Y && FirstSel.Y - 5 < point.Y)
            {
                changer = item.Resize_1;
                changerIndex = 1;
                return true;
            }
            if (SecondSel.X + 5 > point.X && SecondSel.X - 5 < point.X && SecondSel.Y + 5 > point.Y && SecondSel.Y - 5 < point.Y)
            {
                changer = item.Resize_2;
                changerIndex = 2;
                return true;
            }
            if (ThirdSel.X + 5 > point.X && ThirdSel.X - 5 < point.X && ThirdSel.Y + 5 > point.Y && ThirdSel.Y - 5 < point.Y)
            {
                changer = item.Resize_3;
                changerIndex = 3;
                return true;
            }
            if (FourthSel.X + 5 > point.X && FourthSel.X - 5 < point.X && FourthSel.Y + 5 > point.Y && FourthSel.Y - 5 < point.Y)
            {
                changer = item.Resize_4;
                changerIndex = 4;
                return true;
            }
            return false;
        }
        public override void Draw(Graph graph)
        {
            graph.FrameSelection(FirstSel, SecondSel, ThirdSel, FourthSel);
        }
    }
    class LineSelection : Selection
    {
        PointF FirstSel;
        PointF SecondSel;
        public LineSelection(Item item) : base(item) { }
        public override void ResetSelection()
        {
            FirstSel.X = item.Frame.X1;
            FirstSel.Y = item.Frame.Y1;
            SecondSel.X = item.Frame.X2;
            SecondSel.Y = item.Frame.Y2;
        }
        public override bool TryGrabMarker(Point point)
        {
            if (FirstSel.X + 5 > point.X && FirstSel.X - 5 < point.X && FirstSel.Y + 5 > point.Y && FirstSel.Y - 5 < point.Y)
            {
                changer = item.Resize_1;
                changerIndex = 1;
                return true;
            }
            if (SecondSel.X + 5 > point.X && SecondSel.X - 5 < point.X && SecondSel.Y + 5 > point.Y && SecondSel.Y - 5 < point.Y)
            {
                changer = item.Resize_3;
                changerIndex = 3;
                return true;
            }
            return false;
        }
        public override void Draw(Graph graph)
        {
            graph.LineSelection(FirstSel, SecondSel);
        }
    }
}
