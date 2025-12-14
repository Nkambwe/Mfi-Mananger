using MfiManager.Middleware.Enums;

namespace MfiManager.Middleware.Data.Entities.Operations.Loans {
    /// <summary>
    /// Loan repayment
    /// </summary>
    public class RepaymentTransaction : BaseEntity {
        public long LoanId { get; set; }
        public DateTime PaidOn { get; set; }
        public Payment Payment { get; set; }
        public decimal Principal { get; set; }
        public decimal Interest { get; set; }
        public decimal Commission { get; set; }
        public decimal Penalty { get; set; }
        public decimal OverPayment { get; set; }
        public string ProcessedBy { get; set; }
        public virtual LoanRecord Loan { get; set; }
        public virtual ICollection<GroupRepaymentBreakdown> MembersRepayments { get; set; } = [];
    }
}
