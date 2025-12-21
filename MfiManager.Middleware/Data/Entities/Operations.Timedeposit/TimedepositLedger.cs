using MfiManager.Middleware.Data.Entities.Audits;
using MfiManager.Middleware.Enums;

namespace MfiManager.Middleware.Data.Entities.Operations.Timedeposit {
    /// <summary>
    /// Timedeposit transaction record
    /// </summary>
    public class TimedepositLedger : BaseEntity {
        public string TransactionCode {get;set; }
        public DateTime TransactionDate {get;set; }
        public string Particulars {get;set; }
        public string Folio {get;set; }
        public Payment Payment {get;set; }
        public decimal TransAmount {get;set;}
        public string Notes {get;set;}
        public DateTime EntryDate {get;set; }
        public long TimedepositAccountId {get;set; }
        public virtual TimedepositAccount TimedepositAccount { get; set; }
        public virtual ICollection<ModifiedTimedepositLedger> ModifiedTimedepositTransactions {get;set;}=[];
    }
}
