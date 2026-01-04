namespace MfiManager.Middleware.Data.Entities.System {
    public class SystemRolePermissionSet {
        public long PermissionSetId {get;set;}
        public PermissionSet PermissionSet {get;set;}   
        public long SystemRoleId {get;set;}
        public SystemRole SystemRole {get;set;}
    }

}
