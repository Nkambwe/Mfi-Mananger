namespace MfiManager.Middleware.Data.Entities.Operations.Loans {
    /// <summary>
    /// Loan application and approved amounts for a given loan
    /// </summary>
    public class LoanApprovedAmount : BaseEntity {
        public decimal AppliedForAmount { get; set; }
        /// <summary>
        /// Get or Set approval stage. Use <see cref="ApprovalStage"/> enum
        /// </summary>
        public string ApprovalStage { get; set; }
        public decimal AmountApproved { get; set; }
        public string Notes {get;set; }
        public long? IndividualLoanId { get; set; }
        public virtual IndividualLoan IndividualLoan {get;set; }
        public long? GroupLoanId { get; set; }
        public virtual GroupLoan GroupLoan {get;set; }
        public long? BusinessLoanId { get; set; }
        public virtual BusinessLoan BusinessLoan {get;set; }
    }
}
