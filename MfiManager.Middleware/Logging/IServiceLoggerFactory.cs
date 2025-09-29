namespace MfiManager.Middleware.Logging {
    public interface IServiceLoggerFactory {
        IServiceLogger CreateLogger();
        IServiceLogger CreateLogger(string logName);
    }
}
