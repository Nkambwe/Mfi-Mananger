using MfiManager.App.Enums;

namespace MfiManager.App.ViewModels {
    public class LoginModel {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public bool RememberMe { get; set; }
        public bool IsUsernameValidated { get; set; } = false;
        public string DisplayName { get; set; } = string.Empty; 
        public LoginStage CurrentStage { get; set; } = LoginStage.Username;
    }
}
