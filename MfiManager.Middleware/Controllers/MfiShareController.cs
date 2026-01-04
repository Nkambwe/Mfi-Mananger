using MfiManager.Middleware.Configurations.Providers;
using MfiManager.Middleware.Data.Helpers;
using MfiManager.Middleware.Data.Services;
using MfiManager.Middleware.Utils;
using Microsoft.AspNetCore.Mvc;

namespace MfiManager.Middleware.Controllers {

    [ApiController]
    [Route("mfi/shares")]
    public class MfiShareController(ILogger<MfiShareController> logger,
                                    IObjectMapper objectMapper,
                                    IEnvironmentProvider environment,
                                    IServiceLocalization localizationService,
                                    ISystemErrorService errorService,
                                    ICompanyService companyService,
                                    IEntityAccessService entityAccessService,
                                    IEncryptionConfigProvider encryptionProvider,
                                    IEntityResolver resolver)
        : MfiBaseController(logger, objectMapper, environment, localizationService, errorService, companyService,entityAccessService,encryptionProvider, resolver) {

        private readonly ILogger<MfiShareController> _logger = logger;
        [HttpGet("welcome")]
        public IActionResult ShareWelcome() {
            return Ok("Shares says 'Welcome to MFI-Middleware API'");
        }
    }
}
