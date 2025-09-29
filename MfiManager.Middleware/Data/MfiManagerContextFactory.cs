using MfiManager.Middleware.Configurations.Providers;
using MfiManager.Middleware.Cyphers;
using MfiManager.Middleware.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MfiManager.Middleware.Data {
    public class MfiManagerContextFactory: IDesignTimeDbContextFactory<MfiManagerDbContext> {

        private readonly IServiceLogger _logger;
        private readonly IEnvironmentProvider _environment;
        private readonly IDataConnectionProvider _dataConnectionProvider;

        public MfiManagerContextFactory(IServiceLoggerFactory loggerFactory, 
                                 IDataConnectionProvider dataConnectionProvider,
                                 IEnvironmentProvider environment) { 
            _logger = loggerFactory.CreateLogger("middleware_log");
            _logger.Channel = $"DBCONNECTION-{DateTime.Now:yyyyMMddHHmmss}";
            _dataConnectionProvider = dataConnectionProvider;
            _environment = environment;
        }

        public MfiManagerDbContext CreateDbContext(string[] args) {
            var optionsBuilder = new DbContextOptionsBuilder<MfiManagerDbContext>();
            try {
                var isLive = _environment.IsLive;
                var connectionVar = _dataConnectionProvider.DefaultConnection;

                if(!string.IsNullOrWhiteSpace(connectionVar)){ 
                    //Retrieve the connection string from environment variables
                    string connectionString = Environment.GetEnvironmentVariable(connectionVar);
                    if (!string.IsNullOrEmpty(connectionString)) {
                        string decryptedString = HashGenerator.DecryptString(connectionString);
                        if(isLive){ 
                            _logger.Log($"CONNECTION URL :: {connectionString}", "INFO");
                        } else {
                            _logger.Log($"CONNECTION URL :: {decryptedString}", "INFO");
                        }

                        optionsBuilder.UseSqlServer(decryptedString);
                    } else {
                        string msg="Environmental variable name 'MFI_DBCONNECTION_ENV' which holds connection string not found";
                        _logger.Log(msg, "DB_ERROR");
                        throw new Exception(msg);
                    }
                } else {

                }
                
            } catch (Exception e) {
                _logger.Log($"Database connection failed. {e.Message}", "ERROR");
            }

            return new MfiManagerDbContext(optionsBuilder.Options);
        }
    }
}
