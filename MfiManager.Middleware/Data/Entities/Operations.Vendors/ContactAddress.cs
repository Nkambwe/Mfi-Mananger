using MfiManager.Middleware.Data.Entities.Operations.Trade;
using MfiManager.Middleware.Enums;

namespace MfiManager.Middleware.Data.Entities.Operations.Vendors {
    public class ContactAddress : BaseEntity {
        public long? VendorId { get; set; }
        public long? SupplierId { get; set; }
        public string Details { get; set; }
        public AddressFor For { get; set; }
        public bool IsPrimary { get; set; }
        public virtual Trader Vendor { get; set; }
        public virtual SupplierInfo Supplier { get; set; }
    }
}
