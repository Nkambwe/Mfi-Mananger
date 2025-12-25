using MfiManager.Middleware.Data.Entities.Accounts;

namespace MfiManager.Middleware.Data.Entities.Operations.Loans {
    public class LoanFilter4 : LoanFilterBase {
        public string Activity { get; set; }
        public long? LedgerAccountId { get; set; }
        public virtual LedgerAccount LedgerAccount {get;set;}
        public virtual ICollection<LoanRecord> Loans { get; set; } = [];
        public override string ToString() => $"{Series}-{Description.Trim()}";
        public override int GetHashCode() => ToString().GetHashCode() ^ 3;
    }
}
