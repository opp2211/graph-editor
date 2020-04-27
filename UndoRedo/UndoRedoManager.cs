using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graphics_editor
{
    class UndoRedoManager
    {
        Stack<ICommand> UndoStack = new Stack<ICommand>();
        Stack<ICommand> RedoStack = new Stack<ICommand>();

        public void Undo()
        {
            if (UndoStack.Count > 0)
            {
                //изымаем команду из стека
                var command = UndoStack.Pop();
                //отменяем действие команды
                command.UnExecute();
                //заносим команду в стек Redo
                RedoStack.Push(command);
                if (UndoStack.Count > 0 && command.OperationNumber == UndoStack.Peek().OperationNumber)
                    Undo();
            }
        }

        public void Redo()
        {
            if (RedoStack.Count > 0)
            {
                //изымаем команду из стека
                var command = RedoStack.Pop();
                //выполняем действие команды
                command.Execute();
                //заносим команду в стек Undo
                UndoStack.Push(command);
                if (RedoStack.Count > 0 && command.OperationNumber == RedoStack.Peek().OperationNumber)
                    Redo();
            }
        }

        //выполняем команду
        public void Execute(ICommand command)
        {
            //выполняем команду
            command.Execute();
            //заносим в стек Undo
            UndoStack.Push(command);
            //очищаем стек Redo
            RedoStack.Clear();
        }
    }
}
