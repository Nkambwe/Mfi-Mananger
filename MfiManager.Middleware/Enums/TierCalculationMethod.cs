namespace MfiManager.Middleware.Enums {
    /// <summary>
    /// Interest calculation methods based on tiered approach
    /// </summary>
    public enum TierCalculationMethod {
        /// <summary>
        /// Tier interest calculation does not apply
        /// </summary>
        None = 0,
        /// <summary>
        /// Interest is calculated based on the whole balance at the highest tier reached
        /// </summary>
        Whole = 1,
        /// <summary>
        /// Interest is calculated based on each tier balance reached
        /// </summary>
        Partial = 2,
        /// <summary>
        /// Interest is calculated based on both partial and whole methods
        /// </summary>
        Mixed = 3
    }
}
