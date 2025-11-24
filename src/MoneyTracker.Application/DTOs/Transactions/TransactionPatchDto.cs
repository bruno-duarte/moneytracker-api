using MoneyTracker.Domain.Enums;

namespace MoneyTracker.Application.DTOs.Transactions
{
    /// <summary>
    /// Data transfer object used to partially update an existing transaction.
    /// Only provided fields will be modified.
    /// </summary>
    public class TransactionPatchDto
    {
        /// <summary>
        /// Updated transaction amount.  
        /// If <c>null</c>, the current amount remains unchanged.
        /// </summary>
        public decimal? Amount { get; set; }

        /// <summary>
        /// Updated transaction type.  
        /// If <c>null</c>, the current type remains unchanged.
        /// </summary>
        public TransactionType? Type { get; set; }

        /// <summary>
        /// Updated category identifier.  
        /// If <c>null</c>, the current category remains unchanged.
        /// </summary>
        public Guid? CategoryId { get; set; }

        /// <summary>
        /// Updated transaction date.  
        /// If <c>null</c>, the current date remains unchanged.
        /// </summary>
        public DateTime? Date { get; set; }

        /// <summary>
        /// Updated transaction description.  
        /// If <c>null</c>, the current description remains unchanged.
        /// </summary>
        public string? Description { get; set; }
    }
}
