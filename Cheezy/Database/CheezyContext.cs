
using Cheezy.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Cheezy.Database
{
    public class CheezyContext : DbContext
    {
        public CheezyContext(DbContextOptions<CheezyContext> options) : base(options)
        {
        }

        public DbSet<Cheese> Cheese { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cheese>().ToTable("Cheese");
        }
    }
}
