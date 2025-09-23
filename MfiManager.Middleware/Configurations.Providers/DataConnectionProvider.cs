using MfiManager.Middleware.Configuration.Options;
using Microsoft.Extensions.Options;

namespace MfiManager.Middleware.Configurations.Providers {
    public class DataConnectionProvider : IDataConnectionProvider {

        private readonly DataConnectionOptions _options;
        public string DefaultConnection => _options.DefaultConnection;

        public DataConnectionProvider(IOptions<DataConnectionOptions> options) {
            _options = options.Value;
        }

    }
}
