using System.Text.Json.Serialization;

namespace MfiManager.App.Http.Responses {

    /// <summary>
    /// Organization branch response
    /// </summary>
    public class BranchResponse {
        /// <summary>
        /// Gets or sets branch Id
        /// </summary>
        [JsonPropertyName("id")]
        public long Id { get; set; }
        /// <summary>
        /// Gets or sets branch code
        /// </summary>
        [JsonPropertyName("branchCode")]
        public string BranchCode { get; set; }
        /// <summary>
        /// Gets or sets branch name
        /// </summary>
        [JsonPropertyName("branchName")]
        public string BranchName { get; set; }
        
        [JsonPropertyName("address")]
        public string Address { get; set; }

        [JsonPropertyName("city")]
        public string City  { get; set; }

        [JsonPropertyName("postalAddress")]
        public string PostalAddress { get; set; }

        [JsonPropertyName("contactNumber")]
        public string ContactNumber { get; set; }

        /// <summary>
        /// Get or set the record as deleted
        /// </summary>
        [JsonPropertyName("isDeleted")]
        public bool IsDeleted { get; set; }
        /// <summary>
        /// Get or Set Creation date
        /// </summary>
        [JsonPropertyName("createdOn")]
        public DateTime CreatedOn { get; set; }
        /// <summary>
        /// Get or Set Person who created record
        /// </summary>
        [JsonPropertyName("createdBy")]
        public string CreatedBy { get; set; }
        /// <summary>
        /// Get or Set Modification Date
        /// </summary>
        [JsonPropertyName("modifiedOn")]
        public DateTime? LastModifiedOn { get; set; }
        /// <summary>
        /// Get or Set Person who modified record
        /// </summary>
        [JsonPropertyName("modifiedBy")]
        public string LastModifiedBy { get; set; }
    }

}
