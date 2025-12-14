using MfiManager.Middleware.Data.Entities.Operations.Products;

namespace MfiManager.Middleware.Data.Entities.Operations.Saving {
    /// <summary>
    /// Withdraw charges classified per product based on range of withdraw amount
    /// </summary>
    public class WithdrawClass : BaseEntity {
        public long ProductId { get; set; }
        public decimal Minimum { get; set; }
        public decimal Maximum { get; set; }
        public decimal Charge { get; set; }
        /// <summary>
        /// Get/Set whether withdraw charge is calculated as a percentage rate
        /// </summary>
        public bool Percentage { get; set; }
        public virtual SavingProduct Product { get; set; }
    }
}
