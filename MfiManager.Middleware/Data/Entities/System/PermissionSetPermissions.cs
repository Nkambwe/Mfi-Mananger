namespace MfiManager.Middleware.Data.Entities.System {
    public class PermissionSetPermissions {
        public long PermissionSetId {get;set;}
        public PermissionSet PermissionSet {get;set;}   
        public long PermissionId {get;set;}
        public Permission Permission {get;set;}   
    }
}
