using MfiManager.Middleware.Data.Entities.Operations.Trade;
using MfiManager.Middleware.Data.Entities.Operations.Vendors;
using MfiManager.Middleware.Data.Helpers;
using MfiManager.Middleware.Enums;

namespace MfiManager.Middleware.Data.Entities.Support {
    public class BusinessContact : BaseEntity {
        public long? VendorId { get; set; }
        public long? SupplierId { get; set; }
        [Encryptable("Contact Person")]
        public string ContactPerson { get; set; }
        public ContactType Type { get; set; }
        [Encryptable("Phone or Email")]
        public string PhoneOrEmail { get; set; }
        public bool IsPrimary { get; set; }
        public virtual Trader Vendor { get; set; }
        public virtual SupplierInfo Supplier { get; set; }
    }
}
