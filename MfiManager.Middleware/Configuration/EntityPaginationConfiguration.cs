namespace MfiManager.Middleware.Configuration {

    public class EntityPaginationConfiguration {
        /// <summary>
        /// Override global approximate count setting for this entity
        /// </summary>
        public bool? UseApproximateCount { get; set; }

        /// <summary>
        /// Entity-specific threshold
        /// </summary>
        public long? ApproximateCountThreshold { get; set; }

        /// <summary>
        /// Estimated row count (to avoid database calls)
        /// </summary>
        public long? EstimatedRowCount { get; set; }
    }

}
