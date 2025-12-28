using MfiManager.Middleware.Data.Entities.Customers;
using MfiManager.Middleware.Data.Entities.Operations.Loans;

namespace MfiManager.Middleware.Data.Entities.Operations.Reasons {
    /// <summary>
    /// Clients registration and Loan application rejection reason
    /// </summary>
    public class RejectReason : ReasonBase {
        public virtual ICollection<RejectedLoan> Loans { get; set; } = [];
        public virtual ICollection<RejectedCustomer> Customers { get; set; } = [];
    }

}
