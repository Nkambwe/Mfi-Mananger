using MfiManager.Middleware.Data.Entities.Accounts.Charges;
using MfiManager.Middleware.Data.Entities.Accounts.Taxes;
using MfiManager.Middleware.Data.Entities.Operations.Loans;
using MfiManager.Middleware.Data.Entities.System.Configurations;
using MfiManager.Middleware.Enums;

namespace MfiManager.Middleware.Data.Entities.Operations.Products {

    public class LoanProduct : ProductBase {
        /// <summary>
        /// Get or set target group this loan is. <see cref="CustomerTarget"/> enumeration
        /// </summary>
        public CustomerTarget TargetGroup {get;set; }
        public bool UseClasses {get;set; }
        public long? SectorId {get;set; }
        public virtual BusinessSector Sector { get; set; }
        public long? FundId {get;set; }
        public virtual RevolvingFund Fund { get; set; }
        public long ProductTypeId { get; set; }
        public virtual ProductType ProductType { get; set; }
        public long? ChargeGroupId { get; set; } 
        public virtual ChargeGroup ChargeGroup { get; set; }
        public virtual ICollection<ChargeStage>  ChargeStages {get;set;}
        public virtual ICollection<LoanProductTaxGroup> TaxGroups { get; set; }
        public virtual ICollection<TaxableItem> TaxableItems { get; set; } = [];
        public virtual ICollection<ChargeItem> ChargedItems { get; set; } = [];
        public virtual ICollection<LoanProductParam> ProductParams { get; set; } = [];
        public virtual ICollection<LoanProductApprovalStage> ApprovalStages {get;set; }=[];
        public virtual ICollection<VariableRate> AdjustedRates {get;set; }=[];
        public virtual ICollection<LoanFeePaymentLevel> FeesPaymentLevels {get;set; }=[];
        public virtual ICollection<LoanAgingClass> AgingClasses {get;set; }=[];
        public virtual ICollection<LoanAmountClass> LoanAmountClasses {get;set; }=[];
        public virtual ICollection<LoanPenalty> Penalties {get;set;}=[];
        public virtual ICollection<IndividualLoan> IndividualLoans {get;set; }=[];
        public virtual ICollection<GroupLoan> GroupLoans {get;set; }=[];
        public virtual ICollection<BusinessLoan> BusinessLoans {get;set; }=[];
    }
}
