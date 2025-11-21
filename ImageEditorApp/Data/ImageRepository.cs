using ImageEditorApp.Models;
using System.Linq;
using System.Collections.Generic;

namespace ImageEditorApp.Data
{
    public class ImageRepository : RepositoryBase<ImageRecord>
    {
        public ImageRepository(AppDbContext ctx) : base(ctx) { }

        public ImageRecord GetByPath(string path)
        {
            return _dbSet.FirstOrDefault(x => x.FilePath == path);
        }

        public IEnumerable<ImageRecord> GetRecent(int count = 10)
        {
            return _dbSet.OrderByDescending(r => r.CreatedAt).Take(count).ToList();
        }
    }
}
