namespace MfiManager.Middleware.Enums {
    public enum InterestCalculationMethod {
        Unknown = 0,
        /// <summary>
        /// Simple flat rate interest calculation method
        /// </summary>
        Simple = 1,
        /// <summary>
        /// Declining balance interest calculation method
        /// </summary>
        Declining = 2,
        /// <summary>
        /// Declining method amortized
        /// </summary>
        Amortized = 3
    }
}
