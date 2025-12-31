namespace MfiManager.Middleware.Enums {
    /// <summary>
    /// Approach of inetrest calculation used to calculate loan product payment amounts
    /// </summary>
    public enum InterestCalculation {
        /// <summary>
        /// No Interest calculation is applicable
        /// </summary>
        None = 0,
        /// <summary>
        /// Interest is calculated on the full original principal amount for the entire loan tenure, regardless of repayments made.
        /// </summary>
        /// <remarks>
        /// This is the most expensive method for the borrower. The effective interest rate is much higher than the stated flat rate.
        /// Example: A loan of $10,000 at 10% flat for 2 years. 
        /// Total Interest = $10,000 * 10% * 2 = $2,000. 
        /// The borrower repays $12,000 in equal monthly installments of $500.
        /// Even after paying down the principal, interest is still charged on the initial $10,000.
        /// </remarks>
        FlatRate = 1,
        /// <summary>
        /// Interest is calculated only on the outstanding principal balance at each payment period.
        /// </summary>
        /// <remarks>
        /// Less expensive than Flat Rate for the same nominal rate. 
        /// As borrower pays down principal, the interest charged decreases.
        /// Example: The same $10,000 loan at 10% reducing balance. 
        /// Borrower first month's interest is on $10,000 (~$83.33). 
        /// After paying $400 of principal, next month's interest is on $9,600, and so on.
        /// </remarks>
        ReducingBalance = 2,
        /// <summary>
        /// A variation where the total interest for the loan is calculated upfront, like flat, then is then discounted 
        /// </summary>
        /// <remarks>
        ///  Total interest for the loan is calculated upfront but is then discounted
        ///  using a present value or internal rate of return calculation to express it
        ///  as a reducing balance equivalent rate. 
        ///  It's a way to make a high-cost loan appear to have a lower "effective" rate for comparison.
        ///  Often used for regulatory compliance or price disclosure, to allow apples-to-apples comparison with
        ///  true reducing balance loans. 
        ///  
        /// NOTE:
        /// The borrower's payment amounts might still resemble a flat loan.
        /// </remarks>
        DiscountedReducingBalance = 3,
    }
}
