namespace MfiManager.Middleware.Enums {
    public enum Classification {
        /// <summary>
        /// Classified loan category unknown
        /// </summary>
        Undefined = 0,
        /// <summary>
        /// Not adequately protected loan by the the borrower's current worth, capacity to pay or collateral
        /// </summary>
        Substandard = 1,
        /// <summary>
        /// Loan is substandard and has a high risk of collectability
        /// </summary>
        Doubtful = 2,
        /// <summary>
        /// Loan that cannot be collected at all and can be written off
        /// </summary>
        Loss = 3,
    }
}
