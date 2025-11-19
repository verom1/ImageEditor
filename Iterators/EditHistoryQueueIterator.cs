using System;
using ImageEditorApp.Models;

namespace ImageEditorApp.Iterators
{
    public class EditHistoryQueueIterator : IEditHistoryIterator
    {
        private EditHistoryQueue _queue;
        private int _current = 0;

        public EditHistoryQueueIterator(EditHistoryQueue queue)
        {
            _queue = queue;
        }

        public void First()
        {
            _current = 0;
        }

        public void Next()
        {
            _current++;
        }

        public bool IsDone()
        {
            return _current >= _queue.GetHistory().Count;
        }

        public EditHistory Current()
        {
            if (IsDone())
                throw new InvalidOperationException();
            return _queue.GetHistory()[_current];
        }
    }
}
