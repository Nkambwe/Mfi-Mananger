namespace MfiManager.Middleware.Data.Entities.System.Configurations.Parameters {
    public class BusinessCustomerConfigurationParameter : IConfigurationParameter {
        [ConfigParam(name: "BusinessFilter1Name", description: "Custome business filter 1 name", paramType: "string")]
        public string BusinessFilter1Name { get; set; }
        [ConfigParam(name: "RequireBusinessFilter1", description: "Check whether business filter 1 is required", paramType: "bool")]
        public string RequireBusinessFilter1 { get; set; }
        [ConfigParam(name: "BusinessFilter2Name", description: "Custome business filter 2 name", paramType: "string")]
        public string BusinessFilter2Name { get; set; }
        [ConfigParam(name: "RequireBusinessFilter2", description: "Check whether business filter 2 is required", paramType: "bool")]
        public string RequireBusinessFilter2 { get; set; }
        [ConfigParam(name: "NumberOfSignatoriesRequired", description: "Number of business signatories required", paramType: "int")]
        public string NumberOfSignatoriesRequired { get; set; }
        [ConfigParam(name: "RequireSignatoryPhoto", description: "Check whether business signatory photo is required", paramType: "bool")]
        public string RequireSignatoryPhoto { get; set; }
        [ConfigParam(name: "RequireSignatoryIdentification", description: "Check whether business signatory identification is required", paramType: "bool")]
        public string RequireSignatoryIdentification { get; set; }
        [ConfigParam(name: "RequireSignatorySignatures", description: "Check whether business signatory signatures is required", paramType: "bool")]
        public string RequireSignatorySignatures { get; set; }
        [ConfigParam(name: "BusinessMailMergeUrl", description: "Storage directory for business mail merged files", paramType:"string")]
        public string BusinessMailMergeUrl { get; set; }
    }

}
