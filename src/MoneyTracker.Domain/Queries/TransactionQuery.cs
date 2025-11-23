using MoneyTracker.Domain.Enums;

namespace MoneyTracker.Domain.Queries
{
    public class TransactionQuery : BaseQuery
    {
        public TransactionType? Type { get; set; }
        public Guid? CategoryId { get; set; }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
    }
}
