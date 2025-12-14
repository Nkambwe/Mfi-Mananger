namespace MfiManager.Middleware.Data.Entities.System {
    public class PermissionSet :BaseEntity {
        public string Code {get;set;}
        public string Description {get;set;}
        public virtual ICollection<SystemRole> Roles {get;set;}=[];
        public virtual ICollection<RoleGroup> RoleGroups { get; set; }
        public virtual ICollection<Permission> Permissions {get;set;}=[];
    }

}
