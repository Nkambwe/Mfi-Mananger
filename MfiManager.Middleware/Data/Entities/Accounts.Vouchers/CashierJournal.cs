using MfiManager.Middleware.Data.Entities.Operations;

namespace MfiManager.Middleware.Data.Entities.Accounts.Vouchers {
    public class CashierJournal {
        public long CashierId { get; set; }
        public long JournalId { get; set; }
        public virtual Cashier Cashier { get; set; }
        public virtual JournalType Journal { get; set; }
    }
}
