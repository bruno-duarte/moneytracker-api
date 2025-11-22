using MoneyTracker.Domain.Enums;

namespace MoneyTracker.Application.DTOs
{
    public class TransactionQueryDto
    {
        public TransactionType? Type { get; set; }
        public string? CategoryId { get; set; }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 50;
    }
}
