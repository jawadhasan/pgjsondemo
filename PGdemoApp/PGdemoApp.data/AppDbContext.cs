using Microsoft.EntityFrameworkCore;
using PGdemoApp.Core;

namespace PGdemoApp.data
{
    public class AppDbContext : DbContext
    {
        public DbSet<CustomerDoc> CustomerDocs { get; set; }
        public DbSet<LogRecord> LogRecords { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerDoc>()
                .Property(b => b.Customer)
                .HasColumnType("jsonb");
        }
    }
}
