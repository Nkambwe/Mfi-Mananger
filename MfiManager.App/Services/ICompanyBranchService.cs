using MfiManager.App.Http.Requests;
using MfiManager.App.Http.Responses;

namespace MfiManager.App.Services {

    public interface ICompanyBranchService {
        Task<MfiHttpResponse<PagedResponse<BranchResponse>>> GetAllBranchesAsync(MfiHttpListRequest request);
        Task<MfiHttpResponse<List<BranchResponse>>> GetBranchesAsync(MfiHttpRequest request);
        Task<MfiHttpResponse<MfiWorkspaceResponse>> GetWorkspaceAsync(long userId, long requestingUserId, string ipAddress);
    }
}
