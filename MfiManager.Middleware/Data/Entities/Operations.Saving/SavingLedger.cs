using MfiManager.Middleware.Data.Entities.Audits;
using MfiManager.Middleware.Enums;

namespace MfiManager.Middleware.Data.Entities.Operations.Saving {
    /// <summary>
    /// Saving transaction sub-ledger to track savings transactions
    /// </summary>
    public class SavingLedger : BaseEntity {
        public string TransactionCode { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Particulars { get; set; }
        public string Folio { get; set; }
        public SavingTransactionType TransType { get; set; }
        /// <summary>
        /// Get/Set overdraft number
        /// </summary>
        public string OverdraftNumber { get; set; }
        /// <summary>
        /// Get/Set Standing order number
        /// </summary>
        public string StandingOrder { get; set; }
        public decimal TransAmount { get; set; }
        public decimal AccountBalance { get; set; }
        public DateTime EntryDate { get; set; }
        public string Cashier { get; set; }
        public long SavingAccountId { get; set; }
        public string Notes { get; set; }
        public virtual SavingAccount SavingAccount { get; set; }
        public virtual ICollection<MemberSavingLedger> MemberSavingBreakdowns { get; set; } = [];
        public virtual ICollection<ModifiedSavingLedger> TransactionModifications { get; set; } = [];
    }
}
