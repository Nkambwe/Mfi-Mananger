using MfiManager.Middleware.Data.Entities.Accounts.Taxes;

namespace MfiManager.Middleware.Data.Entities.Operations.Products {
    public class ShareProductTaxGroup {
        public long ProductId { get; set; }
        public long TaxGroupId { get; set; }
        public virtual ShareProduct Product { get; set; }
        public virtual TaxGroup TaxGroup { get; set; }
    }
}
