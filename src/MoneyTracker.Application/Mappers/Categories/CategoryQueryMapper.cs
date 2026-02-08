using MoneyTracker.Application.DTOs.Categories;
using MoneyTracker.Domain.Queries;

namespace MoneyTracker.Application.Mappers
{
  public static class CategoryQueryMapper
  {
      public static CategoryQuery ToQuery(this CategoryQueryDto dto)
      {
          return new CategoryQuery
          {
              Name = dto.Name,
              Description = dto.Description,
              PageNumber = dto.PageNumber,
              PageSize = dto.PageSize
          };
      }
  }
}