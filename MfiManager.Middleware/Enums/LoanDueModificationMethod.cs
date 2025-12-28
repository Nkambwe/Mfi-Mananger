
namespace MfiManager.Middleware.Enums {
    /// <summary>
    /// Due dates modification methods
    /// </summary>
    /// <remarks>
    /// Loan due modifications are changes to existing loan terms to hwlp borrowers
    /// avoid default. They involve reducing monthly payments through interest rate adjustments, 
    /// term extensions, or principal reduction
    /// </remarks>
    public enum LoanDueModificationMethod {
        None = 0,
        /// <summary>
        /// Lower interest rate to reduce monthly payment
        /// </summary>
        InterestRateReduction = 1,
        /// <summary>
        /// Lengthen repayment period to lower monthly obligation
        /// </summary>
        ExtendLoanTerm = 2,
        /// <summary>
        /// Change variable or adjustable interest rate to fixed rate
        /// to prevent future payment hikes
        /// </summary>
        ConvertInterestRate =3,
        /// <summary>
        /// Add past-due repayments (Interest+fees) back to principal
        /// loan balance, requires recalculation
        /// </summary>
        CapitalizeArrears = 4
    }
}
