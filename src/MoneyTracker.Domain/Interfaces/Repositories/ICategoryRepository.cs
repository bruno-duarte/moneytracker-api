using MoneyTracker.Domain.Common;
using MoneyTracker.Domain.Entities;

namespace MoneyTracker.Domain.Interfaces.Repositories
{
    public interface ICategoryRepository
    {
        Task AddAsync(Category category);
        Task UpdateAsync(Category category);
        Task<bool> DeleteAsync(Guid id);
        Task<Category?> GetByIdAsync(Guid id);
        Task<PagedResult<Category>> ListAsync(ISpecification<Category> spec, int pageNumber, int pageSize);
    }
}
