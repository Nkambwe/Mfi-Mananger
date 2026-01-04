using MfiManager.Middleware.Data.Entities.Accounts;
using MfiManager.Middleware.Data.Entities.Audits;
using MfiManager.Middleware.Enums;

namespace MfiManager.Middleware.Data.Entities.Operations.Saving {
    /// <summary>
    /// Standing order request record
    /// </summary>
    public class StandingOrder : BaseEntity {
        /// <summary>
        /// Get/Set Standing order number
        /// </summary>
        public string OrderNumber { get; set; }
        /// <summary>
        /// Get/Set Standing order date
        /// </summary>
        public DateTime OrderDate { get; set; }
        /// <summary>
        /// Get/Set standing order execution interval
        /// </summary>
        public OrderExecution Frequency { get; set; }
        /// <summary>
        /// Get/Set interval type for OrderExecution custom option
        /// </summary>
        public IntervalType IntervalType { get; set; }
        /// <summary>
        /// Get/Set number of days, weeks, months or years for custom execution option
        /// </summary>
        public int CustomFrequency { get; set; }
        /// <summary>
        /// Get/Set person benefiting from this standing order
        /// </summary>
        public string Beneficiary { get; set; }
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
        public bool PayAtNotice { get; set; }
        public bool Cancelled { get; set; }
        public DateTime? CancelledOn { get; set; }
        public string CancelNotes { get; set; }
        public long SavingAccountId { get; set; }
        public virtual SavingAccount SavingAccount { get; set; }
        public long? LedgerAccountId { get; set; }
        public virtual LedgerAccount LedgerAccount { get; set; }
        public virtual ICollection<ModifiedStandingOrder> Modifications { get; set; }
        public virtual ICollection<StandingOrderAmendment> OrderAmendments { get; set; }
    }
}
