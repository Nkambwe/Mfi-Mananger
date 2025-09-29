using MfiManager.Middleware.Configuration;
using MfiManager.Middleware.Configuration.Options;
using MfiManager.Middleware.Data.Services;
using MfiManager.Middleware.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace MfiManager.Middleware.Data.Transaction {

    public class UnitOfWorkFactory(ILogger<UnitOfWork> logger,
                             IDbContextFactory<MfiManagerDbContext> contextFactory,
                             IStaticCacheManager cacheManager,
                             IOptions<BulkOperationOptions> bulkOptions,
                             IPaginationConfigurationService paginationConfig) 
        : IUnitOfWorkFactory {
        private readonly ILogger<UnitOfWork> _logger = logger;
        private readonly IDbContextFactory<MfiManagerDbContext> _contextFactory = contextFactory;
        private readonly IStaticCacheManager _cacheManager = cacheManager;
        private readonly IPaginationConfigurationService _paginationConfig = paginationConfig;
        private readonly IOptions<BulkOperationOptions> _bulkOptions = bulkOptions;
        /// <summary>
        /// Creates a new instance of UnitOfWork.
        /// </summary>
        /// <returns>Created instance of IUnitOfWork</returns>
        public IUnitOfWork Create() => new UnitOfWork(_logger, _cacheManager, _paginationConfig, _contextFactory, _bulkOptions);
    }

}
