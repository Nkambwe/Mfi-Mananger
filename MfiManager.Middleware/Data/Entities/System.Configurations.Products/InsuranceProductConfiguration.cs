namespace MfiManager.Middleware.Data.Entities.System.Configurations.Products {
    public class InsuranceProductConfiguration {
        /// <summary>
        /// Get Or Set the period the policy lasts eg. 1 year, 6 months etc.
        /// </summary>
        public int Period { get; set; }
        /// <summary>
        /// Get Or Set the minimum number of people or assets the policy covers
        /// </summary>
	    public int MinimumInsured { get; set; }
        /// <summary>
        /// Get Or Set the maximum number of people or assets the policy covers
        /// </summary>
        public int MaximumInsured { get; set; }
        /// <summary>
        /// Get Or Set the mniimum age of people or assets covered by the policy
        /// </summary>
	    public decimal MinimumAge { get; set; }
        /// <summary>
        /// Get Or Set the maximum age of people or assets covered by the policy
        /// </summary>
	    public int MaximumAge { get; set; }
        /// <summary>
        /// Get Or Set monly premium amount charge for the policy
        /// </summary>
	    public decimal MonthlyPremium { get; set; }
        /// <summary>
        /// Get or set percentage of premium charged 
        /// </summary>
	    public decimal Percentage { get; set; }
        /// <summary>
        /// Get or set value indicating whether premium is charge as a fixed amount per insured person or asset
        /// </summary>
	    public bool ChargeFixedAmount { get; set; }
        /// <summary>
        /// Get or set  fixed amount chargeable per insured person or asset
        /// </summary>
	    public decimal FixedAmount { get; set; }
        /// <summary>
        /// Get or set value indicating whether agent can modify insurance premium at policy registration
        /// </summary>
	    public bool CanModificationPremium { get; set; }
        /// <summary>
        /// Get or set the minimum amount that is covered by the policy
        /// </summary>
	    public decimal MinimumCoverage { get; set; }
        /// <summary>
        /// Get or set the miaximum amount that is covered by the policy
        /// </summary>
	    public decimal MaximumCoverage { get; set; }
        /// <summary>
        ///  Get or Set discount rate on policies
        /// </summary>
        public decimal Discount { get; set; }
        /// <summary>
        /// Get Or Set percentage of premium for claims
        /// </summary>
        public decimal ClaimsPercentage { get; set; }
        /// <summary>
        /// Get Or Set ledger for claims
        /// </summary>
        public string LedgerForClaims { get; set; }
        /// <summary>
        /// Get Or Set percentage of premium for administrative cost
        /// </summary>
        public decimal AdministrationCostPercentage { get; set; }
        /// <summary>
        /// Get Or Set ledger for administrative costs
        /// </summary>
	    public string LedgerForAdministrationCost { get; set; }
        /// <summary>
        /// Get Or Set percentage of premium for administrative fund
        /// </summary>
        public decimal AdministrationFund { get; set; }
        /// <summary>
        /// Get Or Set ledger for administrative funds
        /// </summary>
        public string LedgerForAdministrationFund { get; set; }
        /// <summary>
        ///  Get or Set value indicating whether product charges witholding tax on charges
        /// </summary>
        public bool ChargeWitholdingTaxOnCharges { get; set; } = false;
        /// <summary>
        /// Get Or Set ledger for Witholding Tax
        /// </summary>
        public string LedgerForWitholdingTax { get; set; } = "";
        /// <summary>
        ///  Get or Set value indicating whether product charges witholding tax on insurance policies
        /// </summary>
        public bool ChargeStampDutyOnPolicies { get; set; } = false;
        /// <summary>
        /// Get Or Set ledger for Witholding Tax
        /// </summary>
        public string LedgerForStampDuty { get; set; } = "";

    }
}
