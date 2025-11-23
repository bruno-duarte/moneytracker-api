namespace MoneyTracker.Domain.Queries
{
    public class BaseQuery
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 50;
    }
}
