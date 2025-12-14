using MfiManager.Middleware.Data.Entities.Customers;

namespace MfiManager.Middleware.Data.Entities.Customer.Files {
    /// <summary>
    /// Title deed attached to a client's record
    /// </summary>
    public class TitleDeed : FileAttachment {
        public long? PersonId {get;set; }
        public long? BusinessId {get;set;}
        public long? GroupId {get;set; }
        public long? MemberId {get;set; }
        public string Number {get;set; }
        public string Block {get;set; }
        public string FileUrl {get;set; }
        public virtual Individual Individual { get; set; }
        public virtual Business Business { get; set; }
        public virtual Group Group { get; set; }
        public virtual Member Member { get; set; }
        public virtual ICollection<ImageFile> Images {get;set;}
    }
}
