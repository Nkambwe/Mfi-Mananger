using MfiManager.Middleware.Data.Entities.Operations.Branches;
using MfiManager.Middleware.Enums;

namespace MfiManager.Middleware.Data.Entities.Archieves {
    public class GroupArchive : BaseEntity {
        public long GroupId { get; set; }
        public string Code { get; set; }
        public string Statistic { get; set; }
        public string Reference { get; set; }
        public DateTime RegisteredOn { get; set; }
        public string LegalName { get; set; }
        public ClientType ClientType { get; set; }
        public bool HoldShares { get; set; }
        public bool Approved { get; set; }
        public string ApprovedBy { get; set; }
        public bool Exited { get; set; }
        public string PermanentAddress { get; set; }
        public string MailAddress { get; set; }
        public string PrimaryLine { get; set; }
        public string SecondaryLine { get; set; }
        public string Mobile { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Town { get; set; }
        public string City { get; set; }
        public string WhatsApp { get; set; }
        public string Facebook { get; set; }
        public string Instagram { get; set; }
        public string Twitter { get; set; }
        public long? Filter1Id { get; set; }
        public long? Filter2Id { get; set; }
        public long? Filter3Id { get; set; }
        public long? Filter4Id { get; set; }
        public long? Filter5Id { get; set; }
        public DateTime? ApprovedOn { get; set; }
        public string Notes { get; set; }
        public DateTime ArchivedOn { get; set; }
        public long BranchId { get; set; }
        public virtual Branch Branch { get; set; }
        public virtual ICollection<MemberArchive> MemberArchive { get; set; }
    }
}
