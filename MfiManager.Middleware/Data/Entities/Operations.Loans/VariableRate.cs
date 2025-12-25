using MfiManager.Middleware.Data.Entities.Operations.Products;

namespace MfiManager.Middleware.Data.Entities.Operations.Loans {
    /// <summary>
    /// Adjustable interest rate/Effective Interest rate for a loan product
    /// </summary>
    public class VariableRate : BaseEntity {
        public long ProductId { get; set; }
        public decimal Rate { get; set; }
        public DateTime Started { get; set; }
        public DateTime? Expired { get; set; }
        public virtual LoanProduct Product { get; set; }
    }
}
