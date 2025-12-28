using MfiManager.Middleware.Data.Entities.Operations.Reasons;

namespace MfiManager.Middleware.Data.Entities.Operations.Loans {
    public class WittenOffLoan : BaseEntity {
        public DateTime WriteOffOn { get; set; }
        public decimal WrittenoffAmount { get; set; }
        public string WittenOffBy { get; set; }
        public string Notes { get; set; }
        public long? IndividualLoanId { get; set; }
        public long? BusinessLoanId { get; set; }
        public long? GroupLoanId { get; set; }
        public long ReasonId { get; set; }
        public virtual WriteOffReason Reason { get; set; }
        public virtual IndividualLoan IndividualLoan { get; set; }
        public virtual BusinessLoan BusinessLoan { get; set; }
        public virtual GroupLoan GroupLoan { get; set; }
    }
}
