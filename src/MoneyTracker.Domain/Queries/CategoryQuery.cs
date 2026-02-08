namespace MoneyTracker.Domain.Queries
{
    public class CategoryQuery : BaseQuery
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
