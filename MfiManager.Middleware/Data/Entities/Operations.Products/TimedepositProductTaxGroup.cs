using MfiManager.Middleware.Data.Entities.Accounts.Taxes;

namespace MfiManager.Middleware.Data.Entities.Operations.Products {
    public class TimedepositProductTaxGroup {
        public long TimedepositProductId { get; set; }
        public long TaxGroupId { get; set; }
        public virtual TimedepositProduct TimedepositProduct { get; set; }
        public virtual TaxGroup TaxGroup { get; set; }
    }
}
