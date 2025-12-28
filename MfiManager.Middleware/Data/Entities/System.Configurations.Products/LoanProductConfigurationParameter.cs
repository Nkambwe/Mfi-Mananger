using MfiManager.Middleware.Data.Entities.System.Configurations.Parameters;

namespace MfiManager.Middleware.Data.Entities.System.Configurations.Products {

    public class LoanProductConfigurationParameter: IConfigurationParameter {
        [ConfigParam(name: "AvailableToSavingCustomersOnly", description: "Check whether product is only availed to saving clients", paramType: "bool")]
        public string AvailableToSavingCustomersOnly { get; set; }
        [ConfigParam(name: "LinkedSavingsProduct", description: "Product code for savings product linked to this loan product", paramType: "string")]
        public string LinkedSavingsProduct { get; set; }
        [ConfigParam(name: "InterestDays", description: "Number of interest days in a year", paramType: "int")]
        public string InterestDays { get; set; }
        [ConfigParam(name: "InterestWeeks", description: "Number of interest weeks in a year", paramType: "int")]
        public string InterestWeeks { get; set; }
        [ConfigParam(name: "LoanApprovalStages", description: "Number of loan approval stages involved, Tier One-any one who has access, Tier Two-secondary approval, Tier Three-third approver, Tier Four-Senior analyst", paramType: "int")]
        public string LoanApprovalStages { get; set; }
        [ConfigParam(name: "ForceModificationOfDueDates", description: "Check whether modification of due dates at disbursement must be enforced", paramType: "bool")]
        public string ForceModificationOfDueDates { get; set; }
        [ConfigParam(name: "ModificationOMethod", description: "Due dates modification method", paramType: "int")]
        public string ModificationOMethod { get; set; }
    }

}
