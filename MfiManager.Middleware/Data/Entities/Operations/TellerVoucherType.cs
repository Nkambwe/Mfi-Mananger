using MfiManager.Middleware.Data.Entities.Accounts.Vouchers;

namespace MfiManager.Middleware.Data.Entities.Operations {
    public class TellerVoucherType {
        public long TellerId { get; set; }
        public long VoucherTypeId { get; set; }
        public virtual Teller Teller { get; set; }
        public virtual VoucherType VoucherType { get; set; }
    }

}
