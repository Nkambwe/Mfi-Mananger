using MfiManager.Middleware.Data.Entities.Operations;
using MfiManager.Middleware.Enums;

namespace MfiManager.Middleware.Data.Entities.Archieves {
    public class IndividualArchive : BaseEntity {
        public long PersonId { get; set; }
        public long BranchId { get; set; }
        public string Code { get; set; }
        public string Statistic { get; set; }
        public string Reference { get; set; }
        public DateTime RegisteredOn { get; set; }
        public long? TitleId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public string Area { get; set; }
        public string Signature { get; set; }
        public string Photo { get; set; }
        public ClientType Type { get; set; }
        public bool HoldShares { get; set; }
        public bool Deleted { get; set; }
        public long? ProfessionId { get; set; }
        public long? EducationId { get; set;}
        public long? NationalityId { get; set; }
        public string PermanentAddress { get; set; }
        public string MailAddress { get; set; }
        public string PrimaryLine { get; set; }
        public string SecondaryLine { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string BirthPlace { get; set; }
        public string RightThumbPrint { get; set; }
        public string LeftThumbPrint { get; set; }
        public MaritalStatus MaritalStatus { get; set; }
        public string SpouseName  { get; set; }
        public int Children { get; set; }
        public int Dependents { get; set; }
        public string Mother { get; set; }
        public string Father { get; set; }
        public bool Literate { get; set; }
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
        public bool Approved { get; set; }
        public string ApprovedBy { get; set; }
        public bool Exited { get; set; }
        public DateTime? ApprovedOn { get; set; }
        public string Notes { get; set; }
        public DateTime ArchivedOn { get; set; }
        public virtual Company Company { get; set; }
    }
}
