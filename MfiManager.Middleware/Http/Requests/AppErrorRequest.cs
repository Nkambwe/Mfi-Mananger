using System.Text.Json.Serialization;

namespace MfiManager.Middleware.Http.Requests {

    public class AppErrorRequest {

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

        [JsonPropertyName("isDeleted")]
        public bool IsDeleted {get; set;}
        
        [JsonPropertyName("status")]
        public string Status { get; set; }

    }

}
