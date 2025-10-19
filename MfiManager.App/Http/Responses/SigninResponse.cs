using System.Text.Json.Serialization;

namespace MfiManager.App.Http.Responses {
    public class SigninResponse {

         [JsonPropertyName("isSignedIn")]
         public bool IsSignedIn { get; set; }
    }
}
