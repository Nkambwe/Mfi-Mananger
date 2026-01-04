using MfiManager.Middleware.Data.Entities.Operations.Branches;

namespace MfiManager.Middleware.Data.Entities.System {

    /// <summary>
    /// _db.EntityAccess.AddRange(
    //new EntityAccess { BranchId = 10, EntityName = "Customer", CanRead = true },
    //new EntityAccess { BranchId = 10, EntityName = "SystemUser", CanRead = false }
    //await _db.SaveChangesAsync();
    /// </summary>
    public class EntityAccess: BaseEntity {
        public string EntityName  { get; set; }
        public bool CanRead {get;set; }
        public long BranchId { get; set; }
        public virtual Branch Branch { get; set;  }
    }

}
