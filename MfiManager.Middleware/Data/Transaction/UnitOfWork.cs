using MfiManager.Middleware.Configuration;
using MfiManager.Middleware.Configuration.Options;
using MfiManager.Middleware.Data.Entities;
using MfiManager.Middleware.Data.Services;
using MfiManager.Middleware.Data.Transaction.Repositories;
using MfiManager.Middleware.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace MfiManager.Middleware.Data.Transaction {

    public class UnitOfWork: IUnitOfWork {

        #region Fields
        private bool _disposed;
        private readonly ILogger<UnitOfWork> _logger;
        private readonly IStaticCacheManager _cacheManager;
        private readonly IDbContextFactory<MfiManagerDbContext> _contextFactory;
        private readonly Dictionary<Type, object> _repositories;
        private readonly IPaginationConfigurationService _paginationConfig;
        private readonly IOptions<BulkOperationOptions> _bulOptions;
        #endregion

        #region Properties
        public MfiManagerDbContext Context { get; }
        #endregion

        #region Repositories

        //public ICompanyRepository CompanyRepository { get; set; }
        //public IBranchRepository BranchRepository { get; set; }
        //public IUserRepository UserRepository { get; set; }
        //public IRoleRepository RoleRepository { get; set; }
        //public IRoleGroupRepository RoleGroupRepository { get; set; }
        //public IUserViewRepository UserViewRepository{get; set;}
        //public IUserPreferenceRepository UserPreferenceRepository { get; set;}
        //public IAttemptRepository AttemptRepository { get; set; }
        //public IQuickActionRepository QuickActionRepository  { get; set; }
        //public ISystemErrorRespository SystemErrorRespository {get;set;}
        //public IActivityTypeRepository ActivityTypeRepository { get; set; }
        //public IActivityLogRepository ActivityLogRepository { get; set; }
        //public IActivityLogSettingRepository ActivityLogSettingRepository { get; set; }
        //public IDepartmentRepository DepartmentRepository { get; set; }
        //public IDepartmentUnitRepository DepartmentUnitRepository { get; set; }
        
        #endregion

        public UnitOfWork(ILogger<UnitOfWork> logger,
                          IStaticCacheManager cacheManager,
                          IPaginationConfigurationService paginationConfig,
                          IDbContextFactory<MfiManagerDbContext> contextFactory,
                          IOptions<BulkOperationOptions> bulkOperationOptions) {
            _logger = logger;
            _contextFactory = contextFactory;
            _paginationConfig = paginationConfig;
            _cacheManager = cacheManager;
            _repositories = [];
        
            //..db context instance for this unit of work
            Context = _contextFactory.CreateDbContext();
            _bulOptions = bulkOperationOptions;
        
            //..initalize repositories
            //CompanyRepository =  new CompanyRepository(_loggerFactory, Context);
            //BranchRepository =  new BranchRepository(_loggerFactory, Context);
            //UserRepository =  new UserRepository(_loggerFactory, Context);
            //RoleRepository = new RoleRepository(_loggerFactory, Context);
            //RoleGroupRepository = new RoleGroupRepository(_loggerFactory, Context);
            //UserViewRepository = new UserViewRepository(_loggerFactory, Context);
            //UserPreferenceRepository = new UserPreferenceRepository(_loggerFactory, Context);
            //AttemptRepository =  new AttemptRepository(_loggerFactory, Context);
            //QuickActionRepository = new QuickActionRepository(_loggerFactory, Context); 
            //SystemErrorRespository = new SystemErrorRespository(_loggerFactory, Context);
            //ActivityLogRepository = new ActivityLogRepository(_loggerFactory, Context);
            //ActivityTypeRepository = new ActivityTypeRepository(_loggerFactory, Context);
            //ActivityLogSettingRepository = new ActivityLogSettingRepository(_loggerFactory, Context);
            //DepartmentRepository = new DepartmentRepository(_loggerFactory, Context);
            //DepartmentUnitRepository = new DepartmentUnitRepository(_loggerFactory, Context);
        }
        /// <summary>
        /// Get an instance of a repository class of type <typeparamref name="T"/>
        /// </summary>
        /// <typeparam name="T">Entity type repository belongs to</typeparam>
        /// <returns>Repository of type specified</returns>
        public IRepository<T> GetRepository<T>() where T : BaseEntity {
            if (_repositories.TryGetValue(typeof(T), out var repo)) {
                return (IRepository<T>)repo;
            }

            //..create repository with shared context instead of context factory
            var repository = new Repository<T>(Context, _logger, _cacheManager,_paginationConfig,_bulOptions);
            _repositories[typeof(T)] = repository;
            return repository;
        }

        /// <summary>
        /// Save all changes made in this unit of work
        /// </summary>
        /// <returns>Number of affected records</returns>
        public async Task<int> SaveChangesAsync() {
            try {
                //..validate string lengths before saving
                var validationErrors = ValidateStringLengths();
                if (validationErrors.Count != 0) {
                    _logger.Log(LogLevel.Error, "String length validation errors:");
                    foreach (var error in validationErrors) {
                        _logger.LogError(error);
                    }
                    throw new InvalidOperationException($"String length validation failed: {string.Join("; ", validationErrors)}");
                }
        
                //..log tracked entities
                var trackedEntities = Context.ChangeTracker.Entries().ToList();
                 _logger.LogError("Tracked entities count: {Count}", trackedEntities.Count);
        
                return await Context.SaveChangesAsync();
            } catch (Exception ex) {
                _logger.LogError(ex, "SaveChangesAsync failed: {Message}", ex.Message);
        
                //..log all inner exceptions
                var innerEx = ex.InnerException;
                var level = 1;
                while (innerEx != null) {
                    _logger.LogError("Inner Exception (Level {level}): {Message}",level, innerEx.Message);
                    _logger.LogError("Inner Exception Type: {Name}", innerEx.GetType().Name);
                    if (innerEx.StackTrace != null) {
                        _logger.LogError("Inner StackTrace: {Stacktrace}", innerEx.StackTrace);
                    }
                    innerEx = innerEx.InnerException;
                    level++;
                }
        
               _logger.LogError("Inner StackTrace: {Stacktrace}", ex.StackTrace);
                throw;
            }
        }

        /// <summary>
        /// Save all changes made in this unit of work synchronously
        /// </summary>
        /// <returns>Number of affected records</returns>
        public int SaveChanges() {
            try {
                var validationErrors = ValidateStringLengths();
                    if (validationErrors.Count != 0) {
                        _logger.LogError("String length validation errors:");
                        foreach (var error in validationErrors) {
                            _logger.LogError(error);
                        }
                        throw new InvalidOperationException($"String length validation failed: {string.Join("; ", validationErrors)}");
                    }
        
                    // Log tracked entities
                    var trackedEntities = Context.ChangeTracker.Entries().ToList();
                    _logger.LogError("Tracked entities count: {Count}", trackedEntities.Count);
        
                return Context.SaveChanges();
            } catch (Exception ex) {
                _logger.LogError("SaveChangesAsync failed: {Message}",ex.Message);
        
                //..log all inner exceptions
                var innerEx = ex.InnerException;
                var level = 1;
                while (innerEx != null) {
                    _logger.LogError("Inner Exception (Level {level}): {Message}",level, innerEx.Message);
                    _logger.LogError("Inner Exception Type: {Name}", innerEx.GetType().Name);
                    if (innerEx.StackTrace != null) {
                        _logger.LogError("Inner StackTrace: {Stacktrace}", innerEx.StackTrace);
                    }
                    innerEx = innerEx.InnerException;
                    level++;
                }
        
                 _logger.LogError("Inner StackTrace: {Stacktrace}", ex.StackTrace);
                throw;
            }
        }

        /// <summary>
        /// Manual disposal of unit of work
        /// </summary>
        /// <param name="isManuallyDisposing"></param>
        protected virtual void Dispose(bool isManuallyDisposing) {
            if (!_disposed) {
                if (isManuallyDisposing) {
                    //..dispose the context
                    Context?.Dispose();
                
                    //..clear repositories
                    _repositories.Clear();
                
                    //..clear repository references
                    //CompanyRepository = null;
                    //BranchRepository = null;
                    //UserRepository = null;
                    //RoleRepository = null;
                    //RoleGroupRepository = null;
                    //AttemptRepository = null;
                    //QuickActionRepository = null;
                    //SystemErrorRespository = null;
                    //ActivityLogRepository = null;
                    //ActivityTypeRepository = null;
                    //ActivityLogSettingRepository = null;
                    //UserPreferenceRepository = null;
                    //UserViewRepository = null;
                    //DepartmentRepository = null;
                    //DepartmentUnitRepository = null;
                }
            }
            _disposed = true;
        }

        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~UnitOfWork() {
            Dispose(false);
        }

        #region Protected Methods
        /// <summary>
        /// Validate object properties before saving
        /// </summary>
        /// <returns></returns>
        protected virtual List<string> ValidateStringLengths() {
            var errors = new List<string>();
    
            foreach (var entry in Context.ChangeTracker.Entries()) {
                if (entry.State == EntityState.Added || entry.State == EntityState.Modified) {
                    var entity = entry.Entity;
                    var entityType = Context.Model.FindEntityType(entity.GetType());
            
                    if (entityType != null) {
                        foreach (var property in entityType.GetProperties()) {
                            var value = entry.Property(property.Name).CurrentValue?.ToString();
                    
                            if (!string.IsNullOrEmpty(value)) {
                                var maxLength = property.GetMaxLength();
                                if (maxLength.HasValue && value.Length > maxLength.Value) {
                                    errors.Add($"Entity: {entity.GetType().Name}, Property: {property.Name}, " +
                                               $"Value Length: {value.Length}, Max Length: {maxLength.Value}, " +
                                               $"Value: {value[..Math.Min(50, value.Length)]}...");
                                }
                            }
                        }
                    }
                }
            }
    
            return errors;
        }

        #endregion

    }
}
