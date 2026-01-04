using MfiManager.Middleware.Configurations.Providers;
using MfiManager.Middleware.Data.Helpers;
using MfiManager.Middleware.Data.Services;
using MfiManager.Middleware.Utils;
using Microsoft.AspNetCore.Mvc;

namespace MfiManager.Middleware.Controllers {

    [ApiController]
    [Route("mfi/files")]
    public class MfiFileController(ILogger<MfiFileController> logger,
                                   IObjectMapper objectMapper,
                                   IEnvironmentProvider environment,
                                   IServiceLocalization localizationService,
                                   ISystemErrorService errorService,
                                   ICompanyService companyService,
                                   IEncryptionConfigProvider encryptionProvider,
                                   IEntityAccessService entityAccessService,
                                   IEntityResolver resolver)
                                   : MfiBaseController(logger, objectMapper, environment, localizationService, errorService, 
                                   companyService, entityAccessService, encryptionProvider, resolver) {
        private readonly ILogger<MfiFileController> _logger = logger;

        [HttpGet("welcome")]
        public IActionResult FilesWelcome() {
            return Ok("Files says 'Welcome to MFI-Middleware API'");
        }
    }
}
