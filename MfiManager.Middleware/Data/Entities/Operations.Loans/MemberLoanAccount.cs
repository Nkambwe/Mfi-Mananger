using MfiManager.Middleware.Data.Entities.Customers;

namespace MfiManager.Middleware.Data.Entities.Operations.Loans {
    public class MemberLoanAccount: BaseEntity { 
        public long MemberId { get; set; }
        public virtual Member Member {get;set;}
        public long GroupAccountId { get; set; }
        public virtual GroupLoanAccount GroupAccount {get;set;}
        public virtual ICollection<MemberAccountBreakdown> LoanBreakdowns { get; set; } = [];
    }

}
