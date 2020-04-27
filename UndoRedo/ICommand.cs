using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graphics_editor
{
    interface ICommand
    {
        int OperationNumber { get; }
        void Execute();
        void UnExecute();
    }
}
