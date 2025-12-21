using MfiManager.Middleware.Data.Entities.Accounts.Ledgers;
using MfiManager.Middleware.Data.Entities.Customers.Support;

namespace MfiManager.Middleware.Data.Entities.Audits {
    public class ModifiedCashLedger : BaseEntity {
        public long TransactionId { get; set; }
        public string TransactionCode { get; set; }
        public string LedgerAccount { get; set; }
        public DateTime PostedOn { get; set; }
        public string Description { get; set; }
        public string Provisional { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public decimal ExchangeAmount { get; set; }
        public decimal Balance { get; set; }
        public long CashAccountId { get; set; }
        public CashLedger Transaction { get; set; }
        public long ReasonId {get;set;}
        public virtual Reason Reason { get; set; }
    }
}
