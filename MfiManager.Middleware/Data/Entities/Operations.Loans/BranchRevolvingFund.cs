using MfiManager.Middleware.Data.Entities.Operations.Branches;

namespace MfiManager.Middleware.Data.Entities.Operations.Loans {
    public class BranchRevolvingFund {
        public long BranchId { get; set; }
        public long FundId { get; set; }
        public virtual Branch Branch { get; set; }
        public virtual RevolvingFund RevolvingFund { get; set; }
    }
}
