using MfiManager.Middleware.Configuration.Options;
using Microsoft.Extensions.Options;

namespace MfiManager.Middleware.Configurations.Providers {

    public class DataConnectionProvider(IOptions<DataConnectionOptions> options) : IDataConnectionProvider {
        private readonly DataConnectionOptions _options = options.Value;
        public string DefaultConnection => _options.DefaultConnection;
    }

}
