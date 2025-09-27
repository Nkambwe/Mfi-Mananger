using MfiManager.Middleware.Configuration.Options;
using MfiManager.Middleware.Data.Connection;
using Microsoft.Extensions.Options;

namespace MfiManager.Middleware.Configurations.Providers {
    public class DabaseServiceProvider(IOptions<DatabaseProviderOptions> options) : IDabaseServiceProvider {
        private readonly DatabaseProviderOptions _options = options.Value;
        public DatabaseProvider Provider => _options.Provider;
        public string MinimumVersionForApproximateCount => _options.MinimumVersionForApproximateCount;
        public bool ForceVersionCheck => _options.ForceVersionCheck;
        public TimeSpan VersionCheckCacheTime=> _options.VersionCheckCacheTime;
    }
}
