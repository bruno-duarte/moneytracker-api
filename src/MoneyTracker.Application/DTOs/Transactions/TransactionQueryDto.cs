using MoneyTracker.Domain.Enums;

namespace MoneyTracker.Application.DTOs.Transactions
{
    /// <summary>
    /// Query parameters used to filter and search transactions.
    /// Supports pagination through <see cref="BaseQueryDto"/>.
    /// </summary>
    public class TransactionQueryDto : BaseQueryDto
    {
        /// <summary>
        /// Optional transaction type filter.
        /// </summary>
        public TransactionType? Type { get; set; }

        /// <summary>
        /// Optional category filter.  
        /// Returns only transactions that belong to the specified category.
        /// </summary>
        public Guid? CategoryId { get; set; }

        /// <summary>
        /// Optional start date filter.  
        /// Returns transactions occurring on or after this date.
        /// </summary>
        public DateTime? From { get; set; }

        /// <summary>
        /// Optional end date filter.  
        /// Returns transactions occurring on or before this date.
        /// </summary>
        public DateTime? To { get; set; }
    }
}
