using Microsoft.EntityFrameworkCore;
using MfiManager.Middleware.Logging;
using MfiManager.Middleware.Configuration.Options;
using MfiManager.Middleware.Configurations.Providers;
using MfiManager.Middleware.Cyphers;
using MfiManager.Middleware.Enums;

namespace MfiManager.Middleware.Data {
    /// <summary>
    /// Runtime context factory — used by middleware services (NOT EF CLI).
    /// Supports SQL Server, PostgreSQL, and Oracle dynamically.
    /// </summary>
    public class MfiManagerContextFactory
    {
        private readonly IServiceLogger _logger;
        private readonly IEnvironmentProvider _environment;
        private readonly IDataConnectionProvider _dataConnectionProvider;
        private readonly DatabaseProviderOptions _dbProviderOptions;

        public MfiManagerContextFactory(
            IServiceLoggerFactory loggerFactory,
            IDataConnectionProvider dataConnectionProvider,
            IEnvironmentProvider environment,
            DatabaseProviderOptions dbProviderOptions)
        {
            _logger = loggerFactory.CreateLogger("middleware_log");
            _logger.Channel = $"DBCONNECTION-{DateTime.Now:yyyyMMddHHmmss}";
            _dataConnectionProvider = dataConnectionProvider;
            _environment = environment;
            _dbProviderOptions = dbProviderOptions;
        }

        /// <summary>
        /// Creates a runtime DbContext instance with the correct database provider.
        /// </summary>
        public MfiManagerDbContext CreateDbContext() {
            var optionsBuilder = new DbContextOptionsBuilder<MfiManagerDbContext>();

            try {
                var isLive = _environment.IsLive;
                var connectionVar = _dataConnectionProvider.DefaultConnection;

                if (string.IsNullOrWhiteSpace(connectionVar))
                {
                    var msg = "Environment variable name for DB connection not found.";
                    _logger.Log(msg, "DB_ERROR");
                    throw new Exception(msg);
                }

                string connectionString = Environment.GetEnvironmentVariable(connectionVar);
                if (string.IsNullOrWhiteSpace(connectionString))
                {
                    var msg = $"Environment variable '{connectionVar}' is empty or missing.";
                    _logger.Log(msg, "DB_ERROR");
                    throw new Exception(msg);
                }

                //..decrypt connection string
                string decryptedString = HashGenerator.DecryptString(connectionString);

                //..log provider information
                _logger.Log($"Using Database Provider: {_dbProviderOptions.Provider}", "DB_CONFIG");
                _logger.Log($"Environment: {(isLive ? "LIVE" : "DEV")}", "DB_CONFIG");

                //..switch provider dynamically
                switch (_dbProviderOptions.Provider) {
                    case DatabaseProvider.SqlServer:
                        optionsBuilder.UseSqlServer(decryptedString);
                        break;
                    case DatabaseProvider.PostgreSQL:
                        optionsBuilder.UseNpgsql(decryptedString);
                        break;
                    case DatabaseProvider.Oracle:
                        optionsBuilder.UseOracle(decryptedString);
                        break;
                    default:
                        var msg = $"Unsupported database provider: {_dbProviderOptions.Provider}";
                        _logger.Log(msg, "DB_ERROR");
                        throw new NotSupportedException(msg);
                }

                _logger.Log($"Database connection configured successfully.", "DB_OK");
            }
            catch (Exception ex)
            {
                _logger.Log($"Database connection failed. {ex.Message}", "DB_ERROR");
                throw;
            }

            return new MfiManagerDbContext(optionsBuilder.Options);
        }
    }
}
