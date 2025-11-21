using System.Collections.Generic;

namespace ImageEditorApp.Patterns.Command
{
    public class CommandManager
    {
        private readonly Stack<ICommand> _undo = new Stack<ICommand>();
        private readonly Stack<ICommand> _redo = new Stack<ICommand>();

        public void Execute(ICommand cmd)
        {
            cmd.Execute();
            _undo.Push(cmd);
            _redo.Clear();
        }

        public void Undo()
        {
            if (_undo.Count > 0)
            {
                var cmd = _undo.Pop();
                cmd.Undo();
                _redo.Push(cmd);
            }
        }

        public void Redo()
        {
            if (_redo.Count > 0)
            {
                var cmd = _redo.Pop();
                cmd.Execute();
                _undo.Push(cmd);
            }
        }
    }
}
