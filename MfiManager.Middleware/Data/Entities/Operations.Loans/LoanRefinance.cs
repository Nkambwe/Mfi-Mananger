using MfiManager.Middleware.Data.Entities.Operations.Reasons;

namespace MfiManager.Middleware.Data.Entities.Operations.Loans {
    /// <summary>
    /// Loan refinance details for a given loan. Loan refinance involves swaping clients existing loan with a new loan
    /// </summary>
    public class LoanRefinance : BaseEntity {
        public string TransactionCode { get; set; }
        public string CurrentLoanNumber { get; set; }
        public DateTime RefinancedOn { get; set; }
        public decimal Amount { get; set; }
        public decimal Fees { get; set; }
        public bool CapitalizeInterest { get; set; }
        public bool CapitalizeCommission { get; set; }
        public bool CapitalizeFees { get; set; }
        public bool CapitalizePenalty { get; set; }
        public string Notes { get; set; }
        public long ReasonId { get; set; }
        public virtual LoanRefinanceReason Reason { get; set; }
        public long? RefinancedIndividualLoanId { get; set; }
        public virtual IndividualLoan RefinancedIndividualLoan { get; set; }
        public long? RefinancedGroupLoanId { get; set; }
        public virtual GroupLoan RefinancedGroupLoan { get; set; }
        public long? RefinancedBusinessLoanId { get; set; }
        public virtual BusinessLoan RefinancedBusinessLoan { get; set; }
    }
}
