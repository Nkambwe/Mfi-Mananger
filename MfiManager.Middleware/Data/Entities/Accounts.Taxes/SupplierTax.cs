using MfiManager.Middleware.Data.Entities.Operations.Vendors;

namespace MfiManager.Middleware.Data.Entities.Accounts.Taxes {
    public class SupplierTax {
        public long SupplierId { get; set; }
        public long TaxId { get; set; }
        public virtual Tax Tax { get; set; }
        public virtual SupplierInfo Supplier { get; set; }
    }
}
