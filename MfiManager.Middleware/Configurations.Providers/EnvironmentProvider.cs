using MfiManager.Middleware.Configuration.Options;
using Microsoft.Extensions.Options;

namespace MfiManager.Middleware.Configurations.Providers {
    public class EnvironmentProvider(IOptions<EnvironmentOptions> options) : IEnvironmentProvider {

        private readonly EnvironmentOptions _options = options.Value;
        public bool IsLive => _options.IsLive;
    }

}
