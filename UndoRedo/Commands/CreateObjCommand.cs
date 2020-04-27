using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace graphics_editor
{
    class CreateObjCommand : ICommand
    {
        Factory factory;
        Store store;
        SelectionList selections;
        Point point;
        Item item;

        int operationNumber;
        public int OperationNumber { get { return operationNumber; } }

        public CreateObjCommand(Factory factory, Store store, SelectionList selections, Point point, int operationNumber)
        {
            this.factory = factory;
            this.store = store;
            this.selections = selections;
            this.point = point;
            this.operationNumber = operationNumber;
        }
        public void Execute()
        {
            if (item == null)
            {
                factory.CreateObj(point);
                item = store.Last<Item>();
                item.Selected = true;
                selections.Add(item.CreateSelection());
            }
            else
            {
                store.Add(item);
                selections.Add(item.CreateSelection());
            }
        }
        public void UnExecute()
        {
            store.Remove(item);
            selections.Clear();
        }
    }
}
