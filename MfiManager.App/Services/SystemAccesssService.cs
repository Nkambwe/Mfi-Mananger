using MfiManager.App.Factories;
using MfiManager.App.Http;
using MfiManager.App.Infrastructure.Settings;
using MfiManager.App.Infrastructure.Utils;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using MfiManager.App.Http.Responses;
using System.Diagnostics;
using MfiManager.App.Http.Requests;
using System.Text.Json;
using MfiManager.App.Enums;

namespace MfiManager.App.Services {

    public class SystemAccesssService(
        ILogger<SystemAccesssService> logger, 
        IHttpHandler<SystemAccesssService> httpHandler, 
        IEnvironmentProvider environment, 
        IEndpointProvider endpointType, 
        IMfiErrorService errorService, 
        IMfiErrorFactory errorFactory, 
        IHttpContextAccessor httpContextAccessor,           
        IWebHelper webHelper, SessionManager sessionManager) :
        ApplicationBaseService<SystemAccesssService>(logger, httpHandler, environment, 
            endpointType, errorService, errorFactory, webHelper, sessionManager), 
        ISystemAccesssService {

        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

        public async Task<MfiHttpResponse<UserResponse>> AuthenticateAsync(MfiLoginRequest request, string ipAddress) {

            if(request == null) {
                var error = new MfiHttpErrorResponse(
                    401,
                    "Request record cannot be empty",
                    "Invalid user request"
                );
                Logger.LogError("BAD REQUEST: {Error}", JsonSerializer.Serialize(error));
                return new MfiHttpResponse<UserResponse>(error);
            }

            try {
                var endpoint = $"{EndpointProvider.Sam.Users}/auth";
                return await HttpHandler.PostAsync<MfiLoginRequest, UserResponse>(endpoint, request);
            } catch (Exception ex) {
                Logger.LogError("Authentication failed: {Message}", ex.Message);
                await ProcessErrorAsync(ex.Message,"SYSTEM-ACCESS-SERVICE" , ex.StackTrace);
                throw new Exception("Uanble to authenticate user.", ex);
            }
        }
        
        public async Task<MfiHttpResponse<UserResponse>> GetCurrentUserAsync(string ipAddress) {
             Logger.LogInformation("Referencing current logged-in user record");
            try {
                var httpContext = _httpContextAccessor.HttpContext;
                if (httpContext?.User?.Identity?.IsAuthenticated != true) {
                    var error = new MfiHttpErrorResponse(
                        401,
                        "User not authenticated",
                        "No authenticated user found"
                    );
                    return new MfiHttpResponse<UserResponse>(error);
                }

                var userId = httpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                var username = httpContext.User.FindFirst(ClaimTypes.Name)?.Value;
                var email = httpContext.User.FindFirst(ClaimTypes.Email)?.Value;
                var displayName = httpContext.User.FindFirst("DisplayName")?.Value;
                var firstName = httpContext.User.FindFirst("FirstName")?.Value;
                var lastName = httpContext.User.FindFirst("LastName")?.Value;
                var roleId = httpContext.User.FindFirst("RoleId")?.Value;
                var roleName = httpContext.User.FindFirst(ClaimTypes.Role)?.Value;
                var roleGroup = httpContext.User.FindFirst("RoleGroup")?.Value;
                var phoneNumber = httpContext.User.FindFirst("PhoneNumber")?.Value;
                var pfNumber = httpContext.User.FindFirst("PFNumber")?.Value;
                var unitName = httpContext.User.FindFirst("UnitName")?.Value;
                var departmentId = httpContext.User.FindFirst("DepartmentId")?.Value;
                var departmentName = httpContext.User.FindFirst("DepartmentName")?.Value;
                var pwdExpired = httpContext.User.FindFirst("PasswordExpired")?.Value;
                var pwdDaysLeft = httpContext.User.FindFirst("PasswordDaysLeft")?.Value;
                var accLocked = httpContext.User.FindFirst("IsLocked")?.Value;
                var branchId = httpContext.User.FindFirst("BranchId")?.Value;
                var branchName = httpContext.User.FindFirst("BranchName")?.Value;

                // If basic claims are available, use them
                if (!string.IsNullOrEmpty(userId) && !string.IsNullOrEmpty(username)) {
                    if(!long.TryParse(userId, out long id)){
                        id=0;
                    }

                    if(!long.TryParse(roleId, out long rId)){
                        rId=0;
                    }

                    if(!long.TryParse(branchId, out long bId)){
                        bId=0;
                    }

                    if(!long.TryParse(departmentId, out long dId)){
                        dId=0;
                    }

                    if(!int.TryParse(pwdDaysLeft, out int days)){
                        days=0;
                    }
                    var user = new UserResponse {
                        Id = id,
                        UserName = username,
                        EmailAddress = email,
                        DisplayName = displayName,
                        FirstName = firstName,
                        LastName = lastName,
                        RoleId = rId,
                        RoleName = roleName,
                        RoleGroup = roleGroup,
                        IsLocked = accLocked.Equals("true", StringComparison.CurrentCultureIgnoreCase),
                        BranchId = bId,
                        BranchName = branchName,
                        DepartmentId = dId,
                        DepartmentName = departmentName,
                        PhoneNumber = phoneNumber,
                        UnitName = unitName,
                        PasswordDaysLeft = days
                    };

                    return new MfiHttpResponse<UserResponse>(user);
                }

                //..fetch from the DB for missing claims
                var userIdString = httpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (!string.IsNullOrEmpty(userIdString) && long.TryParse(userIdString, out long currentId)) {
                    var request = new MfiHttpIdRequest() {
                        UserId = currentId,
                        EntityId = currentId,
                        IPAddress = ipAddress,
                        IncludeDeleted = true,
                        Action = UserActions.RETRIVEUSERBYID.GetDescription(),
                        EncryptFields = [],
                        DecryptFields =["FirstName", "LastName", "OtherName","PhoneNumber", "PFNumber"],
                    };

                    var endpoint = $"{EndpointProvider.Sam.Users}/getuser-id";
                    return await HttpHandler.PostAsync<MfiHttpIdRequest, UserResponse>(endpoint, request);
                }

                //..fallback error
                var fallbackError = new MfiHttpErrorResponse(
                    404,
                    "User information not found",
                    "Unable to retrieve current user information"
                );
                return new MfiHttpResponse<UserResponse>(fallbackError);
            } catch (Exception ex) {
                Logger.LogError("Error retrieving current user Info: {Message}", ex.Message);
                await ProcessErrorAsync(ex.Message,"SYSTEM-ACCESS-SERVICE" , ex.StackTrace);
                var error = new MfiHttpErrorResponse(
                    500,
                    "Error retrieving user information",
                    ex.Message
                );

                return new MfiHttpResponse<UserResponse>(error);
            }
        }

        public async Task<MfiHttpResponse<UserResponse>> GetUserByIdAsync(long userId, long requestId, string ipAddress, bool includeDeleted=true) {

            if (requestId == 0) {
                var error = new MfiHttpErrorResponse(
                    400,
                    "User ID is required",
                    "Invalid user request"
                );

                Logger.LogError("BAD REQUEST: {Error}", JsonSerializer.Serialize(error));
                return new MfiHttpResponse<UserResponse>(error);
            }

            try {

                var request = new MfiHttpIdRequest() {
                    UserId = userId,
                    EntityId = requestId,
                    IPAddress = ipAddress,
                    IncludeDeleted = includeDeleted,
                    Action = UserActions.RETRIVEUSERBYID.GetDescription(),
                    EncryptFields = [],
                    DecryptFields =["FirstName", "LastName", "OtherName","PhoneNumber", "PFNumber"],
                };

                var endpoint = $"{EndpointProvider.Sam.Users}/getuser-id";
                return await HttpHandler.PostAsync<MfiHttpIdRequest, UserResponse>(endpoint, request);
            } catch (Exception ex) {
                Logger.LogError("Failed to retrieve user record for User-Id {ID}: {Message}", requestId, ex.Message);
                await ProcessErrorAsync(ex.Message,"DEPARTMENT-SERVICE" , ex.StackTrace);
                throw new Exception("Uanble to retrieve user.", ex);
            }
        }
 
        public async Task<MfiHttpResponse<UserResponse>> GetUserByEmailAsync(string email, long userId, string ipAddress, bool includeDeleted=false) {
            
            if (string.IsNullOrWhiteSpace(email)) {
                var error = new MfiHttpErrorResponse(
                    400,
                    "Use email is required",
                    "Invalid user request"
                );

                Logger.LogError("BAD REQUEST: {Error}", JsonSerializer.Serialize(error));
                return new MfiHttpResponse<UserResponse>(error);
            }

            try {

                var request = new UserPropertyRequest() {
                    UserId = userId,
                    PropertyName = "Email",
                    PropertyValue = email,
                    IPAddress = ipAddress,
                    Action = UserActions.RETRIVEUSERBYEMAIL.GetDescription(),
                    IncludeDeleted = includeDeleted,
                    EncryptFields = [],
                    DecryptFields =["FirstName", "LastName", "OtherName","PhoneNumber", "PFNumber"],
                };

                var endpoint = $"{EndpointProvider.Sam.Users}/getuser-email";
                return await HttpHandler.PostAsync<UserPropertyRequest, UserResponse>(endpoint, request);
            } catch (Exception ex) {
                Logger.LogError("Failed to retrieve user record for email like '{username}' : {Message}", email, ex.Message);
                await ProcessErrorAsync(ex.Message,"SYSTEM-ACCESS-SERVICE" , ex.StackTrace);
                throw new Exception("Uanble to complete search", ex);
            }
        }

        public async Task<MfiHttpResponse<UserResponse>> GetUserByNameAsync(string username, long userId, string ipAddress, bool includeDeleted=false) {

            if (string.IsNullOrWhiteSpace(username)) {
                var error = new MfiHttpErrorResponse(
                    400,
                    "Username is required",
                    "Invalid user request"
                );

                Logger.LogError("BAD REQUEST: {Error}", JsonSerializer.Serialize(error));
                return new MfiHttpResponse<UserResponse>(error);
            }

            try {

                var request = new UserPropertyRequest() {
                    UserId = userId,
                    PropertyName = "Name",
                    PropertyValue = username,
                    IPAddress = ipAddress,
                    Action = UserActions.RETRIVEUSERBYNAME.GetDescription(),
                    IncludeDeleted = includeDeleted,
                    EncryptFields = [],
                    DecryptFields =["FirstName", "LastName", "OtherName", "PhoneNumber", "PFNumber"],
                };

                var endpoint = $"{EndpointProvider.Sam.Users}/getuser-name";
                return await HttpHandler.PostAsync<UserPropertyRequest, UserResponse>(endpoint, request);
            } catch (Exception ex) {
                Logger.LogError("Failed to retrieve user record for username like '{username}' : {Message}", username, ex.Message);
                await ProcessErrorAsync(ex.Message,"SYSTEM-ACCESS-SERVICE" , ex.StackTrace);
                throw new Exception("Uanble to complete search", ex);
            }
        }

        public async Task<MfiHttpResponse<PagedResponse<UserResponse>>> GetUsersAsync(MfiHttpListRequest request) {

            if(request == null) {
                var error = new MfiHttpErrorResponse(
                    400,
                    "Request record cannot be empty",
                    "Error object is null and cannot be saved"
                );
                Logger.LogError("BAD REQUEST: {Error}", JsonSerializer.Serialize(error));
                return new MfiHttpResponse<PagedResponse<UserResponse>>(error);
            }

            try{
               var endpoint = $"{EndpointProvider.Sam.Users}/users-all";
                return await HttpHandler.PostAsync<MfiHttpListRequest, PagedResponse<UserResponse>>(endpoint, request);
            } catch (Exception ex) {
                Logger.LogError("Error retrieving paged users: {Message}", ex.Message);
                Logger.LogError("SYSTEM-ACCESS-SERVICE: {StackTrace}" , ex.StackTrace);
                var error = new MfiHttpErrorResponse(500,
                    "Error retrieving list of system errors",
                    ex.Message
                );
                 Logger.LogInformation("System Error: {Error}", JsonSerializer.Serialize(error));
                return new MfiHttpResponse<PagedResponse<UserResponse>>(error);
            }
        }

        public async Task UpdateUserStatusAsync(long userId, bool isLoggedIn, string ipAddress) {
            try {
                //..create request
                var model = new LogoutRequest() {
                    UserId = userId,
                    IsLoggedOut = isLoggedIn,
                    IPAddress = ipAddress,
                    Action = UserActions.UPDATEUSERSTATUS.GetDescription(),
                    EncryptFields = [],
                    DecryptFields = []
                };

                //..map endpoint
                var endpoint = $"{EndpointProvider.Sam.Users}/logout";

                //..post request
                await HttpHandler.PostAsync(endpoint, model);
            } catch (Exception ex) {
                Logger.LogError("Logout failed: {Message}", ex.Message);
                Logger.LogCritical("{StackTrace}",ex.StackTrace);
                await ProcessErrorAsync(ex.Message,"SYSTEM-ACCESS-SERVICE" , ex.StackTrace);
                var error = new MfiHttpErrorResponse(
                    500,
                    "User loggout failed, an error occurred",
                    ex.Message
                );
                Logger.LogInformation("SYSTEM ACCESS RESPONSE: {Error}", JsonSerializer.Serialize(error));
            }
        }

        public async Task<MfiHttpResponse<ValidateUserResponse>> ValidateUsernameAsync(ValidateUserRequest request) {
            try {
                //..map endpoint
                var endpoint = $"{EndpointProvider.Sam.Users}/validate-username";
                return await HttpHandler.PostAsync<ValidateUserRequest, ValidateUserResponse>(endpoint, request);
            } catch (Exception ex) {
                Logger.LogError("Authentication failed: {Message}", ex.Message);
                var error = new MfiHttpErrorResponse(
                    500,
                    "Username validation failed, an error occurred",
                    ex.Message
                );
                Logger.LogError("MIDDLEWARE RESPONSE: {Error}", JsonSerializer.Serialize(error));
                await ProcessErrorAsync(ex.Message,"SYSTEM-ACCESS-SERVICE" , ex.StackTrace);
                return new MfiHttpResponse<ValidateUserResponse>(error);
            }
        }

        public async Task<bool> IsSignedIn() {
            try {
                var endpoint = $"{EndpointProvider.Sam.Sambase}/auth/status";
                var response = await HttpHandler.GetAsync<SigninResponse>(endpoint);

                if (response.HasError) {
                    Logger.LogError("Auth status check failed: {Message}", response.Error?.Message);
                    return false;
                }

                return response.Data?.IsSignedIn ?? false;
            } catch (HttpRequestException httpEx) {
                Logger.LogError("Update user-status failed (network): {Message}", httpEx.Message);
                await ProcessErrorAsync(httpEx.Message,"SYSTEM-ACCESS-SERVICE" , httpEx.StackTrace);
                return false;
            } catch (Exception ex) {
                Logger.LogError("Update user-status error: {Message}", ex.Message);
                await ProcessErrorAsync(ex.Message,"SYSTEM-ACCESS-SERVICE" , ex.StackTrace);
                return false;
            }
        }

        public async Task SignInAsync(UserResponse user, bool isPersistent = false) {
            ArgumentNullException.ThrowIfNull(user);

            try {
                 var claims = new List<Claim>{
                    new(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new(ClaimTypes.Name, user.EmailAddress),
                    new("DisplayName", $"{user.FirstName}" ?? ""),
                    new("FirstName", $"{user.FirstName}" ?? ""),
                    new("LastName", $"{user.LastName}" ?? ""),
                    new(ClaimTypes.Role, $"{user.RoleName}" ?? "User"),
                    new("RoleGroup", $"{user.RoleGroup}" ?? ""),
                    new("RoleId", $"{user.RoleId}" ?? ""),
                    new("PhoneNumber", $"{user.PhoneNumber}" ?? ""),
                    new("PFNumber", $"{user.PFNumber}" ?? ""),
                    new("UnitName", $"{user.UnitName}" ?? ""),
                    new("BranchId", $"{user.BranchId}" ?? ""),
                    new("BranchName", $"{user.BranchName}" ?? ""),
                    new("DepartmentId", $"{user.DepartmentId}" ?? ""),
                    new("DepartmentName", $"{user.DepartmentName}" ?? ""),
                    new("PasswordExpired", $"{user.PasswordExpired}" ?? ""),
                    new("PasswordDaysLeft", $"{user.PasswordDaysLeft}" ?? ""),
                    new("IsLocked", $"{user.IsLocked}" ?? "")
                 };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties {
                    IsPersistent = isPersistent,
                    AllowRefresh = true,
                    IssuedUtc = DateTimeOffset.UtcNow,
                    ExpiresUtc = DateTimeOffset.UtcNow.AddHours(24)
                };

                await _httpContextAccessor.HttpContext.SignInAsync("Cookies",
                    new ClaimsPrincipal(claimsIdentity), 
                    authProperties);

            } catch (HttpRequestException httpEx) {
                Logger.LogError("SignIn failed (network): {Message}", httpEx.Message);
                await ProcessErrorAsync(httpEx.Message,"SYSTEM-ACCESS-SERVICE" , httpEx.StackTrace);
                throw new Exception("Unable to sign in. Please check your connection.", httpEx);
            } catch (Exception ex) {
                Logger.LogError("Unexpected SignIn error: {Message}", ex.Message);
                await ProcessErrorAsync(ex.Message,"SYSTEM-ACCESS-SERVICE" , ex.StackTrace);
                throw new Exception("An unexpected error occurred during sign in.", ex);
            }
        }

        public async Task SignOutAsync(LogoutRequest request) {
            try {
                var endpoint = $"{EndpointProvider.Sam.Users}/logout";
                var response = await HttpHandler.PostAsync<LogoutRequest, MfiHttpStatusResponse>(endpoint, request);
                if(response.HasError) { 
                    Logger.LogError("Failed to signout user on server. {Message}", response.Error.Message);
                } else {
                    Logger.LogInformation("User signed out successfully.");
                }
                
                var httpContext = _httpContextAccessor.HttpContext!;
                await httpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            } catch (HttpRequestException httpEx) {
                Logger.LogError("SignOut failed (network): {Message}", httpEx.Message);
                await ProcessErrorAsync(httpEx.Message,"SYSTEM-ACCESS-SERVICE" , httpEx.StackTrace);
                throw new Exception("Failed to sign out. Network issue.", httpEx);
            } catch (Exception ex) {
                Logger.LogError("Unexpected SignOut error: {Message}", ex.Message);
                await ProcessErrorAsync(ex.Message,"SYSTEM-ACCESS-SERVICE" , ex.StackTrace);
                throw new Exception("An unexpected error occurred during sign out.", ex);
            }
        }
    }

}
