using MfiManager.Middleware.Configurations.Providers;
using MfiManager.Middleware.Data.Connection;
using MfiManager.Middleware.Data.Services;
using MfiManager.Middleware.Enums;
using Microsoft.AspNetCore.Mvc;

namespace MfiManager.Middleware.Controllers {

    public class MfiDatabaseInfoController(ILogger<MfiDatabaseInfoController> logger,
                                            IDatabaseVersionCheckerService versionChecker,
                                            IEnvironmentProvider environment,
                                            IServiceLocalization localizationService,
                                            ISystemErrorService errorService,
                                            ICompanyService companyService)
                                            : MfiBaseController(logger, environment, localizationService, errorService, companyService) {
        private readonly ILogger<MfiDatabaseInfoController> _logger = logger;
        private readonly IDatabaseVersionCheckerService _versionChecker = versionChecker;

        /// <summary>
        /// Get complete database information including version, provider, and capabilities
        /// </summary>
        [HttpGet("info")]
        public async Task<IActionResult> GetDatabaseInfo() {
            try {
                var versionInfo = await _versionChecker.GetVersionInfoAsync();
                var providerInfo = await _versionChecker.GetDatabaseProviderInfoAsync();

                var result = new {
                    Provider = new {
                        Name = providerInfo.Provider.ToString(),
                        providerInfo.ProviderName,
                        providerInfo.DetectionMethod,
                        providerInfo.IsSupported,
                        providerInfo.SupportedFeatures
                    },
                    Version = new {
                        versionInfo.VersionString,
                        Major = versionInfo.MajorVersion,
                        Minor = versionInfo.MinorVersion,
                        Build = versionInfo.BuildVersion,
                        versionInfo.Edition,
                        FormattedVersion = $"{versionInfo.MajorVersion}.{versionInfo.MinorVersion}.{versionInfo.BuildVersion}"
                    },
                    Metadata = new {
                        versionInfo.CheckedAt,
                         //..already masked
                        providerInfo.ConnectionString
                    }
                };

                return Ok(result);
            } catch (Exception ex) {
                _logger.LogError("Failed to get database information");
                _logger.LogError("Error Message - {Message}", ex.Message);
                _logger.LogError("{StackTrace}", ex.StackTrace);
                return StatusCode(500, new { Error = "Failed to retrieve database information" });
            }
        }

        /// <summary>
        /// Get only database version information
        /// </summary>
        [HttpGet("version")]
        public async Task<IActionResult> GetDatabaseVersion() {
            try {
                var versionInfo = await _versionChecker.GetVersionInfoAsync();
                return Ok(new {
                    Version = $"{versionInfo.MajorVersion}.{versionInfo.MinorVersion}.{versionInfo.BuildVersion}",
                    versionInfo.VersionString,
                    versionInfo.Edition,
                    versionInfo.SupportsApproximateCount,
                    versionInfo.CheckedAt
                });
            } catch (Exception ex) {
                _logger.LogError("Failed to get database version");
                _logger.LogError("Error Message - {Message}", ex.Message);
                _logger.LogError("{StackTrace}", ex.StackTrace);
                return StatusCode(500, new { Error = "Failed to retrieve database version" });
            }
        }

        /// <summary>
        /// Get only database provider information
        /// </summary>
        [HttpGet("provider")]
        public async Task<IActionResult> GetDatabaseProvider() {
            try {
                var providerInfo = await _versionChecker.GetDatabaseProviderInfoAsync();
                return Ok(new {
                    Provider = providerInfo.Provider.ToString(),
                    providerInfo.ProviderName,
                    providerInfo.DetectionMethod,
                    providerInfo.IsSupported,
                    providerInfo.SupportedFeatures,
                    providerInfo.ConnectionString
                });
            } catch (Exception ex) {
                _logger.LogError("Failed to get database provider information");
                _logger.LogError("Error Message - {Message}", ex.Message);
                _logger.LogError("{StackTrace}", ex.StackTrace);
                return StatusCode(500, new { Error = "Failed to retrieve database provider information" });
            }
        }

        /// <summary>
        /// Test approximate count capability
        /// </summary>
        [HttpGet("test-approximate-count")]
        public async Task<IActionResult> TestApproximateCount() {
            try {
                var supportsApproximate = await _versionChecker.SupportsApproximateCountAsync();
                var provider = _versionChecker.GetDatabaseProvider();

                return Ok(new {
                    Provider = provider.ToString(),
                    SupportsApproximateCount = supportsApproximate,
                    Recommendation = GetApproximateCountRecommendation(provider, supportsApproximate),
                    OptimalThreshold = GetOptimalThreshold(provider)
                });
            } catch (Exception ex) {
                _logger.LogError("Failed to test approximate count capability");
                _logger.LogError("Error Message - {Message}", ex.Message);
                _logger.LogError("{StackTrace}", ex.StackTrace);
                return StatusCode(500, new { Error = "Failed to test approximate count capability" });
            }
        }

        /// <summary>
        /// Get pagination recommendations based on database capabilities
        /// </summary>
        [HttpGet("pagination-recommendations")]
        public async Task<IActionResult> GetPaginationRecommendations() {
            try {
                var providerInfo = await _versionChecker.GetDatabaseProviderInfoAsync();
                var versionInfo = await _versionChecker.GetVersionInfoAsync();

                var recommendations = new
                {
                    Provider = providerInfo.Provider.ToString(),
                    OptimalStrategy = GetOptimalPaginationStrategy(providerInfo.Provider, versionInfo),
                    MaxPageSize = GetMaxRecommendedPageSize(providerInfo.Provider),
                    UseApproximateCount = versionInfo.SupportsApproximateCount,
                    ApproximateCountThreshold = GetOptimalThreshold(providerInfo.Provider),
                    PerformanceNotes = GetPerformanceNotes(providerInfo.Provider, versionInfo)
                };

                return Ok(recommendations);
            } catch (Exception ex) {
                _logger.LogError("Failed to get pagination recommendations");
                _logger.LogError("Error Message - {Message}", ex.Message);
                _logger.LogError("{StackTrace}", ex.StackTrace);
                return StatusCode(500, new { Error = "Failed to retrieve pagination recommendations" });
            }
        }

        #region Private methods

        private static string GetOptimalPaginationStrategy(DatabaseProvider provider, DatabaseVersionInfo versionInfo) {
            return provider switch {
                DatabaseProvider.SqlServer when versionInfo.MajorVersion >= 11 => "OFFSET/FETCH with approximate count for large tables",
                DatabaseProvider.SqlServer => "ROW_NUMBER() pagination with exact count",
                DatabaseProvider.PostgreSQL => "LIMIT/OFFSET with pg_stat_user_tables for approximate count",
                DatabaseProvider.Oracle => "ROW_NUMBER() or ROWNUM with table statistics",
                _ => "Basic pagination with exact count"
            };
        }

        private static int GetMaxRecommendedPageSize(DatabaseProvider provider) {
            return provider switch {
                DatabaseProvider.SqlServer => 1000,
                DatabaseProvider.PostgreSQL => 1000,
                DatabaseProvider.Oracle => 1000,
                _ => 100
            };
        }

        private static string GetApproximateCountRecommendation(DatabaseProvider provider, bool supportsApproximate) {
            return provider switch {
                DatabaseProvider.SqlServer => "Use sys.dm_db_partition_stats for fast approximate counts on tables with 100K+ rows.",
                DatabaseProvider.PostgreSQL => "Use pg_stat_user_tables for approximate counts. Ensure ANALYZE is run regularly.",
                DatabaseProvider.Oracle => "Use USER_TABLES.NUM_ROWS. Ensure statistics are gathered with ANALYZE TABLE.",
                _ => "Approximate count supported but use with caution."
            };
        }

        private static long GetOptimalThreshold(DatabaseProvider provider) {
            return provider switch {
                DatabaseProvider.SqlServer => 100_000,
                DatabaseProvider.PostgreSQL => 100_000,
                DatabaseProvider.Oracle => 100_000,
                _ => 1_000_000
            };
        }

        private static string[] GetPerformanceNotes(DatabaseProvider provider, DatabaseVersionInfo versionInfo) {
            return provider switch {
                DatabaseProvider.SqlServer =>
                [
                    "OFFSET/FETCH is optimized in SQL Server 2012+",
                    "Consider covering indexes for frequently paginated queries",
                    "Use cursor-based pagination for very large offsets (page 1000+)",
                    "sys.dm_db_partition_stats provides instant approximate counts"
                ],
                DatabaseProvider.PostgreSQL =>
                [
                    "LIMIT/OFFSET performance degrades with large offsets",
                    "Consider cursor-based pagination for better performance",
                    "pg_stat_user_tables provides good approximate counts",
                    "Ensure regular ANALYZE for accurate statistics"
                ],
                DatabaseProvider.Oracle =>
                [
                    "ROW_NUMBER() window function is well optimized",
                    "ROWNUM can be faster for simple queries",
                    "USER_TABLES.NUM_ROWS accuracy depends on statistics gathering",
                    "Consider using SAMPLE for very large approximate counts"
                ]
            };
        }

        #endregion

    }
}
