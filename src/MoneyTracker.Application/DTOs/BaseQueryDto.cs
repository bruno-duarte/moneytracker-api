namespace MoneyTracker.Application.DTOs
{
    /// <summary>
    /// Base class for pagination and query parameters used in API search endpoints.
    /// </summary>
    public class BaseQueryDto
    {
        /// <summary>
        /// The page number to retrieve.  
        /// Default is <c>1</c>.
        /// </summary>
        public int PageNumber { get; set; } = 1;

        /// <summary>
        /// The number of items to return per page.  
        /// Default is <c>50</c>.
        /// </summary>
        public int PageSize { get; set; } = 50;
    }
}
