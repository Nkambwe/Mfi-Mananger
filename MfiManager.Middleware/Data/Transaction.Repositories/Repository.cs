using MfiManager.Middleware.Configuration;
using MfiManager.Middleware.Data.Entities;
using MfiManager.Middleware.Data.Services;
using MfiManager.Middleware.Factories;
using MfiManager.Middleware.Utils;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Reflection;

namespace MfiManager.Middleware.Data.Transaction.Repositories {

   public class Repository<T> : IRepository<T> where T : BaseEntity {

        #region Private Fields
        private readonly string _entityName = typeof(T).Name.ToLower();
        private static PropertyInfo _cachedIsDeletedProperty;
        private static PropertyInfo _cachedIdProperty;
        private static readonly object _lockObject = new();
        private readonly IPaginationConfigurationService _paginationConfig;
        #endregion

        protected readonly IServiceLogger Logger;
        protected readonly IStaticCacheManager _cacheManager;
        protected readonly DbSet<T> _dbSet;
        protected readonly MfiManagerDbContext _dbContext; 

        public Repository(MfiManagerDbContext dbContext,
                          IServiceLoggerFactory loggerFactory, 
                          IStaticCacheManager cacheManager, 
                        IPaginationConfigurationService paginationConfig) {
            Logger = loggerFactory.CreateLogger();
            Logger.Channel = $"REPO-{DateTime.Now:yyyyMMddHHmmss}";
            _cacheManager = cacheManager;
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
            _paginationConfig = paginationConfig;
        }

        public int Count() {
            try {
                return _dbSet.Count();
            } catch (Exception ex) {
                Logger?.Log($"Count operation failed: {ex.Message}", "DbAction");
                Logger?.Log($"STACKTRACE :: {ex.StackTrace}", "DbStacktrace");
                return 0;
            }
        }

        public int Count(Expression<Func<T, bool>> predicate) {
            ArgumentNullException.ThrowIfNull(predicate);

            try {
                return _dbSet.Count(predicate);
            } catch (Exception ex) {
                Logger?.Log($"Count with predicate operation failed: {ex.Message}", "DbAction");
                Logger?.Log($"STACKTRACE :: {ex.StackTrace}", "DbStacktrace");
                return 0;
            }
        }

        public async Task<int> CountAsync(CancellationToken cancellationToken = default) {
            try {
                return await _dbSet.CountAsync(cancellationToken);
            } catch (Exception ex) {
                Logger?.Log($"CountAsync operation failed: {ex.Message}", "DbAction");
                Logger?.Log($"STACKTRACE :: {ex.StackTrace}", "DbStacktrace");
                return 0;
            }
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default) {
            ArgumentNullException.ThrowIfNull(predicate);

            try {
                return await _dbSet.CountAsync(predicate, cancellationToken);
            } catch (Exception ex) {
                Logger?.Log($"CountAsync with predicate operation failed: {ex.Message}", "DbAction");
                Logger?.Log($"STACKTRACE :: {ex.StackTrace}", "DbStacktrace");
                return 0;
            }
        }

        public async Task<int> CountAsync(bool excludeDeleted = true, CancellationToken cancellationToken = default) {
            try {
                if (excludeDeleted) {
                    return await _dbSet.CountAsync(e => !EF.Property<bool>(e, "IsDeleted"), cancellationToken);
                }
        
                return await _dbSet.CountAsync(cancellationToken);
            } catch (Exception ex) {
                Logger?.Log($"CountAsync with excludeDeleted operation failed: {ex.Message}", "DbAction");
                Logger?.Log($"STACKTRACE :: {ex.StackTrace}", "DbStacktrace");
                return 0;
            }
        }
        
        public async Task<int> CountAsync(Expression<Func<T, bool>> predicate, bool excludeDeleted = true, CancellationToken cancellationToken = default) {
            ArgumentNullException.ThrowIfNull(predicate);

            try {
                if (excludeDeleted) {
                    var combinedPredicate = CombinePredicates(predicate, e => !EF.Property<bool>(e, "IsDeleted"));
                    return await _dbSet.CountAsync(combinedPredicate, cancellationToken);
                }
        
                return await _dbSet.CountAsync(predicate, cancellationToken);
            } catch (Exception ex) {
                Logger?.Log($"CountAsync with predicate and excludeDeleted operation failed: {ex.Message}", "DbAction");
                Logger?.Log($"STACKTRACE :: {ex.StackTrace}", "DbStacktrace");
                return 0;
            }
        }
        
        public async Task<long> LongCountAsync(CancellationToken cancellationToken = default) {
            try {
                return await _dbSet.LongCountAsync(cancellationToken);
            } catch (Exception ex) {
                Logger?.Log($"LongCountAsync operation failed: {ex.Message}", "DbAction");
                Logger?.Log($"STACKTRACE :: {ex.StackTrace}", "DbStacktrace");
                return 0L;
            }
        }

        public async Task<long> LongCountAsync(Expression<Func<T, bool>> predicate, bool excludeDeleted = true, CancellationToken cancellationToken = default) {
            ArgumentNullException.ThrowIfNull(predicate);

            try {
                if (excludeDeleted) {
                    var combinedPredicate = CombinePredicates(predicate, e => !EF.Property<bool>(e, "IsDeleted"));
                    return await _dbSet.LongCountAsync(combinedPredicate, cancellationToken);
                }
        
                return await _dbSet.LongCountAsync(predicate, cancellationToken);
            } catch (Exception ex) {
                Logger?.Log($"LongCountAsync with predicate operation failed: {ex.Message}", "DbAction");
                Logger?.Log($"STACKTRACE :: {ex.StackTrace}", "DbStacktrace");
                return 0L;
            }
        }

        public bool Exists(Expression<Func<T, bool>> predicate, bool excludeDeleted = true) {
            ArgumentNullException.ThrowIfNull(predicate);

            try {
                var query = _dbSet.AsQueryable();
        
                if (excludeDeleted) {
                    //..combine predicates for a single database query
                    var combinedPredicate = CombinePredicates(predicate, e => !EF.Property<bool>(e, "IsDeleted"));
                    return query.Any(combinedPredicate);
                }
        
                return query.Any(predicate);
            }
            catch (Exception ex)
            {
                Logger?.Log($"Exists operation failed: {ex.Message}", "DbAction");
                Logger?.Log($"STACKTRACE :: {ex.StackTrace}", "DbStacktrace");
                return false;
            }
        }

        public async Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate, bool excludeDeleted = true, CancellationToken cancellationToken = default) {
            ArgumentNullException.ThrowIfNull(predicate);

            try {
                var query = _dbSet.AsQueryable();
                if (excludeDeleted) {
                    var combinedPredicate = CombinePredicates(predicate, e => !EF.Property<bool>(e, "IsDeleted"));
                    return await query.AnyAsync(combinedPredicate, cancellationToken);
                }
        
                return await query.AnyAsync(predicate, cancellationToken);
            } catch (Exception ex) {
                Logger?.Log($"ExistsAsync operation failed: {ex.Message}", "DbAction");
                Logger?.Log($"STACKTRACE :: {ex.StackTrace}", "DbStacktrace");
                return false;
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
                Logger?.Log($"ExistsBatch operation failed: {ex.Message}", "DbAction");
                Logger?.Log($"STACKTRACE :: {ex.StackTrace}", "DbStacktrace");
                return [];
            }
        }

        public T Get(long id, bool includeDeleted = false) {
             T entity = null;
             var entities = _dbSet;

             try {

                var query = entities.AsQueryable();
                if (!includeDeleted) {
                    query = query.Where(e => EF.Property<bool>(e, "IsDeleted") == false);
                }

                entity = query.FirstOrDefault(e => e.Id == id);
             } catch (Exception ex) {
                Logger.Log($"Get by ID operation failed: {ex.Message}", "DbAction");
                Logger.Log("STACKTRACE ::");
                Logger.Log($"{ex.StackTrace}", "DbStacktrace");
                return null;
             }

            return entity;
        }

        public async Task<T> GetAsync(long id, bool includeDeleted = false) {
            T entity = null;
            var entities = _dbSet;

            try {

                var query = entities.AsQueryable();
                if (!includeDeleted) {
                    query = query.Where(e => EF.Property<bool>(e, "IsDeleted") == false);
                }

                entity = await query.FirstOrDefaultAsync(e => e.Id == id);
            } catch (Exception ex) {
                Logger.Log($"Get by ID operation failed: {ex.Message}", "DbAction");
                Logger.Log("STACKTRACE ::");
                Logger.Log($"{ex.StackTrace}", "DbStacktrace");
                return null;
            }

            return entity;
        }

        public T Get(Expression<Func<T, bool>> where, bool includeDeleted = false) {
            T entity = null;
            var entities = _dbSet;
            try {
                var query = entities.AsQueryable();
                if (!includeDeleted) {
                    query = query.Where(e => EF.Property<bool>(e, "IsDeleted") == false);
                }

                entity = query.FirstOrDefault(where);

            } catch (Exception ex) {
                Logger.Log($"Get operation failed: {ex.Message}", "DbAction");
                Logger.Log("STACKTRACE ::");
                Logger.Log($"{ex.StackTrace}", "DbStacktrace");
            }

            return entity;
        }

        public async Task<T> GetByIdAsync(long id, bool includeDeleted = false, CancellationToken cancellationToken = default, params Expression<Func<T, object>>[] includes) {
            try {
                var query = GetAll(e => EF.Property<long>(e, "Id") == id, includeDeleted, includes);
                return await query.FirstOrDefaultAsync(cancellationToken);
            } catch (Exception ex) {
                Logger?.Log($"GetByIdAsync operation failed: {ex.Message}", "DbAction");
                Logger?.Log($"STACKTRACE :: {ex.StackTrace}", "DbStacktrace");
                return null;
            }
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> where, bool includeDeleted = false) {
              var entities = _dbSet;
            try {
                var query = entities.AsQueryable();
                if (!includeDeleted) {
                    query = query.Where(e => EF.Property<bool>(e, "IsDeleted") == false);
                }

                return await query.FirstOrDefaultAsync(where);
            } catch (Exception ex) {
                Logger.Log($"Get operation failed: {ex.Message}", "DbAction");
                Logger.Log("STACKTRACE ::");
                Logger.Log($"{ex.StackTrace}", "DbStacktrace");
                return null;
            }
        }
        
        public T Get(Expression<Func<T, bool>> where, bool includeDeleted = false, params Expression<Func<T, object>>[] includes) {
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
                Logger.Log($"Get operation failed: {ex.Message}", "DbAction");
                Logger.Log("STACKTRACE ::");
                Logger.Log($"{ex.StackTrace}", "DbStacktrace");
                return null;
            }

            return entity;
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> where, bool includeDeleted = false, params Expression<Func<T, object>>[] includes) {
            var entities = _dbSet;
            try {
                var query = entities.AsQueryable();
                if (!includeDeleted) {
                    query = query.Where(e => EF.Property<bool>(e, "IsDeleted") == false);
                }

                return await query.FirstOrDefaultAsync(where);
            } catch (Exception ex) {
                Logger.Log($"Get operation failed: {ex.Message}", "DbAction");
                Logger.Log("STACKTRACE ::");
                Logger.Log($"{ex.StackTrace}", "DbStacktrace");
                return null;
            }
        }

        public IQueryable<T> GetTop(Expression<Func<T, bool>> where, int top, bool includeDeleted = false) {
            try {
                IQueryable<T> query = _dbSet;
                if (!includeDeleted) {
                    query = query.Where(e => EF.Property<bool>(e, "IsDeleted") == false);
                }

                return query.Where(where).Take(top);
            } catch (Exception ex) {
                Logger.Log($"Get Top operation failed: {ex.Message}", "DbAction");
                Logger.Log("STACKTRACE ::");
                Logger.Log($"{ex.StackTrace}", "DbStacktrace");
                return null;
            }
            
        }
        
        public T GetSingleOrDefault(Expression<Func<T, bool>> where, bool includeDeleted = false) {
            try {
                if (!includeDeleted) {
                    var entry = _dbContext.Entry(where);
                    var isDeleted = (bool)entry.Property("IsDeleted").CurrentValue;
                    if (isDeleted) {
                        Logger.Log("Entity found but is marked as deleted.", "DbAction");
                        return null;
                    }
                }

                return _dbSet.SingleOrDefault(where);
            } catch (Exception ex) {
                Logger.Log($"Update operation failed: {ex.Message}", "DbAction");
                Logger.Log("STACKTRACE ::");
                Logger.Log($"{ex.StackTrace}", "DbStacktrace");
                return null;
            }
        }

        public async Task<T> GetSingleOrDefaultAsync(Expression<Func<T, bool>> where, bool includeDeleted = false) {
            try {
                if (!includeDeleted) {
                    var entry = _dbContext.Entry(where);
                    var isDeleted = (bool)entry.Property("IsDeleted").CurrentValue;
                    if (isDeleted) {
                        Logger.Log("Entity found but is marked as deleted.", "DbAction");
                        return null;
                    }
                }

                return await _dbSet.SingleOrDefaultAsync(where);
            } catch (Exception ex) {
                Logger.Log($"Update operation failed: {ex.Message}", "DbAction");
                Logger.Log("STACKTRACE ::");
                Logger.Log($"{ex.StackTrace}", "DbStacktrace");
                return null;
            }
            
        }

        public async Task<T> GetSingleOrDefaultAsync(Expression<Func<T, bool>> predicate, bool includeDeleted = false, CancellationToken cancellationToken = default, params Expression<Func<T, object>>[] includes) {
            ArgumentNullException.ThrowIfNull(predicate);

            try {
                var query = GetAll(predicate, includeDeleted, includes);
                return await query.FirstOrDefaultAsync(cancellationToken);
            } catch (Exception ex) {
                Logger?.Log($"GetSingleAsync operation failed: {ex.Message}", "DbAction");
                Logger?.Log($"STACKTRACE :: {ex.StackTrace}", "DbStacktrace");
                return null;
            }
        }

        public IQueryable<T> GetAll(bool includeDeleted = false) {
            try {
                var query = _dbSet.AsQueryable();
        
                if (!includeDeleted) {
                    query = query.Where(e => !EF.Property<bool>(e, "IsDeleted"));
                }
        
                return query;
            } catch (Exception ex) {
                Logger?.Log($"GetAll operation failed: {ex.Message}", "DbAction");
                Logger?.Log($"STACKTRACE :: {ex.StackTrace}", "DbStacktrace");
                return Enumerable.Empty<T>().AsQueryable();
            }
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate, bool includeDeleted = false) {
            ArgumentNullException.ThrowIfNull(predicate);

            try {
                var query = _dbSet.AsQueryable();
        
                if (!includeDeleted ) {
                    var combinedPredicate = CombinePredicates(predicate, e => !EF.Property<bool>(e, "IsDeleted"));
                    return query.Where(combinedPredicate);
                }
        
                return query.Where(predicate);
            } catch (Exception ex) {
                Logger?.Log($"GetAll with predicate operation failed: {ex.Message}", "DbAction");
                Logger?.Log($"STACKTRACE :: {ex.StackTrace}", "DbStacktrace");
                return Enumerable.Empty<T>().AsQueryable();
            }
        }

        public IQueryable<T> GetAll(bool includeDeleted = false, params Expression<Func<T, object>>[] includes) {

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
                Logger?.Log($"GetAll with predicate and includes operation failed: {ex.Message}", "DbAction");
                Logger?.Log($"STACKTRACE :: {ex.StackTrace}", "DbStacktrace");
                return Enumerable.Empty<T>().AsQueryable();
            }
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate, bool includeDeleted = false, params Expression<Func<T, object>>[] includes){
            ArgumentNullException.ThrowIfNull(predicate);

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
                Logger?.Log($"GetAll with predicate and includes operation failed: {ex.Message}", "DbAction");
                Logger?.Log($"STACKTRACE :: {ex.StackTrace}", "DbStacktrace");
                return Enumerable.Empty<T>().AsQueryable();
            }
        }
        
        public async Task<IList<T>> GetTopAsync(Expression<Func<T, bool>> where, int top, bool includeDeleted = false) {
            try {
                IQueryable<T> query = _dbSet;
                if (!includeDeleted) {
                    query = query.Where(e => EF.Property<bool>(e, "IsDeleted") == false);
                }

                return await query.Where(where).Take(top).ToListAsync();
            } catch (Exception ex) {
                Logger.Log($"Get Top operation failed: {ex.Message}", "DbAction");
                Logger.Log("STACKTRACE ::");
                Logger.Log($"{ex.StackTrace}", "DbStacktrace");
                return null;
            }
        }

        public async Task<IList<T>> GetAllAsync(bool includeDeleted = false, CancellationToken cancellationToken = default) {
            try {
                var query = GetAll(includeDeleted);
                return await query.ToListAsync(cancellationToken);
            } catch (Exception ex) {
                Logger?.Log($"GetAllAsync operation failed: {ex.Message}", "DbAction");
                Logger?.Log($"STACKTRACE :: {ex.StackTrace}", "DbStacktrace");
                return [];
            }
        }

        public async Task<IList<T>> GetAllAsync( Expression<Func<T, bool>> predicate, bool includeDeleted = false, CancellationToken cancellationToken = default) {
            ArgumentNullException.ThrowIfNull(predicate);

            try {
                var query = GetAll(predicate, includeDeleted);
                return await query.ToListAsync(cancellationToken);
            } catch (Exception ex){
                Logger?.Log($"GetAllAsync with predicate operation failed: {ex.Message}", "DbAction");
                Logger?.Log($"STACKTRACE :: {ex.StackTrace}", "DbStacktrace");
                return [];
            }
        }

        public async Task<IList<T>> GetAllAsync(bool includeDeleted = false, params Expression<Func<T, object>>[] includes) {

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
                Logger?.Log($"GetAllAsync with predicate operation failed: {ex.Message}", "DbAction");
                Logger?.Log($"STACKTRACE :: {ex.StackTrace}", "DbStacktrace");
                return [];
            }
        }

        public async Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> where, bool includeDeleted = false, params Expression<Func<T, object>>[] includes) {
            ArgumentNullException.ThrowIfNull(where);

            try {
                var query = GetAll(where, includeDeleted,includes);
                return await query.ToListAsync();
            } catch (Exception ex){
                Logger?.Log($"GetAllAsync with predicate operation failed: {ex.Message}", "DbAction");
                Logger?.Log($"STACKTRACE :: {ex.StackTrace}", "DbStacktrace");
                return [];
            }
        }
        
        public async Task<PagedResult<T>> GetAllPagedAsync( int pageNumber = 1, int pageSize = 10, bool includeDeleted = false, CancellationToken cancellationToken = default) {
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
                Logger?.Log($"GetAllPagedAsync operation failed: {ex.Message}", "DbAction");
                Logger?.Log($"STACKTRACE :: {ex.StackTrace}", "DbStacktrace");
                return PagedResult<T>.Empty();
            }
        }

        public async Task<PagedResult<T>> GetPagedAllAsync(Expression<Func<T, bool>> predicate, int pageNumber, int pageSize, bool includeDeleted, CancellationToken cancellationToken = default) {
            ArgumentNullException.ThrowIfNull(predicate);

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
                Logger?.Log($"GetAllPagedAsync with predicate operation failed: {ex.Message}", "DbAction");
                Logger?.Log($"STACKTRACE :: {ex.StackTrace}", "DbStacktrace");
                return PagedResult<T>.Empty();
            }
        }

        public async Task<PagedResult<T>> GetPagedAllAsync( Expression<Func<T, bool>> predicate, int pageNumber, int pageSize, bool includeDeleted = false, CancellationToken cancellationToken = default,  params Expression<Func<T, object>>[] includes) {
                ArgumentNullException.ThrowIfNull(predicate);

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

                    Logger.Log($"GetPagedAllAsync executed successfully: Page {pageNumber}/{totalPages}, {items.Count} items returned", "DbAction");

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
                    Logger?.Log($"GetPagedAllAsync with predicate operation failed: {ex.Message}", "DbAction");
                    Logger?.Log($"STACKTRACE :: {ex.StackTrace}", "DbStacktrace");
                    return PagedResult<T>.Empty();
                }
        }

        public async Task<PagedResult<T>> GetPagedAllAsync<TKey>( Expression<Func<T, bool>> predicate, Expression<Func<T, TKey>> orderBy, int pageNumber, int pageSize, bool ascending = true, bool includeDeleted = false, CancellationToken cancellationToken = default, params Expression<Func<T, object>>[] includes) {
                ArgumentNullException.ThrowIfNull(predicate);
                ArgumentNullException.ThrowIfNull(orderBy);

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
                    Logger?.Log($"GetPagedAllAsync with ordering operation failed: {ex.Message}", "DbAction");
                    Logger?.Log($"STACKTRACE :: {ex.StackTrace}", "DbStacktrace");
                    return PagedResult<T>.Empty();
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
                Logger?.Log($"GetPagedAllProjectedAsync operation failed: {ex.Message}", "DbAction");
                Logger?.Log($"STACKTRACE :: {ex.StackTrace}", "DbStacktrace");
                return PagedResult<TResult>.Empty();
            }
        }

        public async Task<PagedResult<T>> GetLargePagedAllAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> orderBy,int pageNumber, int pageSize, bool ascending = true, bool includeDeleted = false, CancellationToken cancellationToken = default) {
                ArgumentNullException.ThrowIfNull(predicate);
                ArgumentNullException.ThrowIfNull(orderBy);

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
                }
                catch (Exception ex)
                {
                    Logger?.Log($"GetPagedAllOptimizedAsync operation failed: {ex.Message}", "DbAction");
                    Logger?.Log($"STACKTRACE :: {ex.StackTrace}", "DbStacktrace");
                    return PagedResult<T>.Empty();
                }
        }

        public async Task<CursorPagedResult<T, TCursor>> GetPagedAllCursorAsync<TCursor>(Expression<Func<T, bool>> predicate,Expression<Func<T, TCursor>> cursorSelector, TCursor cursor = default, int pageSize = 10, bool ascending = true, bool includeDeleted = false, CancellationToken cancellationToken = default) where TCursor : IComparable<TCursor> {
            ArgumentNullException.ThrowIfNull(predicate);
            ArgumentNullException.ThrowIfNull(cursorSelector);

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
                Logger?.Log($"GetPagedAllCursorAsync operation failed: {ex.Message}", "DbAction");
                Logger?.Log($"STACKTRACE :: {ex.StackTrace}", "DbStacktrace");
                return CursorPagedResult<T, TCursor>.Empty();
            }
        }

        public Task<bool> BulkInsertAsync(IEnumerable<T> entities) {
            throw new NotImplementedException();
        }

        public Task<bool> BulkUpdateAsync(IEnumerable<T> entities) {
            throw new NotImplementedException();
        }

        public Task<bool> BulkUpdateAsync(IEnumerable<T> entities, params Expression<Func<T, object>>[] propertySelectors) {
            throw new NotImplementedException();
        }
        
        public void Add(T entity) {
            ArgumentNullException.ThrowIfNull(entity);
            try {
                _dbSet.Add(entity);
                InvalidateCache();
            } catch (Exception ex) {
                Logger.Log($"Add operation failed: {ex.Message}", "DbAction");
                Logger.Log("STACKTRACE ::");
                Logger.Log($"{ex.StackTrace}", "DbStacktrace");
            }
            
        }

        public async Task AddAsync(T entity) {
            ArgumentNullException.ThrowIfNull(entity);
            try {
                await _dbSet.AddAsync(entity);
                InvalidateCache();
            } catch (Exception ex) {
                Logger.Log($"Add operation failed: {ex.Message}", "DbAction");
                Logger.Log("STACKTRACE ::");
                Logger.Log($"{ex.StackTrace}", "DbStacktrace");
            }
            
        }

        public async Task AddRangeAsync(IEnumerable<T> entities) {
            ArgumentNullException.ThrowIfNull(entities);
            try {
                await _dbSet.AddRangeAsync(entities);
                InvalidateCache();
            } catch (Exception ex) {
                Logger.Log($"AddRange operation failed: {ex.Message}", "DbAction");
                Logger.Log("STACKTRACE ::");
                Logger.Log($"{ex.StackTrace}", "DbStacktrace");
            }
             
        }

        public void Remove(T entity, bool markAsDeleted = false) {
            ArgumentNullException.ThrowIfNull(entity);
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
                        Logger.Log("Entity found and marked as deleted.", "DbAction");
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
                Logger.Log($"Remove operation failed: {ex.Message}", "DbAction");
                Logger.Log("STACKTRACE ::");
                Logger.Log($"{ex.StackTrace}", "DbStacktrace");
            }
        }

        public async Task RemoveRangeAsync(IEnumerable<T> entities, bool markAsDeleted = false) {
            ArgumentNullException.ThrowIfNull(entities);

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
        
                Logger?.Log($"Successfully processed {entitiesList.Count} entities for removal", "DbAction");
            }
            catch (Exception ex)
            {
                Logger?.Log($"Remove operation failed: {ex.Message}", "DbAction");
                Logger?.Log($"STACKTRACE :: {ex.StackTrace}", "DbStacktrace");
                throw;
            }
        }

        public void Update(T entity, bool includeDeleted = false) {
            ArgumentNullException.ThrowIfNull(entity);
            try {
                if (!includeDeleted) {
                    var entry = _dbContext.Entry(entity);
                    var isDeleted = (bool)entry.Property("IsDeleted").CurrentValue;
                    if (isDeleted) {
                        Logger.Log("Update operation skipped: Entity is marked as deleted.", "DbAction");
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
                Logger.Log($"Update operation failed: {ex.Message}", "DbError");
                Logger.Log("STACKTRACE ::");
                Logger.Log($"{ex.StackTrace}", "DbStacktrace");
            }  
        }
        
        public int GetContextHashCode()
            => _dbContext.GetType().GetHashCode();

        #region Cached Data
        
        public async Task<IList<T>> FindCachedAsync(Expression<Func<T, bool>> where, string cacheKey, TimeSpan? cacheTime = null) {
            try {
                var fullCacheKey = GetCacheKey(cacheKey);
                return await _cacheManager.GetAsync(fullCacheKey, () => GetAllAsync(where), cacheTime);
            } catch (Exception ex) {
                Logger.Log($"Get cached Entity By ID operation failed: {ex.Message}", "DbAction");
                Logger.Log("STACKTRACE ::");
                Logger.Log($"{ex.StackTrace}", "DbStacktrace");
                return null;
            }
        }

        public async Task<T> GetByIdCachedAsync(long id, TimeSpan? cacheTime = null) {
            try {
                 var cacheKey = GetByIdCacheKey(id);
                return await _cacheManager.GetAsync(cacheKey, () => GetAsync(id), cacheTime);
            } catch (Exception ex) {
                Logger.Log($"Get cached Entity By ID operation failed: {ex.Message}", "DbAction");
                Logger.Log("STACKTRACE ::");
                Logger.Log($"{ex.StackTrace}", "DbStacktrace");
                return null;
            }
        }

        public async Task<T> GetByIdCachedAsync( long id, bool includeDeleted = false, TimeSpan? cacheTime = null, CancellationToken cancellationToken = default) {
            var cacheKey = GetCacheKey($"getbyid_{id}");
    
            return await _cacheManager.GetAsync(cacheKey, 
                () => GetByIdAsync(id, includeDeleted, cancellationToken), 
                cacheTime ?? TimeSpan.FromMinutes(30));
        }

        public async Task<IList<T>> GetAllCachedAsync(TimeSpan? cacheTime = null) {
            try {
                 var cacheKey = GetAllCacheKey();
                return await _cacheManager.GetAsync(cacheKey, () => GetAllAsync(), cacheTime);
            } catch (Exception ex) {
                Logger.Log($"Get all cached Entitities operation failed: {ex.Message}", "DbAction");
                Logger.Log("STACKTRACE ::");
                Logger.Log($"{ex.StackTrace}", "DbStacktrace");
                return null;
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

                Logger?.Log($"Using approximate count for {typeof(T).Name}: {approximateCount}", "DbAction");
                return approximateCount;
            } catch (Exception ex) {
                Logger?.Log($"Approximate count failed for {typeof(T).Name}, falling back to exact count: {ex.Message}", "DbAction");
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

            await BulkUpdateAsync(entities, e => e.IsDeleted);
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
            {
                return node == _oldParameter ? _newParameter : base.VisitParameter(node);
            }
        }

        #endregion

        #region Protected Methods

        protected virtual void InvalidateCache() {
            _cacheManager.RemoveByPrefix(_entityName);
            Logger.Log($"Invalidated cache for entity: {_entityName}", "INFO");
        }

        protected virtual void InvalidateCache(long id) {
            var cacheKey = GetByIdCacheKey(id);
            _cacheManager.Remove(cacheKey);
            Logger.Log($"Invalidated cache for entity: {_entityName} with id: {id}","INFO");
        }

        protected static bool SupportsSoftDelete<TV>() where TV : BaseEntity
            => typeof(T).GetProperty("IsDeleted") != null;

        protected virtual string GetCacheKey(string suffix) => $"{_entityName}_{suffix}";
        protected virtual string GetByIdCacheKey(long id) => GetCacheKey($"id_{id}");
        protected virtual string GetAllCacheKey() => GetCacheKey("all");

        #endregion
    }

}
