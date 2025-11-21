using ImageEditorApp.Models;

namespace ImageEditorApp.Patterns.Iterator
{
    public interface IEditHistoryIterator
    {
        void First();
        void Next();
        bool IsDone();
        EditHistory Current();
    }
}
