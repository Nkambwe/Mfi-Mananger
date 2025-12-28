using MfiManager.Middleware.Data.Entities.Operations.Reasons;
using MfiManager.Middleware.Data.Entities.Operations.Saving;
using MfiManager.Middleware.Enums;

namespace MfiManager.Middleware.Data.Entities.Audits {
    /// <summary>
    /// Modified savings transaction record
    /// </summary>
    public class ModifiedSavingLedger : BaseEntity {
        public string TransactionCode { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Particulars { get; set; }
        public string Folio { get; set; }
        public SavingTransactionType TransType { get; set; }
        public string OverdraftNumber { get; set; }
        public string StandingOrder { get; set; }
        public decimal TransAmount { get; set; }
        public decimal AccountBalance { get; set; }
        public DateTime EntryDate { get; set; }
        public string Cashier { get; set; }
        public long SavingAccountId { get; set; }
        public string Notes { get; set; }
        public long TransactionId { get; set; }
        public virtual SavingLedger SavingTransaction { get; set; }
        public long ReasonId {get;set;}
        public virtual GeneralReason Reason { get; set; }
    }
}
