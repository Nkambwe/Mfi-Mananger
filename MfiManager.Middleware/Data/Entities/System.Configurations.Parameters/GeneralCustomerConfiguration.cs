namespace MfiManager.Middleware.Data.Entities.System.Configurations.Parameters {
    public class GeneralCustomerConfiguration {
        /// <summary>
        /// Check whether user can manually enter customer registration numbers
        /// </summary>
        public bool AllowManualRegistrationNumbers { get; set; }=false;
        /// <summary>
        /// RegEx for registration number format
        /// </summary>
        public string RegistrationNumberFormat { get; set; }
        /// <summary>
        /// Get Or Set Customer registration number maximum length
        /// </summary>
        public int RegistrationNumberLength { get; set; }
        /// <summary>
        /// Get Or Set Client reference number required
        /// </summary>
        public bool RequireReferenceNumbers { get; set; }
        /// <summary>
        /// Get Or Set whether users are allowed to generate own reference numbers
        /// </summary>
        public bool AllowManualReferenceNumbers { get; set; }
        /// <summary>
        /// RegEx for reference number format
        /// </summary>
        public string ReferenceNumberFormat { get; set; }
        /// <summary>
        /// Get Or Set Client reference number maximum length
        /// </summary>
        public int ReferenceNumberLength { get; set; }
        /// <summary>
        /// Get Or Set Client statistic number required
        /// </summary>
        public bool RequireStatisticNumbers { get; set; }
        /// <summary>
        /// Get Or Set whether users are allowed to generate own statistic numbers
        /// </summary>
        public bool AllowManualStatisticNumbers { get; set; }
        /// <summary>
        /// Get Or Set Client statistic number maximum length
        /// </summary>
        public int StatisticNumberLength { get; set; }
        /// <summary>
        /// RegEx for user generated statistic number
        /// </summary>
        public string StatisticNumberFormat { get; set; }
        public bool RequirePermanentAddress { get; set; }= false;
        public bool RequirePostalAddress { get; set; }= false;
        public bool RequireTelephoneNumber { get; set; }= false;
        public bool RequireMobileNumber { get; set; }= false;
        public bool RequireCustomerEmail { get; set; }= false;
        public bool RequireVillageOfresidence { get; set; }= false;
        public bool RequireParishOfResidence { get; set; }= false;
        public bool RequireDistrictOfresidence { get; set; }= false;
        public bool RequireCityOfResidence { get; set; }= false;
        public bool RequireTownOfresidence { get; set; }= false;
        /// <summary>
        /// Get/Set whether registration fees are required when creating clients
        /// </summary>
        public bool RequireRegistrationFees { get; set; }
        
        /// <summary>
        /// Get/Set whether custom  filter 1 is required
        /// </summary>
        public bool RequireFilter1 { get; set; }

        /// <summary>
        /// Get/Set custom client filter name 2
        /// </summary>
        public string Filter2Name { get; set; } = "Custome Filter 2";

        /// <summary>
        /// Get/Set whether custom  filter 2 is required
        /// </summary>
        public bool RequireFilter2 { get; set; }

        /// <summary>
        /// Get/Set custom client filter name 3
        /// </summary>
        public string Filter3Name { get; set; } = "Custome Filter 3";

        /// <summary>
        /// Get/Set whether custom  filter 3 is required
        /// </summary>
        public bool RequireFilter3 { get; set; }

        /// <summary>
        /// Get/Set whether client is allowed to transact without paying registration fees
        /// </summary>
        public bool CanTransactWithoutFees { get; set; }

         public bool RequireClientApproval { get; set; } = true;
        /// <summary>
        /// Get/Set if user cannot approve a client registered by them
        /// </summary>
        public bool CanAppovalCustomerCreatedByThem { get; set; } = true;

        public bool SoftDeleteCustomerRecords { get; set; } = false;

        public bool ArchiveSoftDeleteRecords { get; set; } = false;
        
    }
}
