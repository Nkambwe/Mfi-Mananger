using MfiManager.Middleware.Data.Entities.Operations.Loans;

namespace MfiManager.Middleware.Data.Entities.Operations.Reasons {
    /// <summary>
    /// Loan write-off reasons
    /// </summary>
    public class WriteOffReason : ReasonBase {
        public virtual ICollection<WittenOffLoan> Loans { get; set; } = [];
    }
}
