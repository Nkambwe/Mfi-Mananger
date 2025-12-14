using MfiManager.Middleware.Data.Entities.Operations.Saving;
using MfiManager.Middleware.Enums;

namespace MfiManager.Middleware.Data.Entities.Audits {
    /// <summary>
    /// Modified savings transaction record
    /// </summary>
    public class ModifiedSavingTransaction : BaseEntity {
        public long RecordId { get; set; }
        public long AccountId { get; set; }
        public string TransCode { get; set; }
        public DateTime TransDate { get; set; }
        public SavingTransactionType TransType { get; set; }
        public string OverdraftNumber { get; set; }
        public string StandingOrder { get; set; }
        public string Particulars { get; set; }
        public decimal Amount { get; set; }
        public decimal Balance { get; set; }
        public DateTime EntryDate { get; set; }
        public string Cashier { get; set; }
        public long ModifiedAccountId { get; set; }
        public string ModifiedTransCode { get; set; }
        public DateTime ModifiedTransDate { get; set; }
        public SavingTransactionType ModifiedTransType { get; set; }
        public string ModifiedOverdraftNumber { get; set; }
        public string ModifiedStandingOrder { get; set; }
        public string ModifiedParticulars { get; set; }
        public decimal ModifiedAmount { get; set; }
        public decimal ModifiedBalance { get; set; }
        public DateTime ModifiedEntryDate { get; set; }
        public string ModifiedCashier { get; set; }
        public virtual SavingTransaction Transaction { get; set; }
    }
}
