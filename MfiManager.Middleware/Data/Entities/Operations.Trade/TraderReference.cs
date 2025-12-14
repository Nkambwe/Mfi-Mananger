using MfiManager.Middleware.Data.Entities.Accounts;

namespace MfiManager.Middleware.Data.Entities.Operations.Trade {
    public class TraderReference : BaseEntity {
        public long VendorId { get; set; }
        public long ReferenceValueId { get; set; }
        public virtual AccountReferenceValue ReferenceValue { get; set; }
        public virtual Trader Vendor { get; set; }
    }
}
