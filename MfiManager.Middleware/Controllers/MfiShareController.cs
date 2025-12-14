using MfiManager.Middleware.Configurations.Providers;
using MfiManager.Middleware.Data.Services;
using Microsoft.AspNetCore.Mvc;

namespace MfiManager.Middleware.Controllers {
    [ApiController]
    [Route("mfi/shares")]
    public class MfiShareController(
        ILogger<MfiShareController> logger,
        IEnvironmentProvider environment,
        IServiceLocalization localizationService,
        ISystemErrorService errorService,
        ICompanyService companyService)
        : MfiBaseController(logger, environment, localizationService, errorService, companyService) {
        private readonly ILogger<MfiShareController> _logger = logger;
        [HttpGet("welcome")]
        public IActionResult ShareWelcome() {
            return Ok("Shares says 'Welcome to MFI-Middleware API'");
        }
    }
}
