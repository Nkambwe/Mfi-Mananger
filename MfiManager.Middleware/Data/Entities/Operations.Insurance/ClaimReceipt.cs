using MfiManager.Middleware.Enums;

namespace MfiManager.Middleware.Data.Entities.Operations.Insurance {
    /// <summary>
    /// Receipt attached to a claim by the claimant
    /// </summary>
    public class ClaimReceipt: BaseEntity {
        public long ClaimantId { get; set; }
        public DateTime PaidOn { get; set; }
        public string Particulars { get; set; }
        public decimal Amount { get; set; }
        public ReceiptStatus Status { get; set; }
        public string RecordedBy { get; set; }
        public DateTime StatusDate { get; set; }
        public string ApprovedBy { get; set; }
        public DateTime? ApprovalDate { get; set; }
        public string Notes { get; set; }
        public virtual Claimant Claimant { get; set; }
    }
}
