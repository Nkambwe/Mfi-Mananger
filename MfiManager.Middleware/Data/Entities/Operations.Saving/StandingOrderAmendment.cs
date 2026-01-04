using MfiManager.Middleware.Enums;

namespace MfiManager.Middleware.Data.Entities.Operations.Saving {
    /// <summary>
    /// Amendments to a standing order request
    /// </summary>
    public class StandingOrderAmendment : BaseEntity {
        
        public DateTime AmendDate { get; set; }
        /// <summary>
        /// Get/Set if this is the current amendment
        /// </summary>
        public bool Current { get; set; }
        public OrderExecution Frequency { get; set; }
        public IntervalType FrequencyType { get; set; }
        public int CustomFrequency { get; set; }
        public DateTime StartDate { get; set; }
        public decimal StartAmount { get; set; }
        public string Beneficiary { get; set; }
        public string ReferenceNumber { get; set; }
        public decimal FrequencyAmount { get; set; }
        public decimal Charge { get; set; }
        public string Notes { get; set; }
        public DateTime? ExecutionDate { get; set; }
        public DateTime? EndDate { get; set; }
        public long? StandingOrderId { get; set; }
        public long SavingAccountId { get; set; }
        public long? LedgerAccountId { get; set; }
        public virtual StandingOrder StandingOrder { get; set; }
    }
}
