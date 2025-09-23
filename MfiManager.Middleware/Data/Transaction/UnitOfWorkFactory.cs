using MfiManager.Middleware.Factories;
using Microsoft.EntityFrameworkCore;

namespace MfiManager.Middleware.Data.Transaction {

    public class UnitOfWorkFactory(IServiceLoggerFactory loggerFactory,
                             IDbContextFactory<MfiManagerDbContext> contextFactory,
                             IServiceProvider serviceProvider) : IUnitOfWorkFactory {

        private readonly IServiceLoggerFactory _loggerFactory = loggerFactory;
        private readonly IDbContextFactory<MfiManagerDbContext> _contextFactory = contextFactory;
        private readonly IServiceProvider _serviceProvider = serviceProvider;

        /// <summary>
        /// Creates a new instance of UnitOfWork.
        /// </summary>
        /// <returns>Created instance of IUnitOfWork</returns>
        public IUnitOfWork Create() => new UnitOfWork(_loggerFactory, _contextFactory, _serviceProvider);
    }

}
