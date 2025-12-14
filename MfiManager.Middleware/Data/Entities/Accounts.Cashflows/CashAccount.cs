using MfiManager.Middleware.Data.Entities.Accounts.Ledgers;

namespace MfiManager.Middleware.Data.Entities.Accounts.Cashflows {
    public class CashAccount : BaseEntity {
        public string LedgerNumber { get; set; }
        public decimal MinimumPayout{ get; set; }
        public decimal MaximumPayout{ get; set; }
        public bool AllowMultiCurrency{ get; set; }
        public long LedgerId{ get; set; }
        public virtual LedgerAccount LedgerAccount { get; set; }
        public virtual ICollection<Cashier> Cashiers  {get; set; } = [];
        public virtual ICollection<CashLedger> Transactions {get; set; } = [];
    }
}
