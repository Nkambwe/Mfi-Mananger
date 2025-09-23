using MfiManager.Middleware.Data.Entities;
using System.Linq.Expressions;

namespace MfiManager.Middleware.Data.Transaction.Repositories {

    public interface IRepository<T> where T : BaseEntity {
        /// <summary>
        /// DBContext HashCode
        /// </summary>
        /// <returns></returns>
        int GetContextHashCode();

        /// <summary>
        /// Find an entity that fits predicate. Check whether to returned deleted entities <see cref="ISoftDelete"/>
        /// </summary>
        /// <param name="where">Search Predicate</param>
        /// <param name="includeDeleted"></param>
        /// <returns>Single entity that fits predicate or returns default value</returns>
         T SingleOrDefault(Expression<Func<T, bool>> where, bool includeDeleted = false);

         /// <summary>
         /// Find an entity that fits predicate. Check whether to returned deleted entities <see cref="ISoftDelete"/>
         /// </summary>
         /// <param name="where">Search Predicate</param>
         /// <param name="includeDeleted"></param>
         /// <returns>Task containg a single entity that fits predicate or returns default value</returns>
         Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> where, bool includeDeleted = false);

        /// <summary>
        /// Get entity by Id. Check whether to returned deleted entities <see cref="ISoftDelete"/>
        /// </summary>
        /// <param name="id">Entity ID</param>
        /// <param name="includeDeleted">Flag to check whether to returned deleted entities</param>
        /// <returns>Entity with defined Id</returns>
        T Get(long id, bool includeDeleted = false);

        /// <summary>
        /// Get entity by Id. Check whether to returned deleted entities <see cref="ISoftDelete"/>
        /// </summary>
        /// <param name="id">Entity ID</param>
        /// <param name="includeDeleted">Flag to check whether to returned deleted entities</param>
        /// <returns>Task containing entity with defined Id</returns>
        Task<T> GetAsync(long id, bool includeDeleted = false);

        /// <summary>
        /// Get entity the fits predicate. Check whether to returned deleted entities <see cref="ISoftDelete"/>
        /// </summary>
        /// <param name="where">Search Predicate</param>
        /// <param name="includeDeleted">Flag to check whether to returned deleted entities</param>
        /// <returns>Entity that fits predicate</returns>
        T Get(Expression<Func<T, bool>> where, bool includeDeleted = false);

        /// <summary>
        /// Get entity the fits predicate. Check whether to returned deleted entities <see cref="ISoftDelete"/>
        /// </summary>
        /// <param name="where">Search Predicate</param>
        /// <param name="includeDeleted">Flag to check whether to returned deleted entities</param>
        /// <returns>Entity that fits predicate</returns>
        Task<T> GetAsync(Expression<Func<T, bool>> where, bool includeDeleted = false);

         /// <summary>
        /// Get entity the fits predicate. Check whether to returned deleted entities <see cref="ISoftDelete"/>
        /// </summary>
        /// <param name="where">Search Predicate</param>
        /// <param name="includeDeleted">Flag to check whether to returned deleted entities</param>
         /// <returns>Entity that fits predicate</returns>
        T Get(Expression<Func<T, bool>> where, bool includeDeleted = false, params Expression<Func<T, object>>[] includes);

        /// <summary>
        /// Asynchronous search for an entity that fits predicate with related entities. Option to check if it can be marked as deleted
        /// </summary>
        /// <param name="where">Search Predicate</param>
        /// <param name="includeDeleted">Flag to check whether to returned deleted entities</param>
        /// <param name="includes">Search includes</param>
        /// <remarks>Usage var entity = await GetAsync(e => e.Id == 1, includeDeleted: false, x => x.RelatedEntity, x => x.AnotherEntity);</remarks>
        /// <returns>Task with entity that fits predicate</returns>
        Task<T> GetAsync(Expression<Func<T, bool>> where, bool includeDeleted = false, params Expression<Func<T, object>>[] includes);
        
        /// <summary>
        /// Get a list of all entities. Option to check if entities can be marked as deleted
        /// </summary>
        /// <param name="includeDeleted">Flag whether to include deleted records in the search</param>
        /// <remarks>Usage var entities = GetAll(includeDeleted: false);</remarks>
        /// <returns>Collection of all entities</returns>
        IQueryable<T> GetAll(bool includeDeleted = false);

        /// <summary>
        /// Asynchronous search for a list of all entities. Option to check if entities can be marked as deleted 
        /// </summary>
        /// <param name="includeDeleted">Flag whether to include deleted records in the search</param>
        /// <remarks>Usage var entities = await GetAllAsync(includeDeleted: false);</remarks>
        /// <returns>Task containg a collection of all entities</returns>
        Task<IQueryable<T>> GetAllAsync(bool includeDeleted = false);

        /// <summary>
        /// Get a list of all entities that fit search predicate. Option to check if entities can be marked as deleted
        /// </summary>
        /// <param name="where">Search predicate</param>
        /// <param name="includeDeleted">Flag whether to include deleted records in the search</param>
        /// <returns>Collection of all entities that fit predicate</returns>
        IQueryable<T> GetAll(Expression<Func<T, bool>> where, bool includeDeleted);

        /// <summary>
        /// Asynchronous search for a list of all entities that fit search predicate. Option to check if entities can be marked as deleted
        /// </summary>
        /// <param name="where">Search predicate</param>
        /// <param name="includeDeleted">Flag whether to include deleted records in the search</param>
        /// <returns>Task containg a collection of all entities that fit predicate</returns>
        Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>> where, bool includeDeleted);

        /// <summary>
        /// Get queriable data set 
        /// </summary>
        /// <param name="includeDeleted"></param>
        /// <param name="includes"></param>
        /// <returns></returns>
        IQueryable<T> GetAll(bool includeDeleted = false, params Expression<Func<T, object>>[] includes);

        /// <summary>
        /// Asynchronous search for an entity that fits predicate with related entities. Option to check if it can be marked as deleted
        /// </summary>
        /// <param name="includes">Search includes</param>
        /// <remarks>Usage var entity = await GetAsync(e => e.Id == 1, includeDeleted: false, x => x.RelatedEntity, x => x.AnotherEntity);</remarks>
        /// <returns>Task with a list of entitities that fits predicate</returns>
        Task<IQueryable<T>> GetAllAsync(bool includeDeleted = false, params Expression<Func<T, object>>[] includes);

        /// <summary>
        /// Synchronous search for an entity that fits predicate with related entities. Option to check if it can be marked as deleted
        /// </summary>
        /// <param name="where">Search Predicate</param>
        /// <param name="includeDeleted">Flag to check whether to returned deleted entities</param>
        /// <param name="includes">Search includes</param>
        /// <remarks>Usage var entity = await GetAsync(e => e.Id == 1, includeDeleted: false, x => x.RelatedEntity, x => x.AnotherEntity);</remarks>
        /// <returns>Queryable list of entitities that fits predicate</returns>
        IQueryable<T> GetAll(Expression<Func<T, bool>> where, bool includeDeleted = false, params Expression<Func<T, object>>[] includes);

        /// <summary>
        /// Asynchronous search for an entity that fits predicate with related entities. Option to check if it can be marked as deleted
        /// </summary>
        /// <param name="where">Search Predicate</param>
        /// <param name="includeDeleted">Flag to check whether to returned deleted entities</param>
        /// <param name="includes">Search includes</param>
        /// <remarks>Usage var entity = await GetAsync(e => e.Id == 1, includeDeleted: false, x => x.RelatedEntity, x => x.AnotherEntity);</remarks>
        /// <returns>Task with a list of entitities that fits predicate</returns>
        Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>> where, bool includeDeleted = false, params Expression<Func<T, object>>[] includes);

        /// <summary>
        /// Get selected top count of a list of objects
        /// </summary>
        /// <param name="where">Search predicate</param>
        /// <param name="top">Top count to select</param>
        /// <param name="includeDeleted">Flag whether to include deleted records in the search</param>
        /// <returns>Task containg a collection of all entities that fit predicate</returns>
        IQueryable<T> GetTop(Expression<Func<T, bool>> where, int top, bool includeDeleted = false);

        /// <summary>
        /// Get selected top count of a list of objects
        /// </summary>
        /// <param name="where">Search predicate</param>
        /// <param name="top">Top count to select</param>
        /// <param name="includeDeleted">Flag whether to include deleted records in the search</param>
        /// <returns>Task containg a collection of all entities that fit predicate</returns>
        Task<IQueryable<T>> GetTopAsync(Expression<Func<T, bool>> where, int top, bool includeDeleted = false);

        /// <summary>
        /// Add new entity to the database
        /// </summary>
        /// <param name="entity">Entity to insert to the database</param>
        void Add(T entity);

        /// <summary>
        /// Add new entity to the database
        /// </summary>
        /// <param name="entity">Entity to insert to the database</param>
        Task AddAsync(T entity);

        /// <summary>
        /// Asynchronouse add new entity to the database
        /// </summary>
        /// <param name="entities">Entity to insert to the database</param>
        Task AddRangeAsync(IEnumerable<T> entities);

        /// <summary>
        /// Update entity
        /// </summary>
        /// <param name="entity">Entity to update</param>
        /// <param name="includeDeleted">Flag whether to include deleted records in the update</param>
        /// <returns>Result from the update</returns>
        void Update(T entity, bool includeDeleted = false);

        /// <summary>
        /// Remove of an entity
        /// </summary>
        /// <param name="entity">Entity to delete</param>
        /// <param name="markAsDeleted">Flag to soft delete an entity</param>
        void Remove(T entity, bool markAsDeleted = false);

        /// <summary>
        /// Asynchronous remove a list of entities
        /// </summary>
        /// <param name="entities">List of entities to delete</param>
        Task RemoveRangeAsync(IEnumerable<T> entities, bool markAsDeleted = false);

        /// <summary>
        /// Check if an entity exists if it fits predicate
        /// </summary>
        /// <param name="where">Search predicate</param>
        /// <param name="excludeDeleted">Flag to exclude deleted entities in the search</param>
        /// <returns>Search result for entity</returns>
        bool Exists(Expression<Func<T, bool>> where, bool excludeDeleted = false);

        /// <summary>
        /// Asynchronous check if an entity exists if it fits predicate
        /// </summary>
        /// <param name="where">Search predicate</param>
        /// <param name="excludeDeleted">Flag to exclude deleted entities in the search</param>
        /// <returns>Task containg search result for entity</returns>
        Task<bool> ExistsAsync(Expression<Func<T, bool>> where, bool excludeDeleted = false);
        
        /// <summary>
        /// Count number of entities in the database
        /// </summary>
        /// <returns>Number of entities found in the database</returns>
        Task<int> CountAsync();
        /// <summary>
        /// Asynchronous count number of entities in the database
        /// </summary>
        /// <returns>Task containing number of entities found in the database</returns>
        Task<int> CountAsync(Expression<Func<T, bool>> where);
        /// <summary>
        /// Bulk inserts to the database
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        Task<bool> BulkInsertAsync(IEnumerable<T> entities);

        /// <summary>
        /// Bulk updates to the database
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        Task<bool> BulkUpdateAsync(IEnumerable<T> entities);

        /// <summary>
        /// Update bulk entities for specific properties selected
        /// </summary>
        /// <param name="entities">Collection of entities to update</param>
        /// <param name="propertySelectors">List of properyies to update</param>
        /// <returns></returns>
        Task<bool> BulkUpdateAsync(IEnumerable<T> entities, params Expression<Func<T, object>>[] propertySelectors);

        /// <summary>
        /// Get cached entity by ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cacheTime"></param>
        /// <returns>Task containing cached entity</returns>
        Task<T> GetByIdCachedAsync(long id, TimeSpan? cacheTime = null);
        /// <summary>
        /// Get list of cached entitie
        /// </summary>
        /// <param name="cacheTime"></param>
        /// <returns>Task containing list of cached entitities</returns>
        Task<IQueryable<T>> GetAllCachedAsync(TimeSpan? cacheTime = null);
        /// <summary>
        /// Get list of cached entitie
        /// </summary>
        /// <param name="where">Search predicate</param>
        /// <param name="cacheKey">Cache key to search for</param>
        /// <param name="cacheTime"></param>
        /// <returns>Task containing list of cached entitities</returns>
        Task<IQueryable<T>> FindCachedAsync(Expression<Func<T, bool>> where, string cacheKey, TimeSpan? cacheTime = null);

        /// <summary>
        /// Pagenate records that fit predicate
        /// </summary>
        /// <param name="page">Page number</param>
        /// <param name="size">Page size</param>
        /// <param name="includeDeleted">Flag to include deleted entities in the search</param>
        /// <param name="where">Filter predicate</param>
        /// <returns></returns>
        Task<PagedResult<T>> PageAllAsync(int page, int size, bool includeDeleted, Expression<Func<T, bool>> where = null);

        /// <summary>
        /// Page all records seleceted
        /// </summary>
        /// <param name="page">Page number</param>
        /// <param name="size">Number of entities to take</param>
        /// <param name="includeDeleted">Flag to include deleted entities in the search</param>
        /// <param name="where">Search includes</param>
        /// <returns></returns>
        Task<PagedResult<T>> PageAllAsync(int page, int size, bool includeDeleted, params Expression<Func<T, object>>[] where);
        
        /// <summary>
        ///  Pagenate records that fit predicate
        /// </summary>
        /// <param name="token"></param>
        /// <param name="page">Page number</param>
        /// <param name="size">Page size</param>
        /// <param name="includeDeleted">Flag to include deleted entities in the search</param>
        /// <param name="where">Filter predicate</param>
        /// <returns></returns>
        Task<PagedResult<T>> PageAllAsync(int page, int size, bool includeDeleted = false, Expression<Func<T, bool>> where = null,CancellationToken token = default);

        /// <summary>
        /// Page all entities selected in a query
        /// </summary>
        /// <param name="token">Cancellation token</param>
        /// <param name="page">Page number</param>
        /// <param name="size">Number of entities to take</param>
        /// <param name="includeDeleted">Flag to include deleted entities in the search</param>
        /// <param name="includes">Search includes</param>
        /// <returns></returns>
        Task<PagedResult<T>> PageAllAsync(int page, int size, bool includeDeleted, CancellationToken token=default, params Expression<Func<T, object>>[] includes);

    }

}
