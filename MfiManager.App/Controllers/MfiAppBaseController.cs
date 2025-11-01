using MfiManager.App.Enums;
using MfiManager.App.Factories;
using MfiManager.App.Http.Responses;
using MfiManager.App.Infrastructure.Extensions;
using MfiManager.App.Infrastructure.Settings;
using MfiManager.App.Infrastructure.Utils;
using MfiManager.App.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace MfiManager.App.Controllers {
    public class MfiAppBaseController(ILogger<MfiAppBaseController> logger,
                             IEnvironmentProvider environment,
                             IWebHelper webHelper,
                             ILocalizationService localizationService,
                             IMfiErrorService errorService,
                             IMfiErrorFactory errorFactory,
                             SessionManager sessionManager) : Controller  {

        protected readonly ILogger<MfiAppBaseController> Logger = logger;
        protected readonly IMfiErrorService ErrorService = errorService;
        protected readonly IMfiErrorFactory ErrorFactory = errorFactory;
        protected readonly IEnvironmentProvider Environment = environment;
        protected readonly IWebHelper WebHelper = webHelper;
        protected readonly ILocalizationService LocalizationService = localizationService;
        protected readonly SessionManager SessionManager = sessionManager;

        protected async Task<MfiHttpResponse<MfiHttpStatusResponse>> ProcessErrorAsync(string message, string source, string stacktrace) {
            var ipAddress = WebHelper.GetCurrentIpAddress();
            var workspace = SessionManager.GetWorkspace();
            Logger.LogInformation("WORKSPACE BRANCH: {Branch}", JsonSerializer.Serialize(workspace.BranchName));
            long conpanyId = workspace.CompanyId ?? 0;
            var errModel = await ErrorFactory.PrepareErrorModelAsync(conpanyId, message, source, stacktrace);
            Logger.LogInformation("ERROR MODEL: {Error}", JsonSerializer.Serialize(errModel));
            var response = await ErrorService.SaveSystemErrorAsync(errModel, ipAddress);
            Logger.LogInformation("RESPONSE: {Response}", JsonSerializer.Serialize(response));

            return response;
        }

    }
}
