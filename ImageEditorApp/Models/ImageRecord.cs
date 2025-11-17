using System;

namespace ImageEditorApp.Models
{
    public class ImageRecord
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
