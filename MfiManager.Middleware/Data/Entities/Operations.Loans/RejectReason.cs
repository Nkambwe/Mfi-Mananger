using MfiManager.Middleware.Data.Entities.Customers;

namespace MfiManager.Middleware.Data.Entities.Operations.Loans {
    /// <summary>
    /// Clients registration and Loan application rejection reason
    /// </summary>
    public class RejectReason : ReasonBase {
        public virtual ICollection<RejectedLoan> Loans { get; set; } = [];
        public virtual ICollection<Individual> Rejects { get; set; } = [];
    }
}
