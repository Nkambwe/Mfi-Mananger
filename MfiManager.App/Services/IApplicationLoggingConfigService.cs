using MfiManager.App.Infrastructure.Settings;

namespace MfiManager.App.Services {

    public interface IApplicationLoggingConfigService {
        MfiLogging GetSettings();
        void UpdateSettings(MfiLogging settings);
    }
}
