namespace MfiManager.App.Infrastructure.Settings {
    public class MFILogging {
        public const string SectionName = "MFILogging";
        public string FileName { get; set; } = "app";
        public string LogFolder { get; set; } = "MfiLogs";
    }
}
