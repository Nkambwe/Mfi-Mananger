using MfiManager.Middleware.Data.Entities.Accounts;

namespace MfiManager.Middleware.Data.Entities.Operations.Vendors {
    public class SupplierReference {
        public long ReferenceValueId { get; set; }
        public long SupplierId { get; set; }
        public virtual AccountReferenceValue ReferenceValue { get; set; }
        public virtual SupplierInfo Supplier { get; set; }
    }
}
