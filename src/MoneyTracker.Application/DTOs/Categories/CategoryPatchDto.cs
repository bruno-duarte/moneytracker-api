namespace MoneyTracker.Application.DTOs.Categories
{
    public class CategoryPatchDto
    {
        /// <summary>
        /// The new category name.  
        /// If omitted, the existing name remains unchanged.
        /// </summary>
        public string? Name { get; set; }
    }
}
