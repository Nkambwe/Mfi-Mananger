using MfiManager.App.Http.Requests;
using MfiManager.App.Http.Responses;

namespace MfiManager.App.Services {
    public interface ISystemAccesssService {

         Task<MfiHttpResponse<UserResponse>> AuthenticateAsync(MfiLoginRequest request, string ipAddress);
         Task<MfiHttpResponse<UserResponse>> GetCurrentUserAsync(string ipAddress);
         Task<MfiHttpResponse<UserResponse>> GetUserByEmailAsync(string email, long requestingUserId, string ipAddress, bool includeDeleted=true);
         Task<MfiHttpResponse<UserResponse>> GetUserByIdAsync(long userId, long requestingUserId, string ipAddress, bool includeDeleted=true);
         Task<MfiHttpResponse<UserResponse>> GetUserByNameAsync(string username, long requestingUserId, string ipAddress, bool includeDeleted=true);
         Task<MfiHttpResponse<PagedResponse<UserResponse>>> GetUsersAsync(MfiHttpListRequest request);
         Task UpdateUserStatusAsync(long userId, bool isLoggedIn, string ipAddress);
         Task<bool> IsSignedIn();
         Task SignInAsync(UserResponse request, bool isPersistent = false);
         Task SignOutAsync(LogoutRequest model);
         Task<MfiHttpResponse<ValidateUserResponse>> ValidateUsernameAsync(ValidateUserRequest model);
    }

}
