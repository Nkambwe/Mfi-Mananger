using System.Text.Json.Serialization;

namespace MfiManager.App.Http.Requests {

    public class MfiLoginRequest: MfiHttpRequest {

         [JsonPropertyName("username")]
         public string Username { get; set; } = string.Empty;

         [JsonPropertyName("password")]
         public string Password { get; set; } = string.Empty;

         [JsonPropertyName("rememberMe")]
         public bool RememberMe { get; set; }
        
         [JsonPropertyName("isValidated")]
         public bool IsValidated { get; set; } = false;

         [JsonPropertyName("isPersistent")]
         public bool IsPersistent { get; set; }
    }

}
