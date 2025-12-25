namespace MfiManager.Middleware.Data.Entities.Operations.Loans {
    /// <summary>
    /// Provision for loss on bad and debtful loans
    /// </summary>
    public class LoanLossProvision : BaseEntity {
        public DateTime ProvisionedOn { get; set; }
        public decimal Percentage { get; set; }
        public decimal Amount { get; set; }
        public long LoanId { get; set; }
        public virtual LoanRecord Loan { get; set; }

    }
}
