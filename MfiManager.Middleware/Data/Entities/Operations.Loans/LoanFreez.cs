using MfiManager.Middleware.Data.Entities.Operations.Reasons;

namespace MfiManager.Middleware.Data.Entities.Operations.Loans {
    public class LoanFreez : BaseEntity {
        public DateTime FreezDate { get; set; }
        public DateTime? PenaltyDate { get; set; }
        public decimal Penalty { get; set; }
        public long ReasonId { get; set; }
        public LoanFreezeReason Reason { get; set; }
        public long? IndividualLoanId { get; set; }
        public virtual IndividualLoan IndividualLoan {get;set; }
        public long? GroupLoanId { get; set; }
        public virtual GroupLoan GroupLoan {get;set; }
        public long? BusinessLoanId { get; set; }
        public virtual BusinessLoan BusinessLoan {get;set; }
    }
}
