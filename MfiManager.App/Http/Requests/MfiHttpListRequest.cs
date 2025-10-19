﻿using System.Text.Json.Serialization;

namespace MfiManager.App.Http.Requests {

    /// <summary>
    /// Class used to make a request for a list of entities
    /// </summary>
    public class MfiHttpListRequest {
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
        /// Get or Set Intended action
        /// </summary>
        [JsonPropertyName("searchTerm")]
        public string SearchTerm { get; set; }
        /// <summary>
        /// Get or Set User IP Address
        /// </summary>
        [JsonPropertyName("ipAddress")]
        public string IPAddress { get; set; }
        /// <summary>
        /// Get or Set Page Index
        /// </summary>
        public int PageIndex { get; set; }
        /// <summary>
        /// Get or Set Page size
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// Get or Set sort parameter
        /// </summary>
        public string SortBy { get; set; }
        /// <summary>
        /// Get or Set sort direction
        /// </summary>
        public string SortDirection { get; set; }
        /// <summary>
        /// Get or Set flag whether to include deleted items
        /// </summary>
        public bool IncludeDeleted { get; set; }
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
