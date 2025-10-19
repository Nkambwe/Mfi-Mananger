using MfiManager.App.Factories;
using MfiManager.App.Http;
using MfiManager.App.Infrastructure.Settings;
using MfiManager.App.Infrastructure.Utils;

namespace MfiManager.App.Services {
    public class LocalizationService(
        ILogger<LocalizationService> logger, 
        IHttpHandler<LocalizationService> httpHandler, 
        IEnvironmentProvider environment, 
        IEndpointProvider endpointType, 
        IMfiErrorService errorService, 
        IMfiErrorFactory errorFactory, 
        IWebHelper webHelper, 
        SessionManager sessionManager) :
        ApplicationBaseService<LocalizationService>(logger, httpHandler, environment, 
            endpointType, errorService, errorFactory, webHelper, 
            sessionManager), ILocalizationService {
    }

}
