namespace MfiManager.Middleware.Configuration.Options {
    public class ServiceLoggingOption {
        public const string SectionName = "LoggingOptions";
        public string DefaultLogName { get; set; } = "mfi_middleware_log";
        public string LogFolder { get; set; } = "mfi_middleware";
    }
}
