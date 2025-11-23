using System.Linq.Expressions;

namespace MoneyTracker.Domain.Interfaces.Repositories
{
  public interface IRepository<T> where T : class
  {
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task<bool> DeleteAsync(Guid id);
    Task<T?> GetByIdAsync(Guid id);
    Task<IEnumerable<T>> ListAsync();
    Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
  }
}
