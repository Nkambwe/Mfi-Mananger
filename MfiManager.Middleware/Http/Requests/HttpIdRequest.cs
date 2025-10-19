using System.Text.Json.Serialization;

namespace MfiManager.Middleware.Http.Requests {
    /// Class represents a request for an entity by entity ID
    /// </summary>
    public class HttpIdRequest {
        /// <summary>
        /// Get or Set ID for the entity
        /// </summary>
        [JsonPropertyName("entityId")]
        public long EntityId { get; set; }
        /// <summary>
        /// Get or Set value whether to mark entity as deleted
        /// </summary>
        [JsonPropertyName("isDeleted")]
        public bool IsDeleted { get; set; }
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
