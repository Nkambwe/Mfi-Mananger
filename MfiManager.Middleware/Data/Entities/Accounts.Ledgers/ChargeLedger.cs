using MfiManager.Middleware.Data.Entities.Accounts.Charges;

namespace MfiManager.Middleware.Data.Entities.Accounts.Ledgers {
    public class ChargeLedger : BaseEntity {
        public string TransactionId { get; set; }
        public DateTime PostedOn { get; set; }
        public string Series { get; set; }
        public string Client { get; set; }
        public string Loan { get; set; }
        public string Product  { get; set; }
        public string Ledger { get; set; }
        public decimal Amount  { get; set; }
        public long ChargeItemId  { get; set; }
        public virtual ChargeItem ChargeItem { get; set; }
    }
}
