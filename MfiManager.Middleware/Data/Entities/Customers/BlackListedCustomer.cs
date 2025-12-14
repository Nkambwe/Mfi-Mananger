using MfiManager.Middleware.Data.Entities.Customers.Support;
using MfiManager.Middleware.Data.Entities.Operations.Branches;

namespace MfiManager.Middleware.Data.Entities.Customers {
    /// <summary>
    /// Black listed client record
    /// </summary>
    public class BlackListedCustomer : BaseEntity{
        public long? BranchId {get; set; }
        public string Client  {get; set; }
        public DateTime ListedOn  {get; set; }
        public long ReasonId {get; set; }
        public DateTime? UnListedOn  {get; set; }
        public string Notes  {get; set; }
        public virtual Reason Reason { get; set; }
        public virtual Branch Branch { get; set; }
    }
}
