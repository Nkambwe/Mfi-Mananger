using MfiManager.Middleware.Data.Entities.Operations;
using MfiManager.Middleware.Data.Entities.Operations.Branches;


namespace MfiManager.Middleware.Data.Entities.System {

    /// <summary>
    /// Saves EntityName = Customer; FieldName=NationalId;IsEncrypted=true
    /// </summary>
    public class EncryptionSetting: BaseEntity  {
        public string EntityName { get; set; } = default!;
        public string FieldName { get; set; } = default!;
        public bool IsEncrypted { get; set; }
        public long CompanyId { get; set; }
        public virtual Company Company { get; set; }
        public long? BranchId { get; set; } 
        public virtual Branch Branch {get;set;}
        
    }

}
