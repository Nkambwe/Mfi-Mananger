using MfiManager.Middleware.Data.Entities.Accounts.Vouchers;
using MfiManager.Middleware.Enums;

namespace MfiManager.Middleware.Data.Entities.Operations.Insurance {
    /// <summary>
    /// Insurance claim record
    /// </summary>
    public class InsuranceClaim : BaseEntity {
        public long PolicyId { get; set; }
        public long ClaimantId { get; set; }
        public string ClaimNumber { get; set; }
        public string Beneficiary { get; set; }
        public DateTime ReportDate { get; set; }
        public DateTime LossDate { get; set; }
        public ClaimStatus Status { get; set; }
        public SeverityScore Severity { get; set; }
        /// <summary>
        /// Get/Set severity scale for claim eg. Low (1 - 4), Minimal (5 - 7), High (8 - 10)
        /// </summary>
        public int Scale { get; set; }
        /// <summary>
        /// Get/Set whether deductions cover expenses related to this claim
        /// </summary>
        public bool CoveredByDeduction { get; set; }
        public virtual Policy Policy { get; set; }
        public virtual Claimant Claimant { get; set; }
        public virtual ICollection<ClaimPaymentLedger> Transactions { get; set; }
    }
}
