namespace MfiManager.Middleware.Data.Entities.Operations.Loans {
    /// <summary>
    /// Loan application notes for a given loan. Each loan will have 3 provisions on the entry form
    /// </summary>
    public class ApplicationNotes : BaseEntity {
        public long LoanId { get; set; }
        public string Notes { get; set; }
        public virtual LoanRecord Loan { get; set; }
    }
}
