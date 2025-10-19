using System.Text.Json.Serialization;

namespace MfiManager.App.Http.Responses {

    public class UserResponse {

        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }

        [JsonPropertyName("middleName")]
        public string LastName { get; set; }

         [JsonPropertyName("lastName")]
        public string MiddleName { get; set; }

         [JsonPropertyName("username")]
        public string UserName { get; set; }

         [JsonPropertyName("email")]
        public string EmailAddress { get; set; }

        [JsonPropertyName("displayName")]
        public string DisplayName { get; set; }

        [JsonPropertyName("phoneNumber")]
        public string PhoneNumber { get; set; }

        [JsonPropertyName("pfNumber")]
        public string PFNumber { get; set; }

        [JsonPropertyName("branchId")]
        public long BranchId { get; set; }

        [JsonPropertyName("branchName")]
        public string BranchName { get; set; }

        [JsonPropertyName("roleId")]
        public long RoleId { get; set; }

        [JsonPropertyName("roleName")]
        public string RoleName { get; set; }

        [JsonPropertyName("roleGroup")]
        public string RoleGroup { get; set; }

        [JsonPropertyName("departmentId")]
        public long DepartmentId { get; set; }

        [JsonPropertyName("departmentName")]
        public string DepartmentName { get; set; }

        [JsonPropertyName("departmentUnit")]
        public string UnitName { get; set; }

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; }

        [JsonPropertyName("isVerified")]
        public bool IsVerified { get; set; }

        [JsonPropertyName("isAuthenticated")]
        public bool IsAuthenticated { get; set; }

        [JsonPropertyName("isLogged")]
        public bool IsLogged { get; set; }

        [JsonPropertyName("passwordExpired")]
        public bool PasswordExpired { get; set; }

        [JsonPropertyName("passwordDaysLeft")]
        public int PasswordDaysLeft { get; set; }

        [JsonPropertyName("isLocked")]
        public bool IsLocked { get; set; }

        [JsonPropertyName("lockedOn")]
        public DateTime? LockedDate { get; set; }

        [JsonPropertyName("createdOn")]
        public DateTime? CreatedOn { get; set; }

        [JsonPropertyName("createdBy")]
        public string CreatedBy { get; set; }

        [JsonPropertyName("modifiedOn")]
        public DateTime? ModifiedOn { get; set; }

        [JsonPropertyName("modifiedBy")]
        public string ModifiedBy { get; set; }
    }
}
