using System.Text.Json.Serialization;

namespace MfiManager.App.Http.Requests {
    public class ValidateUserRequest {

        [JsonPropertyName("username")]
        public string Username { get; set; } = string.Empty;

        [JsonPropertyName("ipAddress")]
        public string IPAddress { get; set; } = string.Empty;

        [JsonPropertyName("encrypt")]
        public string[] Encrypt {get; set; } = [];

        [JsonPropertyName("dycrypt")]
        public string[] Decrypt {get; set; } = ["firstName", "lastName"];

    }
}
