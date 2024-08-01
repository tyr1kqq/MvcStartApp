using Microsoft.EntityFrameworkCore;

namespace MvcStartApp.Models.Db
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Request> Requests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Здесь вы можете настроить дополнительные параметры модели, если нужно.
            modelBuilder.Entity<Request>().HasKey(r => r.Id);
            base.OnModelCreating(modelBuilder);
        }
    }
}