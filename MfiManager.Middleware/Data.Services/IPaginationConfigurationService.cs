using System.Linq.Expressions;

namespace MfiManager.Middleware.Data.Services {

    public interface IPaginationConfigurationService {
        bool ShouldUseApproximateCount<T>() where T : class;
        bool ShouldUseApproximateCount(Type entityType);
        Task<bool> ShouldUseApproximateCountAsync<T>(Expression<Func<T, bool>> predicate = null) where T : class;
        long GetApproximateCountThreshold<T>() where T : class;
    }

}
