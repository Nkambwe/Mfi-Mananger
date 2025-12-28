using MfiManager.Middleware.Data.Entities.Operations.Reasons;
using MfiManager.Middleware.Data.Entities.Operations.Shares;
using MfiManager.Middleware.Enums;

namespace MfiManager.Middleware.Data.Entities.Audits {
    /// <summary>
    /// Modified share transaction record
    /// </summary>
    public class ModifiedShareLedgerTransaction: BaseEntity {
        public long ShareAccountId { get; set; }
        public string TransactionCode { get; set; }
        public DateTime TransactionDate { get; set; }
        public Payment Payment { get; set; }
        public ShareTransactionType ShareTransactionType { get; set; }
        public int Shares { get; set; }
        public decimal NorminalValue { get; set; }
        public decimal TransactionAmount { get; set; }
        public string Notes { get; set; }
        public long TransactionId { get; set; }
        public virtual ShareTransactionLedger ShareTransaction { get; set; }
        public long ReasonId {get;set;}
        public virtual GeneralReason Reason { get; set; }
    }
}
