using MfiManager.Middleware.Data.Entities.Audits;
using MfiManager.Middleware.Enums;

namespace MfiManager.Middleware.Data.Entities.Operations.Shares {
    /// <summary>
    /// Shares transaction record
    /// </summary>
    public class ShareTransactionLedger : BaseEntity {
        public long ShareAccountId {get;set; }
        public long ShareValueId {get;set; }
        public string Reference {get;set; }
        public DateTime TransactionDate {get;set; }
        public Payment Payment {get;set; }
        public ShareTransactionType ShareTransactionType {get;set; }
        public int Shares {get;set; }
        public decimal TransactionAmount {get;set; }
        public string Notes {get;set; }
        public virtual ShareAccount ShareAccount { get; set; }
        public virtual ShareValue ShareValue { get; set; }
        public virtual ICollection<ModifiedShareTransactionLedger> Modifications {get;set;}=[];

    }
}
