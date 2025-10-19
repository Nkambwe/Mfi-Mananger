using System.Text.Json.Serialization;

namespace MfiManager.App.Http.Requests {
    /// <summary>
    /// Class sends system error request to be saved in the database
    /// </summary>
    public class SystemErrorRequest {
        [JsonPropertyName("companyId")]
        public long CompanyId { get; set; }

        [JsonPropertyName("userId")]
        public long UserId { get; set; }

        [JsonPropertyName("ipAddress")]
        public string IPAddress { get; set; }

        [JsonPropertyName("errorMessage")]
        public string Message { get; set; }

        [JsonPropertyName("errorSource")]
        public string Source { get; set; }

        [JsonPropertyName("severity")]
        public string Severity { get; set; }

        [JsonPropertyName("stackTrace")]
        public string StackTrace { get; set; }
    }
}
