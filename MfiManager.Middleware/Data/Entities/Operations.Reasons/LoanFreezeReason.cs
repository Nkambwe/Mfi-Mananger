using MfiManager.Middleware.Data.Entities.Operations.Loans;

namespace MfiManager.Middleware.Data.Entities.Operations.Reasons {
    /// <summary>
    /// Reason for freezing loans
    /// </summary>
    public class LoanFreezeReason : ReasonBase {
        public virtual ICollection<LoanFreez> LoanFreezes { get; set; }
    }
}
