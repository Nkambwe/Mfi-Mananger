namespace MfiManager.Middleware.Data.Entities.System {

    public class DelegatePermission : BaseEntity { 
        public bool Revoke {get;set;}
        public DateTime StartDate {get;set;}
        public DateTime? ExpiryDate {get;set;}
        public long SystemUserId { get; set; }
        public virtual SystemUser SystemUser { get; set; }
        public long PermissionId { get; set; }
        public virtual Permission Pemission { get; set; }
    }

}
