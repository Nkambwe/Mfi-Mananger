using MfiManager.Middleware.Data.Entities.Customer.Files;
using MfiManager.Middleware.Data.Entities.Operations.Saving;
using MfiManager.Middleware.Data.Entities.Support;

namespace MfiManager.Middleware.Data.Entities.Customers.Support {
    /// <summary>
    /// Identification document for an individual
    /// </summary>
    public class Identification : BaseEntity {       
        public string FileUrl {get;set; }
        public DateTime IssuedOn {get;set;}
        public DateTime? ExpiresOn {get;set;}
        public long IdentityTypeId {get;set; }
        public virtual IdentificationType IdentityType { get; set; }
        public long IssuerAuthorityId {get;set; }
        public virtual IssuerAuthority IssuerAuthority { get; set; }
        public long? PersonId {get;set; }
        public virtual Individual Person { get; set; }
        public long? MemberId {get;set; }
        public virtual Member Member { get; set; }
        public long? SignatoryId {get;set; }
        public virtual Signatory Signatory { get; set; }
        public long? SavingPartnerId {get;set; }
        public virtual SavingPartner SavingPartner { get; set; }
        public string Notes {get;set; }
        public virtual ICollection<ImageFile> Images {get;set;}
        public override string ToString() => $"{Id}";
        public override int GetHashCode() => ToString().GetHashCode() ^ 3;
    }
}
