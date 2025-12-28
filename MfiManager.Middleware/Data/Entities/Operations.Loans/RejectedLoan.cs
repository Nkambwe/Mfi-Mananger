using MfiManager.Middleware.Data.Entities.Operations.Reasons;

namespace MfiManager.Middleware.Data.Entities.Operations.Loans {
    /// <summary>
    /// Rejected loan record
    /// </summary>
    public class RejectedLoan : BaseEntity {
        public DateTime RejectDate { get; set; }
        public string RejectedBy { get; set; }
        public string Notes { get; set; }
        public long ReasonId { get; set; }
        public virtual RejectReason Reason { get; set; }
        public long? IndividualLoanId { get; set; }
        public virtual IndividualLoan IndividualLoan {get;set; }
        public long? GroupLoanId { get; set; }
        public virtual GroupLoan GroupLoan {get;set; }
        public long? BusinessLoanId { get; set; }
        public virtual BusinessLoan BusinessLoan {get;set; }
    }

}
