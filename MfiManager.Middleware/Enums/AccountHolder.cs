using System.ComponentModel;

namespace MfiManager.Middleware.Enums {
    /// <summary>
    /// Bank account holder type
    /// </summary>
    public enum AccountHolder {
        /// <summary>
        /// Type of account holder undefined
        /// </summary>
        [Description("Anonymous Customer")]
        Unknown = 0,
        /// <summary>
        /// Account owned by the business
        /// </summary>
        [Description("Business Customer")]
        Business = 1,
        /// <summary>
        /// Account held by client
        /// </summary>
        [Description("Individual Customer")]
        Customer = 2,
        /// <summary>
        /// Account held by vendor who is also a customer
        /// </summary>
        [Description("Vendor Customer")]
        Vendor = 3
    }
}
