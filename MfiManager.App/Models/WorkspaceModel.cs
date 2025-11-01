namespace MfiManager.App.Models {
    
    /// <summary>
    /// Represents user workspace data containing all user-specific information.
    /// </summary>
    public class WorkspaceModel {
        public long RoleId { get; set; }
        public string RoleName { get; set; } = string.Empty;
        public string RoleGroup { get; set; } = string.Empty;
        public long? CompanyId { get; set; }
        public long? BranchId { get; set; }
        public string BranchCode { get; set; } = string.Empty;
        public string BranchName { get; set; } = string.Empty;
        public bool BranchStatus { get; set; } = false;
        public CurrentUserModel User { get; set; }
        public UserPreferenceModel Preferences { get; set; }
        public IEnumerable<string> Permissions { get; set; }
        public bool IsLiveEnvironment { get; set; }
        public bool HasPermission(string permissionName) => Permissions?.Contains(permissionName) ?? false;
        public bool HasRole(string roleName) => string.Equals(RoleName, roleName, StringComparison.OrdinalIgnoreCase);
    }

}
