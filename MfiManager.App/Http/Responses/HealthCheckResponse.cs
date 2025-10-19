using System.Text.Json.Serialization;

namespace MfiManager.App.Http.Responses {
    public class HealthCheckResponse {
        [JsonPropertyName("status")]
        public bool Status { get; set; }

        [JsonPropertyName("isConnected")]
        public bool IsConnected { get; set; }

        [JsonPropertyName("hasCompanies")]
        public bool HasCompany { get; set; }
    }
}
