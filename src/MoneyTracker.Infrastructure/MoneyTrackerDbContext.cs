using Microsoft.EntityFrameworkCore;
using MoneyTracker.Domain.Entities;

namespace MoneyTracker.Infrastructure
{
    public class MoneyTrackerDbContext(DbContextOptions<MoneyTrackerDbContext> options) : DbContext(options)
    {
        public DbSet<Transaction> Transactions => Set<Transaction>();
        public DbSet<Category> Categories => Set<Category>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MoneyTrackerDbContext).Assembly);
        }
    }
}
