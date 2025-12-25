namespace MfiManager.Middleware.Data.Entities.Operations.Loans {
    /// <summary>
    /// Loan that temporarily stops making payments due until a later date, due to setbacks on side of borrower.
    /// </summary>
    public class DefferedLoan : BaseEntity {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string ApprovedBy { get; set; }
        public long LoanId { get; set; }
        public virtual LoanRecord Loan { get; set; }
        public long ReasonId { get; set; }
        public virtual DefferReason Reason { get; set; }

    }
}
