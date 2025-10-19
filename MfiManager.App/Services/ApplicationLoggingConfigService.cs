using MfiManager.App.Infrastructure.Settings;
using Microsoft.Extensions.Options;

namespace MfiManager.App.Services {
    public class ApplicationLoggingConfigService(IConfiguration configuration, IOptionsMonitor<MfiLogging> optionsMonitor) : IApplicationLoggingConfigService {
        private readonly IConfiguration _configuration = configuration;
        private readonly IOptionsMonitor<MfiLogging> _optionsMonitor = optionsMonitor;
        private readonly string _configFile = "appsettings.json";
        public MfiLogging GetSettings() 
            =>  _optionsMonitor.CurrentValue;

        public void UpdateSettings(MfiLogging settings) {
                var json = File.ReadAllText(_configFile);
                dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);

                jsonObj["LoggingOptions"]["DefaultLogName"] = settings.FileName;
                jsonObj["LoggingOptions"]["LogFolder"] = settings.LogFolder;
                jsonObj["LoggingOptions"]["MaxFileSizeInMB"] = settings.MaxFileSizeInMB;
                jsonObj["LoggingOptions"]["MaxRollingFiles"] = settings.MaxRollingFiles;
                jsonObj["LoggingOptions"]["RetentionDays"] = settings.RetentionDays;

                string output = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(_configFile, output);
            }
    }
}
