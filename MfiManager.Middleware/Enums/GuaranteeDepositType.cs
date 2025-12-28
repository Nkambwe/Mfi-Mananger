namespace MfiManager.Middleware.Enums {
    public enum GuaranteeDepositType {
        /// <summary>
        /// Savings guarantee deposit is undefined
        /// </summary>
        Undefined = 0,
        /// <summary>
        /// Savings guarantee deposit is based on loan amount received
        /// </summary>
        LoanAmount = 1,
        /// <summary>
        /// Savings guarantee deposit is based on loan amount classes
        /// </summary>
        LoanAmountClasses = 2
    }
}
