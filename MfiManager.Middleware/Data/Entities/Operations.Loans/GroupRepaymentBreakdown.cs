using MfiManager.Middleware.Data.Entities.Customers;
using MfiManager.Middleware.Data.Entities.Operations.Saving;

namespace MfiManager.Middleware.Data.Entities.Operations.Loans {
    /// <summary>
    /// Breakdown of group loan repayment among members
    /// </summary>
    public class GroupRepaymentBreakdown : BaseEntity {
        public DateTime PaymentDate { get; set; }
        public decimal Principal { get; set; }
        public decimal Interest { get; set; }
        public decimal Commission { get; set; }
        public decimal Penalty { get; set; }
        public decimal Vat { get; set; }
        public decimal OverPayment { get; set; }
        public string ProcessedBy { get; set; }
        public long MemberId { get; set; }
        public virtual Member Member { get; set; }
        public long RepaymentId { get; set; }
        public virtual RepaymentLedger RepaymentTransaction { get; set; }
        public long? SavingAccountId { get; set; }
        public virtual SavingAccount SavingAccount { get; set; }
    }
}
