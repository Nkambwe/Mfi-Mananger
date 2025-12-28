using MfiManager.Middleware.Data.Entities.Accounts.Taxes;

namespace MfiManager.Middleware.Data.Entities.Operations.Products {
    public class SavingProductTaxGroup {
        public long SavingProductId { get; set; }
        public long TaxGroupId { get; set; }
        public virtual SavingProduct SavingProduct { get; set; }
        public virtual TaxGroup TaxGroup { get; set; }
    }
}
