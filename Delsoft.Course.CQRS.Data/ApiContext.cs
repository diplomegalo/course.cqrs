using Delsoft.Course.CQRS.Model.Data;
using Microsoft.EntityFrameworkCore;

namespace Delsoft.Course.CQRS.Data
{
    public class ApiContext : DbContext
    {

        public ApiContext(DbContextOptions<ApiContext> options)
            : base(options)
        {
        }

        public DbSet<Wine> Wines { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Wine>()
                .HasKey(wine => wine.Id);
        }
    }
}