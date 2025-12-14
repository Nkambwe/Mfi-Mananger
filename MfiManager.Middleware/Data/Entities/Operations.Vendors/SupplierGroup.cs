using MfiManager.Middleware.Data.Entities.Customers;
using MfiManager.Middleware.Data.Entities.Operations.Trade;

namespace MfiManager.Middleware.Data.Entities.Operations.Vendors {
    public class SupplierGroup : ContactGroup {

        public virtual ICollection<PurchaseOrderDefault> OrderDefaults { get; set; }
        public virtual ICollection<SuppliedBranch> SuppliedBranches { get; set; }
        public virtual ICollection<SupplierInfo> Suppliers { get; set; }
    }
}
