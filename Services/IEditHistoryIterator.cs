using ImageEditorApp.Models;

namespace ImageEditorApp.Services
{
    public interface IEditHistoryIterator
    {
        EditHistory Current();
        bool IsDone();
        void Next();
    }
}
