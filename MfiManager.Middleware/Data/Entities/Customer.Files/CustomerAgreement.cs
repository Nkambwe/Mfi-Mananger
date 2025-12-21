using MfiManager.Middleware.Data.Entities.Customers;

namespace MfiManager.Middleware.Data.Entities.Customer.Files {
    /// <summary>
    /// An agreement attached to the client record
    /// </summary>
    public class CustomerAgreement : FileAttachment {
        public string Document {get;set;}
        public long? PersonId {get;set;}
        public virtual Individual Individual { get; set; }
        public long? BusinessId {get;set;}
        public virtual Business Business { get; set; }
        public long? GroupId {get;set;}
        public virtual Group Group { get; set; }
        public long? MemberId {get;set;}
        public virtual Member Member { get; set; }
    }
}
