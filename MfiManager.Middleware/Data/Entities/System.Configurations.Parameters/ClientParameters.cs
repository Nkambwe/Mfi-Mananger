using System.Runtime;

namespace MfiManager.Middleware.Data.Entities.System.Configurations.Parameters {

    public class IndividualConfigurationParameters : CustomerConfigurationParameter, IConfigurationParameter {
        /// <summary>
        /// Get/Set whether customer firstName is required
        /// </summary>
        public bool RequireFirstName { get; set; }
        /// <summary>
        /// Get/Set whether customer middle name is required
        /// </summary>
        public bool RequireMiddleName { get; set; }
        /// <summary>
        /// Get/Set whether customer last name is required
        /// </summary>
        public bool RequireLastName { get; set; }
        /// <summary>
        /// Customer required minimum age
        /// </summary>
        public int ClientMinimumAge { get; set; } = 18;
        /// <summary>
        /// Require customer date of birth
        /// </summary>
        public bool RequireClientBirthDate { get; set; } 
        /// <summary>
        /// require customer image
        /// </summary>
        public bool RequireClientPhoto { get; set; }
        /// <summary>
        /// Require customer signature
        /// </summary>
        public bool RequireClientSignature { get; set; }
        /// <summary>
        /// Get/Set whether client contacts are required
        /// </summary>
        public bool RequireClientContacts { get; set; }

        public bool RequireMaritalStatus { get; set; } = false;

        /// <summary>
        /// Get/Set custom client filter name 1
        /// </summary>
        public string CustomFilter1Name { get; set; } = "Client Category 1";

        /// <summary>
        /// Get/Set whether custom  filter 1 is required
        /// </summary>
        public bool RequireCustomFilter1 { get; set; }

        /// <summary>
        /// Get/Set custom client filter name 2
        /// </summary>
        public string CustomFilter2Name { get; set; } = "Client Filter 2";

        /// <summary>
        /// Get/Set whether custom  filter 2 is required
        /// </summary>
        public bool RequireCustomFilter2 { get; set; }

        /// <summary>
        /// Get/Set custom client filter name 3
        /// </summary>
        public string CustomFilter3Name { get; set; } = "Client Filter 3";

        /// <summary>
        /// Get/Set whether custom  filter 3 is required
        /// </summary>
        public bool RequireCustomFilter3 { get; set; }

        public string IndividualClientMailMerge { get; set; }
    }
}
