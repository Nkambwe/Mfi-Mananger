using MfiManager.Middleware.Enums;

namespace MfiManager.Middleware.Data.Entities.Operations.Saving {
    /// <summary>
    /// Amendments to a standing order request
    /// </summary>
    public class StandingOrderAmendment : BaseEntity {
        public long OrderId { get; set; }
        public DateTime AmendDate { get; set; }
        /// <summary>
        /// Get/Set if this is the current amendment
        /// </summary>
        public bool Current { get; set; }
        public OrderExecution FromFrequency { get; set; }
        public OrderExecution ToFrequency { get; set; }
        public IntervalType FromFrequencyType { get; set; }
        public IntervalType ToFrequencyType { get; set; }
        public int FromCustomFrequency { get; set; }
        public int ToCustomFrequency { get; set; }
        public string FromBeneficiary { get; set; }
        public string ToBeneficiary { get; set; }
        public string FromReferenceNumber { get; set; }
        public string ToReferenceNumber { get; set; }
        public decimal FromAmount { get; set; }
        public decimal ToAmount { get; set; }
        public string Notes { get; set; }
        public DateTime? FromExecutionDate { get; set; }
        public DateTime? ToExecutionDate { get; set; }
        public DateTime? FromEndDate { get; set; }
        public DateTime? ToEndDate { get; set; }
        public bool UntilNotice { get; set; }
        public virtual StandingOrder Order { get; set; }
    }
}
