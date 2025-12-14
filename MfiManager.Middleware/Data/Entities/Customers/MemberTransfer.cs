namespace MfiManager.Middleware.Data.Entities.Customers {
    public class MemberTransfer : BaseEntity {
        public long MemberId { get; set; }
        public bool ClusterTransfer { get; set; }
        public string OldGroup { get; set; }
        public string OldMemberCode { get; set; }
        public string NewGroup { get; set; }
        public string NewMemberCode { get; set; }
        public DateTime TransferredOn { get; set; }
        public string Reason { get; set; }
        public virtual Member Member { get; set; }
    }
}
