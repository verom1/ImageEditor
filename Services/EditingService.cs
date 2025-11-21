using System.Drawing;
using ImageEditorApp.Patterns.Iterator;
using ImageEditorApp.Models;
using System.Collections.Generic;

namespace ImageEditorApp.Services
{
    public class EditingService
    {
        private Bitmap _current;
        private readonly EditHistoryQueue _historyQueue = new EditHistoryQueue();

        public Bitmap GetCurrentBitmap() => _current;
        public void SetCurrentBitmap(Bitmap bmp) { _current = bmp; }

        public void AddHistory(string desc)
        {
            _historyQueue.Add(new EditHistory { Description = desc });
        }

        public EditHistoryQueue GetHistoryQueue() => _historyQueue;
    }
}
