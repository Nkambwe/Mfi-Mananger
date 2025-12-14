using MfiManager.Middleware.Configurations.Providers;
using MfiManager.Middleware.Data.Services;
using Microsoft.AspNetCore.Mvc;

namespace MfiManager.Middleware.Controllers {

    [ApiController]
    [Route("mfi/settings")]
    public class MfiConfigurationController(ILogger<MfiConfigurationController> logger,
                                            IEnvironmentProvider environment,
                                            IServiceLocalization localizationService,
                                            ISystemErrorService errorService,
                                            ICompanyService companyService)
                                                : MfiBaseController(logger, environment, 
                                                    localizationService, errorService, companyService) {
        private readonly ILogger<MfiConfigurationController> _logger = logger;

        [HttpGet("welcome")]
        public IActionResult SystemWelcome() {
            return Ok("Settings says 'Welcome to MFI-Middleware API'");
        }
    }
}
