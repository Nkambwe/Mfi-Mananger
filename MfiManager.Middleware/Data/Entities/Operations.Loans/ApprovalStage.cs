using MfiManager.Middleware.Data.Entities.Operations.Products;

namespace MfiManager.Middleware.Data.Entities.Operations.Loans {
    /// <summary>
    /// Loan approval stages for a given loan product
    /// </summary>
    public class ApprovalStage : BaseEntity {
        public long? ProductId { get; set; }
        public string StageName { get; set; }
        public string ApproveGroup { get; set; }
        public virtual ICollection<LoanProduct> Products { get; set; }
    }
}
