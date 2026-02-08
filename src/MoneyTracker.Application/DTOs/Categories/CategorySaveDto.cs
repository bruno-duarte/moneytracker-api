using MoneyTracker.Domain.Enums;

namespace MoneyTracker.Application.DTOs.Categories
{
  /// <summary>
  /// DTO used to create or update a category.
  /// </summary>
  /// <param name="Name">Name of the category.</param>
	/// <param name="Type">Type of category (income, expense or both).</param>
  /// <param name="Description">Description of the category.</param>
  public record CategorySaveDto(string Name, CategoryType Type, string Description);
}