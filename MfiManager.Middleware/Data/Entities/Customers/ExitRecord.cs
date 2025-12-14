using MfiManager.Middleware.Data.Entities.Customers.Support;
using MfiManager.Middleware.Data.Entities.Operations.Branches;
using MfiManager.Middleware.Enums;

namespace MfiManager.Middleware.Data.Entities.Customers {
    public class ExitRecord : BaseEntity {
        public long? BranchId {get;set; }
        public string Client {get;set; }
        public string Member {get;set; }
        public DateTime ExitedOn {get;set; }
        public ClientType ClientType {get;set; }
        public long? ReasonId {get;set; }
        public virtual Branch Branch { get; set; }
        public virtual Reason Reason { get; set; }
    }
}
