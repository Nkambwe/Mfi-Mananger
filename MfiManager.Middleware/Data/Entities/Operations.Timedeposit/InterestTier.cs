using MfiManager.Middleware.Data.Entities.Operations.Products;

namespace MfiManager.Middleware.Data.Entities.Operations.Timedeposit {
    /// <summary>
    /// Interest calculation rate based on the balance held on the savings account
    /// </summary>
    public class InterestTier : BaseEntity {
        /// <summary>
        /// Get/Set product Id
        /// </summary>
        public long ProductId { get; set; }
        /// <summary>
        /// Get/Set the minimum balance the tier applies to
        /// </summary>
        public decimal LowerTier { get; set; }
        /// <summary>
        /// Get/Set the maximum balance the tier applies to
        /// </summary>
        public decimal UpperTier { get; set; }
        /// <summary>
        /// Get/Set interest rate offered for savings balances in this range
        /// </summary>
        public decimal TierRate { get; set; }

        public virtual TimedepositProduct Product { get; set; }
    }
}
