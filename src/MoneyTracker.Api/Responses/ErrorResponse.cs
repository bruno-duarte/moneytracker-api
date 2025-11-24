namespace MoneyTracker.Api.Responses
{
    /// <summary>
    /// Represents a formatted error response returned by the API.
    /// Follows the structure of RFC 7807 (Problem Details) with optional validation error details.
    /// </summary>
    public class ErrorResponse(int statusCode, string? title = null, string? detail = null)
    {
        /// <summary>
        /// The HTTP status code associated with the error.
        /// </summary>
        public int StatusCode { get; set; } = statusCode;

        /// <summary>
        /// A short, human-readable summary of the problem.
        /// </summary>
        public string? Title { get; set; } = title;

        /// <summary>
        /// A detailed description of the error, intended to help diagnose the problem.
        /// </summary>
        public string? Detail { get; set; } = detail;

        /// <summary>
        /// A unique identifier for this specific occurrence of the error.  
        /// Useful for correlation and logging.
        /// </summary>
        public string? Instance { get; set; }

        /// <summary>
        /// A collection of validation errors.  
        /// Each key represents a field, and each value is an array of validation messages for that field.
        /// </summary>
        public IDictionary<string, string[]>? Errors { get; set; }
    }
}
