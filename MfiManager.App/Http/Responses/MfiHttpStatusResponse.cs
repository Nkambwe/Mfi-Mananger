using System.Text.Json.Serialization;

namespace MfiManager.App.Http.Responses {
    /// <summary>
    /// Class represents a boolean response from the server
    /// </summary>
    public class MfiHttpStatusResponse {

        [JsonPropertyName("status")]
        public bool Status { get; set; }
    }

}
