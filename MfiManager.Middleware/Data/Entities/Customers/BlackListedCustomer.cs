using MfiManager.Middleware.Data.Entities.Customers.Support;
using MfiManager.Middleware.Data.Entities.Operations.Branches;

namespace MfiManager.Middleware.Data.Entities.Customers {
    /// <summary>
    /// Black listed client record
    /// </summary>
    public class BlackListedCustomer : BaseEntity{
        public long? PersonId  {get; set; }
        public long? MemberId  {get; set; }
        public long? BusinessId  {get; set; }
        public DateTime ListedOn  {get; set; }
        public long ReasonId {get; set; }
        public long BranchId {get; set; }
        public DateTime? UnListedOn  {get; set; }
        public string Notes  {get; set; }
        public virtual Reason Reason { get; set; }
        public virtual Branch Branch { get; set; }
        public virtual Individual Person { get; set; }
        public virtual Member Member { get; set; }
        public virtual Business Business { get; set; }
    }
}
