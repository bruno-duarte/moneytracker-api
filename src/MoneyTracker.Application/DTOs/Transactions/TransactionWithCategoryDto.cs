using MoneyTracker.Application.DTOs.Categories;
using MoneyTracker.Domain.Enums;

namespace MoneyTracker.Application.DTOs.Transactions
{
    /// <summary>
    /// Represents a transaction with its associated category included.
    /// Useful for detailed views and expanded query results.
    /// </summary>
    public class TransactionWithCategoryDto
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
        /// Type of transaction (income or expense).
        /// </summary>
        public TransactionType Type { get; set; }

        /// <summary>
        /// Category details associated with the transaction.
        /// </summary>
        public CategoryDto? Category { get; set; }

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
