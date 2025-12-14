using MfiManager.Middleware.Data.Entities.Audits;
using MfiManager.Middleware.Enums;

namespace MfiManager.Middleware.Data.Entities.Operations.Timedeposit {
    /// <summary>
    /// Timedeposit transaction record
    /// </summary>
    public class TimedepositTransaction : BaseEntity {
        public long AccountId {get;set; }
        public DateTime TransDate {get;set; }
        public string TransCode {get;set; }
        public Payment Payment {get;set; }
        public string Particulars {get;set; }
        public decimal Amount {get;set;}
        public string EntryBy {get;set;}
        public virtual TimedepositAccount Account { get; set; }
        public virtual ICollection<ModifiedTimedepositTransaction> Modifications {get;set;}=[];
    }
}
