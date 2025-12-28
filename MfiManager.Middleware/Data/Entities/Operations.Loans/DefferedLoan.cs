using MfiManager.Middleware.Data.Entities.Accounts.Ledgers;
using MfiManager.Middleware.Data.Entities.Operations.Reasons;

namespace MfiManager.Middleware.Data.Entities.Operations.Loans {
    /// <summary>
    /// Loan that temporarily stops making payments due until a later date, due to setbacks on side of borrower.
    /// </summary>
    public class DefferedLoan : BaseEntity {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string ApprovedBy { get; set; }
        public long? IndividualLoanId { get; set; }
        public virtual IndividualLoan IndividualLoan {get;set; }
        public long? GroupLoanId { get; set; }
        public virtual GroupLoan GroupLoan {get;set; }
        public long? BusinessLoanId { get; set; }
        public virtual BusinessLoan BusinessLoan {get;set; }
        public long TransactionId { get; set; }
        public virtual Ledger Transaction { get; set; }
        public long ReasonId { get; set; }
        public virtual DefferReason Reason { get; set; }

    }
}
