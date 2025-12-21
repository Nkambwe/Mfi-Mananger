namespace MfiManager.Middleware.Data.Entities.Customers {
    /// <summary>
    /// Client approval record
    /// </summary>
    public class CustomerApproval : BaseEntity {
        public string ApprovalStatus { get; set; }
        public DateTime ApprovedOn { get; set; }
        public string ApprovedBy { get; set; }
        public string Comments { get; set; }
        public string Notes { get; set; }
        public long? PersonId { get; set; }
        public virtual Individual Individual { get; set; }
        public long? GroupId { get; set; }
        public virtual Group Group { get; set; }
        public long? BusinessId { get; set; }
        public virtual Business Business { get; set; }
        public long? MemberId { get; set; }
        public virtual Member Member { get; set; }
        
    }
}
