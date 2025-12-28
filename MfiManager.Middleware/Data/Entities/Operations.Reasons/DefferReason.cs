using MfiManager.Middleware.Data.Entities.Operations.Loans;

namespace MfiManager.Middleware.Data.Entities.Operations.Reasons {
    /// <summary>
    /// Reason for deferment of a loan
    /// </summary>
    public class DefferReason : ReasonBase {
        public virtual ICollection<DefferedLoan> DefferedLoans { get; set; }
    }
}
