using System.Collections.Generic;
using ImageEditorApp.Models;

namespace ImageEditorApp.Services
{
    public class EditingService
    {
        private List<EditHistory> editHistories = new List<EditHistory>();

        public void ApplyEdit(EditHistory edit)
        {
            editHistories.Add(edit);
        }

        public IEditHistoryIterator GetHistoryIterator()
        {
            return new EditHistoryIterator(editHistories);
        }
    }
}
