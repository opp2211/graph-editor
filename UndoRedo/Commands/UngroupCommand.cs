using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graphics_editor
{
    class UngroupCommand : ICommand
    {
        SelectionList selections;
        Store store;
        List<Item> uItems;
        Group group;
        int operationNumber;
        public int OperationNumber { get { return operationNumber; } }
        public UngroupCommand(SelectionList selections, Store store, int operationNumber)
        {
            this.selections = selections;
            this.store = store;
            this.operationNumber = operationNumber;
        }
        public void Execute()
        {
            if (uItems == null)
                uItems = store.UnGroup((Group)selections[0].Item);
            else
            {
                store.UnGroup(group);
            }
            selections.Clear();
            foreach (Item item in uItems)
            {
                item.Selected = true;
                selections.Add(item.CreateSelection());
            }

        }
        public void UnExecute()
        {
            foreach (var i in uItems)
            {
                store.Remove(i);
            }
            group = new Group(uItems);
            store.Add(group);
            selections.Clear();
            group.ClearSelectionsForItems();
            group.Selected = true;
            selections.Add(group.CreateSelection());
        }
    }
}
