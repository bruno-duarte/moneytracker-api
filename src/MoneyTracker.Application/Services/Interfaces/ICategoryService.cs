using MoneyTracker.Application.DTOs.Categories;
using MoneyTracker.Domain.Common;

namespace MoneyTracker.Application.Services.Interfaces
{
  public interface ICategoryService
  {
    Task<CategoryDto> CreateAsync(string name);
    Task<CategoryDto> UpdateAsync(Guid id, string name);
    Task<bool> DeleteAsync(Guid id);
    Task<CategoryDto?> GetByIdAsync(Guid id);
    Task<PagedResult<CategoryDto>> ListAsync(CategoryQueryDto dto);
    Task<CategoryDto> PatchAsync(Guid id, CategoryPatchDto dto);
  }
}