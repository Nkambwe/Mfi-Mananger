using MfiManager.Middleware.Enums;

namespace MfiManager.Middleware.Data.Entities.System.Configurations.Parameters {
    /// <summary>
    /// Application user settings parameters
    /// </summary>
    public class UserSettingsParameters : IConfigurationParameter {
        /// <summary>
        /// Gets or sets a value indicating whether usernames are used instead of emails
        /// </summary>
        public bool UsernamesEnabled { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether users can check the availability of usernames (when registering or changing on the 'My Account' page)
        /// </summary>
        public bool CheckUsernameAvailabilityEnabled { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether users are allowed to change their usernames
        /// </summary>
        public bool AllowUsersToChangeUsernames { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether username will be validated (when registering or changing on the 'My Account' page)
        /// </summary>
        public bool UsernameValidationEnabled { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether username will be validated using regex (when registering or changing on the 'My Account' page)
        /// </summary>
        public bool UsernameValidationUseRegex { get; set; }

        /// <summary>
        /// Gets or sets a username validation rule
        /// </summary>
        public string UsernameValidationRule { get; set; }

        /// <summary>
        /// Default password format for users
        /// </summary>
        public PasswordFormat DefaultPasswordFormat { get; set; }

        /// <summary>
        /// Gets or sets a customer password format (SHA1, MD5) when passwords are hashed (DO NOT edit in production environment)
        /// </summary>
        public string HashedPasswordFormat { get; set; }

        /// <summary>
        /// Gets or sets a minimum password length
        /// </summary>
        public int PasswordMinLength { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether password are have least one lowercase
        /// </summary>
        public bool PasswordRequireLowercase { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether password are have least one uppercase
        /// </summary>
        public bool PasswordRequireUppercase { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether password are have least one non alphanumeric character
        /// </summary>
        public bool PasswordRequireNonAlphanumeric { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether password are have least one digit
        /// </summary>
        public bool PasswordRequireDigit { get; set; }

        /// <summary>
        /// Gets or sets a number of passwords that should not be the same as the previous one; 0 if the customer can use the same password time after time
        /// </summary>
        public int UnDuplicatedPasswordsNumber { get; set; }

        /// <summary>
        /// Gets or sets a number of days for password recovery link. Set to 0 if it doesn't expire.
        /// </summary>
        public int PasswordRecoveryLinkDaysValid { get; set; }

        /// <summary>
        /// Gets or sets a number of days for password expiration
        /// </summary>
        public int PasswordLifetime { get; set; }

        /// <summary>
        /// Gets or sets maximum login failures to lockout account. Set 0 to disable this feature
        /// </summary>
        public int FailedPasswordAllowedAttempts { get; set; }

        /// <summary>
        /// Gets or sets a number of minutes to lockout users (for login failures).
        /// </summary>
        public int FailedPasswordLockoutMinutes { get; set; }

        /// <summary>
        /// User registration type
        /// </summary>
        public UserRegistrationType UserRegistrationType { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether users are allowed to upload avatars.
        /// </summary>
        public bool AllowUsersToUploadAvatars { get; set; }

        /// <summary>
        /// Gets or sets a maximum avatar size (in bytes)
        /// </summary>
        public int AvatarMaximumSizeBytes { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to display default user avatar.
        /// </summary>
        public bool DefaultAvatarEnabled { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether 'New user' notification message should be sent to a branch manager
        /// </summary>
        public bool NotifyNewUserRegistration { get; set; }

        /// <summary>
        /// Gets or sets a value indicating the number of minutes for 'online users' module
        /// </summary>
        public int OnlineUserMinutes { get; set; }

        /// <summary>
        /// Gets or sets a value indicating we should store IP addresses of users
        /// </summary>
        public bool BranchIpAddresses { get; set; }

        /// <summary>
        /// Gets or sets a value indicating the number of minutes for 'last activity' module
        /// </summary>
        public int LastActivityMinutes { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether deleted user records should be prefixed suffixed with "-DELETED"
        /// </summary>
        public bool SuffixDeletedUsers { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to force entering email twice
        /// </summary>
        public bool EnteringEmailTwice { get; set; }

        #region Form Optional Fields
        /// <summary>
        /// Gets or sets a value indicating whether 'User Name' is enabled
        /// </summary>
        public bool UsernameEnabled { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether 'User Name' is required
        /// </summary>
        public bool UsernameRequired { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether 'Branch' is enabled
        /// </summary>
        public bool BranchEnabled { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether 'Branch' is required
        /// </summary>
        public bool BranchRequired { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether 'Region' is enabled
        /// </summary>
        public bool RegionEnabled { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether 'Region' is required
        /// </summary>
        public bool RegionRequired { get; set; }

        #endregion
    }
}
