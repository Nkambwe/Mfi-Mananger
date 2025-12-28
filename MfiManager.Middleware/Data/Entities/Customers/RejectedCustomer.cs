using MfiManager.Middleware.Data.Entities.Operations.Reasons;

namespace MfiManager.Middleware.Data.Entities.Customers {
    public class RejectedCustomer : BaseEntity {
        public DateTime RejectDate { get; set; }
        public string RejectedBy { get; set; }
        public string Notes { get; set; }
        public long ReasonId { get; set; }
        public virtual RejectReason Reason { get; set; }
        public long? MemberId { get; set; }
        public virtual Member Member { get; set; }
        public long? GroupId { get; set; }
        public virtual Group Group { get; set; }
        public long? PersonId { get; set; }
        public virtual Individual Individual { get; set; }
        public long? BusinessId { get; set; }
        public virtual Business Business { get; set; }
    }
}
