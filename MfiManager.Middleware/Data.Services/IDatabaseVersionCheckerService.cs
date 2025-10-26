using MfiManager.Middleware.Data.Connection;
using MfiManager.Middleware.Enums;

namespace MfiManager.Middleware.Data.Services {
    public interface IDatabaseVersionCheckerService {
        Task<DatabaseVersionInfo> GetVersionInfoAsync();
        bool SupportsApproximateCount();
        Task<bool> SupportsApproximateCountAsync();
        DatabaseProvider GetDatabaseProvider();
        Task<DatabaseProviderInfo> GetDatabaseProviderInfoAsync();
    }
}
