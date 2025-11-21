using System.Collections.Generic;
using ImageEditorApp.Models;

namespace ImageEditorApp.Patterns.Iterator
{
    public class EditHistoryQueue
    {
        private readonly List<EditHistory> _list = new List<EditHistory>();

        public void Add(EditHistory item) => _list.Add(item);

        public IList<EditHistory> GetAll() => _list.AsReadOnly();

        public IEditHistoryIterator CreateIterator() => new EditHistoryIterator(this);
        internal EditHistory GetAt(int index) => _list[index];
        internal int Count => _list.Count;
    }
}
