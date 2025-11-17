using ImageEditorApp.Data;
using ImageEditorApp.Models;
using System;

namespace ImageEditorApp.Services
{
    public class HistoryService
    {
        private readonly AppDbContext _ctx;

        public HistoryService(AppDbContext ctx) => _ctx = ctx;

        public void RecordAction(ImageRecord image, string action)
        {
            var hist = new EditHistory
            {
                ImageRecordId = image?.Id ?? 0,
                ActionType = action,
                Timestamp = DateTime.Now
            };
            _ctx.EditHistories.Add(hist);
            _ctx.SaveChanges();
        }

        public void EnsureImageRecord(ImageRecord record)
        {
            if (record == null) return;
            if (record.Id == 0)
            {
                _ctx.ImageRecords.Add(record);
                _ctx.SaveChanges();
            }
        }
    }
}
