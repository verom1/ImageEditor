using System;

namespace ImageEditorApp.Models
{
    public class EditHistory
    {
        public int Id { get; set; }
        public int ImageRecordId { get; set; }
        public string ActionType { get; set; }  // "Open","Edit","Save"
        public DateTime Timestamp { get; set; }

        public ImageRecord ImageRecord { get; set; }
    }
}
