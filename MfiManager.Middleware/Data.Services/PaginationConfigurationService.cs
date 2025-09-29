using MfiManager.Middleware.Configuration.Options;
using MfiManager.Middleware.Logging;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using System.Linq.Expressions;

namespace MfiManager.Middleware.Data.Services {
    public class PaginationConfigurationService : IPaginationConfigurationService {
        private readonly PaginationOptions _settings;
        private readonly DatabaseProviderOptions _dbOptions;
        private readonly MfiManagerDbContext _context;
        private readonly IServiceLogger _logger;
        private readonly IMemoryCache _cache;
        private readonly IDatabaseVersionCheckerService _versionChecker;

        public PaginationConfigurationService(
                IOptions<PaginationOptions> settings,
                IOptions<DatabaseProviderOptions> dbOptions,
                IDatabaseVersionCheckerService versionChecker,
                MfiManagerDbContext context,
                IServiceLoggerFactory loggerFactory,
                IMemoryCache cache) {
            _settings = settings.Value;
            _dbOptions = dbOptions.Value;
            _context = context;
            _logger = loggerFactory.CreateLogger();
            _logger.Channel = $"PAGINATION-{DateTime.Now:yyyyMMddHHmmss}";
            _versionChecker = versionChecker;
        }

        public bool ShouldUseApproximateCount<T>() where T : class
            => ShouldUseApproximateCount(typeof(T));

        public bool ShouldUseApproximateCount(Type entityType) {
            // ..check if approximate count is globally disabled
            if (!_settings.EnableApproximateCount) {
                _logger.Log("Approximate count globally disabled for {EntityType}", entityType.Name);
                return false;
            }

            //..check if database provider supports approximate counts
            if (!DatabaseSupportsApproximateCount()) {
                _logger.Log($"Database provider {_dbOptions.Provider} doesn't support approximate count","INFO");
                return false;
            }

            //..check entity-specific configuration
            var entityName = entityType.Name;
            if (_settings.EntityConfigurations.TryGetValue(entityName, out var entityConfig)) {
                if (entityConfig.UseApproximateCount.HasValue) {
                    _logger.Log($"Using entity-specific approximate count setting for {entityName}: {entityConfig.UseApproximateCount.Value}","INFO");
                    return entityConfig.UseApproximateCount.Value;
                }

                // If entity has estimated row count, use it for decision
                if (entityConfig.EstimatedRowCount.HasValue) {
                    var threshold = entityConfig.ApproximateCountThreshold ?? _settings.ApproximateCountThreshold;
                    var shouldUse = entityConfig.EstimatedRowCount.Value >= threshold;
                
                    _logger.Log($"Entity {entityName} estimated rows: {entityConfig.EstimatedRowCount.Value}, threshold: {threshold}, using approximate: {shouldUse}", "INFO");
                    return shouldUse;
                }
            }

            //..default: check if entity is known to be large
            return IsLargeTable(entityType);
        }

        public async Task<bool> ShouldUseApproximateCountAsync<T>(Expression<Func<T, bool>>? predicate = null) where T : class
        {
            var entityType = typeof(T);
        
            // Check basic configuration first
            if (!ShouldUseApproximateCount(entityType))
                return false;

            // Check database support asynchronously
            if (!await DatabaseSupportsApproximateCountAsync())
                return false;

            // Rest of the logic remains the same...
            if (predicate != null)
            {
                _logger.Log($"Predicate present for {entityType.Name}, skipping approximate count","INFO");
                return false;
            }

            return true;
        }

        public long GetApproximateCountThreshold<T>() where T : class {
            var entityType = typeof(T);
            var entityName = entityType.Name;

            if (_settings.EntityConfigurations.TryGetValue(entityName, out var entityConfig) && entityConfig.ApproximateCountThreshold.HasValue) {
                return entityConfig.ApproximateCountThreshold.Value;
            }

            return _settings.ApproximateCountThreshold;
        }

        #region Private helper methods
        private bool DatabaseSupportsApproximateCount() {
            try {
                return _versionChecker.SupportsApproximateCount();
            } catch (Exception ex) {
                _logger.Log("Failed to check database version support, assuming no approximate count support");
                _logger.Log($"{ex.Message}", "ERROR");
                _logger.Log($"{ex.StackTrace}", "STACKTRACE");
                return false;
            }
        }

        private async Task<bool> DatabaseSupportsApproximateCountAsync() {
            try {
                return await _versionChecker.SupportsApproximateCountAsync();
            } catch (Exception ex) {
                    _logger.Log("Failed to check database version support, assuming no approximate count support");
                    _logger.Log($"{ex.Message}", "ERROR");
                    _logger.Log($"{ex.StackTrace}", "STACKTRACE");
                    return false;
            }
        }

        private static bool IsLargeTable(Type entityType) {
            //..Heuristic: check if table name suggests it's a large table
            var entityName = entityType.Name.ToLower();
            var largeTableIndicators = new[] 
            { 
                "log", "audit", "history", "event", "transaction", 
                "order", "product", "user", "customer", "invoice", "ladger", "saving" 
            };

            return largeTableIndicators.Any(indicator => entityName.Contains(indicator));
        }

        #endregion
    }
}
