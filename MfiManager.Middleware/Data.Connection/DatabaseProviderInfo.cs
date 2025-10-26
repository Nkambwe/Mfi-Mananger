using MfiManager.Middleware.Enums;

namespace MfiManager.Middleware.Data.Connection {
    public class DatabaseProviderInfo {
        public DatabaseProvider Provider { get; set; }
        public string ProviderName { get; set; } = string.Empty;
        public string ConnectionString { get; set; } = string.Empty;
        public string DetectionMethod { get; set; } = string.Empty;
        public bool IsSupported { get; set; }
        public string[] SupportedFeatures { get; set; } = [];
    }

}
