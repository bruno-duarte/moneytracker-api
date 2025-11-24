using MoneyTracker.Domain.Enums;

namespace MoneyTracker.Domain.Entities
{
    /// <summary>
    /// Represents a financial transaction within the MoneyTracker domain.
    /// A transaction may be an income or an expense, must belong to a category,
    /// and contains metadata such as date, amount, and description.
    /// </summary>
    public class Transaction
    {
        /// <summary>
        /// Unique identifier of the transaction.
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// Monetary value of the transaction.
        /// Must be greater than zero.
        /// </summary>
        public decimal Amount { get; private set; }

        /// <summary>
        /// Specifies whether the transaction is an income or an expense.
        /// </summary>
        public TransactionType Type { get; private set; }

        /// <summary>
        /// Identifier of the category associated with this transaction.
        /// Must not be an empty <see cref="Guid"/>.
        /// </summary>
        public Guid CategoryId { get; private set; }

        /// <summary>
        /// Navigation property for the category to which the transaction belongs.
        /// </summary>
        public Category? Category { get; private set; }

        /// <summary>
        /// Date on which the transaction occurred.
        /// </summary>
        public DateTime Date { get; private set; }

        /// <summary>
        /// Optional descriptive text that provides more details about the transaction.
        /// </summary>
        public string? Description { get; private set; }

        #pragma warning disable CS8618
        /// <summary>
        /// EF Core private constructor.  
        /// Used only for ORM materialization.
        /// </summary>
        private Transaction() { }
        #pragma warning restore CS8618

        /// <summary>
        /// Creates a new <see cref="Transaction"/> instance with validation.
        /// </summary>
        /// <param name="id">Unique identifier. If empty, a new GUID is automatically generated.</param>
        /// <param name="amount">Transaction amount. Must be greater than zero.</param>
        /// <param name="type">Transaction type (income or expense).</param>
        /// <param name="categoryId">Identifier of the associated category. Must not be empty.</param>
        /// <param name="date">Date on which the transaction occurred.</param>
        /// <param name="description">Optional description of the transaction.</param>
        /// <exception cref="ArgumentException">Thrown when <paramref name="amount"/> or <paramref name="categoryId"/> are invalid.</exception>
        public Transaction(
            Guid id,
            decimal amount,
            TransactionType type,
            Guid categoryId,
            DateTime date,
            string? description)
        {
            Id = id == Guid.Empty ? Guid.NewGuid() : id;

            if (amount <= 0)
                throw new ArgumentException("Amount must be greater than zero", nameof(amount));

            if (categoryId == Guid.Empty)
                throw new ArgumentException("CategoryId is required", nameof(categoryId));

            Amount = amount;
            Type = type;
            CategoryId = categoryId;
            Date = date;
            Description = description;
        }

        /// <summary>
        /// Replaces all modifiable fields of the transaction with new validated values.
        /// </summary>
        /// <param name="amount">New transaction amount. Must be greater than zero.</param>
        /// <param name="type">New transaction type.</param>
        /// <param name="categoryId">New category identifier. Must not be empty.</param>
        /// <param name="date">New transaction date.</param>
        /// <param name="description">New transaction description.</param>
        /// <exception cref="ArgumentException">Thrown when <paramref name="amount"/> or <paramref name="categoryId"/> are invalid.</exception>
        public void Update(
            decimal amount,
            TransactionType type,
            Guid categoryId,
            DateTime date,
            string? description)
        {
            if (amount <= 0)
                throw new ArgumentException("Amount must be greater than zero", nameof(amount));

            if (categoryId == Guid.Empty)
                throw new ArgumentException("CategoryId is required", nameof(categoryId));

            Amount = amount;
            Type = type;
            CategoryId = categoryId;
            Date = date;
            Description = description;
        }

        /// <summary>
        /// Partially updates the transaction with the provided values.
        /// Only properties with non-null values are modified.
        /// Validation applies only to updated fields.
        /// </summary>
        /// <param name="amount">Optional new amount. Must be greater than zero if provided.</param>
        /// <param name="type">Optional new transaction type.</param>
        /// <param name="categoryId">Optional new category identifier. Must not be empty if provided.</param>
        /// <param name="date">Optional new date.</param>
        /// <param name="description">Optional new description.</param>
        /// <exception cref="ArgumentException">Thrown when <paramref name="amount"/> is invalid or <paramref name="categoryId"/> is empty.</exception>
        public void Patch(
            decimal? amount,
            TransactionType? type,
            Guid? categoryId,
            DateTime? date,
            string? description)
        {
            if (amount.HasValue)
            {
                if (amount.Value <= 0)
                    throw new ArgumentException("Amount must be greater than zero", nameof(amount));

                Amount = amount.Value;
            }

            if (type.HasValue)
                Type = type.Value;

            if (categoryId.HasValue)
            {
                if (categoryId.Value == Guid.Empty)
                    throw new ArgumentException("CategoryId is required", nameof(categoryId));

                CategoryId = categoryId.Value;
            }

            if (date.HasValue)
                Date = date.Value;

            if (description != null)
                Description = description;
        }
    }
}
