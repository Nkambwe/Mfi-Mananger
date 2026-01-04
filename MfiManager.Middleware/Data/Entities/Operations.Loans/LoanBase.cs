using MfiManager.Middleware.Enums;

namespace MfiManager.Middleware.Data.Entities.Operations.Loans {
    /// <summary>
    /// Client loan record
    /// </summary>
    public abstract class LoanBase : BaseEntity {
        public string LoanNumber { get; set; }
        public decimal InterestRate { get; set; }
        public int Installments { get; set; }
        public decimal Principal { get; set; }
        public decimal Interest { get; set; }
        public DateTime ApplicationDate { get; set; }
        /// <summary>
        /// Get/Set loan assessment date
        /// </summary>
        public DateTime? AssesementDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        /// <summary>
        /// Get/Set approval state. ClientApproval state can be Nap, First, Second, Approved
        /// </summary>
        public ApprovalLevel ApprovalLevel { get; set; }
        public bool IsRescheduled { get; set; }
        public LoanStatus LoanStatus { get; set; }
        public bool IsFrozeen { get; set; }
    } 
}
