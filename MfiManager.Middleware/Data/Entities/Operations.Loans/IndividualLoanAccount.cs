using MfiManager.Middleware.Data.Entities.Customers;

namespace MfiManager.Middleware.Data.Entities.Operations.Loans {
    public class IndividualLoanAccount: BaseEntity { 
        public long PersonId { get; set; }
        public virtual Individual Individual {get;set;}
        public virtual ICollection<LoanCycle> LoanCycles { get; set; } = [];
        public virtual ICollection<IndividualLoan> IndividualLoans { get; set; }
    }

}
