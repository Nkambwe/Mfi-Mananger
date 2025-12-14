namespace MfiManager.Middleware.Data.Entities.System.Configurations.Parameters {
    public abstract class CustomerConfigurationParameter {
        public bool CanGenerateClientNumbers { get; set; }
        /// <summary>
        /// RegEx for user generated client number format
        /// </summary>
        public string ClientNumberFormat { get; set; }
        /// <summary>
        /// Get Or Set Client registration number maximum length
        /// </summary>
        public int ClientNumberLength { get; set; }
        /// <summary>
        /// Get Or Set Client reference number required
        /// </summary>
        public bool RequireReferenceNumbers { get; set; }
        /// <summary>
        /// Get Or Set whether users are allowed to generate own reference numbers
        /// </summary>
        public bool CanGenerateReferenceNumbers { get; set; }
        /// <summary>
        /// RegEx for user generated reference number
        /// </summary>
        public string ReferenceNumberFormat { get; set; }
        /// <summary>
        /// Get Or Set Client reference number maximum length
        /// </summary>
        public int ClientReferenceMaxLength { get; set; }
        /// <summary>
        /// Get Or Set Client statistic number required
        /// </summary>
        public bool RequireStatisticNumbers { get; set; }
        /// <summary>
        /// Get Or Set whether users are allowed to generate own statistic numbers
        /// </summary>
        public bool CanGenerateStatisticNumbers { get; set; }
        /// <summary>
        /// Get Or Set Client statistic number maximum length
        /// </summary>
        public int ClientStatisticMaxLength { get; set; }
        /// <summary>
        /// RegEx for user generated statistic number
        /// </summary>
        public string ClientStatisticFormat { get; set; }
        /// <summary>
        /// Get/Set whether registration fees are required when creating clients
        /// </summary>
        public bool RequireFeesAtRegistration { get; set; }

        /// <summary>
        /// Get/Set whether residence area is required when creating clients
        /// </summary>
        public bool RequireResidenceArea { get; set; }

        /// <summary>
        /// Get/Set whether client is allowed to transact without paying registration fees
        /// </summary>
        public bool CanTransactWithoutFees { get; set; }

         public bool RequireClientApproval { get; set; } = true;
        /// <summary>
        /// Get/Set if user cannot approve a client registered by them
        /// </summary>
        public bool ThirdPartyApproval { get; set; } = true;

        public bool SoftDeleteRecords { get; set; } = false;

        public bool ArchiveSoftDeleteRecords { get; set; } = false;
        /// <summary>
        /// Get/Set whether client contacts identification are required
        /// </summary>
        public bool RequireClientContactIdentification { get; set; }
        
    }
}
