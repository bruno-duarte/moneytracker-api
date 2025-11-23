using MoneyTracker.Domain.Entities;
using MoneyTracker.Domain.Interfaces.Repositories;

namespace MoneyTracker.Infrastructure.Repositories
{
    public class CategoryRepository(MoneyTrackerDbContext db) : BaseRepository<Category>(db), ICategoryRepository
    {
        public async Task<Category?> GetByNameAsync(string name)
        {
            var list = await FindAsync(c => c.Name == name);
            return list.FirstOrDefault();
        }
    }
}
