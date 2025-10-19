using MfiManager.Middleware.Configurations.Providers;
using MfiManager.Middleware.Http.Requests;
using MfiManager.Middleware.Http.Responses;
using Microsoft.AspNetCore.Mvc;

namespace MfiManager.Middleware.Controllers {
    [ApiController]
    [Route("mfi")]
    public class MfiBaseController : ControllerBase {

            protected readonly ILogger<MfiBaseController> Logger;
            protected readonly IEnvironmentProvider Environment;

            public MfiBaseController(ILogger<MfiBaseController> logger, IEnvironmentProvider environment) {
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
        
            [HttpPost("errors/error-list")] 
            public async Task<IActionResult> GetError([FromBody] HttpIdRequest request) {
                return Ok(request);
            }

            [HttpPost("errors/error-list")] 
            public async Task<IActionResult> GetErrorList([FromBody] HttpListRequest request) {
                 //var results = await GetPagedAllAsync(predicate, pageNumber, pageSize);
                return Ok(request);
            }

            [HttpPost("errors/saveerror")] 
            public async Task<IActionResult> SaveError([FromBody] AppErrorRequest request) {
                return Ok(request);
            }

            [HttpPost("install/register")]
            public async Task<IActionResult> Install([FromBody] InstallRequest request) {
                 return Ok(request);
            }

            public async Task<IActionResult> GetPagedUsers([FromBody] HttpListRequest request) {
                    var users = new List<UserResponse>
                    {
                        new() {
                            Id = 1,
                            FirstName = "Wendi",
                            LastName = "Mukasa",
                            MiddleName = "Allan",
                            UserName = "wmukasa",
                            EmailAddress = "wendi.mukasa@example.com",
                            DisplayName = "Wendi A. Mukasa",
                            PhoneNumber = "+256700000001",
                            PFNumber = "PF001",
                            RoleId = 1,
                            RoleName = "Administrator",
                            RoleGroup = "System Admins",
                            DepartmentId = 10,
                            IsActive = true,
                            IsVerified = true,
                            IsLogged = false,
                            CreatedOn = DateTime.Now.AddDays(-30),
                            CreatedBy = "system",
                            ModifiedOn = DateTime.Now,
                            ModifiedBy = "system"
                        },
                        new() {
                            Id = 2,
                            FirstName = "Sarah",
                            LastName = "Nabunya",
                            MiddleName = "Hope",
                            UserName = "snabunya",
                            EmailAddress = "sarah.nabunya@example.com",
                            DisplayName = "Sarah H. Nabunya",
                            PhoneNumber = "+256700000002",
                            PFNumber = "PF002",
                            RoleId = 2,
                            RoleName = "Manager",
                            RoleGroup = "Operations",
                            DepartmentId = 20,
                            IsActive = true,
                            IsVerified = true,
                            IsLogged = false,
                            CreatedOn = DateTime.Now.AddDays(-25),
                            CreatedBy = "system",
                            ModifiedOn = DateTime.Now,
                            ModifiedBy = "system"
                        },
                        new() {
                            Id = 3,
                            FirstName = "John",
                            LastName = "Kato",
                            MiddleName = "Michael",
                            UserName = "jkato",
                            EmailAddress = "john.kato@example.com",
                            DisplayName = "John M. Kato",
                            PhoneNumber = "+256700000003",
                            PFNumber = "PF003",
                            RoleId = 3,
                            RoleName = "Auditor",
                            RoleGroup = "Compliance",
                            DepartmentId = 30,
                            IsActive = true,
                            IsVerified = false,
                            IsLogged = false,
                            CreatedOn = DateTime.Now.AddDays(-20),
                            CreatedBy = "admin",
                            ModifiedOn = DateTime.Now,
                            ModifiedBy = "admin"
                        },
                        new()
                        {
                            Id = 4,
                            FirstName = "Paul",
                            LastName = "Okello",
                            MiddleName = "James",
                            UserName = "pokello",
                            EmailAddress = "paul.okello@example.com",
                            DisplayName = "Paul J. Okello",
                            PhoneNumber = "+256700000004",
                            PFNumber = "PF004",
                            RoleId = 2,
                            RoleName = "Manager",
                            RoleGroup = "Finance",
                            DepartmentId = 40,
                            IsActive = true,
                            IsVerified = true,
                            IsLogged = false,
                            CreatedOn = DateTime.Now.AddDays(-15),
                            CreatedBy = "system",
                            ModifiedOn = DateTime.Now,
                            ModifiedBy = "system"
                        },
                        new()
                        {
                            Id = 5,
                            FirstName = "Grace",
                            LastName = "Nambi",
                            MiddleName = "Lydia",
                            UserName = "gnambi",
                            EmailAddress = "grace.nambi@example.com",
                            DisplayName = "Grace L. Nambi",
                            PhoneNumber = "+256700000005",
                            PFNumber = "PF005",
                            RoleId = 4,
                            RoleName = "Analyst",
                            RoleGroup = "Finance",
                            DepartmentId = 40,
                            IsActive = true,
                            IsVerified = true,
                            IsLogged = false,
                            CreatedOn = DateTime.Now.AddDays(-10),
                            CreatedBy = "system",
                            ModifiedOn = DateTime.Now,
                            ModifiedBy = "system"
                        },
                        new()
                        {
                            Id = 6,
                            FirstName = "Peter",
                            LastName = "Mugisha",
                            MiddleName = "David",
                            UserName = "pmugisha",
                            EmailAddress = "peter.mugisha@example.com",
                            DisplayName = "Peter D. Mugisha",
                            PhoneNumber = "+256700000006",
                            PFNumber = "PF006",
                            RoleId = 3,
                            RoleName = "Auditor",
                            RoleGroup = "Compliance",
                            DepartmentId = 30,
                            IsActive = false,
                            IsVerified = true,
                            IsLogged = false,
                            CreatedOn = DateTime.Now.AddDays(-12),
                            CreatedBy = "admin",
                            ModifiedOn = DateTime.Now,
                            ModifiedBy = "admin"
                        },
                        new()
                        {
                            Id = 7,
                            FirstName = "Mary",
                            LastName = "Namugerwa",
                            MiddleName = "Agnes",
                            UserName = "mnamugerwa",
                            EmailAddress = "mary.namugerwa@example.com",
                            DisplayName = "Mary A. Namugerwa",
                            PhoneNumber = "+256700000007",
                            PFNumber = "PF007",
                            RoleId = 5,
                            RoleName = "Clerk",
                            RoleGroup = "Operations",
                            DepartmentId = 20,
                            IsActive = true,
                            IsVerified = true,
                            IsLogged = false,
                            CreatedOn = DateTime.Now.AddDays(-8),
                            CreatedBy = "system",
                            ModifiedOn = DateTime.Now,
                            ModifiedBy = "system"
                        },
                        new()
                        {
                            Id = 8,
                            FirstName = "David",
                            LastName = "Muwonge",
                            MiddleName = "Isaac",
                            UserName = "dmuwonge",
                            EmailAddress = "david.muwonge@example.com",
                            DisplayName = "David I. Muwonge",
                            PhoneNumber = "+256700000008",
                            PFNumber = "PF008",
                            RoleId = 2,
                            RoleName = "Manager",
                            RoleGroup = "HR",
                            DepartmentId = 50,
                            IsActive = true,
                            IsVerified = false,
                            IsLogged = false,
                            CreatedOn = DateTime.Now.AddDays(-5),
                            CreatedBy = "admin",
                            ModifiedOn = DateTime.Now,
                            ModifiedBy = "admin"
                        },
                        new()
                        {
                            Id = 9,
                            FirstName = "Agnes",
                            LastName = "Nakato",
                            MiddleName = "Joyce",
                            UserName = "anakato",
                            EmailAddress = "agnes.nakato@example.com",
                            DisplayName = "Agnes J. Nakato",
                            PhoneNumber = "+256700000009",
                            PFNumber = "PF009",
                            RoleId = 4,
                            RoleName = "Analyst",
                            RoleGroup = "Finance",
                            DepartmentId = 40,
                            IsActive = true,
                            IsVerified = true,
                            IsLogged = false,
                            CreatedOn = DateTime.Now.AddDays(-3),
                            CreatedBy = "system",
                            ModifiedOn = DateTime.Now,
                            ModifiedBy = "system"
                        },
                        new()
                        {
                            Id = 10,
                            FirstName = "Robert",
                            LastName = "Lule",
                            MiddleName = "Brian",
                            UserName = "rlule",
                            EmailAddress = "robert.lule@example.com",
                            DisplayName = "Robert B. Lule",
                            PhoneNumber = "+256700000010",
                            PFNumber = "PF010",
                            RoleId = 6,
                            RoleName = "Supervisor",
                            RoleGroup = "Operations",
                            DepartmentId = 20,
                            IsActive = true,
                            IsVerified = true,
                            IsLogged = true,
                            CreatedOn = DateTime.Now.AddDays(-1),
                            CreatedBy = "system",
                            ModifiedOn = DateTime.Now,
                            ModifiedBy = "system"
                        }
                    };

            return Ok( new HttpResponse<HttpListResponse<UserResponse>> {
                Data = new HttpListResponse<UserResponse>() {
                    Size = 10,
                    Page = 1,
                    TotalEntities = 10,
                    TotalPages = 1,
                    Entities = users
                }
            });

        }

    }
}
