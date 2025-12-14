using MfiManager.Middleware.Data.Entities.Operations.Saving;
using MfiManager.Middleware.Enums;

namespace MfiManager.Middleware.Data.Entities.Audits {
    /// <summary>
    /// Savings transactions ledger to track breakdown for group member savings
    /// </summary>
    public class MemberSavingTransaction : BaseEntity {
        public long SavingTransactionId { get; set; }
        public string Group { get; set; }
        public string Member { get; set; }
        public string TransCode { get; set; }
        public DateTime TransDate { get; set; }
        public SavingTransactionType TransType { get; set; }
        public decimal Amount { get; set; }
        public decimal Balance { get; set; }
        public DateTime EntryDate { get; set; }
        public string EnteredBy { get; set; }
        public virtual SavingTransaction SavingTransaction { get; set; }

    }
}
