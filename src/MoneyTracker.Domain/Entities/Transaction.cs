using MoneyTracker.Domain.Enums;

namespace MoneyTracker.Domain.Entities
{
    public class Transaction
    {
        public Guid Id { get; private set; }
        public decimal Amount { get; private set; }
        public TransactionType Type { get; private set; }
        public string CategoryId { get; private set; } = string.Empty;
        public DateTime Date { get; private set; }
        public string? Description { get; private set; }

        // For EF
        private Transaction() { }

        public Transaction(Guid id, decimal amount, TransactionType type, string categoryId, DateTime date, string? description)
        {
            Id = id == Guid.Empty ? Guid.NewGuid() : id;
            if (amount <= 0) throw new ArgumentException("Amount must be greater than zero", nameof(amount));
            Amount = amount;
            Type = type;
            if (string.IsNullOrWhiteSpace(categoryId)) throw new ArgumentException("CategoryId is required", nameof(categoryId));
            CategoryId = categoryId;
            Date = date;
            Description = description;
        }

        public void Update(decimal amount, TransactionType type, string categoryId, DateTime date, string? description)
        {
            if (amount <= 0) throw new ArgumentException("Amount must be greater than zero", nameof(amount));
            Amount = amount;
            Type = type;
            if (string.IsNullOrWhiteSpace(categoryId)) throw new ArgumentException("CategoryId is required", nameof(categoryId));
            CategoryId = categoryId;
            Date = date;
            Description = description;
        }
    }
}
