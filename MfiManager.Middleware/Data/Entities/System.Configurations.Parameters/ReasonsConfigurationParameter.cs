using MfiManager.Middleware.Data.Helpers;

namespace MfiManager.Middleware.Data.Entities.System.Configurations.Parameters {

    public class ReasonsConfigurationParameter : IConfigurationParameter {
        [ConfigParam(name: "BlackListReasonsIdentifier", description: "Blacklist Reasons indentifier series indetifier")]
        public string BlackListReasonsIdentifier { get;set;}
        [ConfigParam(name: "BlackListReasonsCode", description: "Blacklist Reasons series last used code", paramType: "int")]
        public string BlackListReasonsCode { get;set;}
        [ConfigParam(name: "DefferReasonsIdentifier", description: "Reasons to deffer loan indentifier series indetifier")]
        public string DefferReasonsIdentifier { get;set;}
        [ConfigParam(name: "DefferReasonsCode", description: "Reasons to deffer loan series last used code", paramType: "int")]
        public string DefferReasonsCode { get;set;}
        [ConfigParam(name: "ExitReasonsIdentifier", description: "Exit reasons indentifier series indetifier")]
        public string ExitReasonsIdentifier { get;set;}
        [ConfigParam(name: "ExitReasonsCode", description: "Exit reasons series last used code", paramType: "int")]
        public string ExitReasonsCode { get;set;}
        [ConfigParam(name: "FreezReasonsIdentifier", description: "Loan freez reasons indentifier series indetifier")]
        public string FreezReasonsIdentifier { get;set;}
        [ConfigParam(name: "FreezReasonsCode", description: "Loan freez reasons  series last used code", paramType: "int")]
        public string FreezReasonFreezReasonsCodesCode { get;set;}
        [ConfigParam(name: "RejectReasonsIdentifier", description: "Rejection reasons indentifier series indetifier")]
        public string RejectReasonsIdentifier { get;set;}
        [ConfigParam(name: "RejectReasonsCode", description: "Rejection reasons  series last used code", paramType: "int")]
        public string RejectReasonsCode { get;set;}
        [ConfigParam(name: "WriteoffReasonsIdentifier", description: "Loan writeoff reasons indentifier series indetifier")]
        public string WriteoffReasonsIdentifier { get;set;}
        [ConfigParam(name: "WriteoffReasonsCode", description: "Loan writeoff series last used code", paramType: "int")]
        public string WriteoffReasonsCode { get;set;}
        [ConfigParam(name: "ReasonCategoryIdentifier", description: "Reason Category indentifier series indetifier")]
        public string ReasonCategoryIdentifier { get;set;}
        [ConfigParam(name: "ReasonCategoryCode", description: "Reason Category series last used code", paramType: "int")]
        public string ReasonCategoryCode { get;set;}
        
    }

}
