using MoneyTracker.Domain.Enums;

namespace MoneyTracker.Application.DTOs.Transactions
{
    /// <summary>
    /// Data transfer object that represents a financial transaction.
    /// </summary>
    public class TransactionDto
    {
        /// <summary>
        /// Unique identifier of the transaction.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Monetary value of the transaction.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Type of transaction (e.g., income or expense).
        /// </summary>
        public TransactionType Type { get; set; }

        /// <summary>
        /// Identifier of the associated category.
        /// </summary>
        public Guid CategoryId { get; set; }

        /// <summary>
        /// Date when the transaction occurred.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Optional description or note about the transaction.
        /// </summary>
        public string? Description { get; set; }
    }
}
