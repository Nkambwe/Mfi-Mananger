namespace MfiManager.Middleware.Data.Entities.System.Configurations.Parameters {
    /// <summary>
    /// Application user settings parameters
    /// </summary>
    public class UserSettingsParameters : IConfigurationParameter {
        [ConfigParam(name: "UsernamesEnabled", description: "Check whether usernames are used for login instead of emails", paramType: "bool")]
        public string UsernamesEnabled { get; set; }
        [ConfigParam(name: "CheckUsernameAvailabilityEnabled", description: "Check whether users can check the availability of usernames (when registering or changing on the 'My Account' page)", paramType: "bool")]
        public string CheckUsernameAvailabilityEnabled { get; set; }
        [ConfigParam(name: "AllowUsersToChangeUsernames", description: "Check whether users are allowed to change their usernames", paramType: "bool")]
        public string AllowUsersToChangeUsernames { get; set; }
        [ConfigParam(name: "UsernameValidationEnabled", description: "Check whether username will be validated (when registering or changing on the 'My Account' page)", paramType: "bool")]
        public string UsernameValidationEnabled { get; set; }
        [ConfigParam(name: "UsernameValidationUseRegex", description: "Check whether username will be validated using regex (when registering or changing on the 'My Account' page)", paramType: "bool")]
        public string UsernameValidationUseRegex { get; set; }
        [ConfigParam(name: "UsernameValidationRule", description: "Reg expression rule for validating usename format", paramType: "string")]
        public string UsernameValidationRule { get; set; }
        [ConfigParam(name: "DefaultPasswordFormat", description: "Reg expression rule for validating password format", paramType: "string")]
        public string DefaultPasswordFormat { get; set; }
        [ConfigParam(name: "HashedPasswordFormat", description: "Check whether to use Hashed passwords, a customer password format (SHA1, MD5) when passwords are hashed (DO NOT edit in production environment)", paramType: "bool")]
        public string HashedPasswordFormat { get; set; }
        [ConfigParam(name: "PasswordMinLength", description: "Length of user passwords", paramType: "int")]
        public string PasswordMinLength { get; set; }
        [ConfigParam(name: "PasswordRequireLowercase", description: "Check whether password are have least one lowercase", paramType: "bool")]
        public string PasswordRequireLowercase { get; set; }
        [ConfigParam(name: "PasswordRequireUppercase", description: "Check whether password are have least one uppercase", paramType: "bool")]
        public string PasswordRequireUppercase { get; set; }
        [ConfigParam(name: "PasswordRequireNonAlphanumeric", description: "Check whether password are have least one non alphanumeric character", paramType: "bool")]
        public string PasswordRequireNonAlphanumeric { get; set; }
        [ConfigParam(name: "PasswordRequireDigit", description: "Check whether password are have least one digit", paramType: "bool")]
        public string PasswordRequireDigit { get; set; }
        [ConfigParam(name: "UnDuplicatedPasswordsNumber", description: "Number of passwords that should not be the same as the previous one; 0 if the customer can use the same password time after time", paramType: "int")]
        public string UnDuplicatedPasswordsNumber { get; set; }
        [ConfigParam(name: "PasswordRecoveryLinkDaysValid", description: "Number of days for password recovery link. Set to 0 if it doesn't expire.", paramType: "int")]
        public string PasswordRecoveryLinkDaysValid { get; set; }
        [ConfigParam(name: "PasswordLifetime", description: "Number of days for password expiration", paramType: "int")]
        public string PasswordLifetime { get; set; }
        [ConfigParam(name: "FailedPasswordAllowedAttempts", description: "Maximum login failures to lockout account. Set 0 to disable this feature", paramType: "int")]
        public string FailedPasswordAllowedAttempts { get; set; }
        [ConfigParam(name: "FailedPasswordLockoutMinutes", description: "Number of minutes to lockout users (for login failures).", paramType: "int")]
        public string FailedPasswordLockoutMinutes { get; set; }
        [ConfigParam(name: "UserRegistrationType", description: "User registration type", paramType: "string")]
        public string UserRegistrationType { get; set; }
        [ConfigParam(name: "AllowUsersToUploadAvatars", description: "Check whether users are allowed to upload avatars.", paramType: "bool")]
        public string AllowUsersToUploadAvatars { get; set; }
        [ConfigParam(name: "AvatarMaximumSizeBytes", description: "Maximum avatar size (in bytes)", paramType: "int")]
        public string AvatarMaximumSizeBytes { get; set; }
        [ConfigParam(name: "DefaultAvatarEnabled", description: "Check whether to display default user avatar.", paramType: "bool")]
        public string DefaultAvatarEnabled { get; set; }
        [ConfigParam(name: "NotifyNewUserRegistration", description: "Check whether 'New user' notification message should be sent to a branch manager", paramType: "bool")]
        public string NotifyNewUserRegistration { get; set; }
        [ConfigParam(name: "OnlineUserMinutes", description: "Number of minutes for 'online users' module", paramType: "int")]
        public int OnlineUserMinutes { get; set; }
        [ConfigParam(name: "UserIpAddresses", description: "Check whether system should store user IP Addresses", paramType: "bool")]
        public string UserIpAddresses { get; set; }
        [ConfigParam(name: "LastActivityMinutes", description: "Number of minutes for 'last activity' module", paramType: "int")]
        public string LastActivityMinutes { get; set; }
        [ConfigParam(name: "SoftDeleteUser", description: "Check whether user records should be marked as deleted(soft delete) or permanently deleted", paramType: "bool")]
        public string SoftDeleteUser { get; set; }
        [ConfigParam(name: "EmailConfirmation", description: "Check whether user should enter their email address twise for confirmation", paramType: "bool")]
        public string EmailConfirmation { get; set; }
        [ConfigParam(name: "TimeoutUserSession", description: "Check whether user session should timeout", paramType: "bool")]
        public string TimeoutUserSession { get; set; }
        [ConfigParam(name: "SystemIdleTime", description: "Number of minutes system can remain idle before session closure", paramType: "int")]
        public string SystemIdleTime { get; set; }
        [ConfigParam(name: "EnabledUsernameField", description: "Check whether username field is enabled", paramType: "bool")]
        public string EnabledUsernameField { get; set; }
        [ConfigParam(name: "RequireUsernameField", description: "Check whether username field is required", paramType: "bool")]
        public string UsernameRequired { get; set; }
        [ConfigParam(name: "EnablePhone", description: "Check whether user phone field is enabled", paramType: "bool")]
        public bool EnablePhone { get; set; }
        [ConfigParam(name: "PhoneRequired", description: "Check whether user phone field is required", paramType: "bool")]
        public bool PhoneRequired { get; set; }
        [ConfigParam(name: "EnabledBranchField", description: "Check whether user branch field is enabled", paramType: "bool")]
        public string EnabledBranchField { get; set; }
        [ConfigParam(name: "RequireUserBranchField", description: "Check whether user branch field is required", paramType: "bool")]
        public string BranchRequired { get; set; }
        [ConfigParam(name: "EnableRegion", description: "Check whether user region field is enabled", paramType: "bool")]
        public string EnableRegion { get; set; }
        [ConfigParam(name: "RegionRequired", description: "Check whether user reqgion field is required", paramType: "bool")]
        public string RegionRequired { get; set; }
        [ConfigParam(name: "ShowLoginPasswordReset", description: "Check whether to display forgot password link at login", paramType: "bool")]
        public string ShowLoginPasswordReset { get; set; }
    }
}
