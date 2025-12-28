namespace MfiManager.Middleware.Data.Entities.Operations.Loans {
    public class MemberAccountBreakdown {
        public long MemberAccountId { get; set; }
        public long LoanBreakdownId { get; set; }
        public virtual MemberLoanAccount MemberAccount { get; set; }
        public virtual GroupLoanBreakdown LoanBreakdown { get; set; }
    }

}
