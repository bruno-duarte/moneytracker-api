namespace MoneyTracker.Domain.Entities
{
    public class Person
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public DateOnly BirthDate { get; private set; }

        public ICollection<Transaction> Transactions { get; private set; }

        private Person() { }

        public Person(Guid id, string name, DateOnly birthDate)
        {
            Id = id == Guid.Empty ? Guid.NewGuid() : id;

            if (string.IsNullOrWhiteSpace(name) || name.Length > 200)
                throw new ArgumentException("Invalid name");

            if (birthDate > DateOnly.FromDateTime(DateTime.UtcNow))
                throw new ArgumentException("Invalid birth date");

            Name = name;
            BirthDate = birthDate;
            Transactions = [];
        }

        public void Update(string name, DateOnly birthDate)
        {
            if (string.IsNullOrWhiteSpace(name) || name.Length > 200)
                throw new ArgumentException("Invalid name");

            if (birthDate > DateOnly.FromDateTime(DateTime.UtcNow))
                throw new ArgumentException("Invalid birth date");

            Name = name;
            BirthDate = birthDate;
        }

        public void Patch(string? name, DateOnly? birthDate)
        {
            if (!string.IsNullOrWhiteSpace(name) && name.Length <= 200)
                Name = name;

            if (birthDate.HasValue && birthDate.Value <= DateOnly.FromDateTime(DateTime.UtcNow))
                BirthDate = birthDate.Value;
        }
    }
}