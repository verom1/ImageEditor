using System.Collections.Generic;
using ImageEditorApp.Models;

namespace ImageEditorApp.Iterators
{
    public class EditHistoryQueue : IImageHistoryCollection
    {
        private List<EditHistory> _history = new List<EditHistory>();

        public void Add(EditHistory edit)
        {
            _history.Add(edit);
        }

        public IEditHistoryIterator CreateIterator()
        {
            return new EditHistoryQueueIterator(this);
        }

        public List<EditHistory> GetHistory()
        {
            return _history;
        }
    }
}
