using Microsoft.EntityFrameworkCore;
using MoneyTracker.Domain.Interfaces.Repositories;
using System.Linq.Expressions;

namespace MoneyTracker.Infrastructure.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        protected readonly MoneyTrackerDbContext _db;
        protected readonly DbSet<T> _set;

        public BaseRepository(MoneyTrackerDbContext db)
        {
            _db = db;
            _set = _db.Set<T>();
        }

        public virtual async Task AddAsync(T entity)
        {
            await _set.AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public virtual async Task UpdateAsync(T entity)
        {
            _set.Update(entity);
            await _db.SaveChangesAsync();
        }

        public virtual async Task<bool> DeleteAsync(Guid id)
        {
            var entity = await _set.FindAsync(id);
            if (entity != null)
            {
                _set.Remove(entity);
                await _db.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public virtual async Task<T?> GetByIdAsync(Guid id)
        {
            return await _set.FindAsync(id);
        }

        public virtual async Task<IEnumerable<T>> ListAsync()
        {
            return await _set.AsNoTracking().ToListAsync();
        }

        public virtual async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _set.AsNoTracking().Where(predicate).ToListAsync();
        }
    }
}
