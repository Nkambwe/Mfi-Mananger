
namespace MfiManager.Middleware.Data.Entities.System.Configurations.Parameters {

    public class IndividualConfiguration {
        /// <summary>
        /// Get/Set whether customer firstName is required
        /// </summary>
        public bool RequireFirstName { get; set; } = true;
        /// <summary>
        /// Get/Set whether customer middle name is required
        /// </summary>
        public bool RequireMiddleName { get; set; }=false;
        /// <summary>
        /// Get/Set whether customer last name is required
        /// </summary>
        public bool RequireLastName { get; set; }=true;
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
        public bool RequireNextOfKin { get; set; }
        /// <summary>
        /// Get/Set whether customer's next of kin identification are required
        /// </summary>
        public bool RequireNextOfKinIdentification { get; set; }
        /// <summary>
        /// Get/Set whether customer's marital status is required
        /// </summary>
        public bool RequireMaritalStatus { get; set; } = false;
        /// <summary>
        /// Check whether customer's spouse's name is required
        /// </summary>
        public bool RequireSpouseName { get; set; }=false;
        
        /// <summary>
        /// Get/Set whether customer's nationality is required
        /// </summary>
        public bool RequireNationality { get; set; }= false;
        /// <summary>
        /// Get/Set whether Father's name is required
        /// </summary>
        public bool RequireNameOfFather { get; set; }= false;
        /// <summary>
        /// Get/Set whether Mother's name is required
        /// </summary>
        public bool RequireNameOfMother { get; set; }= false;
        /// <summary>
        /// Get/Set whether Mother's name is required
        /// </summary>
        public bool RequireNumberOfChildren { get; set; }= false;
        /// <summary>
        /// Get/Set whether Mother's name is required
        /// </summary>
        public bool RequireNumberOfDependents { get; set; }= false;
        
        /// <summary>
        /// Get/Set whether customer's proffession is required
        /// </summary>
        public bool RequireProfession { get; set; }= false;
        /// <summary>
        /// Get/Set whether customer's level of education is required
        /// </summary>
        public bool RequireEducation { get; set; }= false;
        /// <summary>
        /// Get/Set custom client filter name 1
        /// </summary>
        public string Filter1Name { get; set; } = "Customer Filter 1";
        /// <summary>
        /// Folder for mail merged customer files for individual customers
        /// </summary>
        public string IndividualMailMergeUrl { get; set; }
    }
}
