namespace MfiManager.Middleware.Data.Entities.Operations.Loans {
    public class Frozen : BaseEntity {
        public long LoanId { get; set; }
        public DateTime FrozenOn { get; set; }
        public DateTime? PenaltyDate { get; set; }
        public decimal Penalty { get; set; }
        public string Reason { get; set; }
        public virtual LoanRecord Loan { get; set; }
    }
}
