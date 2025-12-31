namespace MfiManager.Middleware.Enums {
    /// <summary>
    /// Methods used to generate loan amorization schedule
    /// </summary>
    public enum AmortizationScheduleGenerationMethod {
        /// <summary>
        /// No calculation method used
        /// </summary>
        None = 0,
        /// <summary>
        /// Used to calculate interest for Flat based interest approach 
        /// </summary>
        /// <remarks>
        /// Formular: Interest = Principal × Rate × Time
        /// Method does not account for the changing principal balance over time.
        /// </remarks>
        Simple = 1,
        /// <summary>
        /// Used to calculate interest for Reducing Balance based interest approach 
        /// </summary>
        /// <remarks>
        /// Also called Reducing Balance
        /// The calculations are done period-by-period on the outstanding balance. 
        /// </remarks>
        DecliningBalance = 2,
        /// <summary>
        ///  Specific payment structure used under the reducing/declining balance method.
        /// </summary>
        /// <remarks>
        /// A fixed total periodic payment is calculated e.g., monthly
        /// where the interest portion is high at the start and the 
        /// principal portion increases over time.
        /// </remarks>
        Amortized = 3
    }
}
