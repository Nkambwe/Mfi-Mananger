using MfiManager.Middleware.Data.Entities.Customers;

namespace MfiManager.Middleware.Data.Entities.Audits {
    /// <summary>
    /// Modified group member record
    /// </summary>
    public class ModifiedMemberRecord {
        public long Id { get; set; }
        public long RecordId { get; set; }
        public long GroupId { get; set; }
        public string GroupMemberCode { get; set; }
        public string StatisticNo { get; set; }
        public string ReferenceNo { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime RegisteredOn { get; set; }
        public bool IsActive { get; set; }
        public string Address { get; set; }
        public string PostalAddress { get; set; }
        public string Email1 { get; set; }
        public string Email2 { get; set; }
        public string Telephone { get; set; }
        public string Mobile { get; set; }
        public DateTime Started { get; set; }
        public DateTime? Ended { get; set; }
        public string Cluster { get; set; }
        public long? CustomProperty1Id { get; set; }
        public long? CustomProperty2Id { get; set; }
        public long ModifiedGroupId { get; set; }
        public string ModifiedGroupMemberCode { get; set; }
        public string ModifiedStatisticNo { get; set; }
        public string ModifiedReferenceNo { get; set; }
        public string ModifiedFirstName { get; set; }
        public string ModifiedMiddleName { get; set; }
        public string ModifiedLastName { get; set; }
        public DateTime ModifiedRegisteredOn { get; set; }
        public bool ModifiedIsActive { get; set; }
        public string ModifiedAddress { get; set; }
        public string ModifiedPostalAddress { get; set; }
        public string ModifiedEmail1 { get; set; }
        public string ModifiedEmail2 { get; set; }
        public string ModifiedTelephone { get; set; }
        public string ModifiedMobile { get; set; }
        public DateTime ModifiedStarted { get; set; }
        public DateTime? ModifiedEnded { get; set; }
        public string ModifiedCluster { get; set; }
        public long? ModifiedCustomProperty1Id { get; set; }
        public long? ModifiedCustomProperty2Id { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public virtual Member Member { get; set; }
    }
}
