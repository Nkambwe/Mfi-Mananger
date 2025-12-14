namespace MfiManager.Middleware.Data.Entities.Operations.Loans {
    /// <summary>
    /// Dues generated at disbursement
    /// </summary>
    public class AmortizedDue : DueBase {
        public long LoanId { get; set; }
        public virtual LoanRecord Loan { get; set; }
    }
}
