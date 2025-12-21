using MfiManager.Middleware.Data.Entities.Customers.Support;

namespace MfiManager.Middleware.Data.Entities.Customers {

    public class UnLockedCustomer : BaseEntity {
        public DateTime UnlockedOn {get;set;}
        public string UnlockedBy  {get;set;}
        public long ReasonId {get;set;}
        public Reason Reason {get;set;}
        public long? PersonId  {get;set;}
        public virtual Individual Individual { get; set; }
        public long? MemberId  {get;set;}
        public virtual Member Member { get; set; }
        public long? GroupId  {get;set;}
        public virtual Group Group { get; set; }
        public long? BusinessId  {get;set;}
        public virtual Business Business { get; set; }
        public string Notes  {get;set;}
    }

}
