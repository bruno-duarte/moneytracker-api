using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

namespace MoneyTracker.Infrastructure.Persistence.PostgreSql
{
    public class PostgreSqlDbContextFactory 
        : IDesignTimeDbContextFactory<PostgreSqlDbContext>
    {
        public PostgreSqlDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true)
                .AddJsonFile("appsettings.Development.json", optional: true)
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<PostgreSqlDbContext>();
            optionsBuilder.UseNpgsql(connectionString);

            return new PostgreSqlDbContext(optionsBuilder.Options);
        }
    }
}
