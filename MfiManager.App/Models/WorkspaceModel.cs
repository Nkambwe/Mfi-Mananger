namespace MfiManager.App.Models {
    
    /// <summary>
    /// Represents user workspace data containing all user-specific information.
    /// </summary>
    public class WorkspaceModel {
        public long RoleId { get; set; }
        public string Role { get; set; }
        public BranchModel Branch { get; set; }
        public CurrentUserModel User { get; set; }
        public UserPreferenceModel Preferences { get; set; }
        public IEnumerable<string> Permissions { get; set; }
        public bool IsLiveEnvironment { get; set; }
        public bool HasPermission(string permissionName) => Permissions?.Contains(permissionName) ?? false;
        public bool HasRole(string roleName) => string.Equals(Role, roleName, StringComparison.OrdinalIgnoreCase);
    }

}
