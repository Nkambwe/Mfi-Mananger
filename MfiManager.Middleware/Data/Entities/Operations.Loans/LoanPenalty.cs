using MfiManager.Middleware.Data.Entities.Operations.Products;

namespace MfiManager.Middleware.Data.Entities.Operations.Loans {
    /// <summary>
    /// Penalty charge based on loan amount per product
    /// </summary>
    public class LoanPenalty : BaseEntity {
        public long ProductId { get; set; }
        public decimal Minimum { get; set; }
        public decimal Maximum { get; set; }
        public decimal Penalty { get; set; }
        public virtual LoanProduct Product { get; set; }

    }
}
