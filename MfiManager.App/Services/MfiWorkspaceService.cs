using MfiManager.App.Factories;
using MfiManager.App.Http;
using MfiManager.App.Infrastructure.Settings;
using MfiManager.App.Infrastructure.Utils;
using MfiManager.App.Models;
using System.Text.Json;

namespace MfiManager.App.Services {
    public class MfiWorkspaceService : ApplicationBaseService<MfiWorkspaceService>, IMfiWorkspaceService {

        private readonly ICompanyBranchService _branchService;
         public MfiWorkspaceService(ILogger<MfiWorkspaceService> logger, 
                                IHttpHandler<MfiWorkspaceService> httpHandler, 
                                IEnvironmentProvider environment, 
                                IEndpointProvider endpointType, 
                                IMfiErrorService errorService, 
                                IMfiErrorFactory errorFactory, 
                                IWebHelper webHelper, 
                                ICompanyBranchService branchService,
                                ILocalizationService localizationService,
                                SessionManager sessionManager)
                                : base(logger, httpHandler, environment, endpointType, errorService, 
                                      errorFactory, webHelper, localizationService, sessionManager) {
            _branchService = branchService;
        }

        public async Task<WorkspaceModel> BuildWorkspaceAsync(long userId, string ipAddress) {

            try{
                //..get work model
                var response = await _branchService.GetWorkspaceAsync(userId, userId, ipAddress);
                Logger.LogInformation("WORKSPACE RESPONSE: {Response}", JsonSerializer.Serialize(response));
                if (response.HasError) {
                    return new();
                }

                //..success response
                var workspace = new WorkspaceModel {
                    IsLiveEnvironment = Environment.IsLive,
                    User = Mapper.ToUserModel(response.Data.User),
                    Permissions = response.Data.Permissions,
                    RoleId = response.Data.Role.RoleId,
                    RoleName = response.Data.Role.RoleName,
                    RoleGroup = response.Data.Role.RoleGroup,
                    CompanyId = response.Data.CompanyId,
                    BranchId = response.Data.Branch.Id,
                    BranchName = response.Data.Branch.BranchName,
                    BranchCode = response.Data.Branch.BranchCode
                };

                return workspace;
            }catch(Exception ex){
                Logger.LogError("{Message}", ex.Message);
                Logger.LogCritical("{StackTrace}", ex.StackTrace);
                await ProcessErrorAsync(ex.Message,"WORKSPACE-SERVICE" , ex.StackTrace);
                return null;
            }
        }

        public async Task CleanupWorkspaceAsync(string userId) {
            try {
                Logger.LogInformation("Cleaning up workspace for user {UserId}", userId);

                //// Update last activity timestamp
                //await _userRepository.UpdateLastActivityAsync(userId, DateTime.UtcNow);

                //// Log the logout event
                //await _userRepository.LogUserActivityAsync(userId, "Logout");

                Logger.LogInformation("Workspace cleanup completed for user {UserId}", userId);
                return;
            }catch(Exception ex){
                Logger.LogError("{Message}", ex.Message);
                Logger.LogCritical("{StackTrace}", ex.StackTrace);
                await ProcessErrorAsync(ex.Message,"WORKSPACE-SERVICE" , ex.StackTrace);
                return;
            }
           
        }

        public async Task SaveWorkspaceChangesAsync(WorkspaceModel workspace) {
            if (workspace?.User?.UserId == null) {
                throw new ArgumentException("Workspace or user ID is null", nameof(workspace));
            }

            var userId = workspace.User.UserId;
            try {
                Logger.LogInformation("Saving workspace changes for user {UserId}", userId);

                //// Save user preferences
                //if (workspace.Preferences != null) {
                //    await _preferencesRepository.SaveUserPreferencesAsync(userId, workspace.Preferences);
                //}

                //// Save favorites
                //if (workspace.Favorites != null) {
                //    await _favoritesRepository.SaveUserFavoritesAsync(userId, workspace.Favorites);
                //}

                Logger.LogInformation("Workspace changes saved successfully for user {UserId}", userId);
                return;
            }catch(Exception ex){
                Logger.LogError("{Message}", ex.Message);
                Logger.LogCritical("{StackTrace}", ex.StackTrace);
                await ProcessErrorAsync(ex.Message,"WORKSPACE-SERVICE" , ex.StackTrace);
                return;
            }
        }
    }
}
