using ImageEditorApp.Models;
using System;

namespace ImageEditorApp.Patterns.Iterator
{
    public class EditHistoryIterator : IEditHistoryIterator
    {
        private readonly EditHistoryQueue _queue;
        private int _current = 0;

        public EditHistoryIterator(EditHistoryQueue queue)
        {
            _queue = queue;
        }

        public void First() => _current = 0;
        public void Next() => _current++;
        public bool IsDone() => _current >= _queue.Count;
        public EditHistory Current()
        {
            if (IsDone()) throw new InvalidOperationException();
            return _queue.GetAt(_current);
        }
    }
}
