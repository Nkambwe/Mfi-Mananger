using System.ComponentModel;

namespace MfiManager.Middleware.Enums {
    /// <summary>
    /// Ledger account level in the chart of accounts
    /// </summary>
    public enum AccountLevel {
        /// <summary>
        /// Account header
        /// </summary>
        [Description("Account Header")]
        Header = 1,
        /// <summary>
        /// Sub-header account
        /// </summary>
        [Description("Account Sub-Header")]
        SubHeader = 2,
        /// <summary>
        /// Ledger account
        /// </summary>
        [Description("Ledger Account")]
        Account = 3,
        /// <summary>
        /// Account total label
        /// </summary>
        [Description("Header Total Label")]
        TotalLabel = 4
    }
}
