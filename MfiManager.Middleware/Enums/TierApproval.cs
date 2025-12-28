using System.ComponentModel;

namespace MfiManager.Middleware.Enums {
    /// <summary>
    /// LOan approval tiers or levels
    /// </summary>
    public enum TierApproval {
        /// <summary>
        /// Loan approval done once by anyone who has access
        /// </summary>
        [Description("Tier One")]
        Tier1 = 1,
        /// <summary>
        /// Loan approval requires secondary approval
        /// </summary>
        [Description("Tier Two")]
        Tier2 = 2,
        /// <summary>
        /// Loan approval requires third approval
        /// </summary>
        [Description("Tier Three")]
        Tier3 = 3,
        /// <summary>
        /// Loan approval requires Senior analyst approval
        /// </summary>
        [Description("Tier Four")]
        Tier4 = 4
    }
}
