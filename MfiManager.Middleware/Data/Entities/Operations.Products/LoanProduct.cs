using MfiManager.Middleware.Data.Entities.Operations.Loans;
using MfiManager.Middleware.Enums;

namespace MfiManager.Middleware.Data.Entities.Operations.Products {

    public class LoanProduct : BaseEntity {
        public long ProductId {get;set; }
        /// <summary>
        /// Get or set target group this loan is. <see cref="LoanTarget"/> enumeration
        /// </summary>
        public LoanTarget Target {get;set; }
        public long? SectorId {get;set; }
        public long? FundId {get;set; }
        public virtual BusinessSector Sector { get; set; }
        public virtual RevolvingFund Fund { get; set; }
        public virtual Product Product {get;set;}
        public virtual ICollection<ProductLoanApprovalStage> ApprovalStages {get;set; }=[];
        public virtual ICollection<VariableRate> AdjustedRates {get;set; }=[];
        public virtual ICollection<LoanFeePaymentLevel> FeesPaymentLevels {get;set; }=[];
        public virtual ICollection<LoanRecord> Loans {get;set; }=[];
        public virtual ICollection<LoanAgingClass> AgingClasses {get;set; }=[];
        public virtual ICollection<LoanPenalty> Penalties {get;set;}=[];
    }
}
