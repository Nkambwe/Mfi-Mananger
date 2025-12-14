using MfiManager.Middleware.Data.Entities.Customer.Files;
using MfiManager.Middleware.Data.Entities.Operations.Saving;
using MfiManager.Middleware.Data.Entities.Support;

namespace MfiManager.Middleware.Data.Entities.Customers.Support {
    /// <summary>
    /// Identification document for an individual
    /// </summary>
    public class Identification : BaseEntity {
        public long? PersonId {get;set; }
        public long? MemberId {get;set; }
        public long? SignatoryId {get;set; }
        public long? HolderId {get;set; }
        public long TypeId {get;set; }
        public long IssuerId {get;set; }
        public string FileUrl {get;set; }
        public DateTime IssuedOn {get;set;}
        public DateTime? ExpiresOn {get;set;}
        public virtual IdentificationType Type { get; set; }
        public virtual IssuerAuthority Issuer { get; set; }
        public virtual Individual Person { get; set; }
        public virtual Member Member { get; set; }
        public virtual Signatory Signatory { get; set; }
        public virtual PartnerHolder PartnerHolder { get; set; }
        public virtual ICollection<ImageFile> Images {get;set;}
        public override string ToString() => $"{Id}";
        public override int GetHashCode() => ToString().GetHashCode() ^ 3;
    }
}
