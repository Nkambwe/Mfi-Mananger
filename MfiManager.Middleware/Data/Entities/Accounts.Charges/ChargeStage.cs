using MfiManager.Middleware.Data.Entities.Operations.Products;

namespace MfiManager.Middleware.Data.Entities.Accounts.Charges {
    /// <summary>
    /// Class represents loan charge stage eg.Application, Disbursement
    /// </summary>
    public class ChargeStage : BaseEntity {
        public bool BeforeApplication {get;set; }
        public bool BeforeApproval {get;set; }
        public bool AfterApproval {get;set; }
        public bool AtDisbursement {get;set;}
        public long ChargeItemId {get;set; }
        public virtual ChargeItem ChargeItem { get; set; }
        public long? TimedepositProductId {get;set; }
        public virtual TimedepositProduct TimedepositProduct { get; set; }
        public long? InsuranceProductId {get;set; }
        public virtual InsuranceProduct InsuranceProduct { get; set; }
        public long? ShareProductId {get;set; }
        public virtual ShareProduct ShareProduct { get; set; }
        public long? SavingProductId {get;set; }
        public virtual SavingProduct SavingProduct { get; set; }
        public long? LoanProductId {get;set; }
        public virtual LoanProduct LoanProduct { get; set; }
        
    }

}
