namespace MfiManager.Middleware.Data.Entities.Operations.Loans {
    public class LoanDue : DueBase {
        public DateTime DueDate { get; set; }
        public long LoanId { get; set; }
        public virtual LoanRecord Loan { get; set; }
    }
}
