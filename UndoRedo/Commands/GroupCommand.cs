using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graphics_editor
{
    class GroupCommand : ICommand
    {
        SelectionList selections;
        Store store;
        Group group;

        int operationNumber;
        public int OperationNumber { get { return operationNumber; } }
        public GroupCommand(SelectionList selections, Store store, int operationNumber)
        {
            this.selections = selections;
            this.store = store;
            this.operationNumber = operationNumber;
        }
        public void Execute()
        {
            if (group == null)
                group = store.Group();
            else
                store.Add(group);

            selections.Clear();
            group.ClearSelectionsForItems();
            group.Selected = true;
            selections.Add(group.CreateSelection());
        }
        public void UnExecute()
        {
            List<Item> ungrouppedItems = store.UnGroup(group);
            selections.Clear();
            foreach (Item item in ungrouppedItems)
            {
                item.Selected = true;
                selections.Add(item.CreateSelection());
            }
        }
    }
}
