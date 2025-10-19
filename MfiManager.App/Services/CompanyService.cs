using MfiManager.App.Factories;
using MfiManager.App.Http;
using MfiManager.App.Infrastructure.Settings;
using MfiManager.App.Infrastructure.Utils;

namespace MfiManager.App.Services {
    public class CompanyService(ILogger<CompanyService> logger,
        IHttpHandler<CompanyService> httpHandler,
        IEnvironmentProvider environment,
        IEndpointProvider endpointType,
        IMfiErrorService errorService,
        IMfiErrorFactory errorFactory,
        IWebHelper webHelper, SessionManager sessionManager) 
        : ApplicationBaseService<CompanyService>(logger, httpHandler, environment, endpointType, 
              errorService, errorFactory, webHelper, sessionManager), ICompanyService {
    }

}
