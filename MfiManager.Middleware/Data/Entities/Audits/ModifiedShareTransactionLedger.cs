using MfiManager.Middleware.Data.Entities.Operations.Shares;
using MfiManager.Middleware.Enums;

namespace MfiManager.Middleware.Data.Entities.Audits {
    /// <summary>
    /// Modified share transaction record
    /// </summary>
    public class ModifiedShareTransactionLedger: BaseEntity {
        public long RecordId { get; set; }
        public long AccountId { get; set; }
        public string Reference { get; set; }
        public DateTime TransactionDate { get; set; }
        public Payment Payment { get; set; }
        public ShareTransactionType ShareTransactionType { get; set; }
        public int Shares { get; set; }
        public decimal NorminalValue { get; set; }
        public decimal TransactionAmount { get; set; }
        public string Notes { get; set; }
        public long ModifiedAccountId { get; set; }
        public string ModifiedReference { get; set; }
        public DateTime ModifiedTransactionDate { get; set; }
        public Payment ModifiedPayment { get; set; }
        public ShareTransactionType MofifiedShareTransactionType { get; set; }
        public int ModifiedShares { get; set; }
        public decimal ModifiedNorminalValue { get; set; }
        public decimal ModifiedTransactionAmount { get; set; }
        public string ModifiedNotes { get; set; }
        public virtual ShareTransactionLedger ShareTransaction { get; set; }
    }
}
