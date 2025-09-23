using MfiManager.Middleware.Configuration;
using MfiManager.Middleware.Data.Entities;
using MfiManager.Middleware.Factories;
using MfiManager.Middleware.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Linq.Expressions;
using System.Reflection;

namespace MfiManager.Middleware.Data.Transaction.Repositories {

   public class Repository<T> : IRepository<T> where T : BaseEntity {

        #region Private Fields
        private readonly string _entityName = typeof(T).Name.ToLower();
        private static PropertyInfo _cachedIsDeletedProperty;
        private static PropertyInfo _cachedIdProperty;
        private static readonly object _lockObject = new();
        #endregion

        protected readonly IServiceLogger Logger;
        protected readonly IStaticCacheManager _cacheManager;
        protected readonly DbSet<T> _dbSet;
        protected readonly MfiManagerDbContext _dbContext; 

        public Repository(IServiceLoggerFactory loggerFactory, IStaticCacheManager cacheManager, MfiManagerDbContext dbContext) {
            Logger = loggerFactory.CreateLogger();
            Logger.Channel = $"REPO-{DateTime.Now:yyyyMMddHHmmss}";
            _cacheManager = cacheManager;
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
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

        public Task<bool> BulkInsertAsync(IEnumerable<T> entities) {
            throw new NotImplementedException();
        }

        public Task<bool> BulkUpdateAsync(IEnumerable<T> entities) {
            throw new NotImplementedException();
        }

        public Task<bool> BulkUpdateAsync(IEnumerable<T> entities, params Expression<Func<T, object>>[] propertySelectors) {
            throw new NotImplementedException();
        }

        public Task<int> CountAsync() {
            throw new NotImplementedException();
        }

        public Task<int> CountAsync(Expression<Func<T, bool>> where) {
            throw new NotImplementedException();
        }

        public bool Exists(Expression<Func<T, bool>> where, bool excludeDeleted = false) {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsAsync(Expression<Func<T, bool>> where, bool excludeDeleted = false) {
            throw new NotImplementedException();
        }

        public T Get(Expression<Func<T, bool>> where, bool includeDeleted = false) {
            throw new NotImplementedException();
        }

        public T Get(Expression<Func<T, bool>> where, bool includeDeleted = false, params Expression<Func<T, object>>[] includes) {
            throw new NotImplementedException();
        }

        public IQueryable<T> GetAll(bool includeDeleted = false) {
            throw new NotImplementedException();
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> where, bool includeDeleted) {
            throw new NotImplementedException();
        }

        public IQueryable<T> GetAll(bool includeDeleted = false, params Expression<Func<T, object>>[] includes) {
            throw new NotImplementedException();
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> where, bool includeDeleted = false, params Expression<Func<T, object>>[] includes) {
            throw new NotImplementedException();
        }

        public Task<IQueryable<T>> GetAllAsync(bool includeDeleted = false) {
            throw new NotImplementedException();
        }

        public Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>> where, bool includeDeleted) {
            throw new NotImplementedException();
        }

        public Task<IQueryable<T>> GetAllAsync(bool includeDeleted = false, params Expression<Func<T, object>>[] includes) {
            throw new NotImplementedException();
        }

        public Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>> where, bool includeDeleted = false, params Expression<Func<T, object>>[] includes) {
            throw new NotImplementedException();
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

        public Task<T> GetAsync(Expression<Func<T, bool>> where, bool includeDeleted = false) {
            throw new NotImplementedException();
        }

        public Task<T> GetAsync(Expression<Func<T, bool>> where, bool includeDeleted = false, params Expression<Func<T, object>>[] includes) {
            throw new NotImplementedException();
        }

        public IQueryable<T> GetTop(Expression<Func<T, bool>> where, int top, bool includeDeleted = false) {
            throw new NotImplementedException();
        }

        public Task<IQueryable<T>> GetTopAsync(Expression<Func<T, bool>> where, int top, bool includeDeleted = false) {
            throw new NotImplementedException();
        }

        public Task<PagedResult<T>> PageAllAsync(int page, int size, bool includeDeleted, Expression<Func<T, bool>> where = null) {
            throw new NotImplementedException();
        }

        public Task<PagedResult<T>> PageAllAsync(int page, int size, bool includeDeleted, params Expression<Func<T, object>>[] where) {
            throw new NotImplementedException();
        }

        public Task<PagedResult<T>> PageAllAsync(int page, int size, bool includeDeleted = false, Expression<Func<T, bool>> where = null, CancellationToken token = default) {
            throw new NotImplementedException();
        }

        public Task<PagedResult<T>> PageAllAsync(int page, int size, bool includeDeleted, CancellationToken token = default, params Expression<Func<T, object>>[] includes) {
            throw new NotImplementedException();
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

        public T SingleOrDefault(Expression<Func<T, bool>> where, bool includeDeleted = false) {
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

        public async Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> where, bool includeDeleted = false) {
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
        
        public int GetContextHashCode() {
            throw new NotImplementedException();
        }

        #region Cached Data
        
        public async Task<IQueryable<T>> FindCachedAsync(Expression<Func<T, bool>> where, string cacheKey, TimeSpan? cacheTime = null) {
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

        public async Task<IQueryable<T>> GetAllCachedAsync(TimeSpan? cacheTime = null) {
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

        #endregion

        #region private Methods

        /// <summary>
        /// Extract class property name form class property
        /// </summary>
        /// <param name="where">Filter Predicate</param>
        /// <returns>Property name</returns>
        private static string GetPropertyName(Expression<Func<T, object>> where) {
            if (where.Body is MemberExpression exMember) {
                return exMember.Member.Name;
            } else if (where.Body is UnaryExpression unary) {
                //..for handling nullable properties
                if (unary.Operand is MemberExpression operand) {
                    return operand.Member.Name;
                }
            }

            return null;
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
