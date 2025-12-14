using MfiManager.Middleware.Data.Entities.Accounts.Fees;
using MfiManager.Middleware.Data.Entities.Operations.Products;

namespace MfiManager.Middleware.Data.Entities.Operations.Loans {
    /// <summary>
    /// Set level at which loan fees payment is made such as at application, approval, disbursement, etc.
    /// </summary>
    public class LoanFeePaymentLevel : BaseEntity {
        public long ProductId { get; set; }
        public bool Required { get; set; }
        public decimal PercentageRate { get; set; }
        public decimal FlatAmount { get; set; }
        public bool PayBeforeApplication { get; set; }
        public string BeforeApplicationFeeLedger { get; set; }
        public bool PayBeforeApproval { get; set; }
        public string BeforeApprovalFeeLedger { get; set; }
        public bool PayAfterApproval { get; set; }
        public string AfterApprovalFeeLedger { get; set; }
        public bool PayAtDisbursement { get; set; }
        public string DisbursementFeeLedger { get; set; }
        /// <summary>
        /// Get/Set whether fees can be paid at any level
        /// </summary>
        public bool IsGeneralFee { get; set; }
        public string GeneralFeeLedger { get; set; }
        public virtual LoanProduct Product { get; set; }
        public virtual ICollection<LoanFeeLedger> LoanFeeTransactions { get; set; } = [];
    }
}
