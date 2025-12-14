using MfiManager.Middleware.Data.Entities.Operations.Loans;
using MfiManager.Middleware.Enums;

namespace MfiManager.Middleware.Data.Entities.Audits {
    /// <summary>
    /// Modified loan record
    /// </summary>
    public class ModifiedLoan {
        public long Id { get; set; }
        public long RecordId { get; set; }
        public string Client { get; set; }
        public string Group { get; set; }
        public string Membership { get; set; }
        public long Product { get; set; }
        public long Donor { get; set; }
        public DateTime? AppliedOn { get; set; }
        /// <summary>
        /// Get/Set loan assesment date
        /// </summary>
        public DateTime? AssesedOn { get; set; }
        public DateTime? ExpiresOn { get; set; }
        public decimal Rate { get; set; }
        public int Instalments { get; set; }
        public decimal Principal { get; set; }
        public decimal Interest { get; set; }
        public long CycleId { get; set; }
        public ApprovalState Approval { get; set; }
        public bool Rescheduled { get; set; }
        public LoanStatus Status { get; set; }
        public string CreditOfficer { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedClient { get; set; }
        public string ModifiedGroup { get; set; }
        public long ModifiedProduct { get; set; }
        public long ModifiedDonor { get; set; }
        public string ModifiedCreditOfficer { get; set; }
        public string ModifiedBy { get; set; }
        public ApprovalState ModifiedApproval { get; set; }
        public bool ModifiedRescheduled { get; set; }
        public LoanStatus ModifiedStatus { get; set; }
        public decimal ModifiedRate { get; set; }
        public int ModifiedInstalments { get; set; }
        public decimal ModifiedPrincipal { get; set; }  
        public decimal ModifiedInterest { get; set; }
        public long ModifiedCycleId { get; set; }
        public string Notes { get; set; }
        public virtual LoanRecord Loan { get; set; }
    }
}
