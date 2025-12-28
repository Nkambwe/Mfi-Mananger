namespace MfiManager.Middleware.Data.Entities.Operations.Loans {
    public class IndividualLoanGuarantor {
        public long GuarantorId { get; set; }
        public virtual Guarantor Guarantor { get; set; }
        public long IndividualLoanId { get; set; }
        public virtual IndividualLoan IndividualLoan {get;set; }
    }
}
