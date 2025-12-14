using MfiManager.Middleware.Data.Entities.Operations.Trade;
using MfiManager.Middleware.Data.Entities.Operations.Vendors;
using MfiManager.Middleware.Enums;

namespace MfiManager.Middleware.Data.Entities.Support {
    public class BusinessContact : BaseEntity {
        public long? VendorId { get; set; }
        public long? SupplierId { get; set; }
        public string ContactPerson { get; set; }
        public ContactType Type { get; set; }
        public string PhoneOrEmail { get; set; }
        public bool IsPrimary { get; set; }
        public virtual Trader Vendor { get; set; }
        public virtual SupplierInfo Supplier { get; set; }
    }
}
