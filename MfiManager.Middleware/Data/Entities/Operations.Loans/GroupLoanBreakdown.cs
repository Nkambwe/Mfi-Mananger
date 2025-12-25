using MfiManager.Middleware.Data.Entities.Customers;

namespace MfiManager.Middleware.Data.Entities.Operations.Loans {
    /// <summary>
    /// Breakdown of group loans per member. Breakdown is done for each group loan
    /// </summary>
    public class GroupLoanBreakdown : BaseEntity {
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
        /// <summary>
        /// Get/Set group member ID
        /// </summary>
        public long MemberId { get; set; }

        public virtual Member Member { get; set; }
        /// <summary>
        /// Get/Set LoanID
        /// </summary>
        public long LoanId { get; set; }
        public virtual LoanRecord Loan { get; set; }
        public long? LoanBreakdownFilter1Id {get;set;}
        public virtual LoanBreakdownFilter1 LoanBreakdownFilter1 { get; set; }
        public long? LoanBreakdownFilter2Id {get;set;}
        public virtual LoanBreakdownFilter2 LoanBreakdownFilter2 { get; set; }
    }
}
