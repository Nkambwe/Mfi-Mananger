using MfiManager.Middleware.Data.Entities.Operations;

namespace MfiManager.Middleware.Data.Entities.Accounts.Vouchers {
    public class CashierVoucher {
        public long CashierId { get; set; }
        public long VoucherId { get; set; }
        public virtual Cashier Cashier { get; set; }
        public virtual VoucherType Voucher { get; set; }
       
    }
}
