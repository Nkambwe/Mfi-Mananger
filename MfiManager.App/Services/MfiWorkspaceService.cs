using MfiManager.App.Models;

namespace MfiManager.App.Services {
    public class MfiWorkspaceService : IMfiWorkspaceService {
        Task<WorkspaceModel> IMfiWorkspaceService.BuildWorkspaceAsync(long userId, string ipAddress) {
            throw new NotImplementedException();
        }

        Task IMfiWorkspaceService.CleanupWorkspaceAsync(string userId) {
            throw new NotImplementedException();
        }

        Task IMfiWorkspaceService.SaveWorkspaceChangesAsync(WorkspaceModel workspace) {
            throw new NotImplementedException();
        }
    }
}
