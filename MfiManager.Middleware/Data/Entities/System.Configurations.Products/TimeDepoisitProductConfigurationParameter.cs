using MfiManager.Middleware.Data.Entities.System.Configurations.Parameters;
using MfiManager.Middleware.Data.Helpers;

namespace MfiManager.Middleware.Data.Entities.System.Configurations.Products {

    public class TimeDepoisitProductConfigurationParameter: IConfigurationParameter {
        [ConfigParam(name: "MinimumProductAmount", description: "Minimum amount for timedeposit product", paramType: "decimal")]
        public string MinimumProductAmount { get; set; }
        [ConfigParam(name: "MaximumProductAmount", description: "Maximum amount for timedeposit product", paramType: "decimal")]
        public string MaximumProductAmount { get; set; }
        [ConfigParam(name: "MinimumInterestRate", description: "Minimum interest rate for timedeposit product", paramType: "decimal")]
        public string MinimumInterestRate { get; set; }
        [ConfigParam(name: "MaximumInterestRate", description: "Maximum interest rate for timedeposit product", paramType: "decimal")]
        public string MaximumInterestRate { get; set; }
        [ConfigParam(name: "MinimumInterestPeriod", description: "Minimum interest period for timedeposit product", paramType: "int")]
        public string MinimumInterestPeriod { get; set; }
        [ConfigParam(name: "MaximumInterestPeriod", description: "Maximum interest period for timedeposit product", paramType: "int")]
        public string MaximumInterestPeriod { get; set; }
        [ConfigParam(name: "PenaltyAmount", description: "Fixed amount chargeable as penalty on timedeposit product", paramType: "decimal")]
        public string PenaltyAmount { get; set; }
        [ConfigParam(name: "UsePercentageBasedPenalty", description: "Check whether penalty should be calculated as a percentage rate", paramType: "bool")]
        public string UsePercentageBasedPenalty { get; set; }
        [ConfigParam(name: "PenaltyRate", description: "Penalty rate for timedeposit product", paramType: "decimal")]
        public string PenaltyRate { get; set; }
        [ConfigParam(name: "NoInterestOnPrematureWithdraw", description: "Check whether interest should not be offered on premature withdraw of timedeposit product", paramType: "bool")]
        public string NoInterestOnPrematureWithdraw { get; set; }
        [ConfigParam(name: "InterestPeriodInDays", description: "Interest period in days", paramType: "int")]
        public string InterestPeriodInDays { get; set; }
        [ConfigParam(name: "ChargeWitholdingTaxOnInterest", description: "Check whether product charges witholding tax on interest earned", paramType: "bool")]
        public string ChargeWitholdingTaxOnInterest { get; set; }
        [ConfigParam(name: "LedgerForWitholdingTax", description: "Ledger for Witholding Tax", paramType: "string")]
        public string LedgerForWitholdingTax { get; set; }
        [ConfigParam(name: "LedgerForTimedeposit", description: "Ledger for timedeposit amounts", paramType: "string")]
        public string LedgerForTimedeposit { get; set; }
        [ConfigParam(name: "LedgerForInterest", description: "Ledger for timedeposit interest", paramType: "string")]
        public string LedgerForInterest { get; set; }
        [ConfigParam(name: "LedgerForInterestDue", description: "Ledger for timedeposit interest due", paramType: "string")]
        public string LedgerForInterestDue { get; set; }
        [ConfigParam(name: "LedgerForPenalty", description: "Ledger for penalty charged on timedeposit products", paramType: "string")]
        public string LedgerForPenalty { get; set; }
        [ConfigParam(name: "LedgerForTimedepositCashDifference", description: "Ledger for timedeposit cash difference", paramType: "string")]
        public string LedgerForTimedepositCashDifference { get; set; }
        [ConfigParam(name: "LedgerTimedepositAccruedInterestCost", description: "Ledger for accrued timedeposit interest cost", paramType: "string")]
        public string LedgerTimedepositAccruedInterestCost { get; set; }
        [ConfigParam(name: "LedgerForTimedepositAccruedInteresDue", description: "Ledger for accrued timedeposit interest due", paramType: "string")]
        public string LedgerForTimedepositAccruedInteresDue { get; set; }
        [ConfigParam(name: "LedgerForTax", description: "Ledger for other taxes", paramType: "string")]
        public string LedgerForTax { get; set; }
    }

}
