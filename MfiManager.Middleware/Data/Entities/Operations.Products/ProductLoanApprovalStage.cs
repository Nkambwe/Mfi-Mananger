using MfiManager.Middleware.Data.Entities.Operations.Loans;

namespace MfiManager.Middleware.Data.Entities.Operations.Products {
    public class ProductLoanApprovalStage {
        public long ProductId { get; set; }
        public long ApprovalStageId { get; set; }
        public virtual LoanProduct Product { get; set; }
        public virtual LoanApprovalStage ApprovalStage { get; set; }
     }
}
