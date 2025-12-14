namespace MfiManager.Middleware.Enums {
    /// <summary>
    /// Overdraft status
    /// </summary>
    public enum OverdraftStatus {
        /// <summary>
        /// Pending Approval
        /// </summary>
        Pending = 0,
        /// <summary>
        /// Overdraft Approved
        /// </summary>
        Approved = 1,
        /// <summary>
        /// Overdraft Rejected
        /// </summary>
        Rejected = 2,
        /// <summary>
        /// Overdraft settled
        /// </summary>
        Settled = 3
    }
}
