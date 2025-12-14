namespace MfiManager.Middleware.Data.Entities.Operations.Branches {
    public class BranchLedgerAccount : BaseEntity {
        public string Code { get; set; }
        /// <summary>
        /// Get Or Set default ledger number in the company  default chart of accounts
        /// </summary>
        public string DefaultNumber { get; set; }
        /// <summary>
        /// Get Or Set new assigned ledger number for this branch
        /// </summary>
        public string AssignedNumber { get; set; }
        public bool Suspend { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
        public long BranchId { get; set; }
        public virtual Branch Branch { get; set; }
    }
}
