namespace MoneyTracker.Domain.Events
{
    public class TransactionCreatedEvent
    {
        public Guid TransactionId { get; init; }
        public decimal Amount { get; init; }
        public string Type { get; init; } = string.Empty;
        public Guid CategoryId { get; init; }
        public DateTime CreatedAt { get; init; }
    }
}
