using MfiManager.Middleware.Data.Entities.Customers;

namespace MfiManager.Middleware.Data.Entities.Operations.Loans {
    public class GroupLoanAccount: BaseEntity { 
        public long GroupId { get; set; }
        public virtual Group Group {get;set;}
        public virtual ICollection<LoanCycle> LoanCycles { get; set; } = [];
        public virtual ICollection<MemberLoanAccount> MemberLoanAccounts { get; set; }
        public virtual ICollection<GroupLoan> GroupLoans { get; set; }
    }

}
