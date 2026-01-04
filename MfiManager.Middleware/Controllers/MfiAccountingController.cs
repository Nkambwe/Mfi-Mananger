using MfiManager.Middleware.Configurations.Providers;
using MfiManager.Middleware.Data.Helpers;
using MfiManager.Middleware.Data.Services;
using MfiManager.Middleware.Utils;
using Microsoft.AspNetCore.Mvc;

namespace MfiManager.Middleware.Controllers {

    [ApiController]
    [Route("mfi/accounting")]
    public class MfiAccountingController(ILogger<MfiAccountingController> logger,
                                        IObjectMapper objectMapper,
                                        IEnvironmentProvider environment,
                                        IServiceLocalization localizationService,
                                        ISystemErrorService errorService,
                                        ICompanyService companyService,
                                        IEntityAccessService entityAccessService,
                                        IEncryptionConfigProvider encryptionProvider,
                                        IEntityResolver EntityResolver)
         : MfiBaseController(logger, objectMapper, environment, localizationService, errorService, 
             companyService,entityAccessService, encryptionProvider, EntityResolver) {
        private readonly ILogger<MfiAccountingController> _logger = logger;

        [HttpGet("welcome")]
        public IActionResult AccountingWelcome() {
            return Ok("Accounting says 'Welcome to MFI-Middleware API'");
        }

    }
}
