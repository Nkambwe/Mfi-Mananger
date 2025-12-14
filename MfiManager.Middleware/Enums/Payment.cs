namespace MfiManager.Middleware.Enums {
    public enum Payment {
        /// <summary>
        /// Not applicable
        /// </summary>
        None = 0,
        /// <summary>
        /// Cash payment mode
        /// </summary>
        Cash = 1,
        /// <summary>
        /// RFT, EFT Bank transfer
        /// </summary>
        Transfer = 2,
        /// <summary>
        /// Bank deposit
        /// </summary>
        Deposit = 3,
        /// <summary>
        /// Bank cheque
        /// </summary>
        Cheque = 4,
        /// <summary>
        /// Credit Card payment
        /// </summary>
        Card = 5,
        /// <summary>
        /// Savings transfer from client's account
        /// </summary>
        Savings = 6,
        /// <summary>
        /// Share transfer from client's account
        /// </summary>
        Shares = 7
    }
}
