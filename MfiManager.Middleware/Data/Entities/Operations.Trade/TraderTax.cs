using MfiManager.Middleware.Data.Entities.Accounts.Taxes;

namespace MfiManager.Middleware.Data.Entities.Operations.Trade {
    public class TraderTax {
        public long VendorId { get; set; }
        public long TaxId { get; set; }
        public virtual Tax Tax { get; set; }
        public virtual Trader Vendor { get; set; }
    }
}
