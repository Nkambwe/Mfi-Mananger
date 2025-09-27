using MfiManager.Middleware.Configuration.Options;
using MfiManager.Middleware.Data.Connection;
using MfiManager.Middleware.Factories;
using MfiManager.Middleware.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using System.Collections.Concurrent;
using System.Text.RegularExpressions;

namespace MfiManager.Middleware.Data.Services {

    public class DatabaseVersionCheckerService : IDatabaseVersionCheckerService {
        private readonly MfiManagerDbContext _context;
        private readonly DatabaseProviderOptions _dbProvider;
        private readonly IMemoryCache _cache;
        private readonly IServiceLogger _logger;
        //..cache for version info to avoid repeated database calls
        private static readonly ConcurrentDictionary<string, DatabaseVersionInfo> _versionCache = new();
        private readonly string _cacheKey;

        public DatabaseVersionCheckerService(MfiManagerDbContext context,  IOptions<DatabaseProviderOptions> _dbProviderOptions, 
                                    IMemoryCache cache, 
                                    IServiceLoggerFactory loggerFactory){
            _context = context;
             _dbProvider = _dbProviderOptions.Value;
            _cache = cache;
           _logger = loggerFactory.CreateLogger();
            _logger.Channel = $"DB-VERSIONCHECKER-{DateTime.Now:yyyyMMddHHmmss}";
            _cacheKey = $"db_version_{context.Database.GetConnectionString()?.GetHashCode()}";
        }

        public async Task<DatabaseVersionInfo> GetVersionInfoAsync() {
            return await _cache.GetOrCreateAsync(_cacheKey, async entry => {
                entry.AbsoluteExpirationRelativeToNow = _dbProvider.VersionCheckCacheTime;

                try {
                    var provider = DetectDatabaseProvider();
                    _logger.Log($"Detected database provider: {provider}", "INFO");

                    return provider switch {
                        DatabaseProvider.SqlServer => await GetSqlServerVersionAsync(),
                        DatabaseProvider.PostgreSQL => await GetPostgreSQLVersionAsync(),
                        DatabaseProvider.MySQL => await GetMySQLVersionAsync(),
                        DatabaseProvider.SQLite => await GetSQLiteVersionAsync(),
                        DatabaseProvider.Oracle => await GetOracleVersionAsync(),
                        _ => new DatabaseVersionInfo { SupportsApproximateCount = false }
                    };
                } catch (Exception ex) {
                    _logger.Log("Failed to get database version information");
                    _logger.Log($"{ex.Message}", "ERROR");
                    _logger.Log($"{ex.StackTrace}", "STACKTRACE");
                    return new DatabaseVersionInfo { SupportsApproximateCount = false };
                }
            }) ?? new DatabaseVersionInfo();
        }

        public bool SupportsApproximateCount() {
            //..synchronous version, use cached result if available
            if (_versionCache.TryGetValue(_cacheKey, out var cachedInfo)) {
                //..check if cache is still valid
                if (DateTime.UtcNow - cachedInfo.CheckedAt < _dbProvider.VersionCheckCacheTime) {
                    return cachedInfo.SupportsApproximateCount;
                }
            }

            //..fallback to provider-based heuristic if no cached version
            var provider = DetectDatabaseProvider();
            return provider switch {
                //..assume modern SQL Server
                DatabaseProvider.SqlServer => true, 
                DatabaseProvider.PostgreSQL => true,
                DatabaseProvider.Oracle => true,
                DatabaseProvider.MySQL => false,
                DatabaseProvider.SQLite => false,
                _ => false
            };
        }

        public async Task<bool> SupportsApproximateCountAsync() {
            var versionInfo = await GetVersionInfoAsync();
            return versionInfo.SupportsApproximateCount;
        }

        private DatabaseProvider DetectDatabaseProvider() {
            var connectionString = _context.Database.GetConnectionString()?.ToLower() ?? "";
            var providerName = _context.Database.ProviderName?.ToLower() ?? "";

            //..check by provider name first
            if (providerName.Contains("sqlserver") || providerName.Contains("microsoft.entityframeworkcore.sqlserver"))
                return DatabaseProvider.SqlServer;
        
            if (providerName.Contains("postgresql") || providerName.Contains("npgsql"))
                return DatabaseProvider.PostgreSQL;
        
            if (providerName.Contains("mysql") || providerName.Contains("pomelo"))
                return DatabaseProvider.MySQL;
        
            if (providerName.Contains("sqlite"))
                return DatabaseProvider.SQLite;
        
            if (providerName.Contains("oracle"))
                return DatabaseProvider.Oracle;

            //..fallback: check connection string
            if (connectionString.Contains("server=") || connectionString.Contains("data source=") && 
                (connectionString.Contains("sql") || connectionString.Contains("integrated security")))
                return DatabaseProvider.SqlServer;
        
            if (connectionString.Contains("host=") || connectionString.Contains("server=") && connectionString.Contains("port=5432"))
                return DatabaseProvider.PostgreSQL;
        
            if (connectionString.Contains("server=") && connectionString.Contains("port=3306"))
                return DatabaseProvider.MySQL;
        
            if (connectionString.Contains(".db") || connectionString.Contains("data source=") && connectionString.Contains(".sqlite"))
                return DatabaseProvider.SQLite;

            return DatabaseProvider.Unknown;
        }
        
        public DatabaseProvider GetDatabaseProvider()
            => DetectDatabaseProvider();

        public async Task<DatabaseProviderInfo> GetDatabaseProviderInfoAsync() {
            var provider = DetectDatabaseProvider();
            var providerName = _context.Database.ProviderName ?? "Unknown";
            var connectionString = _context.Database.GetConnectionString() ?? "Unknown";
        
            //..mask sensitive information in connection string
            var maskedConnectionString = MaskConnectionString(connectionString);
            var detectionMethod = DetermineDetectionMethod(provider, providerName, connectionString);
            var supportedFeatures = GetSupportedFeatures(provider);
            var versionInfo = await GetVersionInfoAsync();

            return new DatabaseProviderInfo
            {
                Provider = provider,
                ProviderName = providerName,
                ConnectionString = maskedConnectionString,
                DetectionMethod = detectionMethod,
                IsSupported = provider != DatabaseProvider.Unknown,
                SupportedFeatures = supportedFeatures
            };
        }

        #region SQL Server Version Checking

        private async Task<DatabaseVersionInfo> GetSqlServerVersionAsync() {
            try {
                var versionQuery = @"
                    SELECT 
                        @@VERSION as VersionString,
                        SERVERPROPERTY('ProductVersion') as ProductVersion,
                        SERVERPROPERTY('ProductLevel') as ProductLevel,
                        SERVERPROPERTY('Edition') as Edition,
                        SERVERPROPERTY('ProductMajorVersion') as MajorVersion,
                        SERVERPROPERTY('ProductMinorVersion') as MinorVersion,
                        SERVERPROPERTY('ProductBuild') as BuildVersion";

                var versionResult = await _context.Database
                    .SqlQueryRaw<SqlServerVersionDto>(versionQuery)
                    .FirstOrDefaultAsync();

                if (versionResult == null)
                    return new DatabaseVersionInfo { SupportsApproximateCount = false };

                var majorVersion = ParseInt(versionResult.MajorVersion?.ToString());
                var minorVersion = ParseInt(versionResult.MinorVersion?.ToString());
                var buildVersion = ParseInt(versionResult.BuildVersion?.ToString());

                //..SQL Server 2012 (version 11) and later support sys.dm_db_partition_stats
                var supportsApproximate = majorVersion >= 11;

                _logger.Log($"SQL Server version detected: {majorVersion}.{minorVersion}.{buildVersion}, Edition: {versionResult.Edition}, Supports Approximate: {supportsApproximate}","INFO" );
                return new DatabaseVersionInfo {
                    VersionString = versionResult.VersionString ?? "",
                    MajorVersion = majorVersion,
                    MinorVersion = minorVersion,
                    BuildVersion = buildVersion,
                    Edition = versionResult.Edition ?? "",
                    SupportsApproximateCount = supportsApproximate
                };
            } catch (Exception ex) {
                _logger.Log("Failed to get SQL Server version");
                _logger.Log($"{ex.Message}", "ERROR");
                _logger.Log($"{ex.StackTrace}", "STACKTRACE");
                return new DatabaseVersionInfo { SupportsApproximateCount = false };
            }
        }

        private class SqlServerVersionDto {
            public string VersionString { get; set; }
            public object MajorVersion { get; set; }
            public object MinorVersion { get; set; }
            public object BuildVersion { get; set; }
            public string Edition { get; set; }
        }

        #endregion

        #region PostgreSQL Version Checking

        private async Task<DatabaseVersionInfo> GetPostgreSQLVersionAsync() {
            try {
                var versionQuery = "SELECT version() as version_string";
                var versionResult = await _context.Database
                    .SqlQueryRaw<PostgreSQLVersionDto>(versionQuery)
                    .FirstOrDefaultAsync();

                if (versionResult?.VersionString == null)
                    return new DatabaseVersionInfo { SupportsApproximateCount = false };

                //arse PostgreSQL version string: "PostgreSQL 13.4 on x86_64-pc-linux-gnu..."
                var versionMatch = Regex.Match(versionResult.VersionString, @"PostgreSQL\s+(\d+)\.(\d+)(?:\.(\d+))?");
            
                if (!versionMatch.Success)
                    return new DatabaseVersionInfo { SupportsApproximateCount = false };

                var majorVersion = int.Parse(versionMatch.Groups[1].Value);
                var minorVersion = ParseInt(versionMatch.Groups[2].Value);
                var patchVersion = ParseInt(versionMatch.Groups[3].Value);

                // pg_stat_user_tables available since PostgreSQL 8.1
                var supportsApproximate = majorVersion >= 8 || (majorVersion == 8 && minorVersion >= 1);

                _logger.Log($"PostgreSQL version detected: {majorVersion}.{minorVersion}.{patchVersion}, Supports Approximate: {supportsApproximate}","INFO");
                return new DatabaseVersionInfo {
                    VersionString = versionResult.VersionString,
                    MajorVersion = majorVersion,
                    MinorVersion = minorVersion,
                    BuildVersion = patchVersion,
                    Edition = "PostgreSQL",
                    SupportsApproximateCount = supportsApproximate
                };
            } catch (Exception ex) {
                //..assume it supports it
                _logger.Log("Failed to get PostgreSQL version");
                _logger.Log($"{ex.Message}", "ERROR");
                _logger.Log($"{ex.StackTrace}", "STACKTRACE");
                return new DatabaseVersionInfo { SupportsApproximateCount = true }; 
            }
        }

        private class PostgreSQLVersionDto {
            public string VersionString { get; set; }
        }

        #endregion

        #region MySQL Version Checking

        private async Task<DatabaseVersionInfo> GetMySQLVersionAsync() {
            try {
                var versionQuery = "SELECT VERSION() as version_string";
                var versionResult = await _context.Database
                    .SqlQueryRaw<MySQLVersionDto>(versionQuery)
                    .FirstOrDefaultAsync();

                if (versionResult?.VersionString == null)
                    return new DatabaseVersionInfo { SupportsApproximateCount = false };

                //..parse MySQL version string: "8.0.25" or "5.7.34-log"
                var versionMatch = Regex.Match(versionResult.VersionString, @"^(\d+)\.(\d+)\.(\d+)");
                if (!versionMatch.Success)
                    return new DatabaseVersionInfo { SupportsApproximateCount = false };

                var majorVersion = int.Parse(versionMatch.Groups[1].Value);
                var minorVersion = int.Parse(versionMatch.Groups[2].Value);
                var patchVersion = int.Parse(versionMatch.Groups[3].Value);

                // MySQL has INFORMATION_SCHEMA.TABLES with TABLE_ROWS (approximate)
                var supportsApproximate = majorVersion >= 8 || (majorVersion == 5 && minorVersion >= 7);

                _logger.Log($"MySQL version detected: {majorVersion}.{minorVersion}.{patchVersion}, Supports Approximate: {supportsApproximate}","INFO");

                return new DatabaseVersionInfo {
                    VersionString = versionResult.VersionString,
                    MajorVersion = majorVersion,
                    MinorVersion = minorVersion,
                    BuildVersion = patchVersion,
                    Edition = "MySQL",
                    SupportsApproximateCount = supportsApproximate
                };
            } catch (Exception ex) {
                _logger.Log("Failed to get MySQL version");
                _logger.Log($"{ex.Message}", "ERROR");
                _logger.Log($"{ex.StackTrace}", "STACKTRACE");
                return new DatabaseVersionInfo { SupportsApproximateCount = false };
            }
        }

        private class MySQLVersionDto {
            public string VersionString { get; set; }
        }

        #endregion

        #region SQLite Version Checking

        private async Task<DatabaseVersionInfo> GetSQLiteVersionAsync() {
            try {
                var versionQuery = "SELECT sqlite_version() as version_string";
                var versionResult = await _context.Database.SqlQueryRaw<SQLiteVersionDto>(versionQuery).FirstOrDefaultAsync();

                if (versionResult?.VersionString == null)
                    return new DatabaseVersionInfo { SupportsApproximateCount = false };

                var versionMatch = Regex.Match(versionResult.VersionString, @"^(\d+)\.(\d+)\.(\d+)");
            
                var majorVersion = 0;
                var minorVersion = 0;
                var patchVersion = 0;
                if (versionMatch.Success) {
                    majorVersion = int.Parse(versionMatch.Groups[1].Value);
                    minorVersion = int.Parse(versionMatch.Groups[2].Value);
                    patchVersion = int.Parse(versionMatch.Groups[3].Value);
                }

                // SQLite doesn't have built-in approximate count capabilities
                // Would require custom implementation or manual statistics tracking
                var supportsApproximate = false;

                _logger.Log($"SQLite version detected: {versionResult.VersionString}, Supports Approximate: {supportsApproximate}","INFO");
                return new DatabaseVersionInfo {
                    VersionString = versionResult.VersionString,
                    MajorVersion = majorVersion,
                    MinorVersion = minorVersion,
                    BuildVersion = patchVersion,
                    Edition = "SQLite",
                    SupportsApproximateCount = supportsApproximate
                };
            } catch (Exception ex) {
                _logger.Log("Failed to get SQLite version");
                _logger.Log($"{ex.Message}", "ERROR");
                _logger.Log($"{ex.StackTrace}", "STACKTRACE");
                return new DatabaseVersionInfo { SupportsApproximateCount = false };
            }
        }

        private class SQLiteVersionDto {
            public string VersionString { get; set; }
        }

        #endregion

        #region Oracle Version Checking

        private async Task<DatabaseVersionInfo> GetOracleVersionAsync() {
            try {
                var versionQuery = @"
                    SELECT 
                        BANNER as version_string,
                        VERSION_FULL as full_version
                    FROM V$VERSION 
                    WHERE BANNER LIKE 'Oracle Database%'";

                var versionResult = await _context.Database
                    .SqlQueryRaw<OracleVersionDto>(versionQuery)
                    .FirstOrDefaultAsync();

                if (versionResult?.VersionString == null)
                    return new DatabaseVersionInfo { SupportsApproximateCount = false };

                //..Oracle version: "Oracle Database 19c Enterprise Edition Release 19.0.0.0.0"
                var versionMatch = Regex.Match(versionResult.VersionString, @"(\d+)c?\s.*Release\s(\d+)\.(\d+)\.(\d+)");
                var majorVersion = 0;
                var minorVersion = 0;
                var patchVersion = 0;

                if (versionMatch.Success) {
                    majorVersion = int.Parse(versionMatch.Groups[1].Value);
                    minorVersion = int.Parse(versionMatch.Groups[2].Value);
                    patchVersion = int.Parse(versionMatch.Groups[3].Value);
                }

                // Oracle has USER_TABLES.NUM_ROWS and DBA_TABLES.NUM_ROWS
                // Oracle 10g and later
                var supportsApproximate = majorVersion >= 10; 
                _logger.Log($"Oracle version detected: {versionResult.VersionString}, Major: {majorVersion}, Supports Approximate: {supportsApproximate}","INFO");
                return new DatabaseVersionInfo {
                    VersionString = versionResult.VersionString,
                    MajorVersion = majorVersion,
                    MinorVersion = minorVersion,
                    BuildVersion = patchVersion,
                    Edition = "Oracle",
                    SupportsApproximateCount = supportsApproximate
                };
            } catch (Exception ex) {
                _logger.Log("Failed to get Oracle version");
                _logger.Log($"{ex.Message}", "ERROR");
                _logger.Log($"{ex.StackTrace}", "STACKTRACE");
                return new DatabaseVersionInfo { SupportsApproximateCount = true }; 
            }
        }

        private class OracleVersionDto {
            public string VersionString { get; set; }
            public string FullVersion { get; set; }
        }

        #endregion

        private static int ParseInt(string value, int defaultValue = 0)
            => int.TryParse(value, out var result) ? result : defaultValue;

        private static string MaskConnectionString(string connectionString) {
            if (string.IsNullOrEmpty(connectionString))
                return "Not Available";

            //mask sensitive information
            var masked = connectionString;
        
            //..common patterns to mask
            var patterns = new[] {
                (@"password\s*=\s*[^;]+", "Password=***"),
                (@"pwd\s*=\s*[^;]+", "Pwd=***"),
                (@"user\s*id\s*=\s*[^;]+", "User ID=***"),
                (@"uid\s*=\s*[^;]+", "UID=***")
            };

            foreach (var (pattern, replacement) in patterns) {
                masked = Regex.Replace(masked, pattern, replacement, RegexOptions.IgnoreCase);
            }

            return masked;
        }

        private static string DetermineDetectionMethod(DatabaseProvider provider, string providerName, string connectionString) {
            if (!string.IsNullOrEmpty(providerName)) {
                if (providerName.Contains("sqlserver", StringComparison.CurrentCultureIgnoreCase) || 
                    providerName.Contains("microsoft.entityframeworkcore.sqlserver", StringComparison.CurrentCultureIgnoreCase))
                    return "EF Core Provider Name (SQL Server)";
            
                if (providerName.Contains("postgresql", StringComparison.CurrentCultureIgnoreCase) || 
                    providerName.Contains("npgsql", StringComparison.CurrentCultureIgnoreCase))
                    return "EF Core Provider Name (PostgreSQL)";
            
                if (providerName.Contains("mysql", StringComparison.CurrentCultureIgnoreCase) || 
                    providerName.Contains("pomelo", StringComparison.CurrentCultureIgnoreCase))
                    return "EF Core Provider Name (MySQL)";
            
                if (providerName.Contains("sqlite", StringComparison.CurrentCultureIgnoreCase))
                    return "EF Core Provider Name (SQLite)";
            
                if (providerName.Contains("oracle", StringComparison.CurrentCultureIgnoreCase))
                    return "EF Core Provider Name (Oracle)";

                return $"EF Core Provider Name ({providerName})";
            }

            if (!string.IsNullOrEmpty(connectionString)) {
                return "Connection String Analysis";
            }

            return "Unknown Detection Method";
        }

        private static string[] GetSupportedFeatures(DatabaseProvider provider) { 
            return provider switch
            {
                DatabaseProvider.SqlServer =>
                [
                    "Approximate Count (sys.dm_db_partition_stats)",
                    "Advanced Pagination (OFFSET/FETCH)",
                    "Compiled Queries",
                    "Bulk Operations",
                    "Complex Joins",
                    "Window Functions"
                ],
                DatabaseProvider.PostgreSQL =>
                [
                    "Approximate Count (pg_stat_user_tables)",
                    "Advanced Pagination (LIMIT/OFFSET)",
                    "Compiled Queries",
                    "Complex Joins",
                    "Window Functions",
                    "Full Text Search"
                ],
                DatabaseProvider.MySQL =>
                [
                    "Limited Approximate Count (INFORMATION_SCHEMA)",
                    "Basic Pagination (LIMIT/OFFSET)",
                    "Compiled Queries",
                    "Complex Joins"
                ],
                DatabaseProvider.Oracle =>
                [
                    "Approximate Count (USER_TABLES.NUM_ROWS)",
                    "Advanced Pagination (ROWNUM/ROW_NUMBER)",
                    "Compiled Queries",
                    "Complex Joins",
                    "Window Functions"
                ],
                DatabaseProvider.SQLite =>
                [
                    "Basic Pagination (LIMIT/OFFSET)",
                    "Simple Queries",
                    "Compiled Queries"
                ],
                _ => ["Unknown Features"]
            };
        }

    }
}
