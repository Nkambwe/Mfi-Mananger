using MfiManager.Middleware.Data.Entities.Accounts.Cashflows;

namespace MfiManager.Middleware.Data.Entities.Operations.Trade {
    public class TraderBankAccount {
        public long VendorId { get; set; }
        public long BankAccountId { get; set; }
        public virtual BankAccount BankAccount { get; set; }
        public virtual Trader Vendor { get; set; }
    }

}
