using MfiManager.Middleware.Data.Entities.Audits;
using MfiManager.Middleware.Enums;

namespace MfiManager.Middleware.Data.Entities.Operations.Saving {
    /// <summary>
    /// Savings overdraft loan application
    /// </summary>
    public class OverdraftLoan : BaseEntity {
        public long SavingAccountId { get; set; }
        public DateTime RequestDate { get; set; }
        public long? TranstypeId { get; set; }
        public string Transcode { get; set; }
        public string OverdraftNumber { get; set; }
        public string LedgerAccount { get; set; }
        public string Particulars { get; set; }
        public decimal Amount { get; set; }
        public decimal Interest { get; set; }
        public DateTime InterestStartDate { get; set; }
        public DateTime SettlementDate { get; set; }
        public string Notes { get; set; }
        public string ProcessedBy { get; set; }
        public DateTime? ApprovedOn { get; set; }
        public string ApprovedBy { get; set; }
        public DateTime EntryDate { get; set; }
        public virtual SavingAccount Account { get; set; }
        public OverdraftStatus Status { get; set; }
        private ICollection<OverdraftGuarantee> _guarantees;
        public virtual ICollection<OverdraftGuarantee> Guarantees { get; set; }
        public virtual ICollection<ModifiedOverdraftLoan> Modifications { get; set; }
    }
}
