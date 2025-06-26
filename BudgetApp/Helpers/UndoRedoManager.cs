using System;
using System.Collections.Generic;

namespace BudgetApp.Helpers
{
    public class UndoRedoManager
    {
        private readonly Stack<(Action redo, Action undo)> _undoStack = new();
        private readonly Stack<(Action redo, Action undo)> _redoStack = new();

        public void Do(Action redo, Action undo)
        {
            redo();
            _undoStack.Push((redo, undo));
            _redoStack.Clear();
        }

        public void Undo()
        {
            if (_undoStack.Count > 0)
            {
                var action = _undoStack.Pop();
                action.undo();
                _redoStack.Push(action);
            }
        }

        public void Redo()
        {
            if (_redoStack.Count > 0)
            {
                var action = _redoStack.Pop();
                action.redo();
                _undoStack.Push(action);
            }
        }
    }
}
