using System.ComponentModel;

namespace MfiManager.App.Enums {
    public enum UserActions {
        [Description("Company Registration")]
        CREATECOMPANY = 0,
        [Description("User Login")]
        LOGIN = 1,
        [Description("User Logout")]
        LOGOUT = 2,
        [Description("Login Username validation")]
        USERNAMEVALIDATION = 3,
        [Description("User authentication")]
        AUTHENTICATE = 4,
        [Description("Retrieve user record by ID")]
        RETRIVEUSERBYID = 5,
        [Description("Retrieve user record by Username")]
        RETRIVEUSERBYNAME = 6,
        [Description("Retrieve user record by email")]
        RETRIVEUSERBYEMAIL = 7,
        [Description("Update user login status")]
        UPDATEUSERSTATUS = 8,
    }
}
