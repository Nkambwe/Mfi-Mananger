using System.Text.Json.Serialization;

namespace MfiManager.App.Http.Responses {

    public class ValidateUserResponse {

         [JsonPropertyName("id")]
         public long Id { get; set; }

         [JsonPropertyName("isValid")]
         public bool IsValid { get; set; }

         [JsonPropertyName("displayName")]
         public string DisplayName { get; set; } = string.Empty;

         [JsonPropertyName("message")]
         public string Message { get; set; } = string.Empty;
       
    }
}
