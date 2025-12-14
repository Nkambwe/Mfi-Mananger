namespace MfiManager.Middleware.Enums {
    /// <summary>
    /// Loan installment payment method 
    /// </summary>
    public enum InterestPaymentMethod {
        /// <summary>
        /// Pay interest per installments
        /// </summary>
        Installment = 1,
        /// <summary>
        /// Pay interest up-front at first installment any balance can be posted on premium
        /// </summary>
        Upfront = 2,
        /// <summary>
        /// Pay only interest as a lump sum amount on first installment and principal is paid in subsequent installments
        /// </summary>
        Lumpsum = 3,
        /// <summary>
        /// Deduct interest at disbursement stage of loan and disburse the principal
        /// </summary>
        Disbursement = 4
    }
}
