namespace MfiManager.Middleware.Data.Entities.Operations.Loans {
    /// <summary>
    /// Loan that temporarily stops making payments due until a later date to setbacks on side of borrower.
    /// </summary>
    public class DefferedLoan : BaseEntity {
        public long LoanId { get; set; }
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }
        public long ReasonId { get; set; }
        public virtual LoanRecord Loan { get; set; }
        public virtual DefferReason Reason { get; set; }

    }
}
