namespace MfiManager.Middleware.Data.Entities.System.Configurations.Parameters {
    public class GeneralCustomerConfigurationParameter : IConfigurationParameter {
        [ConfigParam(name: "AllowManualRegistrationNumbers", description: "Check whether user can manually enter customer registration numbers", paramType: "bool")]
        public string AllowManualRegistrationNumbers { get; set; }
        [ConfigParam(name: "RegistrationNumberFormat", description: "RegEx for registration number format", paramType: "string")]
        public string RegistrationNumberFormat { get; set; }
        [ConfigParam(name: "RegistrationNumberLength", description: "Customer registration number maximum length", paramType: "int")]
        public string RegistrationNumberLength { get; set; }
        [ConfigParam(name: "RequireReferenceNumbers", description: "Check whether user can customer reference number is required", paramType: "bool")]
        public string RequireReferenceNumbers { get; set; }
        [ConfigParam(name: "AllowManualReferenceNumbers", description: "Check whether user can manually enter customer reference numbers", paramType: "bool")]
        public string AllowManualReferenceNumbers { get; set; }
        [ConfigParam(name: "ReferenceNumberFormat", description: "RegEx for reference number format", paramType: "string")]
        public string ReferenceNumberFormat { get; set; }
        [ConfigParam(name: "ReferenceNumberLength", description: "Customer reference number maximum length", paramType: "int")]
        public string ReferenceNumberLength { get; set; }
        [ConfigParam(name: "RequireStatisticNumbers", description: "Check whether user can customer statistic number is required", paramType: "bool")]
        public string RequireStatisticNumbers { get; set; }
        [ConfigParam(name: "AllowManualStatisticNumbers", description: "Check whether user can manually enter customer statistic numbers", paramType: "bool")]
        public string AllowManualStatisticNumbers { get; set; }
        [ConfigParam(name: "StatisticNumberFormat", description: "RegEx for statistic number format", paramType: "string")]
        public string StatisticNumberFormat { get; set; }
        [ConfigParam(name: "StatisticNumberLength", description: "Customer statistic number maximum length", paramType: "int")]
        public string StatisticNumberLength { get; set; }
        [ConfigParam(name: "RequireVillageOfresidence", description: "Check whether customer's village is required", paramType:"bool")]
        public string RequireVillageOfresidence { get; set; }
        [ConfigParam(name: "RequireParishOfResidence", description: "Check whether customer's Parish is required", paramType:"bool")]
        public string RequireParishOfResidence { get; set; }
        [ConfigParam(name: "RequireDistrictOfresidence", description: "Check whether customer's District is required", paramType:"bool")]
        public string RequireDistrictOfresidence { get; set; }
        [ConfigParam(name: "RequireCityOfResidence", description: "Check whether customer's City of residence is required", paramType:"bool")]
        public string RequireCityOfResidence { get; set; }
        [ConfigParam(name: "RequireTownOfresidence", description: "Check whether customer's Town of residence is required", paramType:"bool")]
        public string RequireTownOfresidence { get; set; }
        [ConfigParam(name: "RequirePermanentAddress", description: "Check whether customer's physical address is required", paramType:"bool")]
        public string RequirePermanentAddress { get; set; }
        [ConfigParam(name: "RequirePostalAddress", description: "Check whether customer's postal address is required", paramType:"bool")]
        public string RequirePostalAddress { get; set; }
        [ConfigParam(name: "RequireTelephoneNumber", description: "Check whether customer's phone number is required", paramType:"bool")]
        public string RequireTelephoneNumber { get; set; }
        [ConfigParam(name: "RequireMobileNumber", description: "Check whether customer's mobile number is required", paramType:"bool")]
        public string RequireMobileNumber { get; set; }
        [ConfigParam(name: "RequireCustomerEmail", description: "Check whether customer's email address is required", paramType:"bool")]
        public string RequireCustomerEmail { get; set; }
        [ConfigParam(name: "Filter1Name", description: "Name for Custome filter 1", paramType:"string")]
        public string Filter1Name { get; set; }
        [ConfigParam(name: "RequireFilter3", description: "Check whether custome filter 1 is required", paramType:"bool")]
        public string RequireFilter1 { get; set; }
        [ConfigParam(name: "Filter2Name", description: "Name for Custome filter 2", paramType:"string")]
        public string Filter2Name { get; set; }
        [ConfigParam(name: "RequireFilter2", description: "Check whether custome filter 2 is required", paramType:"bool")]
        public string RequireFilter2 { get; set; }
        [ConfigParam(name: "Filter3Name", description: "Name for Custome filter 3", paramType:"string")]
        public string Filter3Name { get; set; }
        [ConfigParam(name: "RequireFilter3", description: "Check whether custome filter 3 is required", paramType:"bool")]
        public string RequireFilter3 { get; set; }

        [ConfigParam(name: "RequireFeesAtRegistration", description: "Check whether customer registration fees are required at registraion", paramType:"bool")]
        public string RequireFeesAtRegistration { get; set; }
        
        [ConfigParam(name: "CanTransactWithoutFees", description: "Check whether customer is allowed to transact without fees", paramType:"bool")]
        public string CanTransactWithoutFees { get; set; }
        
        [ConfigParam(name: "RequireClientApproval", description: "Check whether customer registration approval is required before customer is activated", paramType:"bool")]
        public string RequireClientApproval { get; set; }
        
        [ConfigParam(name: "CanAppovalCustomerCreatedByThem", description: "Check whether user can approve customer created by them, otherwise require thirdparty approval", paramType:"bool")]
        public string CanAppovalCustomerCreatedByThem { get; set; }
        
        [ConfigParam(name: "SoftDeleteCustomerRecords", description: "Check whether customer records are just marked as deleted instead of being permanently deleted", paramType:"bool")]
        public string SoftDeleteCustomerRecords { get; set; }
        
        [ConfigParam(name: "ArchiveSoftDeleteRecords", description: "Check whether customer recordssoft deleted are archieved immediatly after being deleted", paramType:"bool")]
        public string ArchiveSoftDeleteRecords { get; set; }
    }

}
