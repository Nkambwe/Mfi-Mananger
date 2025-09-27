using MfiManager.Middleware.Data.Connection;

namespace MfiManager.Middleware.Configuration.Options {

    public class DatabaseProviderOptions {
        /// <summary>
        /// Get or set section name
        /// </summary>
        public const string SectionName = "DatabaseProviderOptions";
        /// <summary>
        /// Database provider type
        /// </summary>
        public DatabaseProvider Provider { get; set; } = DatabaseProvider.SqlServer;

        /// <summary>
        /// Minimum database version required for approximate counts
        /// </summary>
        public string MinimumVersionForApproximateCount { get; set; } = "2012";

        /// <summary>
        /// Check whether a version check should be inforced
        /// </summary>
        /// <remarks>
        /// Set true to always check version
        /// </remarks>
        public bool ForceVersionCheck { get; set; } = false;
        /// <summary>
        /// Get or set time for version checking
        /// </summary>
        public TimeSpan VersionCheckCacheTime { get; set; } = TimeSpan.FromHours(1);
    }

}
