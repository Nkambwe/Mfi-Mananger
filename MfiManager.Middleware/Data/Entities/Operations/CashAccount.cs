using MfiManager.Middleware.Data.Entities.Accounts;
using MfiManager.Middleware.Data.Entities.Accounts.Ledgers;

namespace MfiManager.Middleware.Data.Entities.Operations {

    public class CashAccount : BaseEntity {
        public string LedgerNumber { get; set; }
        public decimal MinimumPayout { get; set; }
        public decimal MaximumPayout { get; set; }
        public bool AllowMultiCurrency { get; set; }
        public long LedgerAccountId { get; set; }
        public virtual LedgerAccount LedgerAccount { get; set; }
        public virtual ICollection<CashierCashAccount> Cashiers { get; set; } = [];
        public virtual ICollection<CashLedger> CashLedgerTransactions { get; set; } = [];
    }
}
