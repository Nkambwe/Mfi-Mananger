namespace MfiManager.Middleware.Data.Entities.Operations.Loans {
    public class LoanDue : DueBase {
        public long LoanId { get; set; }
        public virtual LoanRecord Loan { get; set; }
    }
}
