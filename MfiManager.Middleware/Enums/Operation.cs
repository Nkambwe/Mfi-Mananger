namespace MfiManager.Middleware.Enums {
    /// <summary>
    /// Nature of transactions operations that are conducted on a bank account
    /// </summary>
    public enum Operation {
        /// <summary>
        /// Active for all transactions
        /// </summary>
        All = 0,
        /// <summary>
        /// Checking transactions only
        /// </summary>
        Checking = 1,
        /// <summary>
        /// Savings and reserve account
        /// </summary>
        Reserve = 2,
        /// <summary>
        /// General business operations only
        /// </summary>
        Operations = 3
    }
}
