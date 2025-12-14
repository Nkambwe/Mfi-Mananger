using System.ComponentModel;

namespace MfiManager.Middleware.Enums {
    /// <summary>
    /// Define the nature of account
    /// </summary>
    public enum LedgerAccountType {
        /// <summary>
        /// Asset account
        /// </summary>
        [Description("Unknown type")]
        Undefined = 0,
        /// <summary>
        /// Asset account
        /// </summary>
        [Description("Asset account")]
        Asset = 1,
        /// <summary>
        /// Liability account
        /// </summary>
        [Description("Liability account")]
        Liability = 2,
        /// <summary>
        /// Equity account
        /// </summary>
        [Description("Capital account")]
        Equity = 3,
        /// <summary>
        /// Income account
        /// </summary>
        [Description("Income account")]
        Revenue = 4,
        /// <summary>
        /// Expense account
        /// </summary>
        [Description("Expense account")]
        Expense = 5,
        /// <summary>
        /// Special account
        /// </summary>
        [Description("Special account")]
        Special = 6,
        /// <summary>
        /// Off-balance sheet account type
        /// </summary>
        [Description("Off-balance sheet account")]
        OffBalance = 8
    }
}
