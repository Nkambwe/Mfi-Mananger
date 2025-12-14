using MfiManager.App.Factories;
using MfiManager.App.Http;
using MfiManager.App.Http.Requests;
using MfiManager.App.Http.Responses;
using MfiManager.App.Infrastructure.Settings;
using MfiManager.App.Infrastructure.Utils;

namespace MfiManager.App.Services {

    public class SystemActivityService(ILogger<InstallService> logger,
                        IHttpHandler<InstallService> httpHandler,
                        IEnvironmentProvider environment,
                        ILocalizationService localizationService, 
                        IEndpointProvider endpointType,
                        IMfiErrorService errorService,
                        IMfiErrorFactory errorFactory,
                        IWebHelper webHelper,
                        SessionManager sessionManager) 
        : ApplicationBaseService<InstallService>(logger, 
            httpHandler, environment, endpointType,
            errorService, errorFactory, webHelper, 
            localizationService, sessionManager), ISystemActivityService {

        public Task<MfiHttpResponse<PagedResponse<ActivityResponse>>> GetActivityLogsAsync(MfiHttpListRequest request) {
            throw new NotImplementedException();
        }

        public Task<MfiHttpResponse<MfiHttpStatusResponse>> InsertActivityAsync(long userId, string activity, string comment, string systemKeyword = null, string entityName = null, string ipAddress = null) {
            throw new NotImplementedException();
        }

    }

}
