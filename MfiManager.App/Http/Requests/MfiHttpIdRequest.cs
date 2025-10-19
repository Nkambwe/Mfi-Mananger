using System.Text.Json.Serialization;

namespace MfiManager.App.Http.Requests {
    /// <summary>
    /// Class represents a request for an entity by entity ID
    /// </summary>
    public class MfiHttpIdRequest {
        /// <summary>
        /// Get or Set ID for the entity
        /// </summary>
        [JsonPropertyName("entityId")]
        public long EntityId { get; set; }
        /// <summary>
        /// Get or Set value whether to include deleted records
        /// </summary>
        [JsonPropertyName("includeDeleted")]
        public bool IncludeDeleted { get; set; }
        /// <summary>
        /// Get or Set ID of user sending request
        /// </summary>
        [JsonPropertyName("userId")]
        public long UserId { get; set; }
        /// <summary>
        /// Get or Set Intended action
        /// </summary>
        [JsonPropertyName("action")]
        public string Action { get; set; }
        /// <summary>
        /// Get or Set User IP Address
        /// </summary>
        [JsonPropertyName("ipAddress")]
        public string IPAddress { get; set; }
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
