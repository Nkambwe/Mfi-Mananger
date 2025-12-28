
namespace MfiManager.Middleware.Data.Entities.Operations.Loans {
    /// <summary>
    /// Breakdown of group loans per member. Breakdown is done for each group loan
    /// </summary>
    public class GroupLoanBreakdown : BaseEntity {
        /// <summary>
        /// Get/Set Loan number
        /// </summary>
        public string LoanNumber { get; set; }
        /// <summary>
        /// Get/Set loanable amount
        /// </summary>
        public decimal LoanAmount { get; set; }
        /// <summary>
        /// Get/Set amount of interest payable per member
        /// </summary>
        public decimal LoanInterest { get; set; }
        /// <summary>
        /// Get/Set percentage to be saved per installment
        /// </summary>
        public decimal PercentageSaved { get; set; }
        /// <summary>
        /// Get/Set fixed amount to be saved per installment if percentage based
        /// </summary>
        public decimal AmountSaved { get; set; }

        public long? LoanBreakdownFilter1Id {get;set;}
        public virtual LoanBreakdownFilter1 LoanBreakdownFilter1 { get; set; }
        public long? LoanBreakdownFilter2Id {get;set;}
        public virtual LoanBreakdownFilter2 LoanBreakdownFilter2 { get; set; }
        public virtual ICollection<MemberAccountBreakdown> MemberAccounts { get; set; } = [];
    }
}
