using MfiManager.App.Http.Responses;
using MfiManager.App.Models;

namespace MfiManager.App.Services {

    public interface IMfiErrorService  {
        /// <summary>
        /// Save a system error and notify
        /// </summary>
        /// <param name="error">Error object to save</param>
        Task<MfiHttpResponse<MfiHttpStatusResponse>>  SaveSystemErrorAsync(MfiErrorModel error, string ipAddress);
    }
}
