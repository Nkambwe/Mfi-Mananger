using MfiManager.Middleware.Enums;

namespace MfiManager.Middleware.Data.Entities.System.Configurations.Parameters {

    public class UserConfiguration {

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
        /// Gets or sets a value indicating whether phone number will be validated (when registering or changing on the 'My Account' page)
        /// </summary>
        public bool PhoneNumberValidationEnabled { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether phone number will be validated using regex (when registering or changing on the 'My Account' page)
        /// </summary>
        public bool PhoneNumberValidationUseRegex { get; set; }

        /// <summary>
        /// Gets or sets a phone number validation rule
        /// </summary>
        public string PhoneNumberValidationRule { get; set; }

        /// <summary>
        /// Default password format for customers
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
        /// Gets or sets a value indicating whether users location is shown
        /// </summary>
        public bool ShowUsersLocation { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to show user join date
        /// </summary>
        public bool ShowUsersJoinDate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether users are allowed to view profiles of other users
        /// </summary>
        public bool AllowViewingProfiles { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether 'New user' notification message should be sent to a campus owner
        /// </summary>
        public bool NotifyNewUserRegistration { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to hide 'Download material' tab on 'My account' page
        /// </summary>
        public bool HideDownloadMaterialTab { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to hide 'Back in stock subscriptions' tab on 'My account' page
        /// </summary>
        public bool HideBackInStockSubscriptionsTab { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to validate user when downloading material
        /// </summary>
        public bool DownloadMaterialValidateUser { get; set; }

        /// <summary>
        /// Gets or sets a value indicating the number of minutes for 'online users' module
        /// </summary>
        public int OnlineUserMinutes { get; set; }

        /// <summary>
        /// Gets or sets a value indicating we should store last visited page URL for each user
        /// </summary>
        public bool CampusLastVisitedPage { get; set; }

        /// <summary>
        /// Gets or sets a value indicating we should store IP addresses of users
        /// </summary>
        public bool CampusIpAddresses { get; set; }

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

        /// <summary>
        /// Gets or sets a value indicating whether registration is required for download products
        /// </summary>
        public bool RequireRegistrationForDownloadMaterials { get; set; }

        /// <summary>
        /// Gets or sets interval (in minutes) with which the Delete Guest Task runs
        /// </summary>
        public int DeleteGuestTaskOlderThanMinutes { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether 'First Name' is enabled
        /// </summary>
        public bool UserNameEnabled { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether 'First Name' is required
        /// </summary>
        public bool EnabledUsernameField { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether 'Phone number' is enabled
        /// </summary>
        public bool PhoneEnabled { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether 'Phone number' is required
        /// </summary>
        public bool PhoneRequired { get; set; }

        public bool TimeoutUserSession { get; set; }
        public int SystemIdleTime { get; set; }
        public bool EnabledBranchField { get; set; }
        public bool BranchRequired { get; set; }
        public bool EnableRegion { get; set; }
        public bool RegionRequired { get; set; }
        public bool ShowLoginPasswordReset { get; set; }

    }

}
