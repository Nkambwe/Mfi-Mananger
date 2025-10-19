using System.Text.Json.Serialization;

namespace MfiManager.Middleware.Http.Responses {
    public class StatusResponse {
        
        [JsonPropertyName("status")]
        public bool Status { get; set; }
    }
}
