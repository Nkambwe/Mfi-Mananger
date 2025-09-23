using MfiManager.Middleware.Utils;

namespace MfiManager.Middleware.Factories {
    public interface IServiceLoggerFactory {
        IServiceLogger CreateLogger();
        IServiceLogger CreateLogger(string logName);
    }
}
