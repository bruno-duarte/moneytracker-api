namespace MoneyTracker.Domain.Entities
{
    /// <summary>
    /// Represents a financial transaction category.
    /// </summary>
    public class Category
    {
        /// <summary>
        /// Unique identifier of the category.
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// Name of the category.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// List of transactions associated with this category.
        /// </summary>
        public ICollection<Transaction> Transactions { get; private set; }

        private Category() { }

        /// <summary>
        /// Creates a new category.
        /// </summary>
        /// <param name="id">The category ID. If empty, a new GUID will be generated.</param>
        /// <param name="name">The category name. Must not be empty.</param>
        /// <exception cref="ArgumentException">Thrown when the name is null or whitespace.</exception>
        public Category(Guid id, string name)
        {
            Id = id == Guid.Empty ? Guid.NewGuid() : id;

            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name is required", nameof(name));

            Name = name;
            Transactions = [];
        }

        /// <summary>
        /// Updates the category name.
        /// </summary>
        /// <param name="name">The new name. Must not be empty.</param>
        /// <exception cref="ArgumentException">Thrown when the name is null or whitespace.</exception>
        public void Update(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name is required", nameof(name));

            Name = name;
        }

        /// <summary>
        /// Partially updates the category, applying only provided values.
        /// </summary>
        /// <param name="name">The new name, or null to keep the current one.</param>
        public void Patch(string? name)
        {
            if (name != null)
                Name = name;
        }
    }
}
