using System.Text.Json.Serialization;

namespace MfiManager.Middleware.Http.Responses {
    /// <summary>
    /// Default C'tr
    /// </summary>
    [method: JsonConstructor]
    public class HttpErrorResponse(int code, string message, string description) {

        [JsonPropertyName("code")]
        public int Code { get; set; } = code;

        [JsonPropertyName("message")]
        public string Message { get; set; } = message;

        [JsonPropertyName("description")]
        public string Description { get; set; } = description;
    }

}
