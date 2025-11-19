using Microsoft.EntityFrameworkCore;
using ImageEditorApp.Models;

namespace ImageEditorApp.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Image> Images { get; set; }
        public DbSet<Filter> Filters { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=ImageEditor.db");
        }
    }
}
