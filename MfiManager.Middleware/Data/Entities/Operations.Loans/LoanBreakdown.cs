namespace MfiManager.Middleware.Data.Entities.Operations.Loans {
    /// <summary>
    /// Breakdown of group loans per member
    /// </summary>
    public class LoanBreakdown : BaseEntity {
        public long LoanId { get; set; }
        /// <summary>
        /// Get/Set group member code
        /// </summary>
        public string Member { get; set; }
        /// <summary>
        /// Get/Set loanable amount
        /// </summary>
        public decimal MemberAmount { get; set; }
        /// <summary>
        /// Get/Set amount of interest payable per member
        /// </summary>
        public decimal MemberInterest { get; set; }
        /// <summary>
        /// Get/Set percentage to be saved per installment
        /// </summary>
        public decimal PercentageSaved { get; set; }
        /// <summary>
        /// Get/Set fixed amount to be saved per installment if percentage based
        /// </summary>
        public decimal FlatAmountSaved { get; set; }
        public virtual LoanRecord Loan { get; set; }
        public virtual LoanCustomeProperty5 Property5 { get; set; }
        public virtual LoanCustomeProperty6 Property6 { get; set; }
    }
}
