using MfiManager.Middleware.Data.Entities.Customers;

namespace MfiManager.Middleware.Data.Entities.Customer.Files {
    /// <summary>
    /// An agreement attached to the client record
    /// </summary>
    public class CustomerAgreement : FileAttachment {
        public long? IndividualId {get;set;}
        public long? BusinessId {get;set;}
        public long? GroupId {get;set;}
        public long? MemberId {get;set;}
        public string Document {get;set;}
        public string File {get;set;}
        public virtual Individual Person { get; set; }
        public virtual Business Business { get; set; }
        public virtual Group Group { get; set; }
        public virtual Member Member { get; set; }
    }
}
