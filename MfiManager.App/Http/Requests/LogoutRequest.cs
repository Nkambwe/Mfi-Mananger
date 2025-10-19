using System.Text.Json.Serialization;

namespace MfiManager.App.Http.Requests {
    public class LogoutRequest: MfiHttpRequest {
        [JsonPropertyName("loggedOut")]
        public bool IsLoggedOut { get; set; }

    }
}
