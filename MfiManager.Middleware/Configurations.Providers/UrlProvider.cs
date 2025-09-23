using MfiManager.Middleware.Configuration.Options;
using Microsoft.Extensions.Options;

namespace MfiManager.Middleware.Configurations.Providers {
    public class UrlProvider(IOptions<UrlOptions> options) : IUrlProvider {
        private readonly UrlOptions _options = options.Value;
        public string BaseUrl => _options.BaseUrl;
    }
}
