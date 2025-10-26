using MfiManager.Middleware.Configurations.Providers;
using MfiManager.Middleware.Http.Requests;
using MfiManager.Middleware.Http.Responses;
using Microsoft.AspNetCore.Mvc;

namespace MfiManager.Middleware.Controllers {

    [ApiController]
    [Route("mfi/system")]
    public class MfiSystemController(
        ILogger<MfiSystemController> logger,
        IEnvironmentProvider environment)
        : MfiBaseController(logger, environment) {
        private readonly ILogger<MfiSystemController> _logger = logger;


         [HttpGet("welcome")]
        public IActionResult SystemWelcome() {
            return Ok("Support says 'Welcome to MFI-Middleware API'");
        }

         [HttpPost("errors/error")] 
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

        [HttpPost("users/users-all")]
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
