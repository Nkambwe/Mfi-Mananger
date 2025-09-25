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
        }

    }
}
