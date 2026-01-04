using MfiManager.Middleware.Data.Entities.Operations.Loans;

namespace MfiManager.Middleware.Data.Entities.Operations.Reasons {
    public class LoanRefinanceReason : ReasonBase {
        public virtual ICollection<LoanRefinance> Loans { get; set; }
    }
}
