using MfiManager.Middleware.Data.Entities.Audits;
using MfiManager.Middleware.Enums;

namespace MfiManager.Middleware.Data.Entities.Operations.Saving {
    /// <summary>
    /// Saving transaction sub-ledger to track savings transactions
    /// </summary>
    public class SavingTransaction : BaseEntity {
        public long AccountId { get; set; }
        public string TransCode { get; set; }
        public DateTime TransactionDate { get; set; }
        public SavingTransactionType TransType { get; set; }
        /// <summary>
        /// Get/Set overdraft number
        /// </summary>
        public string OverdraftNumber { get; set; }
        /// <summary>
        /// Get/Set Standing order number
        /// </summary>
        public string StandingOrder { get; set; }
        public string Particulars { get; set; }
        public decimal Amount { get; set; }
        public decimal Balance { get; set; }
        public DateTime EntryDate { get; set; }
        public string Cashier { get; set; }
        public virtual SavingAccount Account { get; set; }
        public virtual ICollection<MemberSavingTransaction> MemberSavings { get; set; } = [];
        public virtual ICollection<ModifiedSavingTransaction> Modifications { get; set; } = [];
    }
}
