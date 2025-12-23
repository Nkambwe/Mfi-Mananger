
namespace MfiManager.Middleware.Data.Entities.Customers {
    /// <summary>
    /// Person next of kin records and contact information
    /// </summary>
    public class CustomerContact : BaseEntity {
        public string Series {get;set; }
        public string ContactName {get;set; }
        public string Telephone {get;set; }
        public string Mobile {get;set; }
        public string Email {get;set; }
        public string Relationship {get;set;}
        public long? PersonId {get;set; }
        public virtual Individual Individual { get; set; }
        public long? BusinessId {get;set; }
        public virtual Business Business { get; set; }
        public long? MemberId {get;set; }
        public virtual Member Member { get; set; }
        public string Notes {get;set; }
    }
}
