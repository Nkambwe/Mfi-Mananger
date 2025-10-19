using System.Text.Json.Serialization;

namespace MfiManager.App.Http.Responses {
    /// <summary>
    /// Current user response object
    /// </summary>
    public class CurrentUserResponse {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("pfNumber")]
        public string FileNumber { get; set; }

        [JsonPropertyName("username")]
        public string Username { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }

        [JsonPropertyName("middleName")]
        public string MiddleName { get; set; }

        [JsonPropertyName("lastName")]
        public string LastName { get; set; }
        public string FullName 
            => !string.IsNullOrWhiteSpace(MiddleName)?
            @$"{FirstName} {MiddleName} {LastName}":
            @$"{FirstName} {LastName}";
    }

}
