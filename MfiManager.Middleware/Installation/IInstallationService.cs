using MfiManager.Middleware.Http.Requests;
using MfiManager.Middleware.Http.Responses;

namespace MfiManager.Middleware.Installation {

    public interface IInstallationService {
        Task<HttpResponse<StatusResponse>> SetupCompanyAsync(InstallRequest requestModel);
    }

}
