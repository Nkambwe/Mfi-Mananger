using MfiManager.Middleware.Data.Entities.Operations.Reasons;

namespace MfiManager.Middleware.Data.Entities.Customers {
    public class MemberTransfer : BaseEntity {
        /// <summary>
        /// If true, enable GroupCode else disable it and FromMemberCode and ToMemberCode
        /// </summary>
        public bool ClusterTransfer { get; set; }
        public string GroupCode { get; set; }
        public string TransferFrom { get; set; }
        public string FromMemberCode { get; set; }
        public string TransferTo { get; set; }
        public string ToMemberCode { get; set; }
        public DateTime TransferDate { get; set; }
        public bool Approved { get; set; }
        public long ReasonId { get; set; }
        public GeneralReason Reason { get; set; }
        public long MemberId { get; set; }
        public virtual Member Member { get; set; }
        public string Notes { get; set; }
    }
}
