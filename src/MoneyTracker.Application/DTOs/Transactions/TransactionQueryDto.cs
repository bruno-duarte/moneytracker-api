using MoneyTracker.Domain.Enums;

namespace MoneyTracker.Application.DTOs.Transactions
{
    public class TransactionQueryDto
    {
        public TransactionType? Type { get; set; }
        public Guid? CategoryId { get; set; }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 50;
    }
}
