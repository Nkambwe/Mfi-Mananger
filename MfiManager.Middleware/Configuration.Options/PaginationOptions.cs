namespace MfiManager.Middleware.Configuration.Options {

    public class PaginationOptions {

        public const string SectionName = "Pagination";

        /// <summary>
        /// Enable approximate counting for large tables
        /// </summary>
        public bool EnableApproximateCount { get; set; } = true;

        /// <summary>
        /// Minimum row count threshold to use approximate counting
        /// </summary>
        public long ApproximateCountThreshold { get; set; } = 100_000;

        /// <summary>
        /// Maximum acceptable error percentage for approximate counts (1-100)
        /// </summary>
        public double MaxApproximateCountErrorPercent { get; set; } = 5.0;

        /// <summary>
        /// Cache duration for approximate counts
        /// </summary>
        public TimeSpan ApproximateCountCacheTime { get; set; } = TimeSpan.FromMinutes(30);

        /// <summary>
        /// Entity-specific configurations
        /// </summary>
        public Dictionary<string, EntityPaginationConfiguration> EntityConfigurations { get; set; } = new();

    }

}
