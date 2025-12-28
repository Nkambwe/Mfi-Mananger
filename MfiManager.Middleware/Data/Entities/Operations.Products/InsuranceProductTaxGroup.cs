using MfiManager.Middleware.Data.Entities.Accounts.Taxes;

namespace MfiManager.Middleware.Data.Entities.Operations.Products {
    public class InsuranceProductTaxGroup {
        public long ProductId { get; set; }
        public long TaxGroupId { get; set; }
        public virtual InsuranceProduct Product { get; set; }
        public virtual TaxGroup TaxGroup { get; set; }
    }
}
