
namespace MfiManager.Middleware.Data.Entities.System.Configurations.Products {

    public class TimeDepoisitProductConfiguration {
        /// <summary>
        /// Get or Set minimum amount for timedeposit product
        /// </summary>
        public decimal MinimumProductAmount {get;set;}
        /// <summary>
        /// Get or Set maximum amount for timedeposit product
        /// </summary>
        public decimal MaximumProductAmount {get;set;}
        /// <summary>
        /// Get or Set minimum interest rate for timedeposit product
        /// </summary>
        public decimal MinimumInterestRate {get;set;}
        /// <summary>
        /// Get or Set maximum interest rate for timedeposit product
        /// </summary>
        public decimal MaximumInterestRate {get;set;}
        /// <summary>
        /// Get or Set minimum interest period for timedeposit product
        /// </summary>
        public int MinimumInterestPeriod {get;set;}
        /// <summary>
        /// Get or Set maximum interest period for timedeposit product
        /// </summary>
        public int MaximumInterestPeriod {get;set;}
        /// <summary>
        /// Get or set a fixed amount chargeable as penalty on timedeposit product
        /// </summary>
        public decimal PenaltyAmount  {get;set;}
        /// <summary>
        /// Get or Set value indicating whether penalty should be calculated as a percentage rate
        /// </summary>
        public bool UsePercentageBasedPenalty  {get;set;}
        /// <summary>
        /// Get or Set penalty rate for timedeposit product
        /// </summary>
        public decimal PenaltyRate {get;set;}
        /// <summary>
        /// Get or Set value indicating whether interest should not be offered on premature withdraw of timedeposit product
        /// </summary>
        public bool NoInterestOnPrematureWithdraw  {get;set;}
        /// <summary>
        /// Get or set interest period in days
        /// </summary>
        public int InterestPeriodInDays {get;set;}     
        /// <summary>
        ///  Get or Set value indicating whether product charges witholding tax on interest earned
        /// </summary>
        public bool ChargeWitholdingTaxOnInterest {get;set;} = false;
        /// <summary>
        /// Get Or Set witholding tax code attached to this product [See Witholding tax]
        /// </summary>
        ///public string WitholdingTaxCode {get;set;}
        /// <summary>
        /// Get Or Set ledger for Witholding Tax
        /// </summary>
        public string LedgerForWitholdingTax {get;set;} = "";
        /// <summary>
        /// Get Or Set ledger for timedeposit amounts
        /// </summary>
        public string LedgerForTimedeposit {get;set;} = "";
         /// <summary>
        /// Get Or Set ledger for timedeposit interest
        /// </summary>
        public string LedgerForInterest {get;set;} = "";
        /// <summary>
        /// Get Or Set ledger for timedeposit interest due
        /// </summary>
        public string LedgerForInterestDue {get;set;} = "";
        /// <summary>
        /// Get Or Set ledger for penalty charged on timedeposit products
        /// </summary>
        public string LedgerForPenalty {get;set;} = "";    
        /// <summary>
        /// Get Or Set ledger for timedeposit cash difference
        /// </summary>
        public string LedgerForTimedepositCashDifference {get;set;} = "";
        /// <summary>
        /// Get Or Set ledger for accrued timedeposit interest cost
        /// </summary>
        public string LedgerTimedepositAccruedInterestCost {get;set;} = "";
        /// <summary>
        /// Get Or Set ledger for accrued timedeposit interest due
        /// </summary>
        public string LedgerForTimedepositAccruedInteresDue {get;set;} = "";
        /// <summary>
        /// Get Or Set ledger account for other taxes
        /// </summary>
        public string LedgerForTax{get;set;} = "";
    }
}
