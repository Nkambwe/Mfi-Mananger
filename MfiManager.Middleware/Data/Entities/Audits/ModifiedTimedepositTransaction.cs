using MfiManager.Middleware.Data.Entities.Operations.Timedeposit;
using MfiManager.Middleware.Enums;

namespace MfiManager.Middleware.Data.Entities.Audits {
    /// <summary>
    /// Modified timedeposit transaction record
    /// </summary>
    public class ModifiedTimedepositTransaction {
        public long Id { get; set; }
        public long TransactionId { get; set; }
        public long AccountId { get; set; }
        public DateTime PostedOn { get; set; }
        public string TransactionCode { get; set; }
        public Payment Payment { get; set; }
        public string Particulars { get; set; }
        public decimal Amount { get; set; }
        public string EntryBy { get; set; }
        public Guid ModifiedAccountId { get; set; }
        public DateTime ModifiedPostedOn { get; set; }
        public string ModifiedTransactionCode { get; set; }
        public Payment ModifiedPayment { get; set; }
        public string ModifiedParticulars { get; set; }
        public decimal ModifiedAmount { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public virtual TimedepositTransaction Transaction { get; set; }
    }
}
