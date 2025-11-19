using ImageEditorApp.Models;

namespace ImageEditorApp.Iterators
{
    public interface IEditHistoryIterator
    {
        void First();
        void Next();
        bool IsDone();
        EditHistory Current();
    }
}
