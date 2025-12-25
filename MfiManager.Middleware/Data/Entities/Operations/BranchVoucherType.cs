using MfiManager.Middleware.Data.Entities.Accounts.Vouchers;
using MfiManager.Middleware.Data.Entities.Operations.Branches;

namespace MfiManager.Middleware.Data.Entities.Operations {
    public class BranchVoucherType {
        public long BranchId { get; set; }
        public long VoucherTypeId { get; set; }
        public virtual Branch Branch { get; set; }
        public virtual VoucherType VoucherType { get; set; }
    }

}
