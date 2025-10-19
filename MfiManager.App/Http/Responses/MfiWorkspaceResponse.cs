namespace MfiManager.App.Http.Responses {

    /// <summary>
    /// User workspace response
    /// </summary>
    public class MfiWorkspaceResponse {
        public CurrentUserResponse User { get; set; }
        public CurrentRoleResponse Role { get; set; }
        public UserBranchResponse Branch { get; set; }
        public PreferenceResponse Preferences { get; set; }
        public IEnumerable<string> Permissions { get; set; }

    }
}
