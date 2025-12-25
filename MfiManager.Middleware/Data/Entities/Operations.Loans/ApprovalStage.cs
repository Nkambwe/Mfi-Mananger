using MfiManager.Middleware.Data.Entities.Operations.Products;
using MfiManager.Middleware.Enums;

namespace MfiManager.Middleware.Data.Entities.Operations.Loans {
    /// <summary>
    /// Loan approval stages for a given loan product
    /// </summary>
    public class LoanApprovalStage : BaseEntity {
        public long ProductId { get; set; }
        public ApprovalStage ApprovalStage { get; set; }
        public OfficerPositionCode ApproverPositionCode { get; set; }
        public virtual ICollection<ProductLoanApprovalStage> Products { get; set; }
    }
}
