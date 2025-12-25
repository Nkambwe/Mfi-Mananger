namespace MfiManager.Middleware.Data.Entities.Operations {
    public class CashierCashAccount {
        public long CashierId { get; set; }
        public long CashAccountId { get; set; }
        public virtual Cashier Cashier { get; set; }
        public virtual CashAccount CashAccount { get; set; }
    }

}
