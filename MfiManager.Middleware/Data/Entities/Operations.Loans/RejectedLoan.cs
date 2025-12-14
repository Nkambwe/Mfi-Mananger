namespace MfiManager.Middleware.Data.Entities.Operations.Loans {
    /// <summary>
    /// Rejected loan record
    /// </summary>
    public class RejectedLoan : BaseEntity {
        public DateTime PostedOn { get; set; }
        public int ReasonId { get; set; }
        public string Notes { get; set; }
        public virtual RejectReason Reason { get; set; }
    }
}
