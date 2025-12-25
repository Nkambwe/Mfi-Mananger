using MfiManager.Middleware.Data.Entities.Operations.Saving;
using MfiManager.Middleware.Enums;

namespace MfiManager.Middleware.Data.Entities.Operations.Loans {
    /// <summary>
    /// Loan repayment
    /// </summary>
    public class RepaymentLedger : BaseEntity {
        public DateTime PaymentDate { get; set; }
        public Payment Payment { get; set; }
        public decimal Principal { get; set; }
        public decimal Interest { get; set; }
        public decimal Commission { get; set; }
        public decimal Penalty { get; set; }
        public decimal OverPayment { get; set; }
        public decimal Vat { get; set; }
        public string ProcessedBy { get; set; }
        public long LoanId { get; set; }
        public virtual LoanRecord Loan { get; set; }
        public long? SavingAccountId { get; set; }
        public virtual SavingAccount SavingAccount { get; set; }
        public virtual ICollection<GroupRepaymentBreakdown> MembersRepayments { get; set; } = [];
    }
}
