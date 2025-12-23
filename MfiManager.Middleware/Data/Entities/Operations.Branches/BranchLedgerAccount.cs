using MfiManager.Middleware.Data.Entities.Accounts;

namespace MfiManager.Middleware.Data.Entities.Operations.Branches {
    public class BranchLedgerAccount : BaseEntity {
        /// <summary>
        /// Get Or Set default ledger number in the company  default chart of accounts
        /// </summary>
        public string DefaultNumber { get; set; }
        /// <summary>
        /// Get Or Set new assigned ledger number for this branch
        /// </summary>
        public string AssignedNumber { get; set; }
        /// <summary>
        /// Get Or Set new assigned ledger label for this branch
        /// </summary>
        public string AssignedLabel { get; set; }
        public bool Suspend { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public long BranchId { get; set; }
        public virtual Branch Branch { get; set; }
        public long LedgerAccountId { get; set; }
        public virtual LedgerAccount LedgerAccount { get; set; }
    }
}
