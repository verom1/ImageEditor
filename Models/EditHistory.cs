using System;

namespace ImageEditorApp.Models
{
    public class EditHistory
    {
        public string Description { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.Now;
    }
}
