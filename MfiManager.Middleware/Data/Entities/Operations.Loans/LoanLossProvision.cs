namespace MfiManager.Middleware.Data.Entities.Operations.Loans {
    /// <summary>
    /// Provision for loss on bad and debtful loans
    /// </summary>
    public class LoanLossProvision : BaseEntity {
        public DateTime ProvisionedOn { get; set; }
        public decimal Percentage { get; set; }
        public decimal Amount { get; set; }
        public long? IndividualLoanId { get; set; }
        public virtual IndividualLoan IndividualLoan {get;set; }
        public long? GroupLoanId { get; set; }
        public virtual GroupLoan GroupLoan {get;set; }
        public long? BusinessLoanId { get; set; }
        public virtual BusinessLoan BusinessLoan {get;set; }

    }
}
