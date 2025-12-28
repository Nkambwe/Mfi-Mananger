using MfiManager.Middleware.Data.Entities.Accounts.Ledgers;
using MfiManager.Middleware.Enums;

namespace MfiManager.Middleware.Data.Entities.Operations.Loans {
    /// <summary>
    /// Loan disbursement record
    /// </summary>
    public class Disbursement : BaseEntity {
        public DateTime DisbursementDate { get; set; }
        public decimal DisbursedAmount { get; set; }
        public DisbursementType DisbursementType { get; set; }
        public string DisbursedBy { get; set; }
        public long? IndividualLoanId { get; set; }
        public virtual IndividualLoan IndividualLoan {get;set; }
        public long? GroupLoanId { get; set; }
        public virtual GroupLoan GroupLoan {get;set; }
        public long? BusinessLoanId { get; set; }
        public virtual BusinessLoan BusinessLoan {get;set; }
        public long TransactionId { get; set; }
        public virtual Ledger Transaction { get; set; }
    }
}
