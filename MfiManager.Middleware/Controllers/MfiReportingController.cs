using MfiManager.Middleware.Configurations.Providers;
using MfiManager.Middleware.Data.Helpers;
using MfiManager.Middleware.Data.Services;
using MfiManager.Middleware.Utils;
using Microsoft.AspNetCore.Mvc;

namespace MfiManager.Middleware.Controllers {

    [ApiController]
    [Route("mfi/reporting")]
    public class MfiReportingController(ILogger<MfiReportingController> logger,
                                        IObjectMapper objectMapper,
                                        IEnvironmentProvider environment,
                                        IServiceLocalization localizationService,
                                        ISystemErrorService errorService,
                                        ICompanyService companyService,
                                        IEntityAccessService entityAccessService,
                                        IEncryptionConfigProvider encryptionProvider,
                                        IEntityResolver resolver)
        : MfiBaseController(logger, objectMapper, environment, localizationService, errorService, 
            companyService, entityAccessService,encryptionProvider, resolver) {

        private readonly ILogger<MfiReportingController> _logger = logger;
        [HttpGet("welcome")]
        public IActionResult ReportingWelcome() {
            return Ok("Reporting says 'Welcome to MFI-Middleware API'");
        }
    }
}
