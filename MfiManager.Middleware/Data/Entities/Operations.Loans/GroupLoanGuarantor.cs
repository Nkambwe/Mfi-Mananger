namespace MfiManager.Middleware.Data.Entities.Operations.Loans {
    public class GroupLoanGuarantor {
        public long GuarantorId { get; set; }
        public virtual Guarantor Guarantor { get; set; }
        public long GroupLoanId { get; set; }
        public virtual GroupLoan GroupLoan {get;set; }
    }
}
