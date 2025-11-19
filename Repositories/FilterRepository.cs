using ImageEditorApp.Data;
using ImageEditorApp.Models;

namespace ImageEditorApp.Repositories
{
    public class FilterRepository : RepositoryBase<Filter, int>
    {
        public FilterRepository(AppDbContext context) : base(context) { }
    }
}
