using MfiManager.Middleware.Data.Entities.Operations.Insurance;

namespace MfiManager.Middleware.Data.Entities.Operations.Products {
    /// <summary>
    /// Insurance product
    /// </summary>
    public class InsuranceProduct : BaseEntity {
        public long CoverageId {get;set; }
        public int Period {get;set; }
        public bool AllowPremiumModification {get;set; }
        /// <summary>
        /// Get/Set whether to charge premium per month
        /// </summary>
        public bool ChargeMonthlyPremium {get;set; }
        /// <summary>
        /// Get/Set percentage set as administrative costs
        /// </summary>
        public decimal PercentageAdministrativeAmount {get;set; }
        /// <summary>
        /// Get/Set administrative cost ledger account
        /// </summary>
        public string AdministrativeCostLedgerAccount {get;set; }
        /// <summary>
        /// Get/Set percentage set as claim amount
        /// </summary>
        public decimal PercentageClaimAmount {get;set;}
        /// <summary>
        /// Get/Set claim amount ledger account
        /// </summary>
        public string ClaimLedgerAccount {get;set; }
        public int MinimumInsuredPersons {get;set; }
        public int MaximumInsuredPersons {get;set; }
        public int MinimumInsuredAge {get;set; }
        public int MaximumInsuredAge {get;set; }
        public decimal Fees {get;set; }
        public string FeesLedgerAccount {get;set; }
        public long ProductId {get;set; }
        public virtual Product Product {get;set;}
        public virtual Coverage Coverage { get; set; }
        public virtual ICollection<Policy> Policies {get;set; }
        public virtual ICollection<InsuranceProductProvider> Providers {get;set;}
    }
}
