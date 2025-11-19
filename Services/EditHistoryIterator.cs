using System.Collections.Generic;
using ImageEditorApp.Models;

namespace ImageEditorApp.Services
{
    public class EditHistoryIterator : IEditHistoryIterator
    {
        private List<EditHistory> _editHistories;
        private int _current = 0;

        public EditHistoryIterator(List<EditHistory> editHistories)
        {
            _editHistories = editHistories;
        }

        public EditHistory Current()
        {
            if (_current < _editHistories.Count)
                return _editHistories[_current];
            return null;
        }

        public bool IsDone()
        {
            return _current >= _editHistories.Count;
        }

        public void Next()
        {
            _current++;
        }
    }
}
