using Microsoft.Extensions.Options;

namespace MfiManager.App.Infrastructure.Settings {
    public class EnvironmentProvider(IOptions<MFIEnvironment> options) : IEnvironmentProvider {

        private readonly MFIEnvironment _environmentOptions = options.Value;
        public bool IsLive => _environmentOptions.IsLive;
    }
}
