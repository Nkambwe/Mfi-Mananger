using MfiManager.Middleware.Data.Entities.Customers;
using MfiManager.Middleware.Enums;

namespace MfiManager.Middleware.Data.Entities.Audits {
    public class ModifiedPersonRecord : BaseEntity {
        public long RecordId { get; set; }
        public string Branch { get; set; }
        public string RegistrationCode { get; set; }
        public string MemberNo { get; set; }
        public string StatisticNo { get; set; }
        public string ReferenceNo { get; set; }
        public DateTime RegisteredOn { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Photo { get; set; }
        public string Signature { get; set; }
        public bool IsActive { get; set; }
        public ClientType Type { get; set; }
        public string Address { get; set; }
        public string PostalAddress { get; set; }
        public string Email1 { get; set; }
        public string Email2 { get; set; }
        public string Telephone { get; set; }
        public string Mobile { get; set; }
        public string AccountRef { get; set; }
        public bool Approved { get; set; }
        public bool Unlocked { get; set; }
        public string Notes { get; set; }
        public long? AreaId { get; set; }
        public long? NationalityId { get; set; }
        public long? FirstCustomId { get; set; }
        public long? SecondCustomId { get; set; }
        public long? ThirdCustomId { get; set; }
        public long? ExitId { get; set; }
        public long ModifiedRecordId { get; set; }
        public string ModifiedBranch { get; set; }
        public string ModifiedRegistrationCode { get; set; }
        public string ModificationMemberNo { get; set; }
        public string ModifiedStatisticNo { get; set; }
        public string ModifiedReferenceNo { get; set; }
        public DateTime? ModifiedRegisteredOn { get; set; }
        public string ModifiedFirstName { get; set; }
        public string ModifiedMiddleName { get; set; }
        public string ModifiedLastName { get; set; }
        public string ModifiedGender { get; set; }
        public string ModifiedPhoto { get; set; }
        public string ModifiedSignature { get; set; }
        public bool ModifiedIsActive { get; set; }
        public ClientType ModifiedType { get; set; }
        public string ModifiedAddress { get; set; }
        public string ModifiedPostalAddress { get; set; }
        public string ModifiedEmail1 { get; set; }
        public string ModifiedEmail2 { get; set; }
        public string ModifiedTelephone { get; set; }
        public string ModifiedMobile { get; set; }
        public string ModifiedAccountRef { get; set; }
        public bool ModifiedApproved { get; set; }
        public bool ModifiedUnlocked { get; set; }
        public string ModifiedNotes { get; set; }
        public long? ModifiedAreaId { get; set; }
        public long? ModifiedNationalityId { get; set; }
        public long? ModifiedFirstCustomId { get; set; }
        public long? ModifiedSecondCustomId { get; set; }
        public long? ModifiedThirdCustomId { get; set; }
        public long? ModifiedExitId { get; set; }
        public virtual Individual Person { get; set; }
        public virtual Member Member { get; set; }
    }
}
