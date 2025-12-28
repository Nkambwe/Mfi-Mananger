using MfiManager.Middleware.Data.Entities.Customers;

namespace MfiManager.Middleware.Data.Entities.Operations.Loans {
    public class BusinessLoanAccount: BaseEntity { 
        public long BusinessId { get; set; }
        public virtual Business Business {get;set;}
        public virtual ICollection<LoanCycle> LoanCycles { get; set; } = [];
        public virtual ICollection<BusinessLoan>  BusinessLoans {get;set;}
    }

}
