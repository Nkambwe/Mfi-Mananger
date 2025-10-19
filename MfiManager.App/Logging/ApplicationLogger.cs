using MfiManager.App.Infrastructure.Settings;
using Microsoft.Extensions.Options;
using System.Collections.Concurrent;

namespace MfiManager.App.Logging {
    /// <summary>
    /// Application logging class
    /// </summary>
    public class ApplicationLogger : IApplicationLogger {
        private readonly IEnvironmentProvider _environment;
        private readonly MfiLogging _loggingOptions;
        private readonly string _fileName;
        private readonly string _folderName;
        private static readonly ConcurrentDictionary<string, SemaphoreSlim> _fileLocks = new();

        public string Id { get; set; }
        public string Channel { get; set; }

        public ApplicationLogger(IEnvironmentProvider environment, IOptions<MfiLogging> loggingOptions, string logName) {
            _environment = environment;
            _loggingOptions = loggingOptions.Value;
            _fileName = string.IsNullOrWhiteSpace(logName) ? _loggingOptions.FileName : logName;
            _folderName = _loggingOptions.LogFolder;
        }

        public void Log(string message, string type = "MSG") {
            var date = DateTime.Now;
            var shortDate = date.ToString("yyyy-MM-dd");

            var rootPath = _environment.IsLive ? @$"E:\{_folderName}\Activity_Logs": @$"C:\{_folderName}\Activity_Logs";

            var basePath = Path.Combine(rootPath, _folderName);
            Directory.CreateDirectory(basePath);

            //..cleanup old logs
            CleanupOldLogs(basePath); 

            string filepath = GetRollingFilePath(basePath, shortDate);

            try
            {
                var tz = TimeZoneInfo.FindSystemTimeZoneById("E. Africa Standard Time");
                var abbrev = string.Concat(tz.StandardName.Split(' ').Select(w => w[0]));

                var timeIn = $"{date:yyyy.MM.dd HH:mm:ss} {abbrev}";
                var messageToLog =
                    $"[{timeIn}]: [{type}]\t{(Channel != null ? $"CHANNEL: {Channel}\t" : "")}{(Id != null ? Id + "\t" : "")}{message}";

                

                //..write to log file
                WriteToFile(filepath, messageToLog);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Failed to log message: {ex}");
            }
        }

        private string GetRollingFilePath(string basePath, string shortDate) {
            var maxSize = _loggingOptions.MaxFileSizeInMB * 1024 * 1024;
            var baseFileName = $"mfi_{_fileName}_{shortDate}";

            for (int i = 0; i < _loggingOptions.MaxRollingFiles; i++) {
                string filePath = Path.Combine(basePath, $"{baseFileName}_{i}.txt");

                if (!File.Exists(filePath))
                    return filePath;

                var fileInfo = new FileInfo(filePath);
                if (fileInfo.Length < maxSize)
                    return filePath;
            }

            //..if all files are full, roll back to first file (overwrite oldest)
            return Path.Combine(basePath, $"{baseFileName}_0.txt");
        }

        private static void WriteToFile(string filepath, string message) {
            var fileLock = _fileLocks.GetOrAdd(filepath, _ => new SemaphoreSlim(1, 1));
            fileLock.Wait();
            try {
                File.AppendAllText(filepath, message + Environment.NewLine);
            } finally {
                fileLock.Release();
            }
        }

        private void CleanupOldLogs(string basePath) {
            try {
                var files = Directory.GetFiles(basePath, "mfi_*", SearchOption.TopDirectoryOnly);
                foreach (var file in files) {
                    var info = new FileInfo(file);
                    if (info.CreationTime < DateTime.Now.AddDays(-_loggingOptions.RetentionDays)) {
                        info.Delete();
                    }
                }
            } catch (Exception ex) {
                Console.Error.WriteLine($"Failed to cleanup logs: {ex}");
            }
        }
    }

}
