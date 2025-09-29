namespace MfiManager.Middleware.Configuration.Options {
    public class BulkMonitorOptions {
        public const string SectionName = "BulkOperationMonitor";
        public bool EnableDetailedLogging { get; set; } = false;
        public bool LogPerformanceWarnings { get; set; } = true;
        public TimeSpan MaxMetricAge { get; set; } = TimeSpan.FromDays(7);
        public int MaxMetricsPerOperation { get; set; } = 10000;
        public TimeSpan SlowOperationThreshold { get; set; } = TimeSpan.FromSeconds(30);
        public double LowThroughputThreshold { get; set; } = 1000; 
    }
}
