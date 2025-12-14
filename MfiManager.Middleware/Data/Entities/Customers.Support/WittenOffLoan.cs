using MfiManager.Middleware.Data.Entities.Operations.Loans;

namespace MfiManager.Middleware.Data.Entities.Customers.Support {
    public class WittenOffLoan: BaseEntity {
        public DateTime WrittenOffOn { get; set; }
        public decimal Amount { get; set; }
        public string WittenOffBy { get; set; }
        public long LoanId { get; set; }
        public virtual LoanRecord Loan { get; set; }
        public long ReasonId { get; set; }
        public virtual WriteOffReason Reason { get; set; }
    }
}
