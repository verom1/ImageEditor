using System.Collections.Generic;

namespace ImageEditorApp.Models
{
    public class ImageRecord
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public List<EditHistory> EditHistories { get; set; } = new List<EditHistory>();
    }
}
