using MfiManager.Middleware.Configurations.Providers;
using MfiManager.Middleware.Data.Entities.System;
using MfiManager.Middleware.Data.Helpers;
using MfiManager.Middleware.Data.Services;
using MfiManager.Middleware.Http.Responses;
using MfiManager.Middleware.Utils;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace MfiManager.Middleware.Controllers {

    [ApiController]
    [Route("mfi")]
    public class MfiBaseController(ILogger<MfiBaseController> logger, 
                                   IObjectMapper objectMapper,
                                   IEnvironmentProvider environment,
                                   IServiceLocalization localizationService,
                                   ISystemErrorService errorService,
                                   ICompanyService companyService,
                                   IEntityAccessService entityAccessService,
                                   IEncryptionConfigProvider encryptionProvider,
                                   IEntityResolver resolver) : ControllerBase {
        protected readonly ILogger<MfiBaseController> Logger = logger;
        protected readonly IObjectMapper Mapper = objectMapper;
        protected readonly IEnvironmentProvider Environment = environment;
        protected readonly IServiceLocalization LocalizationService = localizationService;
        protected readonly ICompanyService ErrorService = companyService;
        protected readonly ISystemErrorService CompanyService = errorService;
        protected readonly IEntityAccessService EntityAccessService = entityAccessService;
        protected readonly IEncryptionConfigProvider EncryptionProvider = encryptionProvider;
        protected readonly IEntityResolver EntityResolver = resolver;

        #region Private methods

        protected async Task<HttpErrorResponse> HandleErrorAsync(Exception ex) {
            Logger.LogInformation("{Message}", ex.Message);
            Logger.LogInformation("{StackTrace}", ex.StackTrace);

            var conpany = await CompanyService.GetDefaultCompanyAsync();
            long companyId = conpany != null ? conpany.Id : 1;
            SystemError errorObj = new()
            {
                Message = ex.Message,
                Source = "SUPPORT-MIDDLEWARE-COTROLLER",
                StackTrace = ex.StackTrace,
                Severity = "CRITICAL",
                CompanyId = companyId,
                CreatedOn = DateTime.Now,
                CreatedBy = "SYSTEM",
            };

            //..save error object to the database
            var result = await ErrorService.SaveErrorAsync(errorObj);
            var response = new StatusResponse();
            if (result) {
                response.Status = true;
                response.Message = LocalizationService.GetLocalizedLabel("System.Error.SavedToDatabase");
                Logger.LogInformation("SUPPORT-MIDDLEWARE RESPONSE: {Response}", JsonSerializer.Serialize(response));
            }
            else {
                response.Status = false;
                response.Message = LocalizationService.GetLocalizedLabel("System.Error.NotSavedToDatabase");
                Logger.LogInformation("SUPPORT-MIDDLEWARE-COTROLLER RESPONSE: {Response}",JsonSerializer.Serialize(response));
            }

            return new HttpErrorResponse(
                500,
                LocalizationService.GetLocalizedLabel("Server.Error.Critical"),
                $"{LocalizationService.GetLocalizedLabel("System.Error")} - {ex.Message}"
            );
        }

        #endregion
    }
}
