using MoneyTracker.Domain.Enums;

namespace MoneyTracker.Application.DTOs.Transactions
{
    public class TransactionQueryDto : BaseQueryDto
    {
        public TransactionType? Type { get; set; }
        public Guid? CategoryId { get; set; }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
    }
}
