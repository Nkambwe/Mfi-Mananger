namespace MfiManager.Middleware.Data.Entities.Operations.Loans {
    /// <summary>
    /// Loan refinance details for a given loan. Loan refinance involves swaping clients existing loan with a new loan
    /// </summary>
    public class LoanRefinance : BaseEntity {
        public DateTime RefinancedOn { get; set; }
        public string TransactionId { get; set; }
        public string OldLoan { get; set; }
        public string NewLoan { get; set; }
        public decimal Fees { get; set; }
        public decimal Amount { get; set; }
        public string Reason { get; set; }
        public bool CapitalizeInterest { get; set; }
        public bool CapitalizeCommission { get; set; }
        public bool CapitalizeFees { get; set; }
        public bool CapitalizePenalty { get; set; }
        public string Notes { get; set; }
        public virtual LoanRecord Loan { get; set; }
    }
}
