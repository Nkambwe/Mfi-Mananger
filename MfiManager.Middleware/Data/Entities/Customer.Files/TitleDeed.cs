using MfiManager.Middleware.Data.Entities.Customers;

namespace MfiManager.Middleware.Data.Entities.Customer.Files {
    /// <summary>
    /// Title deed attached to a client's record
    /// </summary>
    public class TitleDeed : FileAttachment {
        public string PlotNumber {get;set; }
        public string Block {get;set; }
        public string Location {get;set; }
        public long? PersonId {get;set; }   
        public virtual Individual Individual { get; set; }
        public long? BusinessId {get;set;}
        public virtual Business Business { get; set; }
        public long? GroupId {get;set; }
        public virtual Group Group { get; set; }
        public long? MemberId {get;set; }
        public virtual Member Member { get; set; }
        public virtual ICollection<ImageFile> Images {get;set;}
    }
}
