using MfiManager.Middleware.Data.Entities.Accounts.Charges;

namespace MfiManager.Middleware.Data.Entities.Accounts.Ledgers {

    public class RegistrationLedger : BaseEntity {
        public string TransactionCode { get; set; }
        public DateTime PostedOn { get; set; }
        public string Series { get; set; }
        public decimal Amount { get; set; }
        public string Client  { get; set; }
        public long ChargeItemId { get; set; }

        public virtual ChargeItem ChargeItem { get; set; }
    }
}
