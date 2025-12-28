namespace MfiManager.Middleware.Data.Entities.Operations.Loans {
    public class BusinessLoanGuarantor {
        public long GuarantorId { get; set; }
        public virtual Guarantor Guarantor { get; set; }
        public long BusinessLoanId { get; set; }
        public virtual BusinessLoan BusinessLoan {get;set; }
    }
}
