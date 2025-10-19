using MfiManager.App.Factories;
using MfiManager.App.Http;
using MfiManager.App.Infrastructure.Settings;
using MfiManager.App.Infrastructure.Utils;

namespace MfiManager.App.Services {
    public class InstallService(ILogger<InstallService> logger,
                        IHttpHandler<InstallService> httpHandler,
                        IEnvironmentProvider environment,
                        IEndpointProvider endpointType,
                        IMfiErrorService errorService,
                        IMfiErrorFactory errorFactory,
                        IWebHelper webHelper,
                        SessionManager sessionManager) 
        : ApplicationBaseService<InstallService>(logger, httpHandler, environment, endpointType, 
            errorService, errorFactory, webHelper, sessionManager), IInstallService {
    }

}
