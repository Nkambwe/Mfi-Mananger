using MfiManager.Middleware.Data.Entities.Operations.Saving;
using MfiManager.Middleware.Enums;

namespace MfiManager.Middleware.Data.Entities.Audits {
    /// <summary>
    /// Modified overdraft loan transaction
    /// </summary>
    public class ModifiedOverdraftLoan : BaseEntity {
        public long RecordId { get; set; }
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
        public long ModifiedRecordId { get; set; }
        public long ModifiedSavingAccountId { get; set; }
        public DateTime ModifiedRequestDate { get; set; }
        public long? ModifiedTranstypeId { get; set; }
        public string ModifiedTranscode { get; set; }
        public string ModifiedOverdraftNumber { get; set; }
        public string ModifiedLedgerAccount { get; set; }
        public string ModifiedParticulars { get; set; }
        public decimal ModifiedAmount { get; set; }
        public decimal ModifiedInterest { get; set; }
        public DateTime ModifiedInterestStartDate { get; set; }
        public DateTime ModifiedSettlementDate { get; set; }
        public OverdraftStatus ModifiedStatus { get; set; }
        public string ModifiedNotes { get; set; }
        public string ModifiedProcessedBy { get; set; }
        public DateTime? ModifiedApprovedOn { get; set; }
        public string ModifiedApprovedBy { get; set; }
        public DateTime ModifiedEntryDate { get; set; }
        public virtual OverdraftLoan Overdraft { get; set; }
        
    }
}
