using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKR1
{
    public class CommandInvoker
    {
        private readonly Stack<ICommand> _undoStack = new Stack<ICommand>();
        private readonly Stack<ICommand> _redoStack = new Stack<ICommand>();

        public void ExecuteCommand(ICommand command)
        {
            command.Execute();
            _undoStack.Push(command);
            _redoStack.Clear(); // Очищаємо redo після нової команди
            Console.WriteLine($"Executed: {command.Description}");
        }

        public void Undo()
        {
            if (_undoStack.Count > 0)
            {
                var command = _undoStack.Pop();
                command.Undo();
                _redoStack.Push(command);
                Console.WriteLine($"Undone: {command.Description}");
            }
            else
            {
                Console.WriteLine("Nothing to undo");
            }
        }

        public void Redo()
        {
            if (_redoStack.Count > 0)
            {
                var command = _redoStack.Pop();
                command.Execute();
                _undoStack.Push(command);
                Console.WriteLine($"Redone: {command.Description}");
            }
            else
            {
                Console.WriteLine("Nothing to redo");
            }
        }

        public void ShowHistory()
        {
            Console.WriteLine("=== Command History ===");
            var commands = _undoStack.ToArray();
            for (int i = commands.Length - 1; i >= 0; i--)
            {
                Console.WriteLine($"{commands.Length - i}. {commands[i].Description}");
            }
        }
    }
}
