using MoneyTracker.Application.DTOs.Categories;
using MoneyTracker.Domain.Entities;

namespace MoneyTracker.Application.Mappers
{
  public static class CategoryMapper
  {
      public static CategoryDto ToDto(this Category c)
      {
        return new CategoryDto
        {
            Id = c.Id,
            Name = c.Name,
            Description = c.Description,
            Type = c.Type.ToString()
        };
      }
  }
}