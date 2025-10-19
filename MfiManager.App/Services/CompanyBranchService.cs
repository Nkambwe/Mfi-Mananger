using MfiManager.App.Factories;
using MfiManager.App.Http;
using MfiManager.App.Http.Requests;
using MfiManager.App.Http.Responses;
using MfiManager.App.Infrastructure.Settings;
using MfiManager.App.Infrastructure.Utils;

namespace MfiManager.App.Services {

    public class CompanyBranchService(ILogger<CompanyBranchService> logger,
        IHttpHandler<CompanyBranchService> httpHandler,
        IEnvironmentProvider environment,
        IEndpointProvider endpointType,
        IMfiErrorService errorService,
        IMfiErrorFactory errorFactory,
        IWebHelper webHelper,
        SessionManager sessionManager) 
        : ApplicationBaseService<CompanyBranchService>(logger, httpHandler, environment, endpointType,
            errorService, errorFactory, webHelper, sessionManager), ICompanyBranchService {
        public Task<MfiHttpResponse<PagedResponse<BranchResponse>>> GetAllBranchesAsync(MfiHttpListRequest request) {
            throw new NotImplementedException();
        }

        public Task<MfiHttpResponse<List<BranchResponse>>> GetBranchesAsync(MfiHttpRequest request) {
            throw new NotImplementedException();
        }

        public Task<MfiHttpResponse<MfiWorkspaceResponse>> GetWorkspaceAsync(long userId, long requestingUserId, string ipAddress) {
            throw new NotImplementedException();
        }
    }
}
