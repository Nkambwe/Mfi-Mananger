using EFCore.BulkExtensions;
using MfiManager.Middleware.Configuration;
using MfiManager.Middleware.Configuration.Options;
using MfiManager.Middleware.Data.Entities;
using MfiManager.Middleware.Data.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MfiManager.Middleware.Data.Transaction.Repositories {

    public class Repository<T> : IRepository<T> where T : BaseEntity {

        #region Private Fields
        private readonly string _entityName = typeof(T).Name.ToLower();
        private static PropertyInfo _cachedIsDeletedProperty;
        private static PropertyInfo _cachedIdProperty;
        private static readonly Lock _lockObject = new();
        private readonly IPaginationConfigurationService _paginationConfig;
        private readonly BulkOperationOptions _bulkOptions;
        #endregion

        private readonly ILogger<UnitOfWork> _logger;
        protected readonly IStaticCacheManager _cacheManager;
        protected readonly DbSet<T> _dbSet;
        protected readonly MfiManagerDbContext _dbContext; 

        public Repository(MfiManagerDbContext dbContext,
                          ILogger<UnitOfWork> logger,
                          IStaticCacheManager cacheManager, 
                          IPaginationConfigurationService paginationConfig,
                          IOptions<BulkOperationOptions> bulkOperationOptions) {
             _logger = logger;
            _cacheManager = cacheManager;
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
            _paginationConfig = paginationConfig;
        }

        
        public T Get(long id, bool includeDeleted = false) {
             using (_logger.BeginScope(new Dictionary<string, object> {["Channel"] = $"REPO-{DateTime.Now:yyyyMMddHHmmss}",["Id"] = id.ToString()})) {
                T entity = null;
                 var entities = _dbSet;

                 try {

                    var query = entities.AsQueryable();
                    if (!includeDeleted) {
                        query = query.Where(e => EF.Property<bool>(e, "IsDeleted") == false);
                    }

                    entity = query.FirstOrDefault(e => e.Id == id);
                 } catch (Exception ex) {
                    _logger.LogError(ex, "Get by ID operation failed: {EntityId}", id);
                    return null;
                 }

                return entity;
             }
             
        }

        public async Task<T> GetAsync(long id, bool includeDeleted = false) {
            using (_logger.BeginScope(new Dictionary<string, object> {["Channel"] = $"REPO-{DateTime.Now:yyyyMMddHHmmss}",["Id"] = id.ToString()})) {
                T entity = null;
                var entities = _dbSet;

                try {

                    var query = entities.AsQueryable();
                    if (!includeDeleted) {
                        query = query.Where(e => EF.Property<bool>(e, "IsDeleted") == false);
                    }

                    entity = await query.FirstOrDefaultAsync(e => e.Id == id);
                } catch (Exception ex) {
                     _logger.LogError(ex, "GetAsync by ID operation failed: {EntityId}", id);
                    return null;
                }

                return entity;
            }
            
        }

        public T Get(Expression<Func<T, bool>> where, bool includeDeleted = false) {
            using (_logger.BeginScope(new Dictionary<string, object> {["Channel"] = $"REPO-{DateTime.Now:yyyyMMddHHmmss}",["Id"] = ""})) {
                T entity = null;
                var entities = _dbSet;
                try {
                    var query = entities.AsQueryable();
                    if (!includeDeleted) {
                        query = query.Where(e => EF.Property<bool>(e, "IsDeleted") == false);
                    }

                    entity = query.FirstOrDefault(where);

                } catch (Exception ex) {
                     _logger.LogError(ex, "Get Operation failed: {Where}", where);
                    return null;
                }

                return entity;
            }
            
        }

        public async Task<T> GetByIdAsync(long id, bool includeDeleted = false, CancellationToken cancellationToken = default, params Expression<Func<T, object>>[] includes) {
            using (_logger.BeginScope(new Dictionary<string, object> {["Channel"] = $"REPO-{DateTime.Now:yyyyMMddHHmmss}",["Id"] = id.ToString()})) {
                 try {
                    var query = GetAll(e => EF.Property<long>(e, "Id") == id, includeDeleted, includes);
                    return await query.FirstOrDefaultAsync(cancellationToken);
                } catch (Exception ex) {
                     _logger.LogError(ex, "GetAsync by ID operation failed: {EntityId}", id);
                    return null;
                }
            }
           
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> where, bool includeDeleted = false) {
            using (_logger.BeginScope(new Dictionary<string, object> {["Channel"] = $"REPO-{DateTime.Now:yyyyMMddHHmmss}",["Id"] = ""})) {
                var entities = _dbSet;
                try {
                    var query = entities.AsQueryable();
                    if (!includeDeleted) {
                        query = query.Where(e => EF.Property<bool>(e, "IsDeleted") == false);
                    }

                    return await query.FirstOrDefaultAsync(where);
                } catch (Exception ex) {
                     _logger.LogError(ex, "Get Operation failed: {Where}", where);
                    return null;
                }
            }
            
        }
        
        public T Get(Expression<Func<T, bool>> where, bool includeDeleted = false, params Expression<Func<T, object>>[] includes) {
            using (_logger.BeginScope(new Dictionary<string, object> {["Channel"] = $"REPO-{DateTime.Now:yyyyMMddHHmmss}",["Id"] = ""})) {
                T entity = null;
                var entities = _dbSet;
                try {
                    var query = entities.AsQueryable();
                    if (includes != null) {
                        query = includes.Aggregate(query,
                                (current, next) => current.Include(next));
                    }

                    if (!includeDeleted) {
                        query = query.Where(e => EF.Property<bool>(e, "IsDeleted") == false);
                    }

                    entity = query.FirstOrDefault(where);

                } catch (Exception ex) {
                     _logger.LogError(ex, "Get Operation failed: {Where}", where);
                    return null;
                }

                return entity;
            }
            
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> where, bool includeDeleted = false, params Expression<Func<T, object>>[] includes) {
            using (_logger.BeginScope(new Dictionary<string, object> {["Channel"] = $"REPO-{DateTime.Now:yyyyMMddHHmmss}",["Id"] = ""})) {
                var entities = _dbSet;
                try {
                    var query = entities.AsQueryable();
                    if (!includeDeleted) {
                        query = query.Where(e => EF.Property<bool>(e, "IsDeleted") == false);
                    }

                    return await query.FirstOrDefaultAsync(where);
                } catch (Exception ex) {
                     _logger.LogError(ex, "Get Operation failed: {Where}", where);
                    return null;
                }
            }
            
        }

        public IQueryable<T> GetAll(bool includeDeleted = false) {
            using (_logger.BeginScope(new Dictionary<string, object> {["Channel"] = $"REPO-{DateTime.Now:yyyyMMddHHmmss}",["Id"] = ""})) {
                try {
                    var query = _dbSet.AsQueryable();
        
                    if (!includeDeleted) {
                        query = query.Where(e => !EF.Property<bool>(e, "IsDeleted"));
                    }
        
                    return query;
                } catch (Exception ex) {
                    _logger.LogError(ex, "Get all Operation failed");
                    return Enumerable.Empty<T>().AsQueryable();
                }
            }
            
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate, bool includeDeleted = false) {
            ArgumentNullException.ThrowIfNull(predicate);

            using (_logger.BeginScope(new Dictionary<string, object> {["Channel"] = $"REPO-{DateTime.Now:yyyyMMddHHmmss}",["Id"] = ""})) {
                try {
                    var query = _dbSet.AsQueryable();
        
                    if (!includeDeleted ) {
                        var combinedPredicate = CombinePredicates(predicate, e => !EF.Property<bool>(e, "IsDeleted"));
                        return query.Where(combinedPredicate);
                    }
        
                    return query.Where(predicate);
                } catch (Exception ex) {
                    _logger.LogError(ex, "Get all Operation failed");
                    return Enumerable.Empty<T>().AsQueryable();
                }
            }
            
        }

        public IQueryable<T> GetAll(bool includeDeleted = false, params Expression<Func<T, object>>[] includes) {
            using (_logger.BeginScope(new Dictionary<string, object> {["Channel"] = $"REPO-{DateTime.Now:yyyyMMddHHmmss}",["Id"] = ""})) {
                try {
                    var query = _dbSet.AsQueryable();
                    if (includes != null){
                        query = includes.Aggregate(query, (current, include) => current.Include(include));
                    }

                    if (!includeDeleted) {
                        query = query.Where(e => EF.Property<bool>(e, "IsDeleted") == false);;
                    }
        
                    return query;
                } catch (Exception ex) {
                     _logger.LogError(ex, "Get all Operation failed");
                    return Enumerable.Empty<T>().AsQueryable();
                }
            }
            
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate, bool includeDeleted = false, params Expression<Func<T, object>>[] includes){
            ArgumentNullException.ThrowIfNull(predicate);
            using (_logger.BeginScope(new Dictionary<string, object> {["Channel"] = $"REPO-{DateTime.Now:yyyyMMddHHmmss}",["Id"] = ""})) {
                try {
                    var query = _dbSet.AsQueryable();
                    if (includes != null){
                        query = includes.Aggregate(query, (current, include) => current.Include(include));
                    }

                    if (!includeDeleted)
                    {
                        var combinedPredicate = CombinePredicates(predicate, e => !EF.Property<bool>(e, "IsDeleted"));
                        return query.Where(combinedPredicate);
                    }
        
                    return query.Where(predicate);
                } catch (Exception ex) {
                    _logger.LogError(ex, "Get Operation failed: {Predicate}", predicate);
                    return Enumerable.Empty<T>().AsQueryable();
                }
            }
            
        }
        
        public async Task<IList<T>> GetAllAsync(bool includeDeleted = false, CancellationToken cancellationToken = default) {
           
            using (_logger.BeginScope(new Dictionary<string, object> {["Channel"] = $"REPO-{DateTime.Now:yyyyMMddHHmmss}",["Id"] = ""})) {
                try {
                    var query = GetAll(includeDeleted);
                    return await query.ToListAsync(cancellationToken);
                } catch (Exception ex) {
                    _logger.LogError(ex, "Get all Operation failed");
                    return [];
                }
            }
            
        }

        public async Task<IList<T>> GetAllAsync( Expression<Func<T, bool>> predicate, bool includeDeleted = false, CancellationToken cancellationToken = default) {
            ArgumentNullException.ThrowIfNull(predicate);
            using (_logger.BeginScope(new Dictionary<string, object> {["Channel"] = $"REPO-{DateTime.Now:yyyyMMddHHmmss}",["Id"] = ""})) {
                try {
                    var query = GetAll(predicate, includeDeleted);
                    return await query.ToListAsync(cancellationToken);
                } catch (Exception ex){
                    _logger.LogError(ex, "Get all Operation failed");
                    return [];
                }
            }
            
        }

        public async Task<IList<T>> GetAllAsync(bool includeDeleted = false, params Expression<Func<T, object>>[] includes) {
            using (_logger.BeginScope(new Dictionary<string, object> {["Channel"] = $"REPO-{DateTime.Now:yyyyMMddHHmmss}",["Id"] = ""})) {
                try {
                    IQueryable<T> query = _dbSet;

                    if (includes != null && includes.Length != 0) {
                        foreach (var include in includes) {
                            query = query.Include(include);
                        }
                    }
            
                    if (!includeDeleted) {
                        query = query.Where(e => EF.Property<bool>(e, "IsDeleted") == false);
                    }

                    return await query.ToListAsync();
                } catch (Exception ex){
                      _logger.LogError(ex, "Get all Operation failed");
                    return [];
                }
            }
            
        }

        public async Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> where, bool includeDeleted = false, params Expression<Func<T, object>>[] includes) {
            ArgumentNullException.ThrowIfNull(where);
            using (_logger.BeginScope(new Dictionary<string, object> {["Channel"] = $"REPO-{DateTime.Now:yyyyMMddHHmmss}",["Id"] = "" })) {
                try {
                    var query = GetAll(where, includeDeleted,includes);
                    return await query.ToListAsync();
                } catch (Exception ex){
                    _logger.LogError(ex, "Get Operation failed: {Where}", where);
                    return [];
                }
            }
            
        }
        
        public void Add(T entity) {
            ArgumentNullException.ThrowIfNull(entity);
            using (_logger.BeginScope(new Dictionary<string, object> {["Channel"] = $"REPO-{DateTime.Now:yyyyMMddHHmmss}",["Id"] = ""})) {
                try {
                    _dbSet.Add(entity);
                    InvalidateCache();
                } catch (Exception ex) {
                     _logger.LogError(ex, "Add operation failed: {Entity}", entity);
                }
            }
            
        }

        public async Task AddAsync(T entity) {
            ArgumentNullException.ThrowIfNull(entity);

            using (_logger.BeginScope(new Dictionary<string, object> {["Channel"] = $"REPO-{DateTime.Now:yyyyMMddHHmmss}",["Id"] = ""})) {
                 try {
                    await _dbSet.AddAsync(entity);
                    InvalidateCache();
                } catch (Exception ex) {
                    _logger.LogError(ex, "Add operation failed: {Entity}", entity);
                }
            }
        }

        public async Task AddRangeAsync(IEnumerable<T> entities) {
            ArgumentNullException.ThrowIfNull(entities);
            using (_logger.BeginScope(new Dictionary<string, object> {["Channel"] = $"REPO-{DateTime.Now:yyyyMMddHHmmss}",["Id"] = ""})) {
                 try {
                    await _dbSet.AddRangeAsync(entities);
                    InvalidateCache();
                } catch (Exception ex) {
                     _logger.LogError(ex, "AddRangeAsync operation failed");
                }
            } 
        }

        public void Remove(T entity, bool markAsDeleted = false) {
            ArgumentNullException.ThrowIfNull(entity);

            using (_logger.BeginScope(new Dictionary<string, object> {["Channel"] = $"REPO-{DateTime.Now:yyyyMMddHHmmss}",["Id"] = ""})) {
                try {

                    if (markAsDeleted) {
                        var entry = _dbContext.Entry(entity);
                        var isDeleted = (bool)entry.Property("IsDeleted").CurrentValue;
                        if (isDeleted) {
                            InvalidateCache();
        
                            var idDeleteProperty = typeof(T).GetProperty("Id");
                            if (idDeleteProperty != null && idDeleteProperty.GetValue(entity) is long idDelete) {
                                InvalidateCache(idDelete);
                            }
                            _logger.LogInformation("Entity found and marked as deleted.");
                            return;
                        }
                    }

                    //..remove entity
                    _dbSet.Remove(entity);
                    InvalidateCache();
        
                    var idProperty = typeof(T).GetProperty("Id");
                    if (idProperty != null && idProperty.GetValue(entity) is long id) {
                        InvalidateCache(id);
                    }
                } catch (Exception ex) {
                    _logger.Log(LogLevel.Error,"AddRangeAsync operation failed {Error}", ex.Message);
                    _logger.Log(LogLevel.Trace, ex, "{Stacktrace}", ex.StackTrace);
                }
            }
            
        }

        public async Task RemoveRangeAsync(IEnumerable<T> entities, bool markAsDeleted = false) {
            ArgumentNullException.ThrowIfNull(entities);

            using (_logger.BeginScope(new Dictionary<string, object> {["Channel"] = $"REPO-{DateTime.Now:yyyyMMddHHmmss}",["Id"] = ""})) {
                try {
                    var entitiesList = entities.ToList();
                    if (entitiesList.Count == 0)
                        return;

                    if (markAsDeleted) {
                        var isDeletedProperty = GetIsDeletedProperty();
                        var idProperty = GetIdProperty();
            
                        var (toSoftDelete, toHardDelete) = ProcessEntitiesForDeletion(entitiesList, isDeletedProperty, idProperty);
                        if (toSoftDelete.Count != 0) {
                            await PerformSoftDeleteAsync(toSoftDelete, isDeletedProperty);
                        }
            
                        if (toHardDelete.Count != 0) {
                            _dbSet.RemoveRange(toHardDelete);
                        }
                    } else {
                        _dbSet.RemoveRange(entitiesList);
                    }

                    InvalidateCache();
                    _logger.Log(LogLevel.Information, "Successfully processed {Count} entities for removal", entitiesList.Count);
                } catch (Exception ex) {
                    _logger.Log(LogLevel.Error,"Remove operation failed: {Error}", ex.Message);
                    _logger.Log(LogLevel.Trace, ex, "{Stacktrace}", ex.StackTrace);
                    throw;
                }
            }
            
        }

        public void Update(T entity, bool includeDeleted = false) {
            ArgumentNullException.ThrowIfNull(entity);
            using (_logger.BeginScope(new Dictionary<string, object> {["Channel"] = $"REPO-{DateTime.Now:yyyyMMddHHmmss}",["Id"] = ""})) {
                try {
                    if (!includeDeleted) {
                        var entry = _dbContext.Entry(entity);
                        var isDeleted = (bool)entry.Property("IsDeleted").CurrentValue;
                        if (isDeleted) {
                            _logger.Log(LogLevel.Information,"Update operation skipped: Entity is marked as deleted.");
                            return;
                        }
                    }

                    //..update entity
                    _dbSet.Update(entity);
                    InvalidateCache();
        
                    //..if entity has Id property, also invalidate specific cache
                    var idProperty = typeof(T).GetProperty("Id");
                    if (idProperty != null && idProperty.GetValue(entity) is int id) {
                        InvalidateCache(id);
                    }
                } catch (Exception ex) {
                    _logger.Log(LogLevel.Error,"Update operation failed: {Error}", ex.Message);
                    _logger.Log(LogLevel.Trace, ex, "{Stacktrace}", ex.StackTrace);
                }  
            }
            
        }
        
        public int GetContextHashCode()
            => _dbContext.GetType().GetHashCode();

        #region Single Records
        
        public T GetSingleOrDefault(Expression<Func<T, bool>> where, bool includeDeleted = false) {
            using (_logger.BeginScope(new Dictionary<string, object> {["Channel"] = $"REPO-{DateTime.Now:yyyyMMddHHmmss}",["Id"] = ""})) {
                try {
                       if (!includeDeleted) {
                           var entry = _dbContext.Entry(where);
                           var isDeleted = (bool)entry.Property("IsDeleted").CurrentValue;
                           if (isDeleted) {
                                _logger.Log(LogLevel.Information, "Entity found but is marked as deleted.");
                                return null;
                           }
                        }

                    return _dbSet.SingleOrDefault(where);
                } catch (Exception ex) {
                    _logger.Log(LogLevel.Error,"Update operation failed: {Error}", ex.Message);
                    _logger.Log(LogLevel.Trace, ex, "{Stacktrace}", ex.StackTrace);
                    throw;
                }
            }
           
        }

        public async Task<T> GetSingleOrDefaultAsync(Expression<Func<T, bool>> where, bool includeDeleted = false) {
            using (_logger.BeginScope(new Dictionary<string, object> {["Channel"] = $"REPO-{DateTime.Now:yyyyMMddHHmmss}",["Id"] = ""})) {
                try {
                      if (!includeDeleted) {
                        var entry = _dbContext.Entry(where);
                        var isDeleted = (bool)entry.Property("IsDeleted").CurrentValue;
                        if (isDeleted) {
                            _logger.Log(LogLevel.Information, "Entity found but is marked as deleted.");
                            return null;
                        }
                      }

                    return await _dbSet.SingleOrDefaultAsync(where);
                } catch (Exception ex) {
                    _logger.Log(LogLevel.Error,"Update operation failed: {Error}", ex.Message);
                    _logger.Log(LogLevel.Trace, ex, "{Stacktrace}", ex.StackTrace);
                    throw;
                }
            }
            
        }

        public async Task<T> GetSingleOrDefaultAsync(Expression<Func<T, bool>> predicate, bool includeDeleted = false, CancellationToken cancellationToken = default, params Expression<Func<T, object>>[] includes) {
            ArgumentNullException.ThrowIfNull(predicate);
            using (_logger.BeginScope(new Dictionary<string, object> {["Channel"] = $"REPO-{DateTime.Now:yyyyMMddHHmmss}",["Id"] = ""})) {
                try {
                    var query = GetAll(predicate, includeDeleted, includes);
                    return await query.FirstOrDefaultAsync(cancellationToken);
                } catch (Exception ex) {
                    _logger.Log(LogLevel.Error,"GetSingleAsync operation failed: {Error}", ex.Message);
                    _logger.Log(LogLevel.Trace, ex, "{Stacktrace}", ex.StackTrace);
                    throw;
                }
            }
            
        }

        #endregion

        #region Top Transactions
        
        public IQueryable<T> GetTop(Expression<Func<T, bool>> where, int top, bool includeDeleted = false) {
            using (_logger.BeginScope(new Dictionary<string, object> {["Channel"] = $"REPO-{DateTime.Now:yyyyMMddHHmmss}",["Id"] = ""})) {
                try {
                       IQueryable<T> query = _dbSet;
                        if (!includeDeleted) {
                            query = query.Where(e => EF.Property<bool>(e, "IsDeleted") == false);
                        }

                        return query.Where(where).Take(top);
                } catch (Exception ex) {
                    _logger.Log(LogLevel.Error,"Get Top operation failed: {Error}", ex.Message);
                    _logger.Log(LogLevel.Trace, ex, "{Stacktrace}", ex.StackTrace);
                    throw;
                }
            }
           
        }
        
        public async Task<IList<T>> GetTopAsync(Expression<Func<T, bool>> where, int top, bool includeDeleted = false) {
            using (_logger.BeginScope(new Dictionary<string, object> {["Channel"] = $"REPO-{DateTime.Now:yyyyMMddHHmmss}",["Id"] = ""})) {
                try {
                    IQueryable<T> query = _dbSet;
                    if (!includeDeleted) {
                        query = query.Where(e => EF.Property<bool>(e, "IsDeleted") == false);
                    }

                    return await query.Where(where).Take(top).ToListAsync();
                } catch (Exception ex) {
                    _logger.Log(LogLevel.Error,"Get Top operation failed: {Error}", ex.Message);
                    _logger.Log(LogLevel.Trace, ex, "{Stacktrace}", ex.StackTrace);
                    throw;
                }
            }
            
        }

        #endregion

        #region Paged Lists

        public async Task<PagedResult<T>> GetAllPagedAsync( int pageNumber = 1, int pageSize = 10, bool includeDeleted = false, CancellationToken cancellationToken = default) {
            using (_logger.BeginScope(new Dictionary<string, object> {["Channel"] = $"REPO-{DateTime.Now:yyyyMMddHHmmss}",["Id"] = ""})) {
                try {
                    if (pageNumber < 1) pageNumber = 1;
                    if (pageSize < 1) pageSize = 10;
                    if (pageSize > 1000) pageSize = 1000; 

                    var query = GetAll(includeDeleted);
                    var totalCount = await query.CountAsync(cancellationToken);
                    var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);
                    var items = await query
                        .Skip((pageNumber - 1) * pageSize)
                        .Take(pageSize)
                        .ToListAsync(cancellationToken);

                    return new PagedResult<T> {
                        Items = items,
                        TotalCount = totalCount,
                        PageNumber = pageNumber,
                        PageSize = pageSize,
                        TotalPages = totalPages,
                        HasNextPage = pageNumber < totalPages,
                        HasPreviousPage = pageNumber > 1
                    };
                } catch (Exception ex) {
                    _logger.Log(LogLevel.Error,"GetAllPagedAsync operation failed: {Error}", ex.Message);
                    _logger.Log(LogLevel.Trace, ex, "{Stacktrace}", ex.StackTrace);
                    throw;
                }
            }
            
        }

        public async Task<PagedResult<T>> GetPagedAllAsync(Expression<Func<T, bool>> predicate, int pageNumber, int pageSize, bool includeDeleted, CancellationToken cancellationToken = default) {
            ArgumentNullException.ThrowIfNull(predicate);
            using (_logger.BeginScope(new Dictionary<string, object> {["Channel"] = $"REPO-{DateTime.Now:yyyyMMddHHmmss}",["Id"] = ""})) {
                try {
                    if (pageNumber < 1) pageNumber = 1;
                    if (pageSize < 1) pageSize = 10;
                    if (pageSize > 1000) pageSize = 1000;

                    var query = GetAll(predicate, includeDeleted);
                    var totalCount = await query.CountAsync(cancellationToken);
                    var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);
                    var items = await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync(cancellationToken);
                    return new PagedResult<T> {
                        Items = items,
                        TotalCount = totalCount,
                        PageNumber = pageNumber,
                        PageSize = pageSize,
                        TotalPages = totalPages,
                        HasNextPage = pageNumber < totalPages,
                        HasPreviousPage = pageNumber > 1
                    };
                } catch (Exception ex) {
                    _logger.Log(LogLevel.Error,"GetAllPagedAsync with predicate operation failed: {Error}", ex.Message);
                    _logger.Log(LogLevel.Trace, ex, "{Stacktrace}", ex.StackTrace);
                    throw;
                }
            }
           
        }

        public async Task<PagedResult<T>> GetPagedAllAsync( Expression<Func<T, bool>> predicate, int pageNumber, int pageSize, bool includeDeleted = false, CancellationToken cancellationToken = default,  params Expression<Func<T, object>>[] includes) {
            ArgumentNullException.ThrowIfNull(predicate);
            using (_logger.BeginScope(new Dictionary<string, object> {["Channel"] = $"REPO-{DateTime.Now:yyyyMMddHHmmss}",["Id"] = ""})) {
                try {
                    //..validate and sanitize pagination parameters
                    pageNumber = Math.Max(1, pageNumber);
                    pageSize = Math.Clamp(pageSize, 1, 1000); 

                    //..build base query with includes
                    var query = _dbSet.AsQueryable();
        
                    if (includes != null && includes.Length != 0) {
                        query = includes.Aggregate(query, (current, include) => current.Include(include));
                    }

                    if (!includeDeleted) {
                        var combinedPredicate = CombinePredicates(predicate, e => !EF.Property<bool>(e, "IsDeleted"));
                        query = query.Where(combinedPredicate);
                    } else {
                        query = query.Where(predicate);
                    }

                    //..get total count before applying pagination
                    var totalCount = await query.CountAsync(cancellationToken);

                    //..calculate pagination metadata
                    var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);
                    var hasNextPage = pageNumber < totalPages;
                    var hasPreviousPage = pageNumber > 1;

                    //..apply pagination and get results
                    var items = totalCount == 0 ? []: await query
                            .Skip((pageNumber - 1) * pageSize)
                            .Take(pageSize)
                            .ToListAsync(cancellationToken);

                    _logger.Log(LogLevel.Information, "GetPagedAllAsync executed successfully: Page {PageNumber}/{TotalPages}, {Count} items returned",
                        pageNumber, totalPages, items.Count);

                    return new PagedResult<T> {
                        Items = items,
                        TotalCount = totalCount,
                        PageNumber = pageNumber,
                        PageSize = pageSize,
                        TotalPages = totalPages,
                        HasNextPage = hasNextPage,
                        HasPreviousPage = hasPreviousPage
                    };
                } catch (Exception ex) {
                    _logger.Log(LogLevel.Error,"GetPagedAllAsync with predicate operation failed: {Error}", ex.Message);
                    _logger.Log(LogLevel.Trace, ex, "{Stacktrace}", ex.StackTrace);
                    throw;
                }
            }
                
        }

        public async Task<PagedResult<T>> GetPagedAllAsync<TKey>( Expression<Func<T, bool>> predicate, Expression<Func<T, TKey>> orderBy, int pageNumber, int pageSize, bool ascending = true, bool includeDeleted = false, CancellationToken cancellationToken = default, params Expression<Func<T, object>>[] includes) {
            ArgumentNullException.ThrowIfNull(predicate);
            ArgumentNullException.ThrowIfNull(orderBy);
            using (_logger.BeginScope(new Dictionary<string, object> {["Channel"] = $"REPO-{DateTime.Now:yyyyMMddHHmmss}",["Id"] = ""})) {
                try {
                    pageNumber = Math.Max(1, pageNumber);
                    pageSize = Math.Clamp(pageSize, 1, 1000);

                    var query = _dbSet.AsQueryable();
                    if (includes != null && includes.Length != 0) {
                        query = includes.Aggregate(query, (current, include) => current.Include(include));
                    }

                    if (!includeDeleted) {
                        var combinedPredicate = CombinePredicates(predicate, e => !EF.Property<bool>(e, "IsDeleted"));
                        query = query.Where(combinedPredicate);
                    } else {
                        query = query.Where(predicate);
                    }

                    //..apply ordering
                    query = ascending ? query.OrderBy(orderBy) : query.OrderByDescending(orderBy);

                    var totalCount = await query.CountAsync(cancellationToken);
                    var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);
                    var items = totalCount == 0 ? [] : await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync(cancellationToken);
                    return new PagedResult<T> {
                        Items = items,
                        TotalCount = totalCount,
                        PageNumber = pageNumber,
                        PageSize = pageSize,
                        TotalPages = totalPages,
                        HasNextPage = pageNumber < totalPages,
                        HasPreviousPage = pageNumber > 1
                    };
                } catch (Exception ex) {
                    _logger.Log(LogLevel.Error,"GetPagedAllAsync with ordering operation failed: {Error}", ex.Message);
                    _logger.Log(LogLevel.Trace, ex, "{Stacktrace}", ex.StackTrace);
                    throw;
                }
            }
               
        }

        public async Task<PagedResult<T>> GetPagedAllCachedAsync(Expression<Func<T, bool>> predicate, int pageNumber, int pageSize, string cacheKey, bool includeDeleted = false, TimeSpan? cacheTime = null, CancellationToken cancellationToken = default, params Expression<Func<T, object>>[] includes) {
            if (string.IsNullOrWhiteSpace(cacheKey))
                throw new ArgumentException("Cache key cannot be null or empty", nameof(cacheKey));

            var fullCacheKey = GetCacheKey($"paged_{cacheKey}_p{pageNumber}_s{pageSize}");
    
            return await _cacheManager.GetAsync(fullCacheKey, 
                () => GetPagedAllAsync(predicate, pageNumber, pageSize, includeDeleted, cancellationToken, includes), 
                cacheTime ?? TimeSpan.FromMinutes(5));
        }
        
        public async Task<PagedResult<TResult>> GetLargePagedAllAsync<TResult>(Expression<Func<T, bool>> predicate, Expression<Func<T, TResult>> selector, int pageNumber, int pageSize, bool includeDeleted = false, CancellationToken cancellationToken = default) {
            ArgumentNullException.ThrowIfNull(predicate);
            ArgumentNullException.ThrowIfNull(selector);
            using (_logger.BeginScope(new Dictionary<string, object> {["Channel"] = $"REPO-{DateTime.Now:yyyyMMddHHmmss}",["Id"] = ""})) {
                try {
                    pageNumber = Math.Max(1, pageNumber);
                    pageSize = Math.Clamp(pageSize, 1, 1000);

                    var query = _dbSet.AsQueryable();
                    if (!includeDeleted) {
                        var combinedPredicate = CombinePredicates(predicate, e => !EF.Property<bool>(e, "IsDeleted"));
                        query = query.Where(combinedPredicate);
                    } else {
                        query = query.Where(predicate);
                    }

                    var totalCount = await query.CountAsync(cancellationToken);
                    var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

                    var items = totalCount == 0 ? [] : await query.Skip((pageNumber - 1) * pageSize).Take(pageSize)
                            .Select(selector)
                            .ToListAsync(cancellationToken);

                    return new PagedResult<TResult> {
                        Items = items,
                        TotalCount = totalCount,
                        PageNumber = pageNumber,
                        PageSize = pageSize,
                        TotalPages = totalPages,
                        HasNextPage = pageNumber < totalPages,
                        HasPreviousPage = pageNumber > 1
                    };
                } catch (Exception ex) {
                    _logger.Log(LogLevel.Error,"GetPagedAllProjectedAsync operation failed: {Error}", ex.Message);
                    _logger.Log(LogLevel.Trace, ex, "{Stacktrace}", ex.StackTrace);
                    throw;
                }
            }
            
        }

        public async Task<PagedResult<T>> GetLargePagedAllAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> orderBy,int pageNumber, int pageSize, bool ascending = true, bool includeDeleted = false, CancellationToken cancellationToken = default) {
            ArgumentNullException.ThrowIfNull(predicate);
            ArgumentNullException.ThrowIfNull(orderBy);
            using (_logger.BeginScope(new Dictionary<string, object> {["Channel"] = $"REPO-{DateTime.Now:yyyyMMddHHmmss}",["Id"] = ""})) {
                try {
                    pageNumber = Math.Max(1, pageNumber);
                    pageSize = Math.Clamp(pageSize, 1, 1000);
                    var query = _dbSet.AsQueryable();

                    if (!includeDeleted) {
                        var combinedPredicate = CombinePredicates(predicate, e => !EF.Property<bool>(e, "IsDeleted"));
                        query = query.Where(combinedPredicate);
                    } else {
                        query = query.Where(predicate);
                    }

                    //..use more efficient counting for large tables
                    var totalCountTask = await ShouldUseApproximateCountAsync() && pageNumber == 1 
                        ? GetApproximateCountAsync(predicate, includeDeleted, cancellationToken)
                        : query.CountAsync(cancellationToken);

                    //..apply ordering and pagination
                    var orderedQuery = ascending ? query.OrderBy(orderBy) : query.OrderByDescending(orderBy);
        
                    var itemsTask = orderedQuery
                        .Skip((pageNumber - 1) * pageSize)
                        .Take(pageSize)
                        .ToListAsync(cancellationToken);

                    await Task.WhenAll(totalCountTask, itemsTask);

                    var totalCount = await totalCountTask;
                    var items = await itemsTask;
                    var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

                    return new PagedResult<T>
                    {
                        Items = items,
                        TotalCount = totalCount,
                        PageNumber = pageNumber,
                        PageSize = pageSize,
                        TotalPages = totalPages,
                        HasNextPage = pageNumber < totalPages,
                        HasPreviousPage = pageNumber > 1
                    };
                } catch (Exception ex) {
                    _logger.Log(LogLevel.Error,"GetPagedAllOptimizedAsync operation failed: {Error}", ex.Message);
                    _logger.Log(LogLevel.Trace, ex, "{Stacktrace}", ex.StackTrace);
                    throw;
                }
            }     
               
        }

        public async Task<CursorPagedResult<T, TCursor>> GetPagedAllCursorAsync<TCursor>(Expression<Func<T, bool>> predicate,Expression<Func<T, TCursor>> cursorSelector, TCursor cursor = default, int pageSize = 10, bool ascending = true, bool includeDeleted = false, CancellationToken cancellationToken = default) where TCursor : IComparable<TCursor> {
            ArgumentNullException.ThrowIfNull(predicate);
            ArgumentNullException.ThrowIfNull(cursorSelector);
            using (_logger.BeginScope(new Dictionary<string, object> {["Channel"] = $"REPO-{DateTime.Now:yyyyMMddHHmmss}",["Id"] = ""})) {
                try {
                    pageSize = Math.Clamp(pageSize, 1, 1000);

                    var query = _dbSet.AsQueryable();
                    if (!includeDeleted) {
                        var combinedPredicate = CombinePredicates(predicate, e => !EF.Property<bool>(e, "IsDeleted"));
                        query = query.Where(combinedPredicate);
                    } else {
                        query = query.Where(predicate);
                    }

                    //..apply cursor filtering
                    if (cursor != null && !cursor.Equals(default(TCursor))) {
                        var parameter = Expression.Parameter(typeof(T), "x");
                        var property = ReplaceParameter(cursorSelector.Body, cursorSelector.Parameters[0], parameter);
                        var cursorConstant = Expression.Constant(cursor);
            
                        var comparison = ascending 
                            ? Expression.GreaterThan(property, cursorConstant)
                            : Expression.LessThan(property, cursorConstant);
                
                        var cursorPredicate = Expression.Lambda<Func<T, bool>>(comparison, parameter);
                        query = query.Where(cursorPredicate);
                    }

                    //..order and take one extra to check if there's a next page
                    query = ascending ? query.OrderBy(cursorSelector) : query.OrderByDescending(cursorSelector);
                    var items = await query.Take(pageSize + 1).ToListAsync(cancellationToken);

                    var hasNextPage = items.Count > pageSize;
                    if (hasNextPage) {
                        //..remove the extra item
                        items.RemoveAt(items.Count - 1); 
                    }

                    var nextCursor = items.Count != 0 ? cursorSelector.Compile()(items.Last()) : default;
                    return new CursorPagedResult<T, TCursor> {
                        Items = items,
                        NextCursor = nextCursor,
                        HasNextPage = hasNextPage,
                        PageSize = pageSize
                    };
                } catch (Exception ex) {
                    _logger.Log(LogLevel.Error,"GetPagedAllCursorAsync operation failed: {Error}", ex.Message);
                    _logger.Log(LogLevel.Trace, ex, "{Stacktrace}", ex.StackTrace);
                    throw;
                }
            }
            
        }

        #endregion

        #region Bulk Transactions

        public async Task<BulkOperationResult<T>> BulkInsertAsync(IEnumerable<T> entities, BulkInsertOptions options = null, CancellationToken cancellationToken = default) {
            var startTime = DateTime.UtcNow;
            var operationId = Guid.NewGuid().ToString("N")[..8];
        
            if (entities == null) {
                _logger?.Log(LogLevel.Information, "[{OperationId}] Bulk insert canceled: entities collection is null", operationId);
                return BulkOperationResult<T>.Failed("Entities collection cannot be null");
            }

            var entitiesList = entities.ToList();
            var validEntities = entitiesList.Where(e => e != null).ToList();

            if (validEntities.Count == 0)
            {
                _logger?.Log(LogLevel.Information, "[{OperationId}] Bulk insert canceled: no valid entities found", operationId);
                return BulkOperationResult<T>.Failed("No valid entities to insert");
            }

            _logger?.Log(LogLevel.Information, "[{OperationId}] Bulk insert started: {Count} entities", operationId,validEntities.Count);
            try {
                var insertOptions = options ?? new BulkInsertOptions();
                var result = new BulkOperationResult<T>();

                //..choose bulk insert strategy based on settings and entity count
                if (ShouldUseEFCoreBulkInsert(validEntities.Count)) {
                    result = await PerformEFCoreBulkInsertAsync(validEntities, insertOptions, cancellationToken);
                } else {
                    result = await PerformThirdPartyBulkInsertAsync(validEntities, insertOptions, cancellationToken);
                }

                // Invalidate cache after successful bulk insert
                if (result.IsSuccess) {
                    InvalidateCache();
                    var duration = DateTime.UtcNow - startTime;
                    _logger?.Log(LogLevel.Information, "[{OperationId}] Bulk insert completed successfully in {duration.TotalMilliseconds:F2}ms. Inserted: {Count}", 
                        operationId,$"{duration.TotalMilliseconds:F2}",result.AffectedRows);
                }

                return result;
            } catch (Exception ex) {
                var duration = DateTime.UtcNow - startTime;
                _logger?.Log(LogLevel.Error,"[{OperationId}] Bulk insert failed after {Duration}ms: {Message}", 
                    operationId,$"{duration.TotalMilliseconds:F2}",ex.Message);
                _logger.Log(LogLevel.Trace,"[{operationId}] STACKTRACE: {Stacktrace}", operationId,ex.StackTrace);
            
                return BulkOperationResult<T>.Failed(ex.Message, ex);
            }
        }

        public async Task<BulkOperationResult<T>> BulkInsertBatchedAsync(IEnumerable<T> entities, int batchSize = 10000, BulkInsertOptions? options = null, IProgress<BulkOperationProgress>? progress = null,CancellationToken cancellationToken = default) {
            var startTime = DateTime.UtcNow;
            var operationId = Guid.NewGuid().ToString("N")[..8];
        
            var entitiesList = entities?.Where(e => e != null).ToList() ?? [];
            if (entitiesList.Count == 0) {
                return BulkOperationResult<T>.Failed("No valid entities to insert");
            }

            _logger?.Log(LogLevel.Information, "[{OperationId}] Batched bulk insert started: {Count} entities in batches of {BatchSize}", 
                 operationId,entitiesList.Count,batchSize);

            var totalBatches = (int)Math.Ceiling((double)entitiesList.Count / batchSize);
            var totalAffectedRows = 0;
            var errors = new List<string>();

            try {
                using var transaction = await _dbContext.Database.BeginTransactionAsync(cancellationToken);
            
                for (int i = 0; i < totalBatches; i++) {
                    var batch = entitiesList.Skip(i * batchSize).Take(batchSize).ToList();
                    var batchResult = await BulkInsertAsync(batch, options, cancellationToken);

                    if (batchResult.IsSuccess) {
                        totalAffectedRows += batchResult.AffectedRows;
                    } else {
                        errors.AddRange(batchResult.Errors);
                    
                        //..decide whether to continue or abort based on settings
                        if (!_bulkOptions.ContinueOnBatchError) {
                            await transaction.RollbackAsync(cancellationToken);
                            return BulkOperationResult<T>.Failed($"Batch {i + 1} failed: {string.Join(", ", batchResult.Errors)}");
                        }
                    }

                    //..report progress
                    progress?.Report(new BulkOperationProgress {
                        ProcessedItems = Math.Min((i + 1) * batchSize, entitiesList.Count),
                        TotalItems = entitiesList.Count,
                        CurrentBatch = i + 1,
                        TotalBatches = totalBatches,
                        ErrorCount = errors.Count
                    });

                    //..check for cancellation
                    cancellationToken.ThrowIfCancellationRequested();
                }

                await transaction.CommitAsync(cancellationToken);

                var duration = DateTime.UtcNow - startTime;
                var hasErrors = errors.Count > 0;
                _logger?.Log(LogLevel.Information, "[{OperationId}] Batched bulk insert completed in {Duration}ms. Inserted: {Total}, Errors: {Count}",
                        operationId,$"{duration.TotalMilliseconds:F2}",totalAffectedRows,errors.Count);
                return new BulkOperationResult<T> {
                    IsSuccess = totalAffectedRows > 0,
                    AffectedRows = totalAffectedRows,
                    Errors = errors,
                    Duration = duration,
                    OperationId = operationId
                };

            } catch (Exception ex) {
                var duration = DateTime.UtcNow - startTime;
                 _logger?.Log(LogLevel.Error,"[{OperationId}] Bulk insert failed after {Duration}ms: {Message}", 
                    operationId,$"{duration.TotalMilliseconds:F2}",ex.Message);
                _logger.Log(LogLevel.Trace,"STACKTRACE: {Stacktrace}",ex.StackTrace);
                return BulkOperationResult<T>.Failed(ex.Message, ex);
            }
        }

        public async Task<BulkOperationResult<T>> BulkUpdateAsync(IEnumerable<T> entities, BulkUpdateOptions<T> options = null, CancellationToken cancellationToken = default) {
            var startTime = DateTime.UtcNow;
            var operationId = Guid.NewGuid().ToString("N")[..8];

            if (entities == null) {
                return BulkOperationResult<T>.Failed("Entities collection cannot be null");
            }

            var entitiesList = entities.Where(e => e != null).ToList();
            if (entitiesList.Count == 0) {
                _logger.Log(LogLevel.Information, "[{OperationId}] Bulk update canceled: no valid entities found", operationId);
                return BulkOperationResult<T>.Failed("No valid entities to update");
            }

            _logger.Log(LogLevel.Information, "[{operationId}] Bulk update started: {Count} entities", operationId,entitiesList.Count);
            try {
                var updateOptions = options ?? new BulkUpdateOptions<T>();
                var result = await PerformBulkUpdateAsync(entitiesList, updateOptions, cancellationToken);

                if (result.IsSuccess) {
                    //..invalidate cache for updated entities
                    InvalidateCache();
                
                    var duration = DateTime.UtcNow - startTime;
                    _logger.Log(LogLevel.Information, "[{OperationId}] Bulk update completed successfully in {Duration}ms. Updated: {Count}",
                        operationId,$"{duration.TotalMilliseconds:F2}",result.AffectedRows);
                }

                return result;
            } catch (Exception ex) {
                var duration = DateTime.UtcNow - startTime;
                _logger?.Log(LogLevel.Error,"[{OperationId}] Bulk insert failed after {Duration}ms: {Message}", 
                    operationId,$"{duration.TotalMilliseconds:F2}",ex.Message);
                _logger.Log(LogLevel.Trace,"[{operationId}] STACKTRACE: {Stacktrace}", operationId,ex.StackTrace);
                return BulkOperationResult<T>.Failed(ex.Message, ex);
            }
        }

        public async Task<BulkOperationResult<T>> BulkUpdateAsync(IEnumerable<T> entities, Expression<Func<T, object>>[] propertySelectors, BulkUpdateOptions<T> options = null, CancellationToken cancellationToken = default) {
            var updateOptions = options ?? new BulkUpdateOptions<T>();
            updateOptions.PropertiesToUpdate = propertySelectors;
            return await BulkUpdateAsync(entities, updateOptions, cancellationToken);
        }

        public async Task<BulkOperationResult<T>> BulkUpdateAsync<TProperty>( Expression<Func<T, bool>> whereExpression, Func<T, TProperty> propertySelector, TProperty newValue, bool excludeDeleted = true, CancellationToken cancellationToken = default) {
            var startTime = DateTime.UtcNow;
            var operationId = Guid.NewGuid().ToString("N")[..8];

            try {
                var query = _dbSet.Where(whereExpression);
                if (excludeDeleted) {
                    query = query.Where(e => !EF.Property<bool>(e, "IsDeleted"));
                }

                var affectedRows = await query.ExecuteUpdateAsync(setters => setters.SetProperty(propertySelector, newValue), cancellationToken);
                InvalidateCache();
            
                var duration = DateTime.UtcNow - startTime;
                _logger?.Log(LogLevel.Information, "[{OperationId}] Conditional bulk update completed in {Duration}ms. Updated: {Count}",
                    operationId,$"{duration.TotalMilliseconds:F2}",affectedRows);

                return new BulkOperationResult<T> {
                    IsSuccess = true,
                    AffectedRows = affectedRows,
                    Duration = duration,
                    OperationId = operationId
                };
            } catch (Exception ex) {
                var duration = DateTime.UtcNow - startTime;
                _logger?.Log(LogLevel.Error,"[{OperationId}] Conditional bulk update failed after {Duration}ms: {Message}", 
                    operationId,$"{duration.TotalMilliseconds:F2}",ex.Message);
                _logger.Log(LogLevel.Trace,"[{operationId}] STACKTRACE: {Stacktrace}", operationId,ex.StackTrace);

                return BulkOperationResult<T>.Failed(ex.Message, ex);
            }
        }

        public async Task<BulkOperationResult<T>> BulkUpdateOrInsertAsync( IEnumerable<T> entities, Expression<Func<T, object>>[] matchOn = null, CancellationToken cancellationToken = default) {
            var startTime = DateTime.UtcNow;
            var operationId = Guid.NewGuid().ToString("N")[..8];

            if (entities == null) {
                return BulkOperationResult<T>.Failed("Entities collection cannot be null");
            }

            var entitiesList = entities.Where(e => e != null).ToList();
        
            if (entitiesList.Count == 0) {
                return BulkOperationResult<T>.Failed("No valid entities for upsert");
            }

            _logger.Log(LogLevel.Information,"[{OperationId}] Bulk upsert started: {Count} entities", operationId,entitiesList.Count);

            try {
                var bulkConfig = new BulkConfig {
                    SetOutputIdentity = true,
                    PreserveInsertOrder = false
                };

                if (matchOn != null && matchOn.Length > 0) {
                    bulkConfig.UpdateByProperties = matchOn.Select(GetPropertyName).Where(name => !string.IsNullOrEmpty(name)).ToList();
                }

                await _dbContext.BulkInsertOrUpdateAsync(entitiesList, bulkConfig, cancellationToken: cancellationToken);
                InvalidateCache();
            
                var duration = DateTime.UtcNow - startTime;
                _logger.Log(LogLevel.Information, "[{OperationId}] Bulk upsert completed in {Duration}ms. Processed: {Count}", 
                    operationId, $"{duration.TotalMilliseconds:F2}",entitiesList.Count);

                return new BulkOperationResult<T>{
                    IsSuccess = true,
                    AffectedRows = entitiesList.Count,
                    Duration = duration,
                    OperationId = operationId
                };
            } catch (Exception ex) {
                var duration = DateTime.UtcNow - startTime;
                _logger?.Log(LogLevel.Error,"[{OperationId}] Bulk insert failed after {Duration}ms: {Message}", operationId,$"{duration.TotalMilliseconds:F2}",ex.Message);
                _logger.Log(LogLevel.Trace,"[{operationId}] STACKTRACE: {Stacktrace}", operationId,ex.StackTrace);
                return BulkOperationResult<T>.Failed(ex.Message, ex);
            }
        }

        public async Task<BulkOperationResult<T>> BulkDeleteWhereAsync(Expression<Func<T, bool>> whereExpression, bool softDelete = true, bool excludeDeleted = true, CancellationToken cancellationToken = default) {
            var startTime = DateTime.UtcNow;
            var operationId = Guid.NewGuid().ToString("N")[..8];

            try {
                var query = _dbSet.Where(whereExpression);
                if (excludeDeleted) {
                    query = query.Where(e => !EF.Property<bool>(e, "IsDeleted"));
                }

                int affectedRows;
                if (softDelete) {
                    //.soft delete using ExecuteUpdateAsync
                    affectedRows = await query.ExecuteUpdateAsync(setters => setters.SetProperty(t => t.IsDeleted, true), cancellationToken);
                } else {
                    //..hard delete using ExecuteDeleteAsync
                    affectedRows = await query.ExecuteDeleteAsync(cancellationToken);
                }

                InvalidateCache();
            
                var duration = DateTime.UtcNow - startTime;
                _logger.Log(LogLevel.Information, "[{operationId}] Conditional bulk delete completed in {Duration}ms. Deleted: {count}",
                    operationId, $"{duration.TotalMilliseconds:F2}",affectedRows);

                return new BulkOperationResult<T> {
                    IsSuccess = true,
                    AffectedRows = affectedRows,
                    Duration = duration,
                    OperationId = operationId
                };
            } catch (Exception ex) {
                var duration = DateTime.UtcNow - startTime;
                _logger?.Log(LogLevel.Error,"[{OperationId}] Conditional bulk delete failed after {Duration}ms: {Message}", operationId,$"{duration.TotalMilliseconds:F2}",ex.Message);
                _logger.Log(LogLevel.Trace,"[{operationId}] STACKTRACE: {Stacktrace}", operationId,ex.StackTrace);
                return BulkOperationResult<T>.Failed(ex.Message, ex);
            }
        }

        public async Task<BulkOperationResult<T>> BulkDeleteAsync(IEnumerable<T> entities, bool softDelete = true, CancellationToken cancellationToken = default) {
            var startTime = DateTime.UtcNow;
            var operationId = Guid.NewGuid().ToString("N")[..8];

            if (entities == null) {
                return BulkOperationResult<T>.Failed("Entities collection cannot be null");
            }

            var entitiesList = entities.Where(e => e != null).ToList();
        
            if (entitiesList.Count == 0) {
                return BulkOperationResult<T>.Failed("No valid entities to delete");
            }

            _logger.Log(LogLevel.Information, "[{OperationId}] Bulk delete started: {Count} entities (soft: {SoftDelete})",
                operationId,entitiesList.Count,softDelete);

            try {
                int affectedRows;
            
                if (softDelete) {
                    //..perform soft delete by updating IsDeleted property
                    foreach (var entity in entitiesList) {
                        var isDeletedProperty = typeof(T).GetProperty("IsDeleted");
                        isDeletedProperty?.SetValue(entity, true);
                    }

                    var updateResult = await BulkUpdateAsync(entitiesList, cancellationToken: cancellationToken);
                    affectedRows = updateResult.AffectedRows;
                } else {
                    //..perform hard delete
                    await _dbContext.BulkDeleteAsync(entitiesList, cancellationToken: cancellationToken);
                    affectedRows = entitiesList.Count;
                }

                InvalidateCache();
                var duration = DateTime.UtcNow - startTime;
                _logger.Log(LogLevel.Information, "[{OperationId}] Bulk delete completed in {Duration}ms. Deleted: {Count}", operationId, $"{duration.TotalMilliseconds:F2}",affectedRows);
                return new BulkOperationResult<T> {
                    IsSuccess = true,
                    AffectedRows = affectedRows,
                    Duration = duration,
                    OperationId = operationId
                };

            } catch (Exception ex) {
                var duration = DateTime.UtcNow - startTime;
                _logger?.Log(LogLevel.Error,"[{OperationId}] Bulk delete failed after {Duration}ms: {Message}", operationId,$"{duration.TotalMilliseconds:F2}",ex.Message);
                _logger.Log(LogLevel.Trace,"[{operationId}] STACKTRACE: {Stacktrace}", operationId,ex.StackTrace);
                return BulkOperationResult<T>.Failed(ex.Message, ex);
            }
        }

        #endregion

        #region Check Existsance
        
        public bool Exists(Expression<Func<T, bool>> predicate, bool excludeDeleted = true) {
            ArgumentNullException.ThrowIfNull(predicate);
            using (_logger.BeginScope(new Dictionary<string, object> {["Channel"] = $"REPO-{DateTime.Now:yyyyMMddHHmmss}",["Id"] = ""})) {
                try {
                     var query = _dbSet.AsQueryable();
        
                    if (excludeDeleted) {
                        //..combine predicates for a single database query
                        var combinedPredicate = CombinePredicates(predicate, e => !EF.Property<bool>(e, "IsDeleted"));
                        return query.Any(combinedPredicate);
                    }
        
                    return query.Any(predicate);
                } catch (Exception ex) {
                    _logger.Log(LogLevel.Error, "Exists operation failed: {Message}", ex.Message);
                    _logger.Log(LogLevel.Trace, "{StackTrace}", ex.StackTrace);
                    return false;
                }
            }
           
        }

        public async Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate, bool excludeDeleted = true, CancellationToken cancellationToken = default) {
            ArgumentNullException.ThrowIfNull(predicate);
            using (_logger.BeginScope(new Dictionary<string, object> {["Channel"] = $"REPO-{DateTime.Now:yyyyMMddHHmmss}",["Id"] = ""})) {
                try {
                     var query = _dbSet.AsQueryable();
                    if (excludeDeleted) {
                        var combinedPredicate = CombinePredicates(predicate, e => !EF.Property<bool>(e, "IsDeleted"));
                        return await query.AnyAsync(combinedPredicate, cancellationToken);
                    }
        
                    return await query.AnyAsync(predicate, cancellationToken);
                } catch (Exception ex) {
                    _logger.Log(LogLevel.Error, "ExistsAsync operation failed: {Message}", ex.Message);
                    _logger.Log(LogLevel.Trace, "{StackTrace}", ex.StackTrace);
                    return false;
                }
            }
            
        }

        public async Task<bool> ExistsByIdCachedAsync(long id, bool excludeDeleted = true, TimeSpan? cacheTime = null, CancellationToken cancellationToken = default) {
            return await ExistsCachedAsync(
                e => EF.Property<long>(e, "Id") == id, 
                $"id_{id}", 
                excludeDeleted, 
                cacheTime, 
                cancellationToken);
        }

        public async Task<bool> ExistsCachedAsync(Expression<Func<T, bool>> predicate, string cacheKey, bool excludeDeleted = true, TimeSpan? cacheTime = null, CancellationToken cancellationToken = default) {
            ArgumentNullException.ThrowIfNull(predicate);

            if (string.IsNullOrWhiteSpace(cacheKey))
                throw new ArgumentException("Cache key cannot be null or empty", nameof(cacheKey));

            var fullCacheKey = GetCacheKey($"exists_{cacheKey}");
    
            return await _cacheManager.GetAsync(fullCacheKey, 
                () => ExistsAsync(predicate, excludeDeleted, cancellationToken), 
                cacheTime ?? TimeSpan.FromMinutes(5));
        }
       
        public async Task<Dictionary<string, bool>> ExistsBatchAsync(Dictionary<string, Expression<Func<T, bool>>> predicates, bool excludeDeleted = true, CancellationToken cancellationToken = default) {
            using (_logger.BeginScope(new Dictionary<string, object> {["Channel"] = $"REPO-{DateTime.Now:yyyyMMddHHmmss}",["Id"] = ""})) {
                 if (predicates == null || predicates.Count == 0)
                return [];

                try {
                    var results = new Dictionary<string, bool>();
                    var query = _dbSet.AsQueryable();

                    //..execute all queries in parallel for better performance
                    var tasks = predicates.Select(async kvp => {
                        var predicate = kvp.Value;
                        var key = kvp.Key;
            
                        if (excludeDeleted) {
                            var combinedPredicate = CombinePredicates(predicate, e => !EF.Property<bool>(e, "IsDeleted"));
                            var exists = await query.AnyAsync(combinedPredicate, cancellationToken);
                            return new KeyValuePair<string, bool>(key, exists);
                        }
            
                        var result = await query.AnyAsync(predicate, cancellationToken);
                        return new KeyValuePair<string, bool>(key, result);
                    });

                    var batchResults = await Task.WhenAll(tasks);
                    foreach (var result in batchResults) {
                        results[result.Key] = result.Value;
                    }

                    return results;
                } catch (Exception ex) {
                    _logger.Log(LogLevel.Error, "ExistsBatch operation failed: {Message}", ex.Message);
                    _logger.Log(LogLevel.Trace, "{StackTrace}", ex.StackTrace);
                     return [];
                }
            }
            
        }

        #endregion

        #region Count Transactions
        public int Count() {
            using (_logger.BeginScope(new Dictionary<string, object> {["Channel"] = $"REPO-{DateTime.Now:yyyyMMddHHmmss}",["Id"] = ""})) {
                try {
                    return _dbSet.Count();
                } catch (Exception ex) {
                    _logger.Log(LogLevel.Error, "Count operation failed:  {Message}", ex.Message);
                    _logger.Log(LogLevel.Trace, "{StackTrace}", ex.StackTrace);
                    return 0;
                }
            }
            
        }

        public int Count(Expression<Func<T, bool>> predicate) {
            ArgumentNullException.ThrowIfNull(predicate);
            using (_logger.BeginScope(new Dictionary<string, object> {["Channel"] = $"REPO-{DateTime.Now:yyyyMMddHHmmss}",["Id"] = ""})) {
                try {
                     return _dbSet.Count(predicate);
                } catch (Exception ex) {
                    _logger.Log(LogLevel.Error, "Count with predicate operation failed  {Message}", ex.Message);
                    _logger.Log(LogLevel.Trace, "{StackTrace}", ex.StackTrace);
                    return 0;
                }
            }
            
        }

        public async Task<int> CountAsync(CancellationToken cancellationToken = default) {
            using (_logger.BeginScope(new Dictionary<string, object> {["Channel"] = $"REPO-{DateTime.Now:yyyyMMddHHmmss}",["Id"] = ""})) {
                try {
                     return await _dbSet.CountAsync(cancellationToken);
                } catch (Exception ex) {
                    _logger.Log(LogLevel.Error, "CountAsync operation failed:  {Message}", ex.Message);
                    _logger.Log(LogLevel.Trace, "{StackTrace}", ex.StackTrace);
                    return 0;
                }
            }
           
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default) {
            ArgumentNullException.ThrowIfNull(predicate);
            using (_logger.BeginScope(new Dictionary<string, object> {["Channel"] = $"REPO-{DateTime.Now:yyyyMMddHHmmss}",["Id"] = ""})) {
                try {
                     return await _dbSet.CountAsync(predicate, cancellationToken);
                } catch (Exception ex) {
                    _logger.Log(LogLevel.Error, "CountAsync with predicate operation failed:  {Message}", ex.Message);
                    _logger.Log(LogLevel.Trace, "{StackTrace}", ex.StackTrace);
                    return 0;
                }
            }
            
        }

        public async Task<int> CountAsync(bool excludeDeleted = true, CancellationToken cancellationToken = default) {
            using (_logger.BeginScope(new Dictionary<string, object> {["Channel"] = $"REPO-{DateTime.Now:yyyyMMddHHmmss}",["Id"] = ""})) {
                try {
                     if (excludeDeleted) {
                        return await _dbSet.CountAsync(e => !EF.Property<bool>(e, "IsDeleted"), cancellationToken);
                    }
        
                    return await _dbSet.CountAsync(cancellationToken);
                } catch (Exception ex) {
                    _logger.Log(LogLevel.Error, "CountAsync with excludeDeleted operation failed: {Message}", ex.Message);
                    _logger.Log(LogLevel.Trace, "{StackTrace}", ex.StackTrace);
                    return 0;
                }
            }
           
        }
        
        public async Task<int> CountAsync(Expression<Func<T, bool>> predicate, bool excludeDeleted = true, CancellationToken cancellationToken = default) {
            ArgumentNullException.ThrowIfNull(predicate);
            using (_logger.BeginScope(new Dictionary<string, object> {["Channel"] = $"REPO-{DateTime.Now:yyyyMMddHHmmss}",["Id"] = ""})) {
                try {
                    if (excludeDeleted) {
                        var combinedPredicate = CombinePredicates(predicate, e => !EF.Property<bool>(e, "IsDeleted"));
                        return await _dbSet.CountAsync(combinedPredicate, cancellationToken);
                    }
        
                    return await _dbSet.CountAsync(predicate, cancellationToken);
                } catch (Exception ex) {
                    _logger.Log(LogLevel.Error, "CountAsync with predicate and excludeDeleted operation failed: {Message}", ex.Message);
                    _logger.Log(LogLevel.Trace, "{StackTrace}", ex.StackTrace);
                    return 0;
                }
            }
            
        }
        
        public async Task<long> LongCountAsync(CancellationToken cancellationToken = default) {
            using (_logger.BeginScope(new Dictionary<string, object> {["Channel"] = $"REPO-{DateTime.Now:yyyyMMddHHmmss}",["Id"] = ""})) {
                try {
                    return await _dbSet.LongCountAsync(cancellationToken);
                } catch (Exception ex) {
                    _logger.Log(LogLevel.Error, "CountAsync with predicate and excludeDeleted operation failed: {Message}", ex.Message);
                    _logger.Log(LogLevel.Trace, "{StackTrace}", ex.StackTrace);
                    return 0;
                }
            }
            
        }

        public async Task<long> LongCountAsync(Expression<Func<T, bool>> predicate, bool excludeDeleted = true, CancellationToken cancellationToken = default) {
            ArgumentNullException.ThrowIfNull(predicate);
            using (_logger.BeginScope(new Dictionary<string, object> {["Channel"] = $"REPO-{DateTime.Now:yyyyMMddHHmmss}",["Id"] = ""})) {
                try {
                    if (excludeDeleted) {
                        var combinedPredicate = CombinePredicates(predicate, e => !EF.Property<bool>(e, "IsDeleted"));
                        return await _dbSet.LongCountAsync(combinedPredicate, cancellationToken);
                    }
        
                    return await _dbSet.LongCountAsync(predicate, cancellationToken);
                } catch (Exception ex) {
                    _logger.Log(LogLevel.Error, "LongCountAsync with predicate operation failed: {Message}", ex.Message);
                    _logger.Log(LogLevel.Trace, "{StackTrace}", ex.StackTrace);
                    return 0;
                }
            }
            
        }

        #endregion

        #region Cached Data

        public async Task<IList<T>> FindCachedAsync(Expression<Func<T, bool>> where, string cacheKey, TimeSpan? cacheTime = null) {
             using (_logger.BeginScope(new Dictionary<string, object> {["Channel"] = $"REPO-{DateTime.Now:yyyyMMddHHmmss}",["Id"] = ""})) {
                try {
                    var fullCacheKey = GetCacheKey(cacheKey);
                    return await _cacheManager.GetAsync(fullCacheKey, () => GetAllAsync(where), cacheTime);
                } catch (Exception ex) {
                    _logger.Log(LogLevel.Error, "Find cached operation failed: {Message}", ex.Message);
                    _logger.Log(LogLevel.Trace, "{StackTrace}", ex.StackTrace);
                    return null;
                }
             }
        }

        public async Task<T> GetByIdCachedAsync(long id, TimeSpan? cacheTime = null) {
            using (_logger.BeginScope(new Dictionary<string, object> {["Channel"] = $"REPO-{DateTime.Now:yyyyMMddHHmmss}",["Id"] = ""})) {
                try {
                    var cacheKey = GetByIdCacheKey(id);
                    return await _cacheManager.GetAsync(cacheKey, () => GetAsync(id), cacheTime);
                } catch (Exception ex) {
                    _logger.Log(LogLevel.Error, "Get cached Entity By ID operation failed: {Message}", ex.Message);
                    _logger.Log(LogLevel.Trace, "{StackTrace}", ex.StackTrace);
                    return null;
                }
             }
            
        }

        public async Task<T> GetByIdCachedAsync( long id, bool includeDeleted = false, TimeSpan? cacheTime = null, CancellationToken cancellationToken = default) {
            var cacheKey = GetCacheKey($"getbyid_{id}");
    
            return await _cacheManager.GetAsync(cacheKey, 
                () => GetByIdAsync(id, includeDeleted, cancellationToken), 
                cacheTime ?? TimeSpan.FromMinutes(30));
        }

        public async Task<IList<T>> GetAllCachedAsync(TimeSpan? cacheTime = null) {
           using (_logger.BeginScope(new Dictionary<string, object> {["Channel"] = $"REPO-{DateTime.Now:yyyyMMddHHmmss}",["Id"] = ""})) {
                try {
                    var cacheKey = GetAllCacheKey();
                    return await _cacheManager.GetAsync(cacheKey, () => GetAllAsync(), cacheTime);
                } catch (Exception ex) {
                    _logger.Log(LogLevel.Error, "Get all cached Entities operation failed: {Message}", ex.Message);
                    _logger.Log(LogLevel.Trace, "{StackTrace}", ex.StackTrace);
                    return null;
                }
             }
           
        }
        
        public async Task<IList<T>> GetAllCachedAsync(string cacheKey, bool includeDeleted = false, TimeSpan? cacheTime = null, CancellationToken cancellationToken = default) {
            if (string.IsNullOrWhiteSpace(cacheKey))
                throw new ArgumentException("Cache key cannot be null or empty", nameof(cacheKey));

            var fullCacheKey = GetCacheKey($"getall_{cacheKey}");
    
            return await _cacheManager.GetAsync(fullCacheKey, 
                () => GetAllAsync(includeDeleted, cancellationToken), 
                cacheTime ?? TimeSpan.FromMinutes(10));
        }

        public async Task<IList<T>> GetAllCachedAsync( Expression<Func<T, bool>> predicate, string cacheKey, bool includeDeleted = false, TimeSpan? cacheTime = null, CancellationToken cancellationToken = default) {
            ArgumentNullException.ThrowIfNull(predicate);

            if (string.IsNullOrWhiteSpace(cacheKey))
                throw new ArgumentException("Cache key cannot be null or empty", nameof(cacheKey));

            var fullCacheKey = GetCacheKey($"getall_{cacheKey}");
    
            return await _cacheManager.GetAsync(fullCacheKey, 
                () => GetAllAsync(predicate, includeDeleted, cancellationToken), 
                cacheTime ?? TimeSpan.FromMinutes(10));
        }

        #endregion

        #region private Methods
        
        private async Task<int> GetApproximateCountAsync(Expression<Func<T, bool>> predicate,bool includeDeleted, CancellationToken cancellationToken) {
            //..use approximate count only if configuration allows it
            if (!await ShouldUseApproximateCountAsync(predicate)) {
                return await GetExactCountAsync(predicate, includeDeleted, cancellationToken);
            }

            try {
                var tableName = _dbContext.Model.FindEntityType(typeof(T))?.GetTableName();
                if (string.IsNullOrEmpty(tableName))
                    return await GetExactCountAsync(predicate, includeDeleted, cancellationToken);

                //..SQL Server approximate count
                var sql = @"
                    SELECT CAST(SUM(row_count) AS INT)
                    FROM sys.dm_db_partition_stats 
                    WHERE object_id = OBJECT_ID({0}) 
                    AND index_id IN (0,1)";

                var approximateCount = await _dbContext.Database
                    .SqlQueryRaw<int>(sql, tableName)
                    .FirstOrDefaultAsync(cancellationToken);

                _logger.Log(LogLevel.Information, "Using approximate count for {Name}: {ApproximateCount}", typeof(T).Name, approximateCount);
                return approximateCount;
            } catch (Exception ex) {
                _logger.Log(LogLevel.Error, "Approximate count failed for {Name} , falling back to exact count: {ApproximateCount}", typeof(T).Name, ex.Message);
                return await GetExactCountAsync(predicate, includeDeleted, cancellationToken);
            }
        }

         private async Task<int> GetExactCountAsync(Expression<Func<T, bool>> predicate, bool includeDeleted, CancellationToken cancellationToken) {
            var query = _dbSet.AsQueryable();
            if (!includeDeleted){
                var combinedPredicate = CombinePredicates(predicate, e => !EF.Property<bool>(e, "IsDeleted"));
                return await query.CountAsync(combinedPredicate, cancellationToken);
            }
        
            return await query.CountAsync(predicate, cancellationToken);
         }

        private static PropertyInfo GetIsDeletedProperty() {
            if (_cachedIsDeletedProperty == null) {
                lock (_lockObject) {
                    _cachedIsDeletedProperty ??= typeof(T).GetProperty("IsDeleted", 
                        BindingFlags.Public | BindingFlags.Instance);
                }
            }
            return _cachedIsDeletedProperty;
        }

        private static PropertyInfo GetIdProperty() {
            if (_cachedIdProperty == null) {
                lock (_lockObject) {
                    _cachedIdProperty ??= typeof(T).GetProperty("Id", 
                        BindingFlags.Public | BindingFlags.Instance);
                }
            }
            return _cachedIdProperty;
        }

        /// <summary>
        /// Extract class property name form class property
        /// </summary>
        /// <param name="predicate">Filter Predicate</param>
        /// <returns>Property name</returns>
        private static string GetPropertyName(Expression<Func<T, object>> predicate) {
            if (predicate.Body is MemberExpression exMember) {
                return exMember.Member.Name;
            } else if (predicate.Body is UnaryExpression unary) {
                //..for handling nullable properties
                if (unary.Operand is MemberExpression operand) {
                    return operand.Member.Name;
                }
            }

            return null;
        }
        
        private async Task<bool> ShouldUseApproximateCountAsync(Expression<Func<T, bool>> predicate = null)
            => await _paginationConfig.ShouldUseApproximateCountAsync<T>(predicate);

        private (List<T> toSoftDelete, List<T> toHardDelete) ProcessEntitiesForDeletion(List<T> entities, PropertyInfo isDeletedProperty, PropertyInfo idProperty) {
            var toSoftDelete = new List<T>();
            var toHardDelete = new List<T>();
            var invalidatedIds = new HashSet<long>();

            foreach (var entity in entities) {
                _ = _dbContext.Entry(entity);

                //..check if entity is already soft deleted
                var isDeleted = (bool?)isDeletedProperty.GetValue(entity) ?? false;
                if (isDeleted){
                    //..already soft deleted, add to hard delete list
                    toHardDelete.Add(entity);
                
                    //..cache invalidation for hard deleted entities
                    if (idProperty?.GetValue(entity) is long id && invalidatedIds.Add(id)) {
                        InvalidateCache(id);
                    }
                } else {
                    //..not soft deleted, add to soft delete list
                    toSoftDelete.Add(entity);
                }
                
            }

            return (toSoftDelete, toHardDelete);
        }

        private async Task PerformSoftDeleteAsync(List<T> entities, PropertyInfo isDeletedProperty) {
            if (isDeletedProperty == null)
                return;

            //..batch update for soft delete
            foreach (var entity in entities) {
                var entry = _dbContext.Entry(entity);
                isDeletedProperty.SetValue(entity, true);
                entry.State = EntityState.Modified;
            }

            await BulkUpdateAsync(entities);
        }

        private static Expression<Func<T, bool>> CombinePredicates(Expression<Func<T, bool>> first, Expression<Func<T, bool>> second) {
            var parameter = Expression.Parameter(typeof(T), "x");
    
            var firstBody = ReplaceParameter(first.Body, first.Parameters[0], parameter);
            var secondBody = ReplaceParameter(second.Body, second.Parameters[0], parameter);
    
            var combinedBody = Expression.AndAlso(firstBody, secondBody);
    
            return Expression.Lambda<Func<T, bool>>(combinedBody, parameter);
        }

        private static Expression ReplaceParameter(Expression expression, ParameterExpression oldParameter, ParameterExpression newParameter)
            => new ParameterReplacerVisitor(oldParameter, newParameter).Visit(expression);

        /// <summary>
        /// Parameter replacer visitor class for expression manipulation
        /// </summary>
        private class ParameterReplacerVisitor(ParameterExpression oldParameter, ParameterExpression newParameter)
            : ExpressionVisitor {
            private readonly ParameterExpression _oldParameter = oldParameter;
            private readonly ParameterExpression _newParameter = newParameter;

            protected override Expression VisitParameter(ParameterExpression node) 
                 => node == _oldParameter ? _newParameter : base.VisitParameter(node);
        }

        #endregion

        #region Private Helper Methods

        /// <summary>
        /// Use EF Core built-in bulk insert for smaller datasets
        /// </summary>
        /// <param name="entityCount"></param>
        /// <returns></returns>
        private bool ShouldUseEFCoreBulkInsert(int entityCount)
            => entityCount <= _bulkOptions.EFCoreThreshold && _bulkOptions.PreferEFCore;

        /// <summary>
        /// Use Bulk Insert
        /// </summary>
        /// <param name="entities"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        private async Task<BulkOperationResult<T>> PerformEFCoreBulkInsertAsync(List<T> entities, BulkInsertOptions options, CancellationToken cancellationToken) 
            => await PerformThirdPartyBulkInsertAsync(entities, options, cancellationToken);

        private async Task<BulkOperationResult<T>> PerformThirdPartyBulkInsertAsync(List<T> entities, BulkInsertOptions options, CancellationToken cancellationToken) {
            var bulkConfig = new BulkConfig {
                SetOutputIdentity = options.SetOutputIdentity,
                PreserveInsertOrder = options.PreserveInsertOrder,
                SqlBulkCopyOptions = options.SqlBulkCopyOptions,
                BatchSize = options.BatchSize > 0 ? options.BatchSize : _bulkOptions.DefaultBatchSize
            };

            await _dbContext.BulkInsertAsync(entities, bulkConfig, cancellationToken: cancellationToken);
            return new BulkOperationResult<T> {
                IsSuccess = true,
                AffectedRows = entities.Count,
                Duration = TimeSpan.Zero 
            };
        }

        private async Task<BulkOperationResult<T>> PerformBulkUpdateAsync(List<T> entities, BulkUpdateOptions<T> options, CancellationToken cancellationToken) {
            var bulkConfig = new BulkConfig {
                SetOutputIdentity = options.SetOutputIdentity,
                PreserveInsertOrder = options.PreserveInsertOrder,
                BatchSize = options.BatchSize > 0 ? options.BatchSize : _bulkOptions.DefaultBatchSize
            };

            if (options.PropertiesToUpdate != null && options.PropertiesToUpdate.Length > 0) {
                bulkConfig.PropertiesToInclude = options.PropertiesToUpdate
                    .Select(GetPropertyName)
                    .Where(name => !string.IsNullOrEmpty(name))
                    .ToList();
            }

            await _dbContext.BulkUpdateAsync(entities, bulkConfig, cancellationToken: cancellationToken);

            return new BulkOperationResult<T> {
                IsSuccess = true,
                AffectedRows = entities.Count,
                Duration = TimeSpan.Zero
            };
        }

        #endregion

        #region Protected Methods

        protected virtual void InvalidateCache() {
            _cacheManager.RemoveByPrefix(_entityName);
            _logger.Log(LogLevel.Information, "Invalidated cache for entity: {EntityName}", _entityName);
        }

        protected virtual void InvalidateCache(long id) {
            var cacheKey = GetByIdCacheKey(id);
            _cacheManager.Remove(cacheKey);
             _logger.Log(LogLevel.Information, "Invalidated cache for entity: {EntityName} with id: {Id}", _entityName, id);
        }

        protected static bool SupportsSoftDelete<TV>() where TV : BaseEntity
            => typeof(T).GetProperty("IsDeleted") != null;

        protected virtual string GetCacheKey(string suffix) => $"{_entityName}_{suffix}";
        protected virtual string GetByIdCacheKey(long id) => GetCacheKey($"id_{id}");
        protected virtual string GetAllCacheKey() => GetCacheKey("all");

        #endregion

    }

}
