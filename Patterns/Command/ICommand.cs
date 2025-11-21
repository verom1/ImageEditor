using System.Drawing;

namespace ImageEditorApp.Patterns.Command
{
    public interface ICommand
    {
        void Execute();
        void Undo();
    }
}
