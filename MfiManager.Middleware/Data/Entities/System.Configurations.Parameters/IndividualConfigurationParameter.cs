using MfiManager.Middleware.Data.Helpers;

namespace MfiManager.Middleware.Data.Entities.System.Configurations.Parameters {

    public class IndividualConfigurationParameter : IConfigurationParameter {
        [ConfigParam(name: "RequireFirstName", description: "Check whether customer firstName is required", paramType:"bool")]
        public string RequireFirstName { get; set; }
        [ConfigParam(name: "RequireMiddleName", description: "Check whether customer middle name is required", paramType:"bool")]
        public string RequireMiddleName { get; set; }
        [ConfigParam(name: "RequireMiddleName", description: "Check whether customer last name is required", paramType:"bool")]
        public string RequireLastName { get; set; }
        [ConfigParam(name: "ClientMinimumAge", description: "Customer required minimum age", paramType:"int")]
        public string ClientMinimumAge { get; set; }
        [ConfigParam(name: "RequireClientBirthDate", description: "Require customer date of birth", paramType:"bool")]
        public string RequireClientBirthDate { get; set; }
        [ConfigParam(name: "RequireClientPhoto", description: "Check whether  to require customer image", paramType:"bool")]
        public string RequireClientPhoto { get; set; }
        [ConfigParam(name: "RequireClientSignature", description: "Check whether to require customer signature", paramType:"bool")]
        public string RequireClientSignature { get; set; }
        [ConfigParam(name: "RequireClientContacts", description: "Check whether customer's next of kin are required", paramType:"bool")]
        public string RequireNextOfKin { get; set; }
        [ConfigParam(name: "RequireNextOfKinIdentification", description: "Check whether identification is required for customer's next of kin", paramType:"bool")]
        public string RequireNextOfKinIdentification { get; set; }
        [ConfigParam(name: "RequireMaritalStatus", description: "Check whether customer's marital status is required", paramType:"bool")]
        public string RequireMaritalStatus { get; set; }
        [ConfigParam(name: "RequireSpouseName", description: "Check whether customer's spouse's name is required", paramType:"bool")]
        public string RequireSpouseName { get; set; }
        [ConfigParam(name: "RequireProfession", description: "Check whether customer's level of education is required", paramType:"bool")]
        public string RequireProfession { get; set; }
        [ConfigParam(name: "RequireEducation", description: "Check whether customer's nationality is required", paramType:"bool")]
        public string RequireEducation { get; set; }
        [ConfigParam(name: "RequireNationality", description: "Check whether customer's nationality is required", paramType:"bool")]
        public string RequireNationality { get; set; }
        [ConfigParam(name: "RequireNameOfFather", description: "Check whether Father's name is required", paramType:"bool")]
        public string RequireNameOfFather { get; set; }
        [ConfigParam(name: "RequireNameOfMother", description: "Check whether Mother's name is required", paramType:"string")]
        public string RequireNameOfMother { get; set; }
        [ConfigParam(name: "RequireNumberOfChildren", description: "Check whether number of children is required", paramType:"bool")]
        public string RequireNumberOfChildren { get; set; }
        [ConfigParam(name: "RequireNumberOfDependents", description: "Check whether number of dependants is required", paramType:"bool")]
        public string RequireNumberOfDependents { get; set; }
        [ConfigParam(name: "IndividualMailMergeUrl", description: "Storage directory for individual mail merged files", paramType:"bool")]
        public string IndividualMailMergeUrl { get; set; }
     }

}
