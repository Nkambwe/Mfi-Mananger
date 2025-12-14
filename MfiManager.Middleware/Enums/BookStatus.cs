namespace MfiManager.Middleware.Enums {
    public enum BookStatus {
        Unknown = 0,
        /// <summary>
        /// Book cheque active
        /// </summary>
        Active = 1,
        /// <summary>
        /// Book cancelled
        /// </summary>
        Cancelled = 2,
        /// <summary>
        /// No longer in use
        /// </summary>
        Finished = 3
    }
}
