using Microsoft.EntityFrameworkCore;
using ImageEditorApp.Models;
using System.IO;

namespace ImageEditorApp.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<ImageRecord> ImageRecords { get; set; }
        public DbSet<EditHistory> EditHistories { get; set; }

        private static string DbPath =>
            Path.Combine(Directory.GetCurrentDirectory(), "imageeditor.db");

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={DbPath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // additional configuration if needed
        }
    }
}
