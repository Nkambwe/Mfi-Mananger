using MfiManager.Middleware.Data.Connection;

namespace MfiManager.Middleware.Data.Services {
    public interface IDatabaseVersionCheckerService {
        Task<DatabaseVersionInfo> GetVersionInfoAsync();
        bool SupportsApproximateCount();
        Task<bool> SupportsApproximateCountAsync();
        DatabaseProvider GetDatabaseProvider();
        Task<DatabaseProviderInfo> GetDatabaseProviderInfoAsync();
    }
}
