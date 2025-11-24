namespace MoneyTracker.Application.DTOs.Categories
{
    /// <summary>
    /// Query parameters used to filter categories in search operations.
    /// </summary>
    public class CategoryQueryDto : BaseQueryDto
    {
        /// <summary>
        /// Optional category name filter.  
        /// Returns categories whose names match or contain the provided value.
        /// </summary>
        public string? Name { get; set; }
    }
}
