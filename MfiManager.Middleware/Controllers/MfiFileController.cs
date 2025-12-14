using MfiManager.Middleware.Configurations.Providers;
using MfiManager.Middleware.Data.Services;
using Microsoft.AspNetCore.Mvc;

namespace MfiManager.Middleware.Controllers {
    [ApiController]
    [Route("mfi/files")]
    public class MfiFileController(ILogger<MfiFileController> logger,
                                   IEnvironmentProvider environment,
                                   IServiceLocalization localizationService,
                                   ISystemErrorService errorService,
                                   ICompanyService companyService)
                                   : MfiBaseController(logger, environment, localizationService, errorService, companyService) {
        private readonly ILogger<MfiFileController> _logger = logger;
        [HttpGet("welcome")]
        public IActionResult FilesWelcome() {
            return Ok("Files says 'Welcome to MFI-Middleware API'");
        }
    }
}
