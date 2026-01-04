namespace MfiManager.Middleware.Data.Entities.System.Configurations.Parameters {

    public class BusinessConfiguration { 
        /// <summary>
        /// Get/Set custom business filter name 1
        /// </summary>
        public string BusinessFilter1Name { get; set; } = "Business Filter 1";
        /// <summary>
        /// Get/Set whether custom business filter 1 is required
        /// </summary>
        public bool RequireBusinessFilter1 { get; set; } = false;
        /// <summary>
        /// Get/Set custom business filter name 2
        /// </summary>
        public string BusinessFilter2Name { get; set; } = "Business Filter 2";
        /// <summary>
        /// Get/Set whether custom business filter 2 is required
        /// </summary>
        public bool RequireBusinessFilter2 { get; set; } = false;
        /// <summary>
        /// require signatory image
        /// </summary>
        public bool RequireSignatoryPhoto { get; set; }
        /// <summary>
        /// Get/Set whether signatory identification are required
        /// </summary>
        public bool RequireSignatoryIdentification { get; set; }
        /// <summary>
        /// Get/Set whether signatory signatures are required
        /// </summary>
        public bool RequireSignatorySignatures { get; set; }
        /// <summary>
        /// Get/Set whether signatory signatures are required
        /// </summary>
        public string BusinessMailMergeUrl { get; set; }
        
    }
}
