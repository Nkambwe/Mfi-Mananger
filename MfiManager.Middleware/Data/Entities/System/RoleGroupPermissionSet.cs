namespace MfiManager.Middleware.Data.Entities.System {
    public class RoleGroupPermissionSet {
        public long PermissionSetId {get;set;}
        public PermissionSet PermissionSet {get;set;}   
        public long RoleGroupId {get;set;}
        public RoleGroup RoleGroup {get;set;}
    }

}
