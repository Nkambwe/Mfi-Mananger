
namespace MfiManager.Middleware.Data.Entities.Operations.Products {

    public abstract class ProductBase : BaseEntity {
        public string Code { get; set; }
        public string ProductName { get; set; }
        public bool IsActive { get; set; }
        public bool VatInclusive { get; set; }
        public bool UseChargeGroups { get; set; }
    }

}
