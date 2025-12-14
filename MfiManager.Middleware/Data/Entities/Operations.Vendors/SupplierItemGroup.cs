using MfiManager.Middleware.Data.Entities.Operations.Trade;

namespace MfiManager.Middleware.Data.Entities.Operations.Vendors {
    public class SupplierItemGroup : BaseEntity {
        public string Code { get; set; }
        public string ItemGroup { get; set; }
        public string Notes { get; set; }
        public virtual ICollection<PurchaseOrderDefault> PurchaseOrderDefaults { get; set; }
    }
}
