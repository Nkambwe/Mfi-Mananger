using MfiManager.Middleware.Data.Entities.Operations.Products;

namespace MfiManager.Middleware.Data.Entities.Operations.Insurance {
    /// <summary>
    /// Policy coverage
    /// </summary>
    public class Coverage: BaseEntity {
        /// <summary>
        /// Get/Set name of item covered by policy eg. Property Insurance, Automobile, agriculture item etc.
        /// </summary>
        public string CoverageName { get; set; }
        /// <summary>
        /// Get/Set percentage rate of premium used as premium amount
        /// </summary>
        public decimal PercentagePremiumAmount { get; set; }
        /// <summary>
        /// Get/Set whether a fixed amount is deducted as premium amount on premium
        /// </summary>
        public bool PremiumAmountIsFixed { get; set; }
        /// <summary>
        /// Get/Set fixed amount as premium amount on premium
        /// </summary>
        public decimal FixedPremiumAmount { get; set; }
        /// <summary>
        /// Get/Set the minimum amount the insurance can cover in case of an insurance lose
        /// </summary>
        public decimal MinimumCoverageAmount { get; set; }
        /// <summary>
        /// Get/Set the maximum amount the insurance can cover in case of an insurance lose
        /// </summary>
        public decimal MaximumCoverageAmount { get; set; }
        public string Notes { get; set; }
        public virtual ICollection<InsuranceProduct> InsuranceProducts {get;set; }=[];
        public virtual ICollection<CoverageItem> CoveredItems {get;set;}=[];
    }
}
