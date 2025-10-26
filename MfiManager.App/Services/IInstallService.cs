
using MfiManager.App.Http.Responses;
using MfiManager.App.Models;

namespace MfiManager.App.Services {

    public interface IInstallService {
         /// <summary>
        /// Register company
        /// </summary>
        /// <param name="model">Company model to register</param>
        /// <returns>Service response object</returns>
        Task<MfiHttpResponse<MfiHttpStatusResponse>> RegisterCompanyAsync(InstallationModel model, string ipAddress);
    }

}
