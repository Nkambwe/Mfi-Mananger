namespace MfiManager.Middleware.Data.Entities.Customers {
    /// <summary>
    /// Client approval record
    /// </summary>
    public class ClientApproval : BaseEntity {
        public long? PersonId { get; set; }
        public long? GroupId { get; set; }
        public long? BusinessId { get; set; }
        public long? MemberId { get; set; }
        public string ApprovalStatus { get; set; }
        public DateTime ApprovedOn { get; set; }
        public string ApprovedBy { get; set; }
        public string Comments { get; set; }
        public string Notes { get; set; }
        public virtual Individual Person { get; set; }
        public virtual Business Business { get; set; }
        public virtual Member Member { get; set; }
        public virtual Group Group { get; set; }
    }
}
