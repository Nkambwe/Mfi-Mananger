using MfiManager.Middleware.Configuration.Options;
using Microsoft.Extensions.Options;

namespace MfiManager.Middleware.Data.Services {
    public class LoggingConfigService(IConfiguration configuration, IOptionsMonitor<ServiceLoggingOption> optionsMonitor) 
            : ILoggingConfigService {
            private readonly IConfiguration _configuration = configuration;
            private readonly IOptionsMonitor<ServiceLoggingOption> _optionsMonitor = optionsMonitor;
            private readonly string _configFile = "appsettings.json";

            public ServiceLoggingOption GetSettings()
                =>  _optionsMonitor.CurrentValue;

            /// <summary>
            /// Update appsettings.json file
            /// </summary>
            /// <param name="settings"></param>
            public void UpdateSettings(ServiceLoggingOption settings) {
                var json = File.ReadAllText(_configFile);
                dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);

                jsonObj["LoggingOptions"]["DefaultLogName"] = settings.DefaultLogName;
                jsonObj["LoggingOptions"]["LogFolder"] = settings.LogFolder;
                jsonObj["LoggingOptions"]["MaxFileSizeInMB"] = settings.MaxFileSizeInMB;
                jsonObj["LoggingOptions"]["MaxRollingFiles"] = settings.MaxRollingFiles;
                jsonObj["LoggingOptions"]["RetentionDays"] = settings.RetentionDays;

                string output = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(_configFile, output);
            }
        }
    }
