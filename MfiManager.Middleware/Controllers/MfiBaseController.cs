using Microsoft.AspNetCore.Mvc;

namespace MfiManager.Middleware.Controllers {
    [ApiController]
    [Route("mfi")]
    public class MfiBaseController : ControllerBase {
        public MfiBaseController() {
            // Basic usage
            //bool exists = await ExistsAsync(p => p.Name == "Product1");

            //// With soft delete exclusion
            //bool existsActive = await ExistsAsync(p => p.Name == "Product1", excludeDeleted: true);

            //// Cached version for frequently checked items
            //bool cachedExists = await ExistsCachedAsync(
            //    p => p.Category == "Electronics", 
            //    "electronics_category",
            //    excludeDeleted: true,
            //    TimeSpan.FromMinutes(10));

            //// Batch check multiple conditions
            //var batchPredicates = new Dictionary<string, Expression<Func<Product, bool>>>
            //{
            //    ["expensive"] = p => p.Price > 1000,
            //    ["cheap"] = p => p.Price < 100,
            //    ["electronics"] = p => p.Category == "Electronics"
            //};

            //var batchResults = await ExistsBatchAsync(batchPredicates);
            //bool exists = await ExistsAsync(p => p.Email == email);
            //bool exists = await ExistsCachedAsync(p => p.Category == "VIP", "vip_category");
            //var results = await ExistsBatchAsync(conditions);

            //int count = await CountAsync(p => p.IsActive);
            //long count = await LongCountAsync();

            // long count = await LongCountAsync();
            // Or for approximate (much faster)
            //long approxCount = await ApproximateCountAsync();
            //int cachedCount = await CountCachedAsync("active_users", TimeSpan.FromMinutes(5));

            //usage for pagenation
            //var results = await GetPagedAllAsync(predicate, pageNumber, pageSize);
            //var results = await GetPagedAllCursorAsync(predicate, cursorSelector, cursor, pageSize);
            //var results = await GetPagedAllCachedAsync(predicate, pageNumber, pageSize, cacheKey);
            //var results = await GetLargePagedAllAsync(predicate, selector, pageNumber, pageSize);

            // Usage Examples
            //public async Task PaginationExamples()
            //{
            //    // Basic pagination
            //    var pagedResults = await GetPagedAllAsync(
            //        p => p.IsActive, 
            //        pageNumber: 1, 
            //        pageSize: 20);

            //    // With ordering
            //    var orderedResults = await GetPagedAllAsync(
            //        p => p.IsActive,
            //        p => p.CreatedAt,
            //        pageNumber: 1,
            //        pageSize: 20,
            //        ascending: false);

            //    // With projections (more efficient for large entities)
            //    var largeResults = await GetLargePagedAllAsync(
            //        p => p.IsActive,
            //        p => new { p.Id, p.Name, p.Price },
            //        pageNumber: 1,
            //        pageSize: 20);

            //    // Cached pagination
            //    var cachedResults = await GetPagedAllCachedAsync(
            //        p => p.Category == "Electronics",
            //        pageNumber: 1,
            //        pageSize: 20,
            //        "electronics_page",
            //        cacheTime: TimeSpan.FromMinutes(5));

            //    // Cursor-based pagination (better for large datasets)
            //    var cursorResults = await GetPagedAllCursorAsync(
            //        p => p.IsActive,
            //        p => p.Id,
            //        cursor: 1000, // Start after ID 1000
            //        pageSize: 20);

            //    // Process results
            //    Console.WriteLine($"Total: {pagedResults.TotalCount}, Page: {pagedResults.PageNumber}/{pagedResults.TotalPages}");
            //    foreach (var item in pagedResults.Items)
            //    {
            //        Console.WriteLine($"Item: {item}");
            //    }
            //}

            // Update all electronics to inactive
            //await repository.BulkUpdateWhereAsync(p => p.Category == "Electronics",p => p.IsActive,false);
            //batch update with progress
            //var progress = new Progress<BulkOperationProgress>(p => Console.WriteLine($"Progress: {p.PercentComplete:F1}%"));
            //await repository.BulkInsertBatchedAsync(entities, progress: progress);
            //update with specific property
            //await repository.BulkUpdateAsync(entities, new[] { p => p.Price, p => p.ModifiedDate });

            // AddRangeAsync() with SaveChangesAsync() //small datasets about 1K record
            // BulkInsertAsync() //use for batch large inserts
            // BulkInsertAsync() //use for meduim size about 10K records
            // ExecuteUpdateAsync() Conditional updates
            // BulkUpdateAsync() Load complex transformations
        }
    }
}
