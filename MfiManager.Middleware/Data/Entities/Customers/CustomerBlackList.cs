using MfiManager.Middleware.Data.Entities.Customers.Support;
using MfiManager.Middleware.Data.Entities.Operations.Branches;

namespace MfiManager.Middleware.Data.Entities.Customers {
    /// <summary>
    /// Black listed client record
    /// </summary>
    public class CustomerBlackList : BaseEntity{
        public DateTime ListedOn  {get; set; }
        public DateTime? UnListedOn  {get; set; }
        public long ReasonId {get; set; }
        public virtual Reason Reason { get; set; }
        public long? PersonId  {get; set; }
        public virtual Individual Individual { get; set; }
        public long? MemberId  {get; set; }
        public virtual Member Member { get; set; }
        public long? BusinessId  {get; set; }
        public virtual Business Business { get; set; }
        public long? GroupId  {get; set; }
        public virtual Group Group { get; set; }
        public string Notes  {get; set; }
    }
}
