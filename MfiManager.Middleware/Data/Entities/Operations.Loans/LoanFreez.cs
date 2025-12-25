namespace MfiManager.Middleware.Data.Entities.Operations.Loans {
    public class LoanFreez : BaseEntity {
        public DateTime FreezDate { get; set; }
        public DateTime? PenaltyDate { get; set; }
        public decimal Penalty { get; set; }
        public long ReasonId { get; set; }
        public FreeReason Reason { get; set; }
        public long LoanId { get; set; }
        public virtual LoanRecord Loan { get; set; }
    }
}
