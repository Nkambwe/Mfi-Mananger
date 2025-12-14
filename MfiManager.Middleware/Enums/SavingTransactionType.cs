namespace MfiManager.Middleware.Enums {
    public enum SavingTransactionType {
        /// <summary>
        /// Undefined transaction
        /// </summary>
        Unknown = 0,
        /// <summary>
        /// Cash deposit transaction
        /// </summary>
        Deposit = 1,
        /// <summary>
        /// Cheque deposit transaction
        /// </summary>
        ChequeDeposit = 2,
        /// <summary>
        /// Cash withdraw transaction
        /// </summary>
        Withdraw = 3,
        /// <summary>
        /// Cheque withdraw transaction
        /// </summary>
        ChequeWithdraw = 4,
        /// <summary>
        /// Bank payment transaction
        /// </summary>
        Payment = 5,
        /// <summary>
        /// Bank receipt transaction
        /// </summary>
        Receipt = 6,
        /// <summary>
        /// Account transfer
        /// </summary>
        Transfer = 7,
        /// <summary>
        /// Mobile transaction
        /// </summary>
        Mobile = 8,
        /// <summary>
        /// Account balance posting
        /// </summary>
        Balance = 9,
        /// <summary>
        /// Standing Order
        /// </summary>
        Order = 10,
        /// <summary>
        /// Charge on account
        /// </summary>
        Charge = 11,
        /// <summary>
        /// Bank penalty
        /// </summary>
        Penalty = 12,
        /// <summary>
        /// Accepted overdraft
        /// </summary>
        Overdraft = 13,
        /// <summary>
        /// Overdraft payment
        /// </summary>
        DraftPayment = 14

    }
}
