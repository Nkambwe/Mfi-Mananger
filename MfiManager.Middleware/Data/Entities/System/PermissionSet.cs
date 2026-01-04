namespace MfiManager.Middleware.Data.Entities.System {
    public class PermissionSet :BaseEntity {
        public string Series {get;set;}
        public string Description {get;set;}
        public virtual ICollection<SystemRolePermissionSet> SystemRoles {get;set;}=[];
        public virtual ICollection<RoleGroupPermissionSet> RoleGroups { get; set; }
        public virtual ICollection<PermissionSetPermissions> Permissions {get;set;}=[];
    }
}
