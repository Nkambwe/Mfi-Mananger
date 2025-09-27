using MfiManager.Middleware.Configuration;
using MfiManager.Middleware.Data.Services;
using MfiManager.Middleware.Factories;
using Microsoft.EntityFrameworkCore;

namespace MfiManager.Middleware.Data.Transaction {

    public class UnitOfWorkFactory(IServiceLoggerFactory loggerFactory,
                             IDbContextFactory<MfiManagerDbContext> contextFactory,
                             IStaticCacheManager cacheManager,
                             IPaginationConfigurationService paginationConfig) : IUnitOfWorkFactory {

        private readonly IServiceLoggerFactory _loggerFactory = loggerFactory;
        private readonly IDbContextFactory<MfiManagerDbContext> _contextFactory = contextFactory;
        private readonly IStaticCacheManager _cacheManager = cacheManager;
        private readonly IPaginationConfigurationService _paginationConfig = paginationConfig;

        /// <summary>
        /// Creates a new instance of UnitOfWork.
        /// </summary>
        /// <returns>Created instance of IUnitOfWork</returns>
        public IUnitOfWork Create() => new UnitOfWork(_loggerFactory, _cacheManager, _paginationConfig, _contextFactory);
    }

}
