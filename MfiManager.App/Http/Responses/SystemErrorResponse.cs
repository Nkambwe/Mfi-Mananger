using System.Text.Json.Serialization;

namespace MfiManager.App.Http.Responses {

    /// <summary>
    /// Class represents a response for system error
    /// </summary>
    public class SystemErrorResponse {
        [JsonPropertyName("id")]
        public long Id {get; set;}

        [JsonPropertyName("errorSource")]
        public string Source {get; set;}

        [JsonPropertyName("errorMessage")]
        public string Message  {get; set;}

        [JsonPropertyName("severity")]
        public string Severity {get; set;}

        [JsonPropertyName("stackTrace")]
        public string StackTrace {get; set;}

        [JsonPropertyName("isDeleted")]
        public bool IsDeleted {get; set;}

        [JsonPropertyName("status")]
        public string Status {get; set;}

        [JsonPropertyName("createdOn")]
        public DateTime CreatedOn {get; set;}
    }

}
