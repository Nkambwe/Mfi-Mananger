using MfiManager.Middleware.Configurations.Providers;
using MfiManager.Middleware.Data.Services;
using Microsoft.AspNetCore.Mvc;

namespace MfiManager.Middleware.Controllers {

    [ApiController]
    [Route("mfi/saving")]
    public class MfiSavingController(
        ILogger<MfiSavingController> logger,
        IEnvironmentProvider environment,
        IServiceLocalization localizationService,
        ISystemErrorService errorService,
        ICompanyService companyService)
        : MfiBaseController(logger, environment, localizationService, errorService, companyService) {
        private readonly ILogger<MfiSavingController> _logger = logger;
        [HttpGet("welcome")]
        public IActionResult SavingWelcome() {
            return Ok("Saving says 'Welcome to MFI-Middleware API'");
        }
    }
}
