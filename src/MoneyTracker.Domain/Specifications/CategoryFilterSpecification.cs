using MoneyTracker.Domain.Entities;
using MoneyTracker.Domain.Queries;

namespace MoneyTracker.Domain.Specifications
{
  public class CategoryFilterSpecification : BaseSpecification<Category>
  {
      public CategoryFilterSpecification(CategoryQuery query)
      {
          if (!string.IsNullOrEmpty(query.Name))
              AddCriteria(c => c.Name.Contains(query.Name));
      }
  }
}