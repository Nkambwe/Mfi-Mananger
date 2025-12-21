namespace MfiManager.Middleware.Data.Entities.Operations.Loans {
    public class LoanGuarantor {
        public long GuarantorId { get; set; }
        public long LoanId { get; set; }
        public virtual Guarantor Guarantor { get; set; }
        public virtual LoanRecord Loan { get; set; }
    }

}
