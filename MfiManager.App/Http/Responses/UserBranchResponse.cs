using System.Text.Json.Serialization;

namespace MfiManager.App.Http.Responses {
    /// <summary>
    /// User branch response
    /// </summary>
    public class UserBranchResponse {
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
        /// <summary>
        /// Gets or sets branch alias
        /// </summary>
        [JsonPropertyName("branchAlias")]
        public string BranchAlias { get; set; }
        /// <summary>
        /// Gets or sets company name
        /// </summary>
        [JsonPropertyName("companyName")]
        public string CompanyName { get; set; }
        /// <summary>
        /// Get or set the record as deleted
        /// </summary>
        [JsonPropertyName("isDeleted")]
        public bool IsDeleted { get; set; }
    }

}
