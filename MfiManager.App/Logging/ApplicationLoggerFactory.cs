using MfiManager.App.Infrastructure.Settings;
using Microsoft.Extensions.Options;

namespace MfiManager.App.Logging {
    public class ApplicationLoggerFactory(IEnvironmentProvider environmentProvider,
                                  IOptions<MfiLogging> loggingOptions) : IApplicationLoggerFactory {
        private readonly IEnvironmentProvider _environmentProvider = environmentProvider;
        private readonly IOptions<MfiLogging> _loggingOptions = loggingOptions;

        public IApplicationLogger CreateLogger() 
            => new ApplicationLogger(_environmentProvider, _loggingOptions, _loggingOptions.Value.FileName);

        public IApplicationLogger CreateLogger(string logName) 
            => new ApplicationLogger(_environmentProvider, _loggingOptions, logName);
    }

}
