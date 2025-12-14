namespace MfiManager.Middleware.Enums {
    /// <summary>
    /// Type of collateral used as guarantee to secure a loan
    /// </summary>
    public enum CollateralType {
        /// <summary>
        /// Loan is not covered by guarantee
        /// </summary>
        Unsecured = 0,
        /// <summary>
        /// Real estate 
        /// </summary>
        House = 1,
        /// <summary>
        /// Equipments such as computers, cars etc
        /// </summary>
        Equipment = 2,
        /// <summary>
        /// Business inventory
        /// </summary>
        Inventory = 3,
        /// <summary>
        /// Guarantee a loan against a timedeposit account
        /// </summary>
        Timedeposit = 4,
        /// <summary>
        /// Financial assets such as shares
        /// </summary>
        Shares = 5
    }
}
