using MfiManager.Middleware.Data.Entities.Accounts.Taxes;

namespace MfiManager.Middleware.Data.Entities.Accounts.Vouchers {
    public class JournalTypeTaxGroup {
        public long JournalTypeId { get; set; }
        public long TaxGroupId { get; set; }
        public virtual JournalType JournalType { get; set; }
        public virtual TaxGroup TaxGroup { get; set; }
    }
}
