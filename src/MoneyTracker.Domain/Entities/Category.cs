using MoneyTracker.Domain.Enums;

namespace MoneyTracker.Domain.Entities
{
    public class Category
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public CategoryType Type { get; private set; }

        public ICollection<Transaction> Transactions { get; private set; }

        private Category() { }

        public Category(Guid id, string name, CategoryType type, string description)
        {
            Id = id == Guid.Empty ? Guid.NewGuid() : id;

            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name is required", nameof(name));

            Name = name;
            Type = type;
            Description = description;
            Transactions = [];
        }

        public void Update(string name, CategoryType type, string description)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name is required", nameof(name));

            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Description is required", nameof(description));

            Name = name;
            Type = type;
            Description = description;
        }

        public void Patch(string? name, CategoryType? type, string? description)
        {
            if (name != null)
                Name = name;

            if (description != null)
                Description = description;

            if (type.HasValue)
                Type = type.Value;
        }
    }
}
