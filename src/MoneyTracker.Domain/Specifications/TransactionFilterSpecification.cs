using MoneyTracker.Domain.Entities;
using MoneyTracker.Domain.Queries;

namespace MoneyTracker.Domain.Specifications
{
  public class TransactionFilterSpecification : BaseSpecification<Transaction>
  {
      public TransactionFilterSpecification(TransactionQuery query)
      {
          if (query.Type.HasValue)
              AddCriteria(t => t.Type == query.Type.Value);

          if (query.CategoryId.HasValue)
              AddCriteria(t => t.CategoryId == query.CategoryId);

          if (query.From.HasValue)
              AddCriteria(t => t.Date >= query.From.Value);

          if (query.To.HasValue)
              AddCriteria(t => t.Date <= query.To.Value);
      }
  }
}