using MfiManager.Middleware.Data.Entities.Operations.Saving;
using MfiManager.Middleware.Enums;

namespace MfiManager.Middleware.Data.Entities.Audits {
    public class ModifiedStandingOrder : BaseEntity {
        /// <summary>
        /// Get/Set record Standing Order Id
        /// </summary>
        public long StandingOrderId { get; set; }
        /// <summary>
        /// Get/Set Savings Account Id
        /// </summary>
        public long AccountId { get; set; }
        /// <summary>
        /// Get/Set General Ledger account Id
        /// </summary>
        public long LedgerId { get; set; }
        /// <summary>
        /// Get/Set Standing order number
        /// </summary>
        public string Number { get; set; }
        public DateTime OrderDate { get; set; }
        /// <summary>
        /// Get/Set standing order execution interval
        /// </summary>
        public OrderExecution Frequency { get; set; }
        /// <summary>
        /// Get/Set interval type for OrderExecution custom option
        /// </summary>
        public IntervalType FrequencyType { get; set; }
        /// <summary>
        /// Get/Set number of days, weeks, months or years for custom execution option
        /// </summary>
        public int CustomFrequency { get; set; }
        /// <summary>
        /// Get/Set person benefiting from this standing order
        /// </summary>
        public string Benficiary { get; set; }
        /// <summary>
        /// Get/Set the beneficiary reference number whatever it may be ie. phone number, account number, etc.
        /// </summary>
        public string ReferenceNumber { get; set; }
        /// <summary>
        /// Get/Set first payment date for the standing order
        /// </summary>
        public DateTime StartDate { get; set; }
        /// <summary>
        /// Get/Set the initial amount paid out on the standing order
        /// </summary>
        public decimal StartAmount { get; set; }
        /// <summary>
        /// Get/Set the amount of money paid out on each order
        /// </summary>
        public decimal FrequencyAmount { get; set; }
        /// <summary>
        /// Get/Set the bank fees charged on each order
        /// </summary>
        public decimal Charge { get; set; }
        /// <summary>
        /// Get/Set execution date for standing order frequency payments
        /// </summary>
        public DateTime? ExecutionDate { get; set; }
        /// <summary>
        /// Get/Set date of last standing order payment
        /// </summary>
        public DateTime? EndDate { get; set; }
        /// <summary>
        /// Get/Set whether payments are to be made until further notice. Set to true where end date is not provided
        /// </summary>
        public bool UntilNotice { get; set; }
        public bool Cancelled { get; set; }
        public DateTime? CancelledOn { get; set; }
        public string CancelNotes { get; set; }
        /// <summary>
        /// Get/Set modified Savings Account Id
        /// </summary>
        public long ModifiedAccountId { get; set; }
        /// <summary>
        /// Get/Set  Modified General Ledger account Id
        /// </summary>
        public long ModifiedLedgerId { get; set; }
        /// <summary>
        /// Get/Set  Modified Standing order number
        /// </summary>
        public string ModifiedNumber { get; set; }
        /// <summary>
        /// Get/Set modified standing order date
        /// </summary>
        public DateTime ModifiedOrderDate { get; set; }
        /// <summary>
        /// Get/Set modified standing order execution interval
        /// </summary>
        public OrderExecution ModifiedFrequency { get; set; }
        /// <summary>
        /// Get/Set modified interval type for OrderExecution custom option
        /// </summary>
        public IntervalType ModifiedFrequencyType { get; set; }
        /// <summary>
        /// Get/Set modified number of days, weeks, months or years for custom execution option
        /// </summary>
        public int ModifiedCustomFrequency { get; set; }
        /// <summary>
        /// Get/Set modified person benefiting from this standing order
        /// </summary>
        public string ModifiedBenficiary { get; set; }
        /// <summary>
        /// Get/Set the modified beneficiary reference number whatever it may be ie. phone number, account number, etc.
        /// </summary>
        public string ModifiedReferenceNumber { get; set; }
        /// <summary>
        /// Get/Set modified first payment date for the standing order
        /// </summary>
        public DateTime ModifiedStartDate { get; set; }
        /// <summary>
        /// Get/Set the modified initial amount paid out on the standing order
        /// </summary>
        public decimal ModifiedStartAmount { get; set; }
        /// <summary>
        /// Get/Set the modified amount of money paid out on each order
        /// </summary>
        public decimal ModifiedFrequencyAmount { get; set; }
        /// <summary>
        /// Get/Set the modified bank fees charged on each order
        /// </summary>
        public decimal ModifiedCharge { get; set; }
        /// <summary>
        /// Get/Set modified execution date for standing order frequency payments
        /// </summary>
        public DateTime? ModifiedExecutionDate { get; set; }
        /// <summary>
        /// Get/Set modified date of last standing order payment
        /// </summary>
        public DateTime? ModifiedEndDate { get; set; }
        /// <summary>
        /// Get/Set modified whether payments are to be made until further notice. Set to true where end date is not provided
        /// </summary>
        public bool ModifiedUntilNotice { get; set; }
        public bool ModifiedCancelled { get; set; }
        public DateTime? ModifiedCancelledOn { get; set; }
        public string ModifiedCancelNotes { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public virtual StandingOrder StandingOrder { get; set; }
    }
}
