using MfiManager.Middleware.Configuration.Options;
using MfiManager.Middleware.Configurations.Providers;
using MfiManager.Middleware.Utils;
using Microsoft.Extensions.Options;

namespace MfiManager.Middleware.Factories {
    public class ServiceLoggerFactory(IEnvironmentProvider environmentProvider, IOptions<ServiceLoggingOption> loggingOptions) {

         private readonly IEnvironmentProvider _environmentProvider = environmentProvider;
         private readonly IOptions<ServiceLoggingOption> _loggingOptions = loggingOptions;

        public IServiceLogger CreateLogger()
            => new ServiceLogger(_environmentProvider,  _loggingOptions, _loggingOptions.Value.DefaultLogName);

         public IServiceLogger CreateLogger(string name)
            => new ServiceLogger(_environmentProvider, _loggingOptions, name);
    }
}
