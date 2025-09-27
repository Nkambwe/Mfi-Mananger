using MfiManager.Middleware.Data.Connection;

namespace MfiManager.Middleware.Configurations.Providers {
    public interface IDabaseServiceProvider {
        DatabaseProvider Provider {get; }
        string MinimumVersionForApproximateCount {get; }
        bool ForceVersionCheck {get; }
        TimeSpan VersionCheckCacheTime {get; }
    }
}
