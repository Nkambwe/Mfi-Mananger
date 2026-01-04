using MfiManager.Middleware.Data.Entities.System.Configurations.Parameters;
using MfiManager.Middleware.Data.Helpers;

namespace MfiManager.Middleware.Data.Entities.System.Configurations.Products {

    public class InsuranceProductConfigurationParameter: IConfigurationParameter {
        [ConfigParam(name: "PolicyPeriod", description: "Period the policy lasts eg. 1 year, 6 months etc.", paramType: "int")]
        public string PolicyPeriod { get; set; }
        [ConfigParam(name: "MinimumNumberInsured", description: "Minimum number of people or assets the policy covers", paramType: "int")]
        public string MinimumNumberInsured { get; set; }
        [ConfigParam(name: "MaximumNumberInsured", description: "Maximum number of people or assets the policy covers", paramType: "int")]
        public string MaximumNumberInsured { get; set; }
        [ConfigParam(name: "MinimumInsurableAge", description: "Minimum age of people or assets covered by the policy", paramType: "int")]
        public string MinimumInsurableAge { get; set; }
        [ConfigParam(name: "MaximumInsurableAge", description: "Maximum age of people or assets covered by the policy", paramType: "int")]
        public string MaximumInsurableAge { get; set; }
        [ConfigParam(name: "MonthlyPremium", description: "Monthly premium amount charge for the policy", paramType: "decimal")]
        public string MonthlyPremium { get; set; }
        [ConfigParam(name: "PremiumPercentageCharged", description: "Percentage of premium charged ", paramType: "decimal")]
        public string PremiumPercentageCharged { get; set; }
        [ConfigParam(name: "ChargeFixedAmount", description: "Check whether premium is charge as a fixed amount per insured person or asset", paramType: "bool")]
        public string ChargeFixedAmount { get; set; }
        [ConfigParam(name: "FixedAmount", description: "Fixed amount chargeable per insured person or asset", paramType: "decimal")]
        public string FixedAmount { get; set; }
        [ConfigParam(name: "CanModificationPremium", description: "whether agent can modify insurance premium at policy registration", paramType: "decimal")]
        public string CanModificationPremium { get; set; }
        [ConfigParam(name: "MinimumCoverage", description: "Minimum amount that is covered by the policy", paramType: "decimal")]
        public string MinimumCoverage { get; set; }
        [ConfigParam(name: "MaximumCoverage", description: "Maximum amount that is covered by the policy", paramType: "decimal")]
        public string MaximumCoverage { get; set; }
        [ConfigParam(name: "Discount", description: "Discount rate on policies", paramType: "decimal")]
        public string Discount { get; set; }
        [ConfigParam(name: "ClaimsPercentage", description: "Percentage of premium for claims", paramType: "decimal")]
        public string ClaimsPercentage { get; set; }
        [ConfigParam(name: "LedgerForClaims", description: "Ledger for claims", paramType: "string")]
        public string LedgerForClaims { get; set; }
        [ConfigParam(name: "AdministrationCostPercentage", description: "Percentage of premium for administrative cost", paramType: "decimal")]
        public string AdministrationCostPercentage { get; set; }
        [ConfigParam(name: "LedgerForAdministrationCost", description: "Ledger for administrative costs", paramType: "string")]
        public string LedgerForAdministrationCost { get; set; }
        [ConfigParam(name: "AdministrationFund", description: "Percentage of premium for administrative fund", paramType: "decimal")]
        public string AdministrationFund { get; set; }
        [ConfigParam(name: "LedgerForAdministrationFund", description: "Ledger for administrative funds", paramType: "string")]
        public string LedgerForAdministrationFund { get; set; }
        [ConfigParam(name: "ChargeWitholdingTaxOnCharges", description: "Check whether product charges witholding tax on charges", paramType: "bool")]
        public string ChargeWitholdingTaxOnCharges { get; set; }
        [ConfigParam(name: "LedgerForWitholdingTax", description: "Ledger for Witholding Tax", paramType: "string")]
        public string LedgerForWitholdingTax { get; set; }
        [ConfigParam(name: "ChargeStampDutyOnPolicies", description: "Check whether product charges witholding tax on insurance policies", paramType: "bool")]
        public string ChargeStampDutyOnPolicies { get; set; }
        [ConfigParam(name: "LedgerForStampDuty", description: "Ledger for Stampduty", paramType: "string")]
        public string LedgerForStampDuty { get; set; }
    }

}
