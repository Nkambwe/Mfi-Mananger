namespace MfiManager.Middleware.Data.Connection {
    public class DatabaseVersionInfo {
        public string VersionString { get; set; } = string.Empty;
        public int MajorVersion { get; set; }
        public int MinorVersion { get; set; }
        public int BuildVersion { get; set; }
        public string Edition { get; set; } = string.Empty;
        public bool SupportsApproximateCount { get; set; }
        public DateTime CheckedAt { get; set; } = DateTime.UtcNow;
    }
}
