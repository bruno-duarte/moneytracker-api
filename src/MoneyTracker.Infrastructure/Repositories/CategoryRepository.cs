using Microsoft.EntityFrameworkCore;
using MoneyTracker.Domain.Common;
using MoneyTracker.Domain.Entities;
using MoneyTracker.Domain.Interfaces;
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

        public async Task<PagedResult<Category>> ListAsync(ISpecification<Category> spec, int pageNumber, int pageSize)
        {
            var query = _set.AsNoTracking().Where(spec.Criteria);

            var totalCount = await query.CountAsync();

            var items = await query
                .OrderBy(t => t.Name)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PagedResult<Category>(items, pageNumber, pageSize, totalCount);
        }
    }
}
