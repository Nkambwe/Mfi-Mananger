namespace MfiManager.Middleware.Enums {
    /// <summary>
    /// Enumeration of the nature and state of loan
    /// </summary>
    public enum LoanStatus {
        /// <summary>
        /// Loan created but not yet approved
        /// </summary>
        New = 1,
        /// <summary>
        /// Loan has been approved but not yet disbursed 
        /// </summary>
        Approved = 2,
        /// <summary>
        /// Loan approved and disbursed  
        /// </summary>
        Disbursed = 3,
        /// <summary>
        /// Loan in normal progress
        /// </summary>
        Normal = 4,
        /// <summary>
        /// Loan fully paid off 
        /// </summary>
        Cleared = 5,
        /// <summary>
        /// Loan in arrears 
        /// </summary>
        Arrears = 6,
        /// <summary>
        /// Loan in arrears and expired
        /// </summary>
        Expired = 7,
        /// <summary>
        /// Loan written-off as bad debt
        /// </summary>
        Bad = 8,
        /// <summary>
        /// Loan Rejected
        /// </summary>
        Rejected = 9
    }
}
