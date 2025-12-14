using MfiManager.Middleware.Data.Entities.Customers;
using MfiManager.Middleware.Data.Entities.Customers.Support;

namespace MfiManager.Middleware.Data.Entities.Customer.Files {
    /// <summary>
    /// An attached file other than an agreement, Contract or title deed
    /// </summary>
    public class OtherFile : FileAttachment {
        public long? PersonId {get;set; }
        public long? BusinessId {get;set; }
        public long? SignatoryId {get;set; }
        public long? GroupId {get;set; }
        public long? MemberId {get;set; }
        public string File {get;set; }
        public virtual Individual Individual { get; set; }
        public virtual Group Group { get; set; }
        public virtual Member Member { get; set; }
        public virtual Signatory Signatory { get; set; }
        public virtual Business Business { get; set; }

        public virtual ICollection<ImageFile> Images {get;set;}

    }
}
