using MfiManager.Middleware.Data.Entities.Operations.Branches;

namespace MfiManager.Middleware.Data.Entities.System {
    public class EntityAccess:BaseEntity {
        public long BranchId { get; set; }
        public long EntityId  { get; set; }
        public string EntityName  { get; set; }
        /// <summary>
        /// Exclude this entity from branch access
        /// </summary>
        public bool Exclude {get;set; }
        public virtual Branch Branch { get; set;  }
    }
}
