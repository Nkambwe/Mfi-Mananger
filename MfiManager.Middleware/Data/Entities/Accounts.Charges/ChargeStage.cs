using MfiManager.Middleware.Data.Entities.Operations.Products;

namespace MfiManager.Middleware.Data.Entities.Accounts.Charges {
    /// <summary>
    /// Class represents loan charge stage eg.Application, Disbursement
    /// </summary>
    public class ChargeStage : BaseEntity {
        public long ProductId {get;set; }
        public bool BeforeApplication {get;set; }
        public bool BeforeApproval {get;set; }
        public bool AfterApproval {get;set; }
        public bool AtDisbursement {get;set;}
        public long ChargeItemId {get;set; }
        public virtual ChargeItem ChargeItem { get; set; }
        public virtual Product Product {get;set;}
        
    }

}
