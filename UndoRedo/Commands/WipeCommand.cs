using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graphics_editor
{
    class WipeCommand : ICommand
    {
        Store store;
        Store oldStore;
        SelectionList selections;
        int operationNumber;
        public int OperationNumber { get { return operationNumber; } }
        public WipeCommand(Store store, SelectionList selections, int operationNumber)
        {
            this.store = store;
            this.selections = selections;
            this.operationNumber = operationNumber;
        }
        public void Execute()
        {
            if (oldStore == null)
            {
                oldStore = store.SubClone();
                store.Clear();
            }
            else
            {
                foreach (var i in oldStore)
                {
                    store.Remove(i);
                }
            }
            selections.Clear();
        }
        public void UnExecute()
        {
            foreach (var i in oldStore)
            {
                store.Add(i);
            }
            foreach (var i in store)
            {
                if (i.Selected == true)
                    selections.Add(i.CreateSelection());
            }
        }
    }
}
