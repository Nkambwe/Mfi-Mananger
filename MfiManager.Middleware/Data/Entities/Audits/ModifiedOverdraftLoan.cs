using MfiManager.Middleware.Data.Entities.Operations.Saving;
using MfiManager.Middleware.Enums;

namespace MfiManager.Middleware.Data.Entities.Audits {
    /// <summary>
    /// Modified overdraft loan transaction
    /// </summary>
    public class ModifiedOverdraftLoan : BaseEntity {
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
        public OverdraftStatus Status { get; set; }
        public string Notes { get; set; }
        public string ProcessedBy { get; set; }
        public DateTime? ApprovedOn { get; set; }
        public string ApprovedBy { get; set; }
        public DateTime EntryDate { get; set; }
        public long OverdraftId { get; set; }
        public virtual OverdraftLoan Overdraft { get; set; }
        
    }
}
