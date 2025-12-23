using MfiManager.Middleware.Data.Entities.Operations.Products;
using MfiManager.Middleware.Enums;

namespace MfiManager.Middleware.Data.Entities.Operations.Loans {
    /// <summary>
    /// Loan approval stages for a given loan product
    /// </summary>
    public class ApprovalStage : BaseEntity {
        public long? ProductId { get; set; }
        public string StageName { get; set; }
        public OfficerLevel ApproveLevel { get; set; }
        public virtual ICollection<LoanProduct> Products { get; set; }
    }
}
