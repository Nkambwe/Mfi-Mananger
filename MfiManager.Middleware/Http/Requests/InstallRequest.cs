using System.Text.Json.Serialization;

namespace MfiManager.Middleware.Http.Requests {
    public class InstallRequest {

        [JsonPropertyName("companyName")]
        public string CompanyName { get; set; }

        [JsonPropertyName("alias")]
        public string CompanyAlias { get; set; }

        [JsonPropertyName("regNumber")]
        public string RegNumber { get; set; }

       [JsonPropertyName("userId")]
        public long UserId { get; set; }

        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }

        [JsonPropertyName("middleName")]
        public string MiddleName { get; set; }

        [JsonPropertyName("lastName")]
        public string LastName { get; set; }

        [JsonPropertyName("emailAddress")]
        public string EmailAddress { get; set; }

        [JsonPropertyName("contactNumber")]
        public string ContactNumber { get; set; }

        [JsonPropertyName("username")]
        public string Username { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; }

        [JsonPropertyName("databaseProvider")]
        public string DatabaseProvider {get; set; }

        [JsonPropertyName("minimumVersion")]
        public string MinimumVersion { get; set; }
        
        [JsonPropertyName("versionCheckTime")]
        public string VersionCheckTime { get; set; }

        [JsonPropertyName("defaultLanguage")]
        public string DefaultLanguage { get; set; }

        [JsonPropertyName("action")]
        public string Action { get; set; }

        [JsonPropertyName("ipAddress")]
        public string IPAddress { get; set; }

        [JsonPropertyName("encrypts")]
        public List<string> Encrypts { get; set; }

        [JsonPropertyName("decrypts")]
        public List<string> Decrypts { get; set; }
    }

}
