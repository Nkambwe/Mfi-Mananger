using System.Text.Json.Serialization;

namespace MfiManager.App.Http.Requests {

    public class InstallationRequest: MfiHttpRequest  {

        [JsonPropertyName("companyName")]
        public string CompanyName { get; set; }

        [JsonPropertyName("alias")]
        public string CompanyAlias { get; set; }

        [JsonPropertyName("regNumber")]
        public string RegNumber { get; set; }
        
        [JsonPropertyName("username")]
        public string Username { get; set; } = "Mfiuser";

        [JsonPropertyName("emailAddress")]
        public string EmailAddress { get; set; }

        [JsonPropertyName("contactNumber")]
        public string ContactNumber { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; }

        [JsonPropertyName("databaseProvider")]
        public string DatabaseProvider {get; set; }

        [JsonPropertyName("minimumVersion")]
        public string MinimumVersion { get; set; }
    }

}
