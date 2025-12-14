namespace MfiManager.Middleware.Data.Entities.System {
    public class DelegatePermission : BaseEntity { 
        public long PermissionId { get; set; }
        public long UserId { get; set; }
        public bool Revoke {get;set;}
        public DateTime StartDate {get;set;}
        public DateTime? ExpiryDate {get;set;}
        public virtual SystemUser User { get; set; }
        public virtual Permission Pemission { get; set; }
    }

}
