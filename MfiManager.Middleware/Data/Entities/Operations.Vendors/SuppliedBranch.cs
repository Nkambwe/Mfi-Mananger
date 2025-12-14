using MfiManager.Middleware.Data.Entities.Operations.Trade;

namespace MfiManager.Middleware.Data.Entities.Operations.Vendors {
    /// <summary>
    /// Company branches supplied by a given vendor
    /// </summary>
    public class SuppliedBranch : BaseEntity {
        public string Branch { get; set; }
        public bool OnHold { get; set; }
        public long SupplierGroupId { get; set; }
        public long SupplierId { get; set; }
        public virtual SupplierInfo SupplierInfo { get; set; }
        public virtual SupplierGroup SupplierGroup { get; set; }
        public virtual ICollection<HeldContract> Contracts { get; set; } = [];

    }
}
