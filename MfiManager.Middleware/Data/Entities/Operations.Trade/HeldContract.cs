using MfiManager.Middleware.Data.Entities.Customers.Support;
using MfiManager.Middleware.Data.Entities.Operations.Vendors;

namespace MfiManager.Middleware.Data.Entities.Operations.Trade {
    public class HeldContract : BaseEntity {
        public long ReasonId  {get;set; }
        public long? VendorId  {get;set; }
        public long? SupplierId  {get;set; }
        public long? BranchId  {get;set; }
        public DateTime ReleaseOn {get;set;}
        public virtual Reason Reason { get; set; }
        public virtual Trader Vendor { get; set; }
        public virtual SupplierInfo Supplier { get; set; }
        public virtual SuppliedBranch Branch { get; set; }
    }
}
