using MfiManager.Middleware.Data.Entities.Customers.Support;
using MfiManager.Middleware.Data.Entities.Operations.Timedeposit;
using MfiManager.Middleware.Enums;

namespace MfiManager.Middleware.Data.Entities.Audits {
    /// <summary>
    /// Modified timedeposit transaction record
    /// </summary>
    public class ModifiedTimedepositLedger: BaseEntity {
        public long TransactionId { get; set; }
        public string TransactionCode {get;set; }
        public DateTime TransactionDate {get;set; }
        public string Particulars {get;set; }
        public string Folio {get;set; }
        public Payment Payment {get;set; }
        public decimal TransAmount {get;set;}
        public string Notes {get;set;}
        public DateTime EntryDate {get;set; }
        public long ReasonId {get;set; }
        public virtual Reason Reason { get; set; }
        public long TimedepositAccountId {get;set; }
        public virtual TimedepositLedger TimedepositTransaction { get; set; }
        
    }
}
