using MfiManager.Middleware.Data.Entities.Accounts.Vouchers;

namespace MfiManager.Middleware.Data.Entities.Operations {
    public class LoanOfficerVoucherType {
        public long LoanOfficerId { get; set; }
        public long VoucherTypeId { get; set; }
        public virtual LoanOfficer LoanOfficer { get; set; }
        public virtual VoucherType VoucherType { get; set; }
    }

}
