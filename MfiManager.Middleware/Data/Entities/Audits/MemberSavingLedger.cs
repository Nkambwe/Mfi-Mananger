using MfiManager.Middleware.Data.Entities.Operations.Saving;
using MfiManager.Middleware.Enums;

namespace MfiManager.Middleware.Data.Entities.Audits {
    /// <summary>
    /// Savings transactions ledger to track breakdown for group member savings
    /// </summary>
    public class MemberSavingLedger : BaseEntity {
        public string TransactionCode { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Group { get; set; }
        public string Member { get; set; }
        public SavingTransactionType TransType { get; set; }
        public decimal TransAmount { get; set; }
        public decimal AccountBalance { get; set; }
        public DateTime EntryDate { get; set; }
        public string EnteredBy { get; set; }
        public string Notes { get; set; }
        public long TransactionId { get; set; }
        public virtual SavingLedger SavingTransaction { get; set; }

    }
}
