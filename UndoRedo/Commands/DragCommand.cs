using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace graphics_editor
{
    class DragCommand : ICommand
    {
        SelectionList selections;
        List<Item> items;
        Point newPoint;
        Point oldPoint;
        int changerIndex;
        int operationNumber;
        public int OperationNumber { get { return operationNumber; } }
        public DragCommand(SelectionList selections, Point point, int operationNumber)
        {
            this.selections = selections;
            this.newPoint = point;
            this.operationNumber = operationNumber;
        }
        public void Execute()
        {
            if(items == null)
            {
                items = new List<Item>();
                oldPoint = selections[0].GrabbedPoint;
                changerIndex = selections[0].changerIndex;
                foreach (Selection s in selections)
                {
                    s.DragTo(newPoint);
                    items.Add(s.Item);
                }
            }
            else
            {
                selections.Clear();
                foreach(var i in items)
                {
                    selections.Add(i.CreateSelection());
                }
                selections[0].SetGrabbedPoint(oldPoint);
                foreach (Selection s in selections)
                {
                    s.ChangeChanger(changerIndex);
                    s.DragTo(newPoint);
                }
            }
            selections[0].SetGrabbedPoint(newPoint);
        }
        public void UnExecute()
        {
            selections.Clear();
            foreach (var item in items)
            {
                selections.Add(item.CreateSelection());
            }
            selections[0].SetGrabbedPoint(newPoint);
            foreach (Selection s in selections)
            {
                s.ChangeChanger(changerIndex);
                s.DragTo(oldPoint);
            }
            selections[0].SetGrabbedPoint(oldPoint);
        }
    }
}
