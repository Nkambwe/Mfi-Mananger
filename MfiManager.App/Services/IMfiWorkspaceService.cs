﻿using MfiManager.App.Models;

namespace MfiManager.App.Services {

    /// <summary>
    /// Interface for workspace service that builds and manages user workspace data.
    /// </summary>
    public interface IMfiWorkspaceService {
        /// <summary>
        /// Builds a workspace for the specified user.
        /// </summary>
        Task<WorkspaceModel> BuildWorkspaceAsync(long userId, string ipAddress);
    
        /// <summary>
        /// Saves changes to the workspace.
        /// </summary>
        Task SaveWorkspaceChangesAsync(WorkspaceModel workspace);
    
        /// <summary>
        /// Performs cleanup when a user logs out.
        /// </summary>
        Task CleanupWorkspaceAsync(string userId);
    }
}
