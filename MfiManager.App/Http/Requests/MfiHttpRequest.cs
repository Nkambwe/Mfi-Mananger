using System.Text.Json.Serialization;

namespace MfiManager.App.Http.Requests {
    /// <summary>
    ///Class represent an entity request sent to the API
    /// </summary>
    public class MfiHttpRequest {
        /// <summary>
        /// Get or Set ID of user sending request
        /// </summary>
        [JsonPropertyName("userId")]
        public long UserId { get; set; }
        /// <summary>
        /// Get or Set Intended request action
        /// </summary>
        [JsonPropertyName("requestAction")]
        public string RequestAction { get; set; }
        /// <summary>
        /// Get or Set User IP Address
        /// </summary>
        [JsonPropertyName("ipAddress")]
        public string IPAddress { get; set; }
        /// <summary>
        /// Get Or Set request action
        /// </summary>
        [JsonPropertyName("action")]
        public string Action { get; set; }
        /// <summary>
        /// Get Or Send Fields intended to be encrypted
        /// </summary>
        [JsonPropertyName("encrypts")]
        public string[] EncryptFields { get; set; }
        /// <summary>
        /// Get Or Set Fields intended to be decrypted
        /// </summary>
        [JsonPropertyName("decrypts")]
        public string[] DecryptFields { get; set; }
    }
}
