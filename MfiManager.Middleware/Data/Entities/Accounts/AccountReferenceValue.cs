using MfiManager.Middleware.Data.Entities.Operations.Branches;
using MfiManager.Middleware.Data.Entities.Operations.Trade;
using MfiManager.Middleware.Data.Entities.Operations.Vendors;

namespace MfiManager.Middleware.Data.Entities.Accounts {
    public class AccountReferenceValue : BaseEntity {
        public string Code { get; set; }
        public string Description { get; set; }
        public bool Suspend { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
        public bool AllowManualEntry { get; set; }
        public long ReferenceId { get; set; }
        public virtual AccountReference AccountReference { get; set; }
        public virtual ICollection<BranchReference> BranchReferences { get; set; } = [];
        public virtual ICollection<TraderReference> VendorReferences { get; set; } = [];
        public virtual ICollection<SupplierReference> SupplierReferences { get; set; } = [];
    }
}
