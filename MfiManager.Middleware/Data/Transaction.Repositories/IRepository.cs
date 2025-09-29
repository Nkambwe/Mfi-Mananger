using MfiManager.Middleware.Configuration.Options;
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
        T GetSingleOrDefault(Expression<Func<T, bool>> where, bool includeDeleted = false);

        /// <summary>
        /// Find an entity that fits predicate. Check whether to returned deleted entities <see cref="ISoftDelete"/>
        /// </summary>
        /// <param name="where">Search Predicate</param>
        /// <param name="includeDeleted"></param>
        /// <returns>Task containg a single entity that fits predicate or returns default value</returns>
        Task<T> GetSingleOrDefaultAsync(Expression<Func<T, bool>> where, bool includeDeleted = false);
        /// <summary>
        /// Find an entity that fits predicate. Check whether to returned deleted entities <see cref="ISoftDelete"/>
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="includeDeleted"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="includes"></param>
        /// <returns></returns>
        Task<T> GetSingleOrDefaultAsync(Expression<Func<T, bool>> predicate, bool includeDeleted = false, CancellationToken cancellationToken = default, params Expression<Func<T, object>>[] includes);

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
        Task<IList<T>> GetAllAsync(bool includeDeleted = false, CancellationToken cancellationToken = default);

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
        Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> where, bool includeDeleted, CancellationToken cancellationToken = default);

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
        Task<IList<T>> GetAllAsync(bool includeDeleted = false, params Expression<Func<T, object>>[] includes);

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
        Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> where, bool includeDeleted = false, params Expression<Func<T, object>>[] includes);

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
        Task<IList<T>> GetTopAsync(Expression<Func<T, bool>> where, int top, bool includeDeleted = false);
        /// <summary>
        /// Get entity with ID. Check whether to returned deleted entities <see cref="ISoftDelete"/>
        /// </summary>
        /// <param name="id"></param>
        /// <param name="includeDeleted"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="includes"></param>
        /// <returns></returns>
        Task<T> GetByIdAsync(long id, bool includeDeleted = false, CancellationToken cancellationToken = default, params Expression<Func<T, object>>[] includes);

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
        Task<bool> ExistsAsync(Expression<Func<T, bool>> where, bool excludeDeleted = false, CancellationToken token = default);
        /// <summary>
        /// Check exists for constantly checked values
        /// </summary>
        /// <param name="id"></param>
        /// <param name="excludeDeleted"></param>
        /// <param name="cacheTime"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<bool> ExistsByIdCachedAsync(long id, bool excludeDeleted = true, TimeSpan? cacheTime = null, CancellationToken cancellationToken = default);
        /// <summary>
        /// Check exists for constantly checked values
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="cacheKey"></param>
        /// <param name="excludeDeleted"></param>
        /// <param name="cacheTime"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<bool> ExistsCachedAsync(Expression<Func<T, bool>> predicate, string cacheKey, bool excludeDeleted = true, TimeSpan? cacheTime = null, CancellationToken cancellationToken = default);
        /// <summary>
        /// Check for batch existence for multiple conditions
        /// </summary>
        /// <param name="predicates"></param>
        /// <param name="excludeDeleted"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<Dictionary<string, bool>> ExistsBatchAsync(Dictionary<string, Expression<Func<T, bool>>> predicates, bool excludeDeleted = true, CancellationToken cancellationToken = default);
        /// <summary>
        /// Count number of entities in the database
        /// </summary>
        /// <returns>Number of entities found in the database</returns>
        int Count();
        /// <summary>
        /// Count number of entities in the database
        /// </summary>
        /// <param name="predicate">Count filter</param>
        /// <returns>Number of entities found in the database</returns>
        int Count(Expression<Func<T, bool>> predicate);
        /// <summary>
        /// Count number of entities in the database
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns>Task containg number of entities found in the database</returns>
        Task<int> CountAsync(CancellationToken cancellationToken = default);
        
        /// <summary>
        /// Asynchronous count number of entities in the database
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>Task containg number of entities found in the database</returns>
        Task<int> CountAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);

        /// <summary>
        /// Asynchronous count number of entities in the database
        /// </summary>
        /// <param name="excludeDeleted">Exclude deleted entities</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Task containg number of entities found in the database</returns>
        Task<int> CountAsync(bool excludeDeleted = true, CancellationToken cancellationToken = default);
        
        /// <summary>
        /// Asynchronous count number of entities in the database
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="excludeDeleted">Exclude deleted entities</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Task containg number of entities found in the database</returns>
        Task<int> CountAsync(Expression<Func<T, bool>> predicate, bool excludeDeleted = true, CancellationToken cancellationToken = default) ;
        /// <summary>
        /// Count large data sets
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<long> LongCountAsync(CancellationToken cancellationToken = default);
        /// <summary>
        /// Cont large data sets
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="excludeDeleted"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<long> LongCountAsync(Expression<Func<T, bool>> predicate, bool excludeDeleted = true, CancellationToken cancellationToken = default);
        /// <summary>
        /// High-performance bulk insert with validation and error handling
        /// </summary>
        /// <param name="entities">List of entities</param>
        /// <param name="options">Bulk options</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<BulkOperationResult<T>> BulkInsertAsync(IEnumerable<T> entities, BulkInsertOptions options = null, CancellationToken cancellationToken = default);
        /// <summary>
        ///  Bulk insert with automatic batching for very large datasets
        /// </summary>
        /// <param name="entities">List of entities</param>
        /// <param name="batchSize">Batch size limit</param>
        /// <param name="options">Bulk options</param>
        /// <param name="progress"></param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<BulkOperationResult<T>> BulkInsertBatchedAsync(IEnumerable<T> entities, int batchSize = 10000, BulkInsertOptions? options = null, IProgress<BulkOperationProgress> progress = null,CancellationToken cancellationToken = default);
        /// <summary>
        /// Optimized bulk update with property selection support
        /// </summary>
        /// <param name="entities">List of entities</param>
        /// <param name="options">Bulk options</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<BulkOperationResult<T>> BulkUpdateAsync(IEnumerable<T> entities, BulkUpdateOptions<T> options = null, CancellationToken cancellationToken = default);
        /// <summary>
        ///  Bulk update specific properties only
        /// </summary>
        /// <param name="entities">List of entities</param>
        /// <param name="propertySelectors">Property selector</param>
        /// <param name="options">Bulk options</param>
        /// <param name="cancellationToken">Cancellation options</param>
        /// <returns></returns>
        Task<BulkOperationResult<T>> BulkUpdateAsync( IEnumerable<T> entities, Expression<Func<T, object>>[] propertySelectors, BulkUpdateOptions<T> options = null,  CancellationToken cancellationToken = default);
        /// <summary>
        /// Conditional bulk update using EF Core's ExecuteUpdateAsync
        /// </summary>
        Task<BulkOperationResult<T>> BulkUpdateAsync<TProperty>( Expression<Func<T, bool>> whereExpression, Func<T, TProperty> propertySelector, TProperty newValue, bool excludeDeleted = true, CancellationToken cancellationToken = default);
        /// <summary>
        /// Bulk insert or update operation
        /// </summary>
        Task<BulkOperationResult<T>> BulkUpdateOrInsertAsync( IEnumerable<T> entities, Expression<Func<T, object>>[] matchOn = null, CancellationToken cancellationToken = default); 
        /// <summary>
        /// Conditional bulk delete using EF Core's ExecuteDeleteAsync (EF Core 7+)
        /// </summary>
        Task<BulkOperationResult<T>> BulkDeleteWhereAsync(Expression<Func<T, bool>> whereExpression, bool softDelete = true, bool excludeDeleted = true, CancellationToken cancellationToken = default);
        /// <summary>
        /// Bulk delete with soft delete support
        /// </summary>
        Task<BulkOperationResult<T>> BulkDeleteAsync(IEnumerable<T> entities, bool softDelete = true, CancellationToken cancellationToken = default);
        /// <summary>
        /// Get cached entity by ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cacheTime"></param>
        /// <returns>Task containing cached entity</returns>
        Task<T> GetByIdCachedAsync(long id, TimeSpan? cacheTime = null);
        /// <summary>
        /// Get cached entity by ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="includeDeleted"></param>
        /// <param name="cacheTime"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<T> GetByIdCachedAsync( long id, bool includeDeleted = false, TimeSpan? cacheTime = null, CancellationToken cancellationToken = default);
        /// <summary>
        /// Get list of cached entitie
        /// </summary>
        /// <param name="cacheTime"></param>
        /// <returns>Task containing list of cached entitities</returns>
        Task<IList<T>> GetAllCachedAsync(TimeSpan? cacheTime = null);
        /// <summary>
        /// Get list of cached entitie
        /// </summary>
        /// <param name="where">Search predicate</param>
        /// <param name="cacheKey">Cache key to search for</param>
        /// <param name="cacheTime"></param>
        /// <returns>Task containing list of cached entitities</returns>
        Task<IList<T>> FindCachedAsync(Expression<Func<T, bool>> where, string cacheKey, TimeSpan? cacheTime = null);
        /// <summary>
        /// Get all cached entities
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="cacheKey"></param>
        /// <param name="includeDeleted"></param>
        /// <param name="cacheTime"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>Task containing list of cached entitities</returns>
        Task<IList<T>> GetAllCachedAsync( Expression<Func<T, bool>> predicate, string cacheKey, bool includeDeleted = false, TimeSpan? cacheTime = null, CancellationToken cancellationToken = default);
        
        /// <summary>
        /// Get all cached entities
        /// </summary>
        /// <param name="cacheKey"></param>
        /// <param name="includeDeleted"></param>
        /// <param name="cacheTime"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>Task containing list of cached entitities</returns>
        Task<IList<T>> GetAllCachedAsync(string cacheKey, bool includeDeleted = false, TimeSpan? cacheTime = null, CancellationToken cancellationToken = default);
        
        /// <summary>
        /// Get a list of pagenated records
        /// </summary>
        /// <param name="pageNumber">Page number</param>
        /// <param name="pageSize">Pafe size</param>
        /// <param name="includeDeleted">Flag whether to include deleted entities</param>
        /// /// <param name="cancellationToken">Async cancellation token</param>
        /// <returns>Task containing pagenated records</returns>
        Task<PagedResult<T>> GetAllPagedAsync( int pageNumber = 1, int pageSize = 10, bool includeDeleted = false, CancellationToken cancellationToken = default);
        
        /// <summary>
        /// Pagenate records that fit predicate
        /// </summary>
        /// <param name="pageNumber">Page number</param>
        /// <param name="pageSize">Pafe size</param>
        /// <param name="includeDeleted">Flag whether to include deleted entities</param>
        /// <param name="predicate">Filter predicate</param>
        /// <param name="cancellationToken">Async cancellation token</param>
        /// <returns>Task containing list of cached entitities</returns>
        Task<PagedResult<T>> GetPagedAllAsync(Expression<Func<T, bool>> predicate, int pageNumber, int pageSize, bool includeDeleted, CancellationToken cancellationToken = default);
        
        /// <summary>
        /// Page all records seleceted
        /// </summary>
        /// <param name="predicate">Search includes</param>
        /// <param name="pageNumber">Page number</param>
        /// <param name="pageSize">Number of entities to take</param>
        /// <param name="includeDeleted">Flag to include deleted entities in the search</param>
        /// <param name="cancellationToken">Async cancellation token</param>
        /// <param name="includes">Filter includes</param>
        /// <returns>Task containing list of cached entitities</returns>
        Task<PagedResult<T>> GetPagedAllAsync(Expression<Func<T, bool>> predicate, int pageNumber, int pageSize, bool includeDeleted, CancellationToken cancellationToken = default, params Expression<Func<T, object>>[] includes);

        /// <summary>
        /// Pagenate selected records with order by
        /// </summary>
        /// <typeparam name="TKey">Group by key</typeparam>
        /// <param name="predicate">Search includes</param>
        /// <param name="pageNumber">Page number</param>
        /// <param name="pageSize">Number of entities to take</param>
        /// <param name="ascending">Order ascending</param>
        /// <param name="includeDeleted">Flag to include deleted entities in the search</param>
        /// <param name="cancellationToken">Async cancellation token</param>
        /// <param name="includes">Filter includes</param>
        /// <returns>Task containing list of entitities</returns>
        Task<PagedResult<T>> GetPagedAllAsync<TKey>( Expression<Func<T, bool>> predicate, Expression<Func<T, TKey>> orderBy, int pageNumber, int pageSize, bool ascending = true, bool includeDeleted = false, CancellationToken cancellationToken = default, params Expression<Func<T, object>>[] includes);
    
        /// <summary>
        ///  Pagenate selected records. Optimized version for large datasets using offset/fetch instead of Skip/Take
        /// </summary>
        /// <param name="predicate">Search includes</param>
        /// <param name="pageNumber">Page number</param>
        /// <param name="pageSize">Number of entities to take</param>
        /// <param name="includeDeleted">Flag to include deleted entities in the search</param>
        /// <param name="cancellationToken">Async cancellation token</param>
        /// <returns>Task containing list of entitities</returns>
        Task<PagedResult<T>> GetPagedAllCachedAsync(Expression<Func<T, bool>> predicate, int pageNumber, int pageSize, string cacheKey, bool includeDeleted = false, TimeSpan? cacheTime = null, CancellationToken cancellationToken = default, params Expression<Func<T, object>>[] includes);
        
        /// <summary>
        ///  Pagenate selected records with selectors
        /// </summary>
        /// <typeparam name="TResult">Selector type</typeparam>
        /// <param name="predicate">Search includes</param>
        /// <param name="pageNumber">Page number</param>
        /// <param name="pageSize">Number of entities to take</param>
        /// <param name="includeDeleted">Flag to include deleted entities in the search</param>
        /// <param name="cancellationToken">Async cancellation token</param>
        /// <returns>Task containing list of entitities</returns>
        Task<PagedResult<TResult>> GetLargePagedAllAsync<TResult>(Expression<Func<T, bool>> predicate, Expression<Func<T, TResult>> selector, int pageNumber, int pageSize, bool includeDeleted = false, CancellationToken cancellationToken = default);
   
        /// <summary>
        /// Pagenate records 
        /// </summary>
        /// <param name="predicate">Search includes</param>
        /// <param name="pageNumber">Page number</param>
        /// <param name="pageSize">Number of entities to take</param>
        /// <param name="ascending">Order ascending</param>
        /// <param name="includeDeleted">Flag to include deleted entities in the search</param>
        /// <param name="cancellationToken">Async cancellation token</param>
        /// <returns>Task containing list of entitities</returns>
        Task<PagedResult<T>> GetLargePagedAllAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> orderBy,int pageNumber, int pageSize, bool ascending = true, bool includeDeleted = false, CancellationToken cancellationToken = default);
    
        /// <summary>
        /// Pagenate records using Cursor-based pagination for better performance on large datasets
        /// </summary>
        /// <param name="predicate">Search includes</param>
        /// <param name="cursorSelector">Cursor Selector</param>
        /// <param name="pageSize">Number of entities to take</param>
        /// <param name="ascending">Order ascending</param>
        /// <param name="includeDeleted">Flag to include deleted entities in the search</param>
        /// <param name="cancellationToken">Async cancellation token</param>
        /// <returns>Task containing list of entitities</returns>
        Task<CursorPagedResult<T, TCursor>> GetPagedAllCursorAsync<TCursor>(Expression<Func<T, bool>> predicate, Expression<Func<T, TCursor>> cursorSelector, TCursor cursor = default, int pageSize = 10, bool ascending = true, bool includeDeleted = false, CancellationToken cancellationToken = default) where TCursor : IComparable<TCursor>;
    }

}
