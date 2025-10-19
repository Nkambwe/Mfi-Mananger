using MfiManager.Middleware.Configuration.Options;

namespace MfiManager.Middleware.Data.Services {
    public interface ILoggingConfigService {
        ServiceLoggingOption GetSettings();
        void UpdateSettings(ServiceLoggingOption settings);
    }
}
