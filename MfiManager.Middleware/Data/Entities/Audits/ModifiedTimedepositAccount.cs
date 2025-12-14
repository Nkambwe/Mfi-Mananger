using MfiManager.Middleware.Data.Entities.Operations.Timedeposit;

namespace MfiManager.Middleware.Data.Entities.Audits {
    /// <summary>
    /// Modified timedeposit account record
    /// </summary>
    public class ModifiedTimedepositAccount: BaseEntity  {
        public long RecordId { get; set; }
        public long ProductId { get; set; }
        public long BranchId { get; set; }
        public long CustomerId { get; set; }
        public DateTime OpenedOn { get; set; }
        public string AccountNumber { get; set; }
        public decimal DepositAmount { get; set; }
        public decimal NegotiatedRate { get; set; }
        public decimal MaturityValue { get; set; }
        public DateTime MaturityDate { get; set; }
        public bool HoldInterest { get; set; }
        public bool Renewed { get; set; }
        public long ModifiedProductId { get; set; }
        public long ModifiedBranchId { get; set; }
        public DateTime ModifiedOpenedOn { get; set; }
        public string ModifiedAccountNumber { get; set; }
        public decimal ModifiedDepositAmount { get; set; }
        public decimal ModifiedNegotiatedRate { get; set; }
        public decimal ModifiedMaturityValue { get; set; }
        public DateTime ModifiedMaturityDate { get; set; }
        public bool ModifiedHoldInterest { get; set; }
        public bool ModfiedRenewed { get; set; }
        public virtual TimedepositAccount TimedepositAccount { get; set; }
    }
}
