namespace MoneyTracker.Domain.Enums
{
    /// <summary>
    /// Defines the type of a financial transaction within the system.
    /// </summary>
    public enum TransactionType
    {
        /// <summary>
        /// Represents a money outflow.  
        /// Use this value for transactions where funds are spent or deducted.
        /// </summary>
        Expense = 0,

        /// <summary>
        /// Represents a money inflow.  
        /// Use this value for transactions where funds are received or added.
        /// </summary>
        Income = 1
    }
}
